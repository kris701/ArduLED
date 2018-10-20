using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using ArduLED_Serial_Protocol;

namespace ArduLEDNameSpace
{
    public class AmbiLightSection : IDisposable
    {
        private enum SideID { Left, Top, Right, Bottom };
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private List<Block> BlockList = new List<Block>();
        private List<List<List<int>>> AmbilightColorStore = new List<List<List<int>>>();
        private List<Rectangle> ScreenList = new List<Rectangle>();
        private bool RunAmbilight = false;
        private DateTime AmbilightFPSCounter;
        private int AmbilightFPSCounterFramesRendered;
        private Task AmbilightTask;
        private MainForm MainFormClass;
        private double AssumeLevel = 1;
        private int MaxVariation = 765;
        private AmbilightSide LeftSide;
        private AmbilightSide TopSide;
        private AmbilightSide RightSide;
        private AmbilightSide BottomSide;

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
                if (AmbilightTask != null)
                {
                    if (AmbilightTask.Status == TaskStatus.Running)
                    {
                        StopAmbilight();
                        AmbilightTask.Dispose();
                    }
                }
                AmbilightColorStore.Clear();
                BlockList.Clear();
            }

            IsDisposed = true;
        }

        public AmbiLightSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
            ScreenList.Clear();
            ScreenList.Add(SystemInformation.VirtualScreen);
            foreach(Screen Rec in Screen.AllScreens)
            {
                ScreenList.Add(Rec.Bounds);
            }
        }

        public void ShowBlocks(int _ScreenID, int _SampleSplit)
        {
            SetSides();

            if (BlockList.Count == 0)
            {
                if (LeftSide.Enabled)
                {
                    MakeNewBlock(
                        (ScreenList[_ScreenID].Height - LeftSide.Height + LeftSide.YOffSet),
                        LeftSide.YOffSet,
                        LeftSide.Height + LeftSide.BlockSpacing,
                        true,
                        LeftSide.Width,
                        LeftSide.Height,
                        false,
                        ScreenList[_ScreenID].X + LeftSide.XOffSet,
                        ScreenList[_ScreenID].Y,
                        _SampleSplit
                        );
                }
                if (TopSide.Enabled)
                {
                    MakeNewBlock(
                        TopSide.XOffSet,
                        (ScreenList[_ScreenID].Width - TopSide.Width),
                        TopSide.Width + TopSide.BlockSpacing,
                        false,
                        TopSide.Width,
                        TopSide.Height,
                        true,
                        ScreenList[_ScreenID].X,
                        ScreenList[_ScreenID].Y + TopSide.YOffSet,
                        _SampleSplit
                        );
                }
                if (RightSide.Enabled)
                {
                    MakeNewBlock(
                        RightSide.YOffSet,
                        ScreenList[_ScreenID].Height - RightSide.Height,
                        RightSide.Height + RightSide.BlockSpacing,
                        false,
                        RightSide.Width,
                        RightSide.Height,
                        false,
                        (ScreenList[_ScreenID].X + ScreenList[_ScreenID].Width - RightSide.Width) + RightSide.XOffSet,
                        ScreenList[_ScreenID].Y + RightSide.YOffSet,
                        _SampleSplit
                        );
                }
                if (BottomSide.Enabled)
                {
                    MakeNewBlock(
                        (ScreenList[_ScreenID].Width - BottomSide.Width) + BottomSide.XOffSet,
                        0,
                        BottomSide.Width + BottomSide.BlockSpacing,
                        true,
                        BottomSide.Width,
                        BottomSide.Height,
                        true,
                        ScreenList[_ScreenID].X,
                        (ScreenList[_ScreenID].Y + ScreenList[_ScreenID].Height - BottomSide.Height) + BottomSide.YOffSet,
                        _SampleSplit
                        );
                }
            }
            else
                HideBlocks();
        }

        public void HideBlocks()
        {
            if (BlockList.Count > 0)
            {
                foreach (Block b in BlockList)
                    b.Close();
                BlockList.Clear();
            }
        }

        private void MakeNewBlock(int _FromI, int _UntilI, int _AddWith, bool _UntilILarger, int _BoxWidth, int _BoxHeight, bool _LocOfI, int _XOffset, int _YOffset, int _PixelSpread)
        {
            if (_UntilILarger)
            {
                for (int i = _FromI; i > _UntilI; i -= _AddWith)
                {
                    MakeNewBoxInner(
                        _BoxWidth,
                        _BoxHeight,
                        _LocOfI,
                        i,
                        _XOffset,
                        _YOffset,
                        _PixelSpread
                        );
                }
            }
            else
            {
                for (int i = _FromI; i < _UntilI; i += _AddWith)
                {
                    MakeNewBoxInner(
                        _BoxWidth,
                        _BoxHeight,
                        _LocOfI,
                        i,
                        _XOffset,
                        _YOffset,
                        _PixelSpread
                        );
                }
            }
        }

        private void MakeNewBoxInner(int _BoxWidth, int _BoxHeight, bool _LocOfI, int _i, int _XOffset, int _YOffset, int _PixelSpread)
        {
            Block NewBlock = new Block();
            NewBlock.Show();
            NewBlock.Width = _BoxWidth;
            NewBlock.Height = _BoxHeight;
            if (_LocOfI)
                NewBlock.Location = new Point(_XOffset + _i, _YOffset);
            else
                NewBlock.Location = new Point(_XOffset, _YOffset + _i);
            BlockList.Add(NewBlock);
            if (_PixelSpread > 20)
            {
                for (int j = 0; j < _BoxWidth; j += _PixelSpread)
                {
                    for (int l = 0; l < _BoxHeight; l += _PixelSpread)
                    {
                        Panel Pixel = new Panel
                        {
                            BackColor = Color.Black,
                            Width = 1,
                            Height = 1,
                            Location = new Point(j, l)
                        };
                        NewBlock.Controls.Add(Pixel);
                    }
                }
            }
        }

        public void AutoSetOffsets(int _ScreenID, int _SampleSplit)
        {
            SetSides();

            MainFormClass.Opacity = 0;
            Bitmap Screenshot = new Bitmap(ScreenList[_ScreenID].Width, ScreenList[_ScreenID].Height, PixelFormat.Format32bppRgb);
            using (Graphics GFXScreenshot = Graphics.FromImage(Screenshot))
            {
                GFXScreenshot.CopyFromScreen(ScreenList[_ScreenID].X, ScreenList[_ScreenID].Y, 0, 0, new Size(Screenshot.Width, Screenshot.Height), CopyPixelOperation.SourceCopy);
            }
            MainFormClass.Opacity = 1;

            if (LeftSide.Enabled)
            {
                MainFormClass.AmbiLightModeLeftBlockOffsetXNumericUpDown.Value = FindFirstLightPixel(
                    0,
                    ScreenList[_ScreenID].Width / 2,
                    false,
                    true,
                    0,
                    ScreenList[_ScreenID].Height / 2,
                    Screenshot
                    );
            }

            if (TopSide.Enabled)
            {
                MainFormClass.AmbiLightModeTopBlockOffsetYNumericUpDown.Value = FindFirstLightPixel(
                    0,
                    ScreenList[_ScreenID].Height / 2,
                    false,
                    false,
                    ScreenList[_ScreenID].Width / 2,
                    0,
                    Screenshot
                    );
            }

            if (RightSide.Enabled)
            {
                MainFormClass.AmbiLightModeRightBlockOffsetXNumericUpDown.Value = -(ScreenList[_ScreenID].Width - FindFirstLightPixel(
                    ScreenList[_ScreenID].Width - 1,
                    ScreenList[_ScreenID].Width / 2,
                    true,
                    true,
                    0,
                    ScreenList[_ScreenID].Height / 2,
                    Screenshot
                    ));
            }

            if (BottomSide.Enabled)
            {
                MainFormClass.AmbiLightModeBottomBlockOffsetYNumericUpDown.Value = -(ScreenList[_ScreenID].Height - FindFirstLightPixel(
                    ScreenList[_ScreenID].Height - 1,
                    ScreenList[_ScreenID].Height / 2,
                    true,
                    false,
                    ScreenList[_ScreenID].Width / 2,
                    -2,
                    Screenshot
                    ));
            }
            Screenshot.Dispose();

            Application.DoEvents();

            SetSides();

            ShowBlocks(_ScreenID, _SampleSplit);

            Thread.Sleep(1000);

            HideBlocks();
        }

        private int FindFirstLightPixel(int _FromI, int _UntilI, bool _UntilILarger, bool _ILoc, int _XOffset, int _YOffset, Bitmap _ScreenShot)
        {
            if (_UntilILarger)
            {
                for (int i = _FromI; i > _UntilI; i--)
                {
                    Color Pixel;
                    if (_ILoc)
                        Pixel = _ScreenShot.GetPixel(_XOffset + i, _YOffset);
                    else
                        Pixel = _ScreenShot.GetPixel(_XOffset, _YOffset + i);
                    if (Convert.ToInt32(Pixel.R > 5) + Convert.ToInt32(Pixel.G > 5) + Convert.ToInt32(Pixel.B > 5) > 0)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = _FromI; i < _UntilI; i++)
                {
                    Color Pixel;
                    if (_ILoc)
                        Pixel = _ScreenShot.GetPixel(_XOffset + i, _YOffset);
                    else
                        Pixel = _ScreenShot.GetPixel(_XOffset, _YOffset + i);
                    if (Convert.ToInt32(Pixel.R > 5) + Convert.ToInt32(Pixel.G > 5) + Convert.ToInt32(Pixel.B > 5) > 0)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        public void AutoSetBlockSize(int _ScreenID, int _SampleSplit)
        {
            SetSides();

            if (LeftSide.Enabled)
            {
                MainFormClass.AmbiLightModeLeftBlockHeightNumericUpDown.Value = (decimal)((ScreenList[_ScreenID].Height - LeftSide.YOffSet) / Math.Round((double)(Math.Abs(LeftSide.ToID - LeftSide.FromID) / LeftSide.LEDsPrBlock),0) - LeftSide.BlockSpacing);
            }

            if (TopSide.Enabled)
            {
                MainFormClass.AmbiLightModeTopBlockWidthNumericUpDown.Value = (decimal)((ScreenList[_ScreenID].Width - TopSide.XOffSet) / Math.Round((double)(Math.Abs(TopSide.ToID - TopSide.FromID) / TopSide.LEDsPrBlock), 0) - TopSide.BlockSpacing);
            }

            if (RightSide.Enabled)
            {
                MainFormClass.AmbiLightModeRightBlockHeightNumericUpDown.Value = (decimal)((ScreenList[_ScreenID].Height - RightSide.YOffSet) / Math.Round((double)(Math.Abs(RightSide.ToID - RightSide.FromID) / RightSide.LEDsPrBlock), 0) - RightSide.BlockSpacing);
            }

            if (BottomSide.Enabled)
            {
                MainFormClass.AmbiLightModeBottomBlockWidthNumericUpDown.Value = (decimal)((ScreenList[_ScreenID].Width - BottomSide.XOffSet) / Math.Round((double)(Math.Abs(BottomSide.ToID - BottomSide.FromID) / BottomSide.LEDsPrBlock), 0) - BottomSide.BlockSpacing);
            }

            Application.DoEvents();

            SetSides();

            ShowBlocks(_ScreenID, _SampleSplit);

            Thread.Sleep(1000);

            HideBlocks();
        }

        public void StartAmbilight(int _ScreenID, int _SampleSplit, double _GammaValue, double _FadeFactor, int _RefreshRate)
        {
            SetSides();

            if (AmbilightTask != null)
                if (AmbilightTask.Status == TaskStatus.Running)
                    StopAmbilight();

            int Highest = 0;
            int Lowest = 0;

            if (LeftSide.Enabled)
                if (LeftSide.FromID < Lowest)
                    Lowest = LeftSide.FromID;

            if (TopSide.Enabled)
                if (TopSide.FromID < Lowest)
                    Lowest = TopSide.FromID;

            if (RightSide.Enabled)
                if (RightSide.FromID < Lowest)
                    Lowest = RightSide.FromID;

            if (BottomSide.Enabled)
                if (BottomSide.FromID < Lowest)
                    Lowest = BottomSide.FromID;

            if (LeftSide.Enabled)
                if (LeftSide.ToID < Lowest)
                    Lowest = LeftSide.ToID;

            if (TopSide.Enabled)
                if (TopSide.ToID < Lowest)
                    Lowest = TopSide.ToID;

            if (RightSide.Enabled)
                if (RightSide.ToID < Lowest)
                    Lowest = RightSide.ToID;

            if (BottomSide.Enabled)
                if (BottomSide.ToID < Lowest)
                    Lowest = BottomSide.ToID;

            if (LeftSide.Enabled)
                if (LeftSide.ToID > Highest)
                    Highest = LeftSide.ToID;

            if (TopSide.Enabled)
                if (TopSide.ToID > Highest)
                    Highest = TopSide.ToID;

            if (RightSide.Enabled)
                if (RightSide.ToID > Highest)
                    Highest = RightSide.ToID;

            if (BottomSide.Enabled)
                if (BottomSide.ToID > Highest)
                    Highest = BottomSide.ToID;

            if (LeftSide.Enabled)
                if (LeftSide.FromID > Highest)
                    Highest = LeftSide.FromID;

            if (TopSide.Enabled)
                if (TopSide.FromID > Highest)
                    Highest = TopSide.FromID;

            if (RightSide.Enabled)
                if (RightSide.FromID > Highest)
                    Highest = RightSide.FromID;

            if (BottomSide.Enabled)
                if (BottomSide.FromID > Highest)
                    Highest = BottomSide.FromID;

            MainFormClass.Serial.Write(new Ranges(Lowest,Highest));

            if (AmbilightColorStore.Count != 4)
            {
                AmbilightColorStore.Clear();
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
            }

            AssumeLevel = (double)MainFormClass.AmbiLightModeAssumeNumericUpDown.Value;
            MaxVariation = (int)MainFormClass.AmbiLightModeMaxVariationNumericUpDown.Value;

            MainFormClass.AmbiLightModeWorkingPanel.Enabled = false;

            AmbilightTask = new Task(delegate { AmbilightThread(LeftSide, TopSide, RightSide, BottomSide, _ScreenID, _SampleSplit, _GammaValue, _FadeFactor, _RefreshRate); });
            AmbilightTask.Start();

            RunAmbilight = true;
        }

        public void StopAmbilight()
        {
            if (AmbilightTask != null)
            {
                RunAmbilight = false;
                while (AmbilightTask.Status == TaskStatus.Running)
                {
                    Thread.Sleep(5);
                    Application.DoEvents();
                }
            }
            MainFormClass.AmbiLightModeWorkingPanel.Enabled = true;
        }

        private void AmbilightThread(AmbilightSide _LeftSide, AmbilightSide _TopSide, AmbilightSide _RightSide, AmbilightSide _BottomSide, int _ScreenID, int _SampleSplit, double _GammaValue, double _FadeFactor, int _RefreshRate)
        {
            DateTime CalibrateRefreshRate = new DateTime();
            int SerialOutLeftSection = 0;
            int SerialOutTopSection = 0;
            int SerialOutRightSection = 0;
            int SerialOutBottomSection = 0;

            int SerialOutLeftSection2 = 0;
            int SerialOutTopSection2 = 0;
            int SerialOutRightSection2 = 0;
            int SerialOutBottomSection2 = 0;

            Ambilight[] SerialOutLeft = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] SerialOutTop = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] SerialOutRight = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] SerialOutBottom = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutLeft = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutTop = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutRight = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutBottom = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };

            Ambilight[] InnerSerialOutLeft2 = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutTop2 = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutRight2 = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };
            Ambilight[] InnerSerialOutBottom2 = new Ambilight[] { new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, ""), new Ambilight(0, 0, 0, "") };

            bool SerialOutLeftReady = false;
            bool SerialOutTopReady = false;
            bool SerialOutRightReady = false;
            bool SerialOutBottomReady = false;

            bool SerialOutLeftReady2 = false;
            bool SerialOutTopReady2 = false;
            bool SerialOutRightReady2 = false;
            bool SerialOutBottomReady2 = false;

            bool AllSendt = true;
            bool ProcessingDoneInnerFlip = true;

            bool ProcessingDoneInnerFlip2 = true;

            Bitmap ImageWindowLeft = new Bitmap(_LeftSide.Width, ScreenList[_ScreenID].Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowTop = new Bitmap(ScreenList[_ScreenID].Width, _TopSide.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowRight = new Bitmap(_RightSide.Width, ScreenList[_ScreenID].Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowBottom = new Bitmap(ScreenList[_ScreenID].Width, _BottomSide.Height, PixelFormat.Format24bppRgb);
            Graphics GFXScreenshotLeft = Graphics.FromImage(ImageWindowLeft);
            Graphics GFXScreenshotTop = Graphics.FromImage(ImageWindowTop);
            Graphics GFXScreenshotRight = Graphics.FromImage(ImageWindowRight);
            Graphics GFXScreenshotBottom = Graphics.FromImage(ImageWindowBottom);

            Bitmap ImageWindowLeft2 = new Bitmap(_LeftSide.Width, ScreenList[_ScreenID].Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowTop2 = new Bitmap(ScreenList[_ScreenID].Width, _TopSide.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowRight2 = new Bitmap(_RightSide.Width, ScreenList[_ScreenID].Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowBottom2 = new Bitmap(ScreenList[_ScreenID].Width, _BottomSide.Height, PixelFormat.Format24bppRgb);
            Graphics GFXScreenshotLeft2 = Graphics.FromImage(ImageWindowLeft2);
            Graphics GFXScreenshotTop2 = Graphics.FromImage(ImageWindowTop2);
            Graphics GFXScreenshotRight2 = Graphics.FromImage(ImageWindowRight2);
            Graphics GFXScreenshotBottom2 = Graphics.FromImage(ImageWindowBottom2);

            int LeftCaptureX = ScreenList[_ScreenID].X + _LeftSide.XOffSet;
            int LeftCaptureY = ScreenList[_ScreenID].Y + _LeftSide.YOffSet;
            int LeftCaptureWidth = _LeftSide.Width;
            int LeftCaptureHeight = ScreenList[_ScreenID].Height;
            int LeftFromI = ScreenList[_ScreenID].Height - _LeftSide.Height;
            int LeftAddIWith = _LeftSide.Height + _LeftSide.BlockSpacing;

            int TopCaptureX = ScreenList[_ScreenID].X + _TopSide.XOffSet;
            int TopCaptureY = ScreenList[_ScreenID].Y + _TopSide.YOffSet;
            int TopCaptureWidth = ScreenList[_ScreenID].Width;
            int TopCaptureHeight = _TopSide.Height;
            int TopUntilI = (ScreenList[_ScreenID].Width - _TopSide.Width);
            int TopAddIWith = _TopSide.Width + _TopSide.BlockSpacing;

            int RightCaptureX = (ScreenList[_ScreenID].X + ScreenList[_ScreenID].Width - _RightSide.Width) + _RightSide.XOffSet;
            int RightCaptureY = ScreenList[_ScreenID].Y + _RightSide.YOffSet;
            int RightCaptureWidth = _RightSide.Width;
            int RightCaptureHeight = ScreenList[_ScreenID].Height;
            int RightUntilI = ScreenList[_ScreenID].Height - _RightSide.Height;
            int RightAddIWith = _RightSide.Height + _RightSide.BlockSpacing;

            int BottomCaptureX = ScreenList[_ScreenID].X + _BottomSide.XOffSet;
            int BottomCaptureY = (ScreenList[_ScreenID].Y + ScreenList[_ScreenID].Height - _BottomSide.Height) + _BottomSide.YOffSet;
            int BottomCaptureWidth = ScreenList[_ScreenID].Width;
            int BottomCaptureHeight = _BottomSide.Height;
            int BottomFromI = ScreenList[_ScreenID].Width - _BottomSide.Width;
            int BottomAddIWith = _BottomSide.Width + _BottomSide.BlockSpacing;

            int WaitTime = -1;

            while (RunAmbilight)
            {
                if (ProcessingDoneInnerFlip)
                {
                    ProcessingDoneInnerFlip = false;

                    SerialOutLeftReady = false;
                    SerialOutTopReady = false;
                    SerialOutRightReady = false;
                    SerialOutBottomReady = false;

                    SerialOutLeftSection = 0;
                    SerialOutTopSection = 0;
                    SerialOutRightSection = 0;
                    SerialOutBottomSection = 0;

                    Array.Clear(InnerSerialOutLeft, 0, InnerSerialOutLeft.Length);
                    Array.Clear(InnerSerialOutTop, 0, InnerSerialOutTop.Length);
                    Array.Clear(InnerSerialOutRight, 0, InnerSerialOutRight.Length);
                    Array.Clear(InnerSerialOutBottom, 0, InnerSerialOutBottom.Length);

                    if (_LeftSide.Enabled)
                    {
                        Task.Run(() =>
                        {
                            SerialOutLeftReady = ProcessSection(
                                InnerSerialOutLeft,
                                GFXScreenshotLeft,
                                ImageWindowLeft,
                                SerialOutLeftSection,
                                LeftCaptureX,
                                LeftCaptureY,
                                LeftCaptureWidth,
                                LeftCaptureHeight,
                                _LeftSide.FromID,
                                _LeftSide.ToID,
                                _LeftSide.LEDsPrBlock,
                                LeftFromI,
                                0,
                                LeftAddIWith,
                                true,
                                _LeftSide.Width,
                                _LeftSide.Height,
                                false,
                                SideID.Left,
                                _FadeFactor,
                                _SampleSplit,
                                _GammaValue
                                );
                        });
                    }
                    else
                        SerialOutLeftReady = true;

                    if (_TopSide.Enabled)
                    {
                        Task.Run(() =>
                        {
                            SerialOutTopReady = ProcessSection(
                                InnerSerialOutTop,
                                GFXScreenshotTop,
                                ImageWindowTop,
                                SerialOutTopSection,
                                TopCaptureX,
                                TopCaptureY,
                                TopCaptureWidth,
                                TopCaptureHeight,
                                _TopSide.FromID,
                                _TopSide.ToID,
                                _TopSide.LEDsPrBlock,
                                0,
                                TopUntilI,
                                TopAddIWith,
                                false,
                                _TopSide.Width,
                                _TopSide.Height,
                                true,
                                SideID.Top,
                                _FadeFactor,
                                _SampleSplit,
                                _GammaValue
                                );
                        });
                    }
                    else
                        SerialOutTopReady = true;

                    if (_RightSide.Enabled)
                    {
                        Task.Run(() =>
                        {
                            SerialOutRightReady = ProcessSection(
                                InnerSerialOutRight,
                                GFXScreenshotRight,
                                ImageWindowRight,
                                SerialOutRightSection,
                                RightCaptureX,
                                RightCaptureY,
                                RightCaptureWidth,
                                RightCaptureHeight,
                                _RightSide.FromID,
                                _RightSide.ToID,
                                _RightSide.LEDsPrBlock,
                                0,
                                RightUntilI,
                                RightAddIWith,
                                false,
                                _RightSide.Width,
                                _RightSide.Height,
                                false,
                                SideID.Right,
                                _FadeFactor,
                                _SampleSplit,
                                _GammaValue
                                );
                        });
                    }
                    else
                        SerialOutRightReady = true;

                    if (_BottomSide.Enabled)
                    {
                        Task.Run(() =>
                        {
                            SerialOutBottomReady = ProcessSection(
                                InnerSerialOutBottom,
                                GFXScreenshotBottom,
                                ImageWindowBottom,
                                SerialOutBottomSection,
                                BottomCaptureX,
                                BottomCaptureY,
                                BottomCaptureWidth,
                                BottomCaptureHeight,
                                _BottomSide.FromID,
                                _BottomSide.ToID,
                                _BottomSide.LEDsPrBlock,
                                BottomFromI,
                                0,
                                BottomAddIWith,
                                true,
                                _BottomSide.Width,
                                _BottomSide.Height,
                                true,
                                SideID.Bottom,
                                _FadeFactor,
                                _SampleSplit,
                                _GammaValue
                                );
                        });
                    }
                    else
                        SerialOutBottomReady = true;

                    if (ProcessingDoneInnerFlip2 && WaitTime != -1)
                    {
                        ProcessingDoneInnerFlip2 = false;

                        SerialOutLeftReady2 = false;
                        SerialOutTopReady2 = false;
                        SerialOutRightReady2 = false;
                        SerialOutBottomReady2 = false;

                        SerialOutLeftSection2 = 0;
                        SerialOutTopSection2 = 0;
                        SerialOutRightSection2 = 0;
                        SerialOutBottomSection2 = 0;

                        Array.Clear(InnerSerialOutLeft2, 0, InnerSerialOutLeft2.Length);
                        Array.Clear(InnerSerialOutTop2, 0, InnerSerialOutTop2.Length);
                        Array.Clear(InnerSerialOutRight2, 0, InnerSerialOutRight2.Length);
                        Array.Clear(InnerSerialOutBottom2, 0, InnerSerialOutBottom2.Length);

                        int WaitTimeInner = WaitTime;
                        WaitTime = -1;

                        if (_LeftSide.Enabled)
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(WaitTimeInner);
                                SerialOutLeftReady2 = ProcessSection(
                                    InnerSerialOutLeft2,
                                    GFXScreenshotLeft2,
                                    ImageWindowLeft2,
                                    SerialOutLeftSection2,
                                    LeftCaptureX,
                                    LeftCaptureY,
                                    LeftCaptureWidth,
                                    LeftCaptureHeight,
                                    _LeftSide.FromID,
                                    _LeftSide.ToID,
                                    _LeftSide.LEDsPrBlock,
                                    LeftFromI,
                                    0,
                                    LeftAddIWith,
                                    true,
                                    _LeftSide.Width,
                                    _LeftSide.Height,
                                    false,
                                    SideID.Left,
                                    _FadeFactor,
                                    _SampleSplit,
                                    _GammaValue
                                    );
                            });
                        }
                        else
                            SerialOutLeftReady2 = true;

                        if (_TopSide.Enabled)
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(WaitTimeInner);
                                SerialOutTopReady2 = ProcessSection(
                                    InnerSerialOutTop2,
                                    GFXScreenshotTop2,
                                    ImageWindowTop2,
                                    SerialOutTopSection2,
                                    TopCaptureX,
                                    TopCaptureY,
                                    TopCaptureWidth,
                                    TopCaptureHeight,
                                    _TopSide.FromID,
                                    _TopSide.ToID,
                                    _TopSide.LEDsPrBlock,
                                    0,
                                    TopUntilI,
                                    TopAddIWith,
                                    false,
                                    _TopSide.Width,
                                    _TopSide.Height,
                                    true,
                                    SideID.Top,
                                    _FadeFactor,
                                    _SampleSplit,
                                    _GammaValue
                                    );
                            });
                        }
                        else
                            SerialOutTopReady2 = true;

                        if (_RightSide.Enabled)
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(WaitTimeInner);
                                SerialOutRightReady2 = ProcessSection(
                                    InnerSerialOutRight2,
                                    GFXScreenshotRight2,
                                    ImageWindowRight2,
                                    SerialOutRightSection2,
                                    RightCaptureX,
                                    RightCaptureY,
                                    RightCaptureWidth,
                                    RightCaptureHeight,
                                    _RightSide.FromID,
                                    _RightSide.ToID,
                                    _RightSide.LEDsPrBlock,
                                    0,
                                    RightUntilI,
                                    RightAddIWith,
                                    false,
                                    _RightSide.Width,
                                    _RightSide.Height,
                                    false,
                                    SideID.Right,
                                    _FadeFactor,
                                    _SampleSplit,
                                    _GammaValue
                                    );
                            });
                        }
                        else
                            SerialOutRightReady2 = true;

                        if (_BottomSide.Enabled)
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(WaitTimeInner);
                                SerialOutBottomReady2 = ProcessSection(
                                    InnerSerialOutBottom2,
                                    GFXScreenshotBottom2,
                                    ImageWindowBottom2,
                                    SerialOutBottomSection2,
                                    BottomCaptureX,
                                    BottomCaptureY,
                                    BottomCaptureWidth,
                                    BottomCaptureHeight,
                                    _BottomSide.FromID,
                                    _BottomSide.ToID,
                                    _BottomSide.LEDsPrBlock,
                                    BottomFromI,
                                    0,
                                    BottomAddIWith,
                                    true,
                                    _BottomSide.Width,
                                    _BottomSide.Height,
                                    true,
                                    SideID.Bottom,
                                    _FadeFactor,
                                    _SampleSplit,
                                    _GammaValue
                                    );
                            });
                        }
                        else
                            SerialOutBottomReady2 = true;
                    }
                }

                if (AllSendt && (SerialOutLeftReady && SerialOutTopReady && SerialOutRightReady && SerialOutBottomReady) | (SerialOutLeftReady2 && SerialOutTopReady2 && SerialOutRightReady2 && SerialOutBottomReady2))
                {
                    if ((DateTime.Now - AmbilightFPSCounter).TotalSeconds >= 1)
                    {
                        MainFormClass.AmbilightModeFPSCounterLabel.Invoke((MethodInvoker)delegate { MainFormClass.AmbilightModeFPSCounterLabel.Text = "FPS: " + AmbilightFPSCounterFramesRendered; });
                        AmbilightFPSCounterFramesRendered = 0;
                        AmbilightFPSCounter = DateTime.Now;
                    }

                    AllSendt = false;
                    if (SerialOutLeftReady && SerialOutTopReady && SerialOutRightReady && SerialOutBottomReady)
                    {
                        WaitTime = (DateTime.Now.Millisecond - CalibrateRefreshRate.Millisecond) / 2;
                        if (WaitTime < 0)
                            WaitTime = 0;
                        ProcessingDoneInnerFlip = true;
                        for (int i = 0; i < 5; i++)
                        {
                            SerialOutLeft[i] = InnerSerialOutLeft[i];
                            SerialOutTop[i] = InnerSerialOutTop[i];
                            SerialOutRight[i] = InnerSerialOutRight[i];
                            SerialOutBottom[i] = InnerSerialOutBottom[i];
                        }
                    }
                    if (SerialOutLeftReady2 && SerialOutTopReady2 && SerialOutRightReady2 && SerialOutBottomReady2)
                    {
                        ProcessingDoneInnerFlip2 = true;
                        for (int i = 0; i < 5; i++)
                        {
                            SerialOutLeft[i] = InnerSerialOutLeft2[i];
                            SerialOutTop[i] = InnerSerialOutTop2[i];
                            SerialOutRight[i] = InnerSerialOutRight2[i];
                            SerialOutBottom[i] = InnerSerialOutBottom2[i];
                        }
                    }

                    Task.Run(() =>
                    {
                        if (_LeftSide.Enabled)
                        {
                            for (int i = 0; i < 5; i++)
                                if (SerialOutLeft[i].Values != null)
                                    MainFormClass.Serial.Write(SerialOutLeft[i]);
                        }
                        if (_TopSide.Enabled)
                        {
                            for (int i = 0; i < 5; i++)
                                if (SerialOutTop[i].Values != null)
                                    MainFormClass.Serial.Write(SerialOutTop[i]);
                        }
                        if (_RightSide.Enabled)
                        {
                            for (int i = 0; i < 5; i++)
                                if (SerialOutRight[i].Values != null)
                                    MainFormClass.Serial.Write(SerialOutRight[i]);
                        }
                        if (_BottomSide.Enabled)
                            for (int i = 0; i < 5; i++)
                                if (SerialOutBottom[i].Values != null)
                                    MainFormClass.Serial.Write(SerialOutBottom[i]);

                        AllSendt = true;

                        AmbilightFPSCounterFramesRendered++;
                    });

                    int ExectuionTime = (int)(DateTime.Now - CalibrateRefreshRate).TotalMilliseconds;
                    int ActuralRefreshTime = _RefreshRate - ExectuionTime;

                    if (ActuralRefreshTime < 0)
                        ActuralRefreshTime = 0;

                    Thread.Sleep(ActuralRefreshTime);

                    CalibrateRefreshRate = DateTime.Now;
                }
            }

            while(!(SerialOutLeftReady && SerialOutTopReady && SerialOutRightReady && SerialOutBottomReady) && !(SerialOutLeftReady2 && SerialOutTopReady2 && SerialOutRightReady2 && SerialOutBottomReady2))
                Thread.Sleep(100);

            Thread.Sleep(1000);

            GFXScreenshotLeft.Dispose();
            GFXScreenshotTop.Dispose();
            GFXScreenshotRight.Dispose();
            GFXScreenshotBottom.Dispose();
            GFXScreenshotLeft2.Dispose();
            GFXScreenshotTop2.Dispose();
            GFXScreenshotRight2.Dispose();
            GFXScreenshotBottom2.Dispose();

            ImageWindowLeft.Dispose();
            ImageWindowTop.Dispose();
            ImageWindowRight.Dispose();
            ImageWindowBottom.Dispose();
            ImageWindowLeft2.Dispose();
            ImageWindowTop2.Dispose();
            ImageWindowRight2.Dispose();
            ImageWindowBottom2.Dispose();
        }

        private bool ProcessSection(
            Ambilight[] InnerSerialOut,
            Graphics _GFXScreenShot,
            Bitmap _ImageWindow,
            int _SectionIndex,
            int _CaptureX,
            int _CaptureY,
            int _CaptureWidth,
            int _CaptureHeight,
            int _FromID,
            int _ToID,
            int _PixelsPrBlock,
            int _FromI,
            int _UntilI,
            int _AddToI,
            bool _WhileILarger,
            int _ProcessColorWidth,
            int _ProcessColorHeight,
            bool _ILoc,
            SideID _SideID,
            double _FadeFactor,
            int _AddBy,
            double _GammaValue
            )
        {
            _GFXScreenShot.CopyFromScreen(_CaptureX, _CaptureY, 0, 0, new Size(_CaptureWidth, _CaptureHeight), CopyPixelOperation.SourceCopy);

            int Count = 0;
            InnerSerialOut[_SectionIndex] = new Ambilight(_FromID, _ToID, _PixelsPrBlock, "");
            if (_WhileILarger)
            {
                for (int i = _FromI; i > _UntilI; i -= _AddToI)
                {
                    _SectionIndex = ProcessSectionInner(
                        _ILoc,
                        _ImageWindow,
                        _ProcessColorWidth,
                        _ProcessColorHeight,
                        i,
                        _SideID,
                        Count,
                        InnerSerialOut,
                        _SectionIndex,
                        _FromID,
                        _ToID,
                        _PixelsPrBlock,
                        _FadeFactor,
                        _AddBy,
                        _GammaValue
                        );
                    Count++;
                }
            }
            else
            {
                for (int i = _FromI; i < _UntilI; i += _AddToI)
                {
                    _SectionIndex = ProcessSectionInner(
                        _ILoc,
                        _ImageWindow,
                        _ProcessColorWidth,
                        _ProcessColorHeight,
                        i,
                        _SideID,
                        Count,
                        InnerSerialOut,
                        _SectionIndex,
                        _FromID,
                        _ToID,
                        _PixelsPrBlock,
                        _FadeFactor,
                        _AddBy,
                        _GammaValue
                        );
                    Count++;
                }
            }

            return true;
        }

        private int ProcessSectionInner(
            bool _ILoc,
            Bitmap _ImageWindow,
            int _ProcessColorWidth,
            int _ProcessColorHeight,
            int _i,
            SideID _SideID,
            int _Count,
            Ambilight[] _InnerSerialOut,
            int _SectionIndex,
            int _FromID,
            int _ToID,
            int _PixelsPrBlock,
            double _FadeFactor,
            int _AddBy,
            double _GammaValue
            )
        {
            Color OutPutColor;
            if (_ILoc)
                OutPutColor = GetColorOfSection(_ImageWindow, _ProcessColorWidth, _ProcessColorHeight, _i, 0, _AddBy);
            else
                OutPutColor = GetColorOfSection(_ImageWindow, _ProcessColorWidth, _ProcessColorHeight, 0, _i, _AddBy);
            if (_FadeFactor != 0)
            {
                int RedValue;
                int GreenValue;
                int BlueValue;
                if (AmbilightColorStore[(int)_SideID].Count == _Count)
                {
                    AmbilightColorStore[(int)_SideID].Add(new List<int> { OutPutColor.R, OutPutColor.G, OutPutColor.B });
                    RedValue = OutPutColor.R;
                    GreenValue = OutPutColor.G;
                    BlueValue = OutPutColor.B;
                }
                else
                {
                    RedValue = AmbilightColorStore[(int)_SideID][_Count][0] + (int)(((double)OutPutColor.R - (double)AmbilightColorStore[(int)_SideID][_Count][0]) * _FadeFactor);
                    if (RedValue > 255)
                        RedValue = 255;
                    if (RedValue < 0)
                        RedValue = 0;
                    AmbilightColorStore[(int)_SideID][_Count][0] = RedValue;
                    GreenValue = AmbilightColorStore[(int)_SideID][_Count][1] + (int)(((double)OutPutColor.G - (double)AmbilightColorStore[(int)_SideID][_Count][1]) * _FadeFactor);
                    if (GreenValue > 255)
                        GreenValue = 255;
                    if (GreenValue < 0)
                        GreenValue = 0;
                    AmbilightColorStore[(int)_SideID][_Count][1] = GreenValue;
                    BlueValue = AmbilightColorStore[(int)_SideID][_Count][2] + (int)(((double)OutPutColor.B - (double)AmbilightColorStore[(int)_SideID][_Count][2]) * _FadeFactor);
                    if (BlueValue > 255)
                        BlueValue = 255;
                    if (BlueValue < 0)
                        BlueValue = 0;
                    AmbilightColorStore[(int)_SideID][_Count][2] = BlueValue;
                }
                OutPutColor = GammaCorrection(Color.FromArgb(RedValue, GreenValue, BlueValue), _GammaValue);
            }
            else
            {
                OutPutColor = GammaCorrection(OutPutColor, _GammaValue);
            }
            Color AfterShuffel = MainFormClass.ShuffleColors(OutPutColor);

            int RVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.R + 1)), 0) + 1;
            int GVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.G + 1)), 0) + 1;
            int BVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.B + 1)), 0) + 1;

            string AddString = "";

            if (RVal == GVal && GVal == BVal)
            {
                AddString = RVal.ToString() + ";";
            }
            else
            {
                if (RVal == GVal && RVal != 0)
                {
                    AddString = RVal.ToString() + BVal.ToString() + ";";
                }
                else
                {
                    AddString = RVal.ToString() + GVal.ToString() + BVal.ToString() + ";";
                }
            }

            if (AddString.Length + _InnerSerialOut[_SectionIndex].Values.Length > 75)
            {
                string[] ChangeToIDString = _InnerSerialOut[_SectionIndex].Values.Split(';');
                if (_FromID < _ToID)
                    _InnerSerialOut[_SectionIndex].ToID = (_FromID + (_Count * _PixelsPrBlock));
                else
                    _InnerSerialOut[_SectionIndex].ToID = (_FromID - (_Count * _PixelsPrBlock));

                _SectionIndex++;

                if (_FromID < _ToID)
                    _InnerSerialOut[_SectionIndex] = new Ambilight((_FromID + (_Count * _PixelsPrBlock)), _ToID, _PixelsPrBlock, "");
                else
                    _InnerSerialOut[_SectionIndex] = new Ambilight((_FromID - (_Count * _PixelsPrBlock)), _ToID, _PixelsPrBlock, "");
            }
            _InnerSerialOut[_SectionIndex].Values += AddString;
            return _SectionIndex;
        }

        private Color GetColorOfSection(Bitmap _InputImage, int _Width, int _Height, int _Xpos, int _Ypos, int _AddBy)
        {
            int Count = 0;
            int AvgR = 0;
            int AvgG = 0;
            int AvgB = 0;

            int High = 0;
            int Low = 765;

            int CountTarget = (int)(((_Height / _AddBy) * (_Width / _AddBy)) * AssumeLevel);

            for (int y = _Ypos; y < _Ypos + _Height; y += _AddBy)
            {
                for (int x = _Xpos; x < _Xpos + _Width; x += _AddBy)
                {
                    Color Pixel = _InputImage.GetPixel(x, y);
                    AvgR += Pixel.R;
                    AvgG += Pixel.G;
                    AvgB += Pixel.B;
                    if ((AvgR + AvgG + AvgB) > High)
                        High = (AvgR + AvgG + AvgB);
                    if ((AvgR + AvgG + AvgB) < Low)
                        Low = (AvgR + AvgG + AvgB);
                    if (CountTarget == Count)
                        if (High - Low <= MaxVariation)
                            break;
                    Count++;
                }
            }

            AvgR = AvgR / Count;
            AvgG = AvgG / Count;
            AvgB = AvgB / Count;

            return Color.FromArgb(AvgR, AvgG, AvgB);
        }

        private Color GammaCorrection(Color _InputColor, double _GammaValue)
        {
            int OutColorR = (int)(Math.Pow((double)_InputColor.R / (double)255, _GammaValue) * 255 + 0.5);
            if (OutColorR > 255)
                OutColorR = 0;
            if (OutColorR < 0)
                OutColorR = 0;

            int OutColorG = (int)(Math.Pow((double)_InputColor.G / (double)255, _GammaValue) * 255 + 0.5);
            if (OutColorG > 255)
                OutColorG = 0;
            if (OutColorG < 0)
                OutColorG = 0;

            int OutColorB = (int)(Math.Pow((double)_InputColor.B / (double)255, _GammaValue) * 255 + 0.5);
            if (OutColorB > 255)
                OutColorB = 0;
            if (OutColorB < 0)
                OutColorB = 0;

            return Color.FromArgb(OutColorR, OutColorG, OutColorB);
        }

        public void SetSides()
        {
            LeftSide.Enabled = MainFormClass.AmbiLightModeLeftCheckBox.Checked;
            LeftSide.Width = (int)MainFormClass.AmbiLightModeLeftBlockWidthNumericUpDown.Value;
            LeftSide.Height = (int)MainFormClass.AmbiLightModeLeftBlockHeightNumericUpDown.Value;
            LeftSide.BlockSpacing = (int)MainFormClass.AmbiLightModeLeftBlockSpacingNumericUpDown.Value;
            LeftSide.XOffSet = (int)MainFormClass.AmbiLightModeLeftBlockOffsetXNumericUpDown.Value;
            LeftSide.YOffSet = (int)MainFormClass.AmbiLightModeLeftBlockOffsetYNumericUpDown.Value;
            LeftSide.FromID = (int)MainFormClass.AmbiLightModeLeftFromIDNumericUpDown.Value;
            LeftSide.ToID = (int)MainFormClass.AmbiLightModeLeftToIDNumericUpDown.Value;
            LeftSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Value;

            TopSide.Enabled = MainFormClass.AmbiLightModeTopCheckBox.Checked;
            TopSide.Width = (int)MainFormClass.AmbiLightModeTopBlockWidthNumericUpDown.Value;
            TopSide.Height = (int)MainFormClass.AmbiLightModeTopBlockHeightNumericUpDown.Value;
            TopSide.BlockSpacing = (int)MainFormClass.AmbiLightModeTopBlockSpacingNumericUpDown.Value;
            TopSide.XOffSet = (int)MainFormClass.AmbiLightModeTopBlockOffsetXNumericUpDown.Value;
            TopSide.YOffSet = (int)MainFormClass.AmbiLightModeTopBlockOffsetYNumericUpDown.Value;
            TopSide.FromID = (int)MainFormClass.AmbiLightModeTopFromIDNumericUpDown.Value;
            TopSide.ToID = (int)MainFormClass.AmbiLightModeTopToIDNumericUpDown.Value;
            TopSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeTopLEDsPrBlockNumericUpDown.Value;

            RightSide.Enabled = MainFormClass.AmbiLightModeRightCheckBox.Checked;
            RightSide.Width = (int)MainFormClass.AmbiLightModeRightBlockWidthNumericUpDown.Value;
            RightSide.Height = (int)MainFormClass.AmbiLightModeRightBlockHeightNumericUpDown.Value;
            RightSide.BlockSpacing = (int)MainFormClass.AmbiLightModeRightBlockSpacingNumericUpDown.Value;
            RightSide.XOffSet = (int)MainFormClass.AmbiLightModeRightBlockOffsetXNumericUpDown.Value;
            RightSide.YOffSet = (int)MainFormClass.AmbiLightModeRightBlockOffsetYNumericUpDown.Value;
            RightSide.FromID = (int)MainFormClass.AmbiLightModeRightFromIDNumericUpDown.Value;
            RightSide.ToID = (int)MainFormClass.AmbiLightModeRightToIDNumericUpDown.Value;
            RightSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeRightLEDsPrBlockNumericUpDown.Value;

            BottomSide.Enabled = MainFormClass.AmbiLightModeBottomCheckBox.Checked;
            BottomSide.Width = (int)MainFormClass.AmbiLightModeBottomBlockWidthNumericUpDown.Value;
            BottomSide.Height = (int)MainFormClass.AmbiLightModeBottomBlockHeightNumericUpDown.Value;
            BottomSide.BlockSpacing = (int)MainFormClass.AmbiLightModeBottomBlockSpacingNumericUpDown.Value;
            BottomSide.XOffSet = (int)MainFormClass.AmbiLightModeBottomBlockOffsetXNumericUpDown.Value;
            BottomSide.YOffSet = (int)MainFormClass.AmbiLightModeBottomBlockOffsetYNumericUpDown.Value;
            BottomSide.FromID = (int)MainFormClass.AmbiLightModeBottomFromIDNumericUpDown.Value;
            BottomSide.ToID = (int)MainFormClass.AmbiLightModeBottomToIDNumericUpDown.Value;
            BottomSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Value;
        }
    }
}
