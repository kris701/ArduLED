using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ArduLED_Serial_Protocol
{
    public class ArduLEDSerialProtocol
    {
        public SerialPort SerialPort1;
        public bool UnitReady = false;
        public bool Wait = false;
        private bool ReadyToRecive = false;
        private int UnitTimeoutCounter = 0;

        public ArduLEDSerialProtocol()
        {
            SerialPort1 = new SerialPort();
            SerialPort1.WriteTimeout = 500;
            SerialPort1.RtsEnable = true;
            SerialPort1.DtrEnable = true;
            SerialPort1.DataReceived += Read;
        }

        private void Read(object sender, SerialDataReceivedEventArgs e)
        {
            if (!UnitReady)
                UnitReady = true;
            if (SerialPort1.BytesToRead > 0)
            {
                if (!ReadyToRecive)
                {
                    ReadyToRecive = true;
                    UnitTimeoutCounter = 0;
                }
                SerialPort1.ReadChar();
            }
        }

        public void Write(NoneMode _Input)
        {
            InnerWrite("0;" + _Input.Data);
        }

        public void Write(FadeColorsMode _Input)
        {
            InnerWrite("1;" + _Input.Red + ";" + _Input.Green + ";" + _Input.Blue + ";" + _Input.FadeSpeed + ";" + Math.Round(_Input.FadeFactor * 100, 0));
        }

        public void Write(VisualizerBeat _Input)
        {
            InnerWrite("2;" + _Input.BeatValue.ToString().Replace(',','.'));
        }

        public void Write(VisualizerWave _Input)
        {
            InnerWrite("3;" + _Input.Red + ";" + _Input.Green + ";" + _Input.Blue);
        }

        public void Write(IndividualLEDs _Input)
        {
            InnerWrite("4;" + _Input.PinID + ";" + _Input.HardwareID + ";" + _Input.Red + ";" + _Input.Green + ";" + _Input.Blue);
        }

        public void Write(VisualizerFullSpectrum _Input)
        {
            InnerWrite("5;" + _Input.SpectrumValues);
        }

        public void Write(Ranges _Input)
        {
            InnerWrite("6;" + _Input.FromID + ";" + _Input.ToID);
        }

        public void Write(Ambilight _Input)
        {
            InnerWrite("7;" + _Input.FromID + ";" + _Input.ToID + ";" + _Input.LEDsPrBlock + ";" + _Input.Values);
        }

        public void Write(Animation _Input)
        {
            InnerWrite("8;" + _Input.LineCount + ";" + Convert.ToInt32(_Input.UseCompression) + ";" + Convert.ToInt32(_Input.ShowNow) + ";" + _Input.Values);
        }

        private void InnerWrite(string _Input)
        {
            if (!Wait)
            {
                if (UnitReady)
                {
                    int TimeoutCounter = 0;
                    while (!ReadyToRecive)
                    {
                        Thread.Sleep(1);
                        TimeoutCounter++;
                        if (TimeoutCounter > 250)
                        {
                            UnitTimeoutCounter++;
                            if (UnitTimeoutCounter > 20)
                            {
                                Console.WriteLine("Communication to Unit failed!");
                                UnitTimeoutCounter = 0;
                                break;
                            }
                            ReadyToRecive = true;
                            break;
                        }
                    }
                }
                if (ReadyToRecive)
                {
                    try
                    {
                        SerialPort1.WriteLine(";" + _Input + ";-1;");
                    }
                    catch { }
                    ReadyToRecive = false;
                }
            }
        }
    }

    public struct NoneMode
    {
        public string Data;

        public NoneMode(string _Data)
        {
            Data = _Data;
        }
    }

    public struct FadeColorsMode
    {
        public Int16 Red;
        public Int16 Green;
        public Int16 Blue;
        public int FadeSpeed;
        public double FadeFactor;

        public FadeColorsMode(Int16 _Red, Int16 _Green, Int16 _Blue, int _FadeSpeed, double _FadeFactor)
        {
            Red = _Red;
            Green = _Green;
            Blue = _Blue;
            FadeSpeed = _FadeSpeed;
            FadeFactor = _FadeFactor;
        }
    }

    public struct VisualizerBeat
    {
        public int BeatValue;

        public VisualizerBeat(int _BeatValue)
        {
            BeatValue = _BeatValue;
        }
    }

    public struct VisualizerWave
    {
        public Int16 Red;
        public Int16 Green;
        public Int16 Blue;

        public VisualizerWave(Int16 _Red, Int16 _Green, Int16 _Blue)
        {
            Red = _Red;
            Green = _Green;
            Blue = _Blue;
        }
    }

    public struct IndividualLEDs
    {
        public Int16 Red;
        public Int16 Green;
        public Int16 Blue;
        public int PinID;
        public int HardwareID;

        public IndividualLEDs(Int16 _Red, Int16 _Green, Int16 _Blue, int _PinID, int _HardwareID)
        {
            Red = _Red;
            Green = _Green;
            Blue = _Blue;
            PinID = _PinID;
            HardwareID = _HardwareID;
        }
    }

    public struct VisualizerFullSpectrum
    {
        public int SpectrumSplit;
        public string SpectrumValues;

        public VisualizerFullSpectrum(string _SpectrumValues, int _SpectrumSplit)
        {
            SpectrumValues = _SpectrumValues;
            SpectrumSplit = _SpectrumSplit;
        }
    }

    public struct Ranges
    {
        public int FromID;
        public int ToID;

        public Ranges(int _FromID, int _ToID)
        {
            FromID = _FromID;
            ToID = _ToID;
        }
    }

    public struct Ambilight
    {
        public int FromID;
        public int ToID;
        public int LEDsPrBlock;
        public string Values;

        public Ambilight(int _FromID, int _ToID, int _LEDsPrBlock, string _Values)
        {
            FromID = _FromID;
            ToID = _ToID;
            LEDsPrBlock = _LEDsPrBlock;
            Values = _Values;
        }
    }

    public struct Animation
    {
        public int LineCount;
        public bool UseCompression;
        public bool ShowNow;
        public string Values;

        public Animation(int _LineCount, bool _UseCompression, bool _ShowNow, string _Values)
        {
            LineCount = _LineCount;
            UseCompression = _UseCompression;
            ShowNow = _ShowNow;
            Values = _Values;
        }
    }
}
