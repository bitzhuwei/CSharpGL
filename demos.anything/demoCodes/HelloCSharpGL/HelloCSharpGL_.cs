using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpGL {
    internal unsafe class HelloCSharpGL_ : demoCode {
        public HelloCSharpGL_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private LegacyPicking legacyPickingAction;
        private FormNodePropertyGrid frmNodePropertyGrid;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

        }

        public override void init(GL gl) {
            //var rootElement = GetLegacyPropellerLegacyFlabellum();
            //var rootElement = GetLegacyPropellerFlabellum();
            //var rootElement = GetPropellerLegacyFlabellum();
            //var rootElement = GetPropellerFlabellum();
            var rootElement = GetPropellerRTT();

            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.legacyPickingAction = new LegacyPicking(scene);

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            this.frmNodePropertyGrid = new FormNodePropertyGrid(scene.RootNode);
            this.frmNodePropertyGrid.Show();

            this.canvas.GLMouseDown += Canvas_GLMouseDown;
        }

        private void Canvas_GLMouseDown(object sender, GLMouseEventArgs e) {
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            List<HitTarget> list = this.legacyPickingAction.Pick(x, y);
            //foreach (var item in list)
            //{
            //    var parent = item.node.Parent;
            //    if (parent != null)
            //    {
            //        var node = parent as IRenderable;
            //        if (node != null)
            //        {
            //            node.RenderingEnabled = !node.RenderingEnabled;
            //        }
            //    }
            //}

            if (list.Count == 0) {
                //this.propGrid.SelectedObject = null;
                this.frmNodePropertyGrid.SetNode(null);
            }
            else if (list.Count == 1) {
                //this.propGrid.SelectedObject = list[0].node;
                this.frmNodePropertyGrid.SetNode(list[0].node);
            }
            else {
                //this.propGrid.SelectedObjects = (from item in list select item.node).ToArray();
            }

            this.mainForm.SetInfo($"{list.Count} objects selected.");
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }

        private SceneNodeBase GetPropellerRTT() {
            var propeller = GetPropellerFlabellum();

            return propeller;
        }

        private SceneNodeBase GetLegacyPropellerLegacyFlabellum() {
            var propeller = new LegacyPropellerNode();
            propeller.Children.Add(new LegacyBoundingBoxNode(propeller.ModelSize));

            var xflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(2, 0, 0) };
            xflabellum.Children.Add(new LegacyBoundingBoxNode(xflabellum.ModelSize));

            var nxflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(-2, 0, 0), RotationAngle = 180, };
            nxflabellum.Children.Add(new LegacyBoundingBoxNode(nxflabellum.ModelSize));

            var zflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(0, 0, -2), RotationAngle = 90, };
            zflabellum.Children.Add(new LegacyBoundingBoxNode(zflabellum.ModelSize));

            var nzflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(0, 0, 2), RotationAngle = 270, };
            nzflabellum.Children.Add(new LegacyBoundingBoxNode(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private SceneNodeBase GetLegacyPropellerFlabellum() {
            var propeller = new LegacyPropellerNode();
            propeller.Children.Add(new LegacyBoundingBoxNode(propeller.ModelSize));

            var xflabellum = FlabellumNode.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            xflabellum.Children.Add(new LegacyBoundingBoxNode(xflabellum.ModelSize));

            var nxflabellum = FlabellumNode.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            nxflabellum.Children.Add(new LegacyBoundingBoxNode(nxflabellum.ModelSize));

            var zflabellum = FlabellumNode.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            zflabellum.Children.Add(new LegacyBoundingBoxNode(zflabellum.ModelSize));

            var nzflabellum = FlabellumNode.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
            nzflabellum.Children.Add(new LegacyBoundingBoxNode(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private SceneNodeBase GetPropellerLegacyFlabellum() {
            var propeller = PropellerRenderer.Create();
            propeller.Children.Add(new LegacyBoundingBoxNode(propeller.ModelSize));

            var xflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(2, 0, 0) };
            xflabellum.Children.Add(new LegacyBoundingBoxNode(xflabellum.ModelSize));

            var nxflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(-2, 0, 0), RotationAngle = 180, };
            nxflabellum.Children.Add(new LegacyBoundingBoxNode(nxflabellum.ModelSize));

            var zflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(0, 0, -2), RotationAngle = 90, };
            zflabellum.Children.Add(new LegacyBoundingBoxNode(zflabellum.ModelSize));

            var nzflabellum = new LegacyFlabellumNode() { WorldPosition = new vec3(0, 0, 2), RotationAngle = 270, };
            nzflabellum.Children.Add(new LegacyBoundingBoxNode(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private SceneNodeBase GetPropellerFlabellum() {
            var propeller = PropellerRenderer.Create();
            propeller.Children.Add(new LegacyBoundingBoxNode(propeller.ModelSize));

            var xflabellum = FlabellumNode.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            xflabellum.Children.Add(new LegacyBoundingBoxNode(xflabellum.ModelSize));

            var nxflabellum = FlabellumNode.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            nxflabellum.Children.Add(new LegacyBoundingBoxNode(nxflabellum.ModelSize));

            var zflabellum = FlabellumNode.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            zflabellum.Children.Add(new LegacyBoundingBoxNode(zflabellum.ModelSize));

            var nzflabellum = FlabellumNode.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
            nzflabellum.Children.Add(new LegacyBoundingBoxNode(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }


    }
}
