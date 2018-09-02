namespace ArduLEDNameSpace
{
    public struct WorkingPanelBox
    {
        public int XLoc;
        public int YLoc;
        public bool Moving;
        public int XLEDCount;
        public int YLEDCount;
        public int PinID;
        public bool InvertXDir;
        public bool InvertYDir;
        public int FromLEDID;
        public int PixelTypeIndex;
        public int PixelBitstreamIndex;

        public WorkingPanelBox(int _XLoc, int _YLoc, bool _Moving, int _XLEDCount, int _YLEDCount, int _PinID, bool _InvertXDir, bool _InvertYDir, int _FromLEDID, int _PixelTypeIndex, int _PixelBitstreamIndex)
        {
            XLoc = _XLoc;
            YLoc = _YLoc;
            Moving = _Moving;
            XLEDCount = _XLEDCount;
            YLEDCount = _YLEDCount;
            PinID = _PinID;
            InvertXDir = _InvertXDir;
            InvertYDir = _InvertYDir;
            FromLEDID = _FromLEDID;
            PixelTypeIndex = _PixelTypeIndex;
            PixelBitstreamIndex = _PixelBitstreamIndex;
        }
    }
}
