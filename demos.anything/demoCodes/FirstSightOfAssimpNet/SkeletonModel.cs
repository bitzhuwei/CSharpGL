using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet {
	class SkeletonModel : IBufferSource {
		public readonly Assimp.Scene scene;
		public readonly AllBoneInfos allBones;
		private vec3[] positions;
		private vec3[] colors;
		private Assimp.Node[] nodes;
		private int[] boneIndexes;

		public SkeletonModel(Assimp.Scene scene, AllBoneInfos allBoneInfos) {
			this.scene = scene;
			this.allBones = allBoneInfos;
			GeneratePositions(scene);
			GenerateBoneIndexes(this.nodes, allBoneInfos);
		}

		private void GenerateBoneIndexes(Assimp.Node[] nodes, AllBoneInfos allBones) {
			Dictionary<string, uint> nameIndexDict = allBones.name2index;
			var boneIndexes = new int[nodes.Length];
			for (int i = 0; i < nodes.Length; i++) {
				Assimp.Node node = nodes[i];
				uint index;
				if (nameIndexDict.TryGetValue(node.Name, out index)) {
					boneIndexes[i] = (int)index;
				}
				else {
					boneIndexes[i] = -1;
				}
			}
			this.boneIndexes = boneIndexes;
		}

		private void ParseNodeIndexes(Assimp.Node node, List<int> list, Dictionary<string, uint> nameIndexDict) {
			uint index;
			if (nameIndexDict.TryGetValue(node.Name, out index)) {
				list.Add((int)index);
			}
			else {
				list.Add(-1);
			}

			if (node.HasChildren) {
				foreach (Assimp.Node child in node.Children) {
					ParseNodeIndexes(child, list, nameIndexDict);
				}
			}
		}

		private void GeneratePositions(Assimp.Scene scene) {
			var lstPosition = new List<vec3>();
			var lstColor = new List<vec3>();
			var lstNode = new List<Assimp.Node>();
			if (scene.RootNode != null && scene.RootNode.HasChildren) {
				mat4 mat = scene.RootNode.Transform.ToMat4();
				foreach (Assimp.Node child in scene.RootNode.Children) {
					ParseNode(child, lstPosition, lstColor, lstNode, mat);
				}
			}

			this.positions = lstPosition.ToArray();
			this.colors = lstColor.ToArray();
			this.nodes = lstNode.ToArray();
		}

		private void ParseNode(Assimp.Node node, List<vec3> lstPosition, List<vec3> lstColor, List<Assimp.Node> lstNode, mat4 parentTransform) {
			var parentPosition = new vec3(parentTransform * new vec4(0, 0, 0, 1));
			lstPosition.Add(parentPosition); lstColor.Add(new vec3(1, 0, 0)); lstNode.Add(node.Parent);
			mat4 thisTransform = parentTransform * node.Transform.ToMat4();
			var position = new vec3(thisTransform * new vec4(0, 0, 0, 1));
			lstPosition.Add(position); lstColor.Add(new vec3(1, 1, 1)); lstNode.Add(node);
			if (node.HasChildren) {
				foreach (Assimp.Node child in node.Children) {
					ParseNode(child, lstPosition, lstColor, lstNode, thisTransform);
				}
			}
		}

		public const string strPosition = "position";
		private VertexBuffer positionBuffer;
		public const string strColor = "color";
		private VertexBuffer colorBuffer;
		public const string strBoneIndex = "boneIndex";
		private VertexBuffer boneIndexBuffer;

		private IDrawCommand drawCommand;

		#region IBufferSource 成员

		public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
			if (strPosition == bufferName) {
				if (this.positionBuffer == null) {
					this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
				}

				yield return this.positionBuffer;
			}
			else if (strColor == bufferName) {
				if (this.colorBuffer == null) {
					this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
				}

				yield return this.colorBuffer;
			}
			else if (strBoneIndex == bufferName) {
				if (this.boneIndexBuffer == null) {
					this.boneIndexBuffer = this.boneIndexes.GenVertexBuffer(VBOConfig.Int, GLBuffer.Usage.StaticDraw);
				}

				yield return this.boneIndexBuffer;
			}
			else {
				throw new ArgumentException();
			}
		}

		public IEnumerable<IDrawCommand> GetDrawCommand() {
			if (this.drawCommand == null) {
				this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Lines, this.positions.Length);
			}

			yield return this.drawCommand;
		}

		#endregion
	}
}
