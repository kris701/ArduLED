using System;
using System.Drawing;
using ArduLED_Serial_Protocol;

namespace ArduLEDNameSpace
{
    public class FadeColorsSection
    {
        private MainForm MainFormClass;

        public FadeColorsSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void FadeColorsSendData(bool _FromZero, int _FromID, int _ToID, Color _OutputColor, int _FadeSpeed, double _FadeFactor)
        {
            if (MainFormClass.Serial.SerialPort1.IsOpen)
            {
                MainFormClass.Serial.Write(new Ranges(_FromID, _ToID));

                if (_FromZero)
                {
                    MainFormClass.Serial.Write(new FadeColorsMode(0,0,0,0,0));
                }

                Color AfterShuffel = MainFormClass.ShuffleColors(_OutputColor);

                MainFormClass.Serial.Write(new FadeColorsMode(AfterShuffel.R, AfterShuffel.G, AfterShuffel.B, _FadeSpeed, _FadeFactor));
            }
        }
    }
}
