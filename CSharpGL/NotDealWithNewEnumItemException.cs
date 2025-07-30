namespace CSharpGL {
    public unsafe class NotDealWithNewEnumItemException : Exception {
        private readonly Type type;

        public NotDealWithNewEnumItemException(Type type) {
            this.type = type;
        }

        public override string ToString() {
            return $"not deal with new enum item ({type}) yet";
        }
    }
}
