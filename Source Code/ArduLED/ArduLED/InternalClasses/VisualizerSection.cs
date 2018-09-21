using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ArduLEDNameSpace
{
    public class VisualizerSection : IDisposable
    {
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private WASAPIPROC BassProcess;
        private Task VisualizerThread;
        private bool RunVisualizerThread = true;
        private MainForm MainFormClass;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                EnableBASS(false);
                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();
            }

            IsDisposed = true;
        }

        public VisualizerSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void UpdateSpectrumChart(Chart _Chart, string _Red, string _Green, string _Blue, int _XValues, bool _AutoScale)
        {
            _Chart.Series.Clear();
            Series SeriesRed = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Red, Tag = _Red };
            Series SeriesGreen = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Green, Tag = _Green };
            Series SeriesBlue = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Blue, Tag = _Blue };
            Series[] AllSeries = { SeriesRed, SeriesGreen, SeriesBlue };
            for (int i = 0; i < _XValues; i++)
            {
                foreach (Series InnerSeries in AllSeries)
                {
                    InnerSeries.Points.Add(0);
                }
            }

            try
            {

                for (int i = 0; i < _XValues; i++)
                {
                    foreach (Series InnerSeries in AllSeries)
                    {
                        if (((string)InnerSeries.Tag).Contains("PW["))
                        {
                            string CurColor = (string)InnerSeries.Tag;
                            List<string> RedInternals = new List<string>();
                            while (CurColor.Contains("PW["))
                            {
                                int StartIndex = CurColor.IndexOf('[');
                                int EndIndex = CurColor.IndexOf(']');
                                RedInternals.Add(CurColor.Substring(StartIndex + 1, EndIndex - StartIndex - 1));
                                CurColor = CurColor.Remove(EndIndex, 1);
                                CurColor = CurColor.Remove(StartIndex - 2, 3);
                            }
                            foreach (string s in RedInternals)
                            {
                                string[] InternalSplit = s.Split(':');
                                if (Int32.Parse(InternalSplit[1]) <= i && Int32.Parse(InternalSplit[2]) >= i)
                                {
                                    double ColorValue = TransformToPoint(InternalSplit[0], i);
                                    if (_AutoScale)
                                    {
                                        if (ColorValue > 255)
                                        {
                                            InnerSeries.Points[i].YValues[0] = 255;
                                        }
                                        else
                                        {
                                            if (ColorValue < 0)
                                                InnerSeries.Points[i].YValues[0] = 0;
                                            else
                                                InnerSeries.Points[i].YValues[0] = ColorValue;
                                        }
                                    }
                                    else
                                        InnerSeries.Points[i].YValues[0] = ColorValue;
                                }
                            }
                        }
                        else
                        {
                            double ColorValue = TransformToPoint((string)InnerSeries.Tag, i);
                            if (ColorValue == -1)
                            {
                                i = _XValues;
                                break;
                            }
                            if (_AutoScale)
                            {
                                if (ColorValue > 255)
                                {
                                    InnerSeries.Points[i].YValues[0] = 255;
                                }
                                else
                                {
                                    if (ColorValue < 0)
                                        InnerSeries.Points[i].YValues[0] = 0;
                                    else
                                        InnerSeries.Points[i].YValues[0] = ColorValue;
                                }
                            }
                            else
                                InnerSeries.Points[i].YValues[0] = ColorValue;
                        }
                    }
                }
            }
            catch { MessageBox.Show("Error in input string"); }

            foreach (Series InnerSeries in AllSeries)
            {
                _Chart.Series.Add(InnerSeries);
            }
        }

        private double TransformToPoint(string _InputEquation, int _XValue)
        {
            try
            {
                string TransformedInputString = _InputEquation.ToLower().Replace("x", _XValue.ToString()).Replace(".", ",").Replace(" ", "");
                string[] Split = System.Text.RegularExpressions.Regex.Split(TransformedInputString, @"(?<=[()^*/+-])");

                List<string> EquationParts = new List<string>();
                foreach (string s in Split)
                {
                    EquationParts.Add(s);
                }

                if (EquationParts[0] == "-")
                {
                    EquationParts[0] = "-" + EquationParts[1];
                    EquationParts.RemoveAt(1);
                }
                if (EquationParts[0] == "+")
                {
                    EquationParts.RemoveAt(0);
                }

                for (int i = 0; i < EquationParts.Count; i++)
                {
                    if (EquationParts[i].Contains("(") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("(", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("(", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains(")") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace(")", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace(")", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains("^") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("^", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("^", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains("*") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("*", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("*", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains("/") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("/", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("/", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains("+") && EquationParts[i].Length > 1)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("+", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("+", "");
                        i = 0;
                    }
                    if (EquationParts[i].Contains("-") && EquationParts[i].Length > 1 && EquationParts[i].IndexOf('-') != 0)
                    {
                        EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("-", ""), ""));
                        EquationParts[i] = EquationParts[i].Replace("-", "");
                        i = 0;
                    }
                }

                while (EquationParts.Contains("("))
                {
                    int StartIndex = EquationParts.FindIndex(s => s.Equals("("));
                    int EndIndex = EquationParts.FindIndex(s => s.Equals(")"));
                    string ComputeString = "";
                    for (int i = StartIndex + 1; i < EndIndex; i++)
                        ComputeString += EquationParts[i];
                    EquationParts[StartIndex] = TransformToPoint(ComputeString, _XValue).ToString();
                    EquationParts.RemoveRange(StartIndex + 1, EndIndex - StartIndex);
                }
                while (EquationParts.Contains("^"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("^"));
                    EquationParts[Index] = (Math.Pow(Convert.ToDouble(EquationParts[Index - 1]), Convert.ToDouble(EquationParts[Index + 1]))).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("*"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("*"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) * Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("/"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("/"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) / Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("+"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("+"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) + Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("-"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("-"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) - Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }

                return Convert.ToDouble(EquationParts[0]);

            }
            catch
            {
                MessageBox.Show("Error in input string");
                EnableBASS(false);
                return -1;
            }
        }

        public void EnableBASS(bool setto)
        {
            if (setto)
            {
                if (BassWasapi.BASS_WASAPI_IsStarted())
                    BassWasapi.BASS_WASAPI_Stop(true);

                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();

                if (VisualizerThread != null)
                {
                    RunVisualizerThread = false;
                    while (VisualizerThread.Status == TaskStatus.Running)
                    {
                        Thread.Sleep(5);
                        Application.DoEvents();
                    }
                    VisualizerThread.Dispose();
                }

                BassProcess = new WASAPIPROC(Process);

                var array = (MainFormClass.AudioSourceComboBox.Items[MainFormClass.AudioSourceComboBox.SelectedIndex] as string).Split(' ');
                int devindex = Convert.ToInt32(array[0]);
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, BassProcess, IntPtr.Zero);
                if (!result)
                {
                    var error = Bass.BASS_ErrorGetCode();
                    MessageBox.Show(error.ToString());
                }

                BassWasapi.BASS_WASAPI_Start();

                RunVisualizerThread = true;

                VisualizerThread = new Task(delegate { AudioDataThread(); });
                VisualizerThread.Start();
            }
            else
            {
                if (VisualizerThread != null)
                {
                    RunVisualizerThread = false;
                    while (VisualizerThread.Status == TaskStatus.Running)
                    {
                        Thread.Sleep(5);
                        Application.DoEvents();
                    }
                    VisualizerThread.Dispose();
                }

                if (BassWasapi.BASS_WASAPI_IsStarted())
                    BassWasapi.BASS_WASAPI_Stop(true);

                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();
            }
        }

        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        private void AudioDataThread()
        {
            DateTime VisualizerRPSCounter = new DateTime();
            DateTime CalibrateRefreshRate = new DateTime();
            int VisualizerUpdatesCounter = 0;
            List<List<int>> AudioDataPointStore = new List<List<int>>();
            float[] AudioData = { };

            int VisualSamles = 0;
            int Smoothness = 0;
            int Sensitivity = 0;
            int BASSDataRate = 0;
            int BeatZoneFrom = 0;
            int BeatZoneTo = 0;
            int SelectedIndex = 0;
            int TriggerHeight = 0;
            int SpectrumSplit = 0;
            int RefreshTime = 0;

            MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate {
                VisualSamles = (int)MainFormClass.VisualSamplesNumericUpDown.Value;
                Smoothness = MainFormClass.SmoothnessTrackBar.Value;
                Sensitivity = MainFormClass.SensitivityTrackBar.Value;
                BASSDataRate = Int32.Parse(MainFormClass.AudioSampleRateComboBox.SelectedItem.ToString());
                BeatZoneFrom = MainFormClass.BeatZoneFromTrackBar.Value;
                BeatZoneTo = MainFormClass.BeatZoneToTrackBar.Value;
                AudioData = new float[Int32.Parse(MainFormClass.AudioSampleRateComboBox.SelectedItem.ToString())];
                SelectedIndex = MainFormClass.VisualizationTypeComboBox.SelectedIndex;
                TriggerHeight = MainFormClass.BeatZoneTriggerHeight.Value;
                RefreshTime = MainFormClass.SampleTimeTrackBar.Value;
                SpectrumSplit = (int)MainFormClass.FullSpectrumNumericUpDown.Value;
                for (int i = 0; i < MainFormClass.VisualSamplesNumericUpDown.Value; i++)
                    AudioDataPointStore.Add(new List<int>(new int[Smoothness]));
            });

            while (RunVisualizerThread)
            {
                CalibrateRefreshRate = DateTime.Now;

                MainFormClass.BeatZoneTriggerHeight.Invoke((MethodInvoker)delegate { TriggerHeight = MainFormClass.BeatZoneTriggerHeight.Value; });

                Series BeatZoneSeries = new Series
                {
                    IsVisibleInLegend = false,
                    IsXValueIndexed = false,
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(0, 122, 217)
                };

                int ReturnValue = BassWasapi.BASS_WASAPI_GetData(AudioData, (int)(BASSData)Enum.Parse(typeof(BASSData), "BASS_DATA_FFT" + BASSDataRate));
                if (ReturnValue < -1) return;

                int X, Y;
                int B0 = 0;
                for (X = BeatZoneFrom; X < BeatZoneTo; X++)
                {
                    float Peak = 0;
                    int B1 = (int)Math.Pow(2, X * 10.0 / ((int)VisualSamles - 1));
                    if (B1 > 1023) B1 = 1023;
                    if (B1 <= B0) B1 = B0 + 1;
                    for (; B0 < B1; B0++)
                    {
                        if (Peak < AudioData[1 + B0]) Peak = AudioData[1 + B0];
                    }
                    Y = (int)(Math.Sqrt(Peak) * Sensitivity * 255 - 4);
                    if (Y > 255) Y = 255;
                    if (Y < 1) Y = 1;

                    if (X >= BeatZoneFrom)
                    {
                        if (X <= BeatZoneTo)
                        {

                            AudioDataPointStore[X].Add((byte)Y);
                            while (AudioDataPointStore[X].Count > Smoothness)
                                AudioDataPointStore[X].RemoveAt(0);

                            int AverageValue = 0;
                            if (Smoothness > 1)
                            {
                                for (int s = 0; s < Smoothness; s++)
                                {
                                    AverageValue += AudioDataPointStore[X][s];
                                }
                                AverageValue = AverageValue / Smoothness;
                            }
                            else
                            {
                                AverageValue = AudioDataPointStore[X][0];
                            }
                            if (AverageValue > 255)
                                AverageValue = 255;
                            if (AverageValue < 0)
                                AverageValue = 0;

                            BeatZoneSeries.Points.AddXY(X, AverageValue);
                        }
                    }
                }

                if (SelectedIndex == 0)
                {
                    double Hit = 0;
                    for (int i = 0; i < BeatZoneSeries.Points.Count; i++)
                    {
                        if (BeatZoneSeries.Points[i].YValues[0] >= TriggerHeight)
                            Hit++;
                    }
                    double OutValue = Math.Round(Math.Round((Hit / ((double)BeatZoneTo - (double)BeatZoneFrom)), 2) * 99, 0);
                    AutoTrigger((OutValue / 99) * (255 * 3));
                    if (OutValue > 99)
                        OutValue = 99;
                    string SerialOut = "2;" + OutValue.ToString().Replace(',', '.');
                    MainFormClass.SendDataBySerial(SerialOut);
                }
                if (SelectedIndex == 1 | SelectedIndex == 2)
                {
                    double EndR = 0;
                    double EndG = 0;
                    double EndB = 0;
                    int CountR = 0;
                    int CountG = 0;
                    int CountB = 0;
                    int Hit = 0;
                    for (int i = 0; i < BeatZoneSeries.Points.Count; i++)
                    {
                        if (BeatZoneSeries.Points[i].YValues[0] >= TriggerHeight)
                        {
                            try
                            {
                                if (MainFormClass.SpectrumChart.Series[0].Points[i].YValues[0] <= 255)
                                {
                                    if (MainFormClass.SpectrumChart.Series[0].Points[i].YValues[0] >= 0)
                                    {
                                        EndR += MainFormClass.SpectrumChart.Series[0].Points[i].YValues[0];
                                        CountR++;
                                    }
                                }
                            }
                            catch
                            {
                                EndR += 0;
                                CountR++;
                            }
                            try
                            {
                                if (MainFormClass.SpectrumChart.Series[1].Points[i].YValues[0] <= 255)
                                {
                                    if (MainFormClass.SpectrumChart.Series[1].Points[i].YValues[0] >= 0)
                                    {
                                        EndG += MainFormClass.SpectrumChart.Series[1].Points[i].YValues[0];
                                        CountG++;
                                    }
                                }
                            }
                            catch
                            {
                                EndG += 0;
                                CountG++;
                            }
                            try
                            {
                                if (MainFormClass.SpectrumChart.Series[2].Points[i].YValues[0] <= 255)
                                {
                                    if (MainFormClass.SpectrumChart.Series[2].Points[i].YValues[0] >= 0)
                                    {
                                        EndB += MainFormClass.SpectrumChart.Series[2].Points[i].YValues[0];
                                        CountB++;
                                    }
                                }
                            }
                            catch
                            {
                                EndB += 0;
                                CountB++;
                            }
                            Hit++;
                        }
                    }

                    AutoTrigger(((float)Hit / ((float)BeatZoneTo - (float)BeatZoneFrom)) * (255 * 3));

                    if (CountR > 0)
                    {
                        EndR = EndR / CountR;
                    }
                    if (CountG > 0)
                    {
                        EndG = EndG / CountG;
                    }
                    if (CountB > 0)
                    {
                        EndB = EndB / CountB;
                    }

                    Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb((int)Math.Round(EndR, 0), (int)Math.Round(EndG, 0), (int)Math.Round(EndB, 0)));

                    string SerialOut = "";
                    if (SelectedIndex == 1)
                        SerialOut = "1;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + ";0;0";
                    if (SelectedIndex == 2)
                        SerialOut = "3;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B;
                    MainFormClass.SendDataBySerial(SerialOut);
                }
                if (SelectedIndex == 3 | SelectedIndex == 4)
                {
                    int EndR = 0;
                    int EndG = 0;
                    int EndB = 0;
                    int Hit = 0;

                    for (int i = 0; i < BeatZoneSeries.Points.Count; i++)
                    {
                        if (BeatZoneSeries.Points[i].YValues[0] >= TriggerHeight)
                        {
                            Hit++;
                        }
                    }

                    int EndValue = (int)(((float)255 * (float)3) * ((float)Hit / ((float)BeatZoneTo - (float)BeatZoneFrom)));
                    if (EndValue >= 765)
                        EndValue = 764;
                    if (EndValue < 0)
                        EndValue = 0;

                    MainFormClass.BeatWaveProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.BeatWaveProgressBar.Value = EndValue; });
                    try
                    {
                        EndR = (int)MainFormClass.WaveChart.Series[0].Points[EndValue].YValues[0];
                        EndG = (int)MainFormClass.WaveChart.Series[1].Points[EndValue].YValues[0];
                        EndB = (int)MainFormClass.WaveChart.Series[2].Points[EndValue].YValues[0];
                    }
                    catch
                    {
                        EndR = 0;
                        EndG = 0;
                        EndB = 0;
                    }

                    AutoTrigger(((float)Hit / ((float)BeatZoneTo - (float)BeatZoneFrom)) * (255 * 3));

                    if (EndR > 255)
                        EndR = 0;

                    if (EndG > 255)
                        EndG = 0;

                    if (EndB > 255)
                        EndB = 0;

                    if (EndR < 0)
                        EndR = 0;

                    if (EndG < 0)
                        EndG = 0;

                    if (EndB < 0)
                        EndB = 0;

                    Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(EndR, EndG, EndB));

                    string SerialOut = "";
                    if (SelectedIndex == 4)
                        SerialOut = "1;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + ";0;0";
                    if (SelectedIndex == 3)
                        SerialOut = "3;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + "";
                    MainFormClass.SendDataBySerial(SerialOut);
                }
                if (SelectedIndex == 5)
                {
                    int Hit = 0;
                    string SerialOut = "5;" + SpectrumSplit.ToString() + ";";
                    for (int i = 0; i < BeatZoneSeries.Points.Count; i++)
                    {
                        if (BeatZoneSeries.Points[i].YValues[0] >= TriggerHeight)
                        {
                            SerialOut += Math.Round((BeatZoneSeries.Points[i].YValues[0] / 255) * (double)SpectrumSplit, 0) + ";";
                            Hit++;
                        }
                        else
                            SerialOut += "0;";
                    }

                    AutoTrigger(((float)Hit / ((float)BeatZoneTo - (float)BeatZoneFrom)) * (255 * 3));

                    MainFormClass.SendDataBySerial(SerialOut);
                }

                VisualizerUpdatesCounter++;
                if ((DateTime.Now - VisualizerRPSCounter).TotalSeconds >= 1)
                {
                    MainFormClass.VisualizerRPSLabel.Invoke((MethodInvoker)delegate { MainFormClass.VisualizerRPSLabel.Text = "RPS: " + VisualizerUpdatesCounter; });
                    VisualizerUpdatesCounter = 0;
                    VisualizerRPSCounter = DateTime.Now;
                }
                MainFormClass.BeatZoneChart.Invoke((MethodInvoker)delegate
                {
                    MainFormClass.BeatZoneChart.Series.Clear();
                    MainFormClass.BeatZoneChart.Series.Add(BeatZoneSeries);
                });

                int ExectuionTime = (int)(DateTime.Now - CalibrateRefreshRate).TotalMilliseconds;
                int ActuralRefreshTime = RefreshTime - ExectuionTime;

                if (ActuralRefreshTime < 0)
                    ActuralRefreshTime = 0;

                Thread.Sleep(ActuralRefreshTime);
            }
        }

        private void AutoTrigger(double _TriggerValue)
        {
            if (MainFormClass.AutoTriggerCheckBox.Checked)
            {
                MainFormClass.BeatZoneTriggerHeight.Invoke((MethodInvoker)delegate {
                    MainFormClass.VisualizerCurrentValueLabel.Text = ((int)(_TriggerValue)).ToString();
                    if (_TriggerValue >= (double)MainFormClass.AutoTriggerDecreseAtNumericUpDown.Value)
                    {
                        if (MainFormClass.BeatZoneTriggerHeight.Value < MainFormClass.AutoTriggerMaxNumericUpDown.Value)
                            MainFormClass.BeatZoneTriggerHeight.Value = MainFormClass.BeatZoneTriggerHeight.Value + 1;
                    }
                    if (_TriggerValue <= (double)MainFormClass.AutoTriggerIncreseAtNumericUpDown.Value)
                    {
                        if (MainFormClass.BeatZoneTriggerHeight.Value > MainFormClass.AutoTriggerMinNumericUpDown.Value)
                            MainFormClass.BeatZoneTriggerHeight.Value = MainFormClass.BeatZoneTriggerHeight.Value - 1;
                    }

                    MainFormClass.FormatCustomText(MainFormClass.BeatZoneTriggerHeight.Value, MainFormClass.BeatZoneTriggerHeightLabel, "");
                });
            }
            else
                MainFormClass.VisualizerCurrentValueLabel.Invoke((MethodInvoker)delegate { MainFormClass.VisualizerCurrentValueLabel.Text = "0"; });
        }
    }
}
