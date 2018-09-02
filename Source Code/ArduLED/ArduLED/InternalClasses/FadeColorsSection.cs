using System.Drawing;

namespace ArduLEDNameSpace
{
    public class FadeColorsSection
    {
        private MainForm MainFormClass;

        public FadeColorsSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void FadeColorsSendData(bool _FromZero, int _FromID, int _ToID, Color _OutputColor, int _FadeSpeed, int _FadeFactor)
        {
            if (MainFormClass.SerialPort1.IsOpen)
            {
                string SerialOut;
                SerialOut = "6;" + _FromID + ";" + _ToID;
                MainFormClass.SendDataBySerial(SerialOut);

                if (_FromZero)
                {
                    SerialOut = "1;0;0;0;0;0";
                    MainFormClass.SendDataBySerial(SerialOut);
                }

                Color AfterShuffel = MainFormClass.ShuffleColors(_OutputColor);

                SerialOut = "1;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + ";" + _FadeSpeed + ";" + _FadeFactor;
                MainFormClass.SendDataBySerial(SerialOut);
            }
        }
    }
}
