namespace ArduLEDNameSpace
{
    public struct AmbilightSide
    {
        public bool Enabled;
        public int Width;
        public int Height;
        public int BlockSpacing;
        public int XOffSet;
        public int YOffSet;
        public int FromID;
        public int ToID;
        public int LEDsPrBlock;

        public AmbilightSide(bool _Enabled, int _Width, int _Height, int _BlockSpacing, int _XOffSet, int _YOffSet, int _FromID, int _ToID, int _LEDsPrBlock)
        {
            Enabled = _Enabled;
            Width = _Width;
            Height = _Height;
            BlockSpacing = _BlockSpacing;
            XOffSet = _XOffSet;
            YOffSet = _YOffSet;
            FromID = _FromID;
            ToID = _ToID;
            LEDsPrBlock = _LEDsPrBlock;
        }
    }
}
