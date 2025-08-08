namespace Import3D {
    /// <summary> Standard return type for some library functions.
    /// Rarely used, and if, mostly in the C API.
    /// </summary>
    public enum aiReturn {
        /// <summary> Indicates that a function was successful/// </summary>
        aiReturn_SUCCESS = 0x0,

        /// <summary> Indicates that a function failed/// </summary>
        aiReturn_FAILURE = -0x1,

        /// <summary> Indicates that not enough memory was available
        /// to perform the requested operation
        /// </summary>
        aiReturn_OUTOFMEMORY = -0x3,

        ///// <summary> @cond never
        /////  Force 32-bit size enum
        ///// </summary>
        //_AI_ENFORCE_ENUM_SIZE = 0x7fffffff

        ///// @endcond
    }

}