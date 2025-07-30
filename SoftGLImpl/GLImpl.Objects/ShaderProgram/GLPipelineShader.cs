using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    abstract class GLPipelineShader : GLShader {
        public abstract int PipelineOrder { get; }

        /// <summary>
        /// user-defined in var
        /// </summary>
        public readonly Dictionary<string, PassVariable> name2inVar = new();
        /// <summary>
        /// user-defined out var
        /// </summary>
        public readonly Dictionary<string, FieldInfo> name2outFieldInfo = new();

        public GLPipelineShader(Kind shaderType, uint id) : base(shaderType, id) { }

        public override object? ApplyCodeInstance() {
            if (this.scriptPool == null) { return null; }
            else { return this.scriptPool.Rent(); }
        }

        protected override string AfterCompile() {
            if (this.codeType == null) { return "code type is null!"; }
            this.name2inVar.Clear();
            this.name2outFieldInfo.Clear();
            uint nextLoc = 0;
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            foreach (var item in codeType.GetFields(flags)) {
                name2fielfInfo.Add(item.Name, item);
                {
                    object[] attribute = item.GetCustomAttributes(typeof(InAttribute), true);
                    var hasIn = item.IsDefined(typeof(InAttribute), true);
                    if (attribute != null && attribute.Length > 0) // this is a 'in ...;' field.
                    {
                        Debug.Assert(hasIn);
                        var v = new PassVariable(item);
                        object[] layouts = item.GetCustomAttributes(typeof(layoutAttribute), false);
                        if (layouts != null && layouts.Length > 0 && layouts[0] is layoutAttribute layout) // layout (location = 0) in vec3 aPos;
                        {
                            uint loc = layout.location;
                            if (loc < nextLoc) { return string.Format("location error in {0}!", this.GetType().Name); }
                            v.location = loc;
                            nextLoc = loc + 1;
                        }
                        else {
                            v.location = nextLoc++;
                        }
                        this.name2inVar.Add(item.Name, v);

                    }
                }
                {
                    object[] attribute = item.GetCustomAttributes(typeof(OutAttribute), true);
                    var hasOut = item.IsDefined(typeof(OutAttribute), true);
                    if (attribute != null && attribute.Length > 0) // this is a 'in ...;' field.
                    {
                        Debug.Assert(hasOut);
                        //var v = new PassVariable(item);
                        this.name2outFieldInfo.Add(item.Name, item);
                    }
                }
            }
            return string.Empty;
        }



    }
}
