﻿using System;

namespace CSharpGL {
    // TODO: No Uniform Array Variable types are tested yet.
    /// <summary>
    /// shader中的一个数组类型的uniform变量。
    /// 例如：uniform vec3 positions[10];
    /// </summary>
    public abstract unsafe class UniformArrayVariable<T> : UniformArrayVariableBase where T : struct, IEquatable<T> {
        private NoisyArray<T> array = new NoisyArray<T>(0);

        /// <summary>
        ///
        /// </summary>
        [UniformValueAttribute]
        public NoisyArray<T> Value {
            get { return this.array; }
            set {
                if (value != null) {
                    if (this.array != value) {
                        if (this.array != null) { this.array.ItemUpdated -= eventHandler; }

                        value.ItemUpdated += eventHandler;
                        this.array = value;
                        this.updated = true;
                    }
                }
                else {
                    if (this.array.Length != 0) {
                        this.array.ItemUpdated -= eventHandler;
                        this.array = new NoisyArray<T>(0);
                        this.updated = true;
                    }
                }
            }
        }

        private void value_ItemUpdated(object? sender, NoisyArrayEventArgs<T> e) {
            this.updated = true;
        }

        private EventHandler<NoisyArrayEventArgs<T>> eventHandler;

        /// <summary>
        /// shader中的一个数组类型的uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformArrayVariable(string varName, int length)
            : base(varName) {
            this.eventHandler = new EventHandler<NoisyArrayEventArgs<T>>(value_ItemUpdated);
            this.Value = new NoisyArray<T>(length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            Array array = this.Value.Array;
            if (array != null) {
                return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.varName, array.PrintArray("; "));
            }
            else {
                return string.Format("{0} {1}: []", this.GetType().Name, this.varName);
            }
        }
    }
}