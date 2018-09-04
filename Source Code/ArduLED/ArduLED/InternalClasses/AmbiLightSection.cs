using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ArduLEDNameSpace
{
    public class AmbiLightSection : IDisposable
    {
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private List<Block> BlockList = new List<Block>();
        private List<List<List<int>>> AmbilightColorStore = new List<List<List<int>>>();
        private bool RunAmbilight = false;
        private DateTime AmbilightFPSCounter;
        private int AmbilightFPSCounterFramesRendered;
        private Task AmbilightTask;
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
        }

        public void ShowBlocks(AmbilightSide _LeftSide, AmbilightSide _ToptSide, AmbilightSide _RightSide, AmbilightSide _BottomSide, int _ScreenID, int _SampleSplit)
        {
            if (BlockList.Count == 0)
            {
                if (_LeftSide.Enabled)
                {
                    MakeNewBlock(
                        (Screen.AllScreens[_ScreenID].Bounds.Height - _LeftSide.Height + _LeftSide.XOffSet),
                        _LeftSide.XOffSet,
                        _LeftSide.Height + _LeftSide.BlockSpacing,
                        true,
                        _LeftSide.Width,
                        _LeftSide.Height,
                        false,
                        Screen.AllScreens[_ScreenID].Bounds.X + _LeftSide.XOffSet,
                        Screen.AllScreens[_ScreenID].Bounds.Y,
                        _SampleSplit
                        );
                }
                if (_ToptSide.Enabled)
                {
                    MakeNewBlock(
                        _ToptSide.XOffSet,
                        (Screen.AllScreens[_ScreenID].Bounds.Width - _ToptSide.Width),
                        _ToptSide.Width + _ToptSide.BlockSpacing,
                        false,
                        _ToptSide.Width,
                        _ToptSide.Height,
                        true,
                        Screen.AllScreens[_ScreenID].Bounds.X,
                        Screen.AllScreens[_ScreenID].Bounds.Y + _ToptSide.YOffSet,
                        _SampleSplit
                        );
                }
                if (_RightSide.Enabled)
                {
                    MakeNewBlock(
                        _RightSide.YOffSet,
                        Screen.AllScreens[_ScreenID].Bounds.Height - _RightSide.Height,
                        _RightSide.Height + _RightSide.BlockSpacing,
                        false,
                        _RightSide.Width,
                        _RightSide.Height,
                        false,
                        Screen.AllScreens[_ScreenID].Bounds.X + Screen.AllScreens[_ScreenID].Bounds.Width - _RightSide.XOffSet - _RightSide.Width,
                        Screen.AllScreens[_ScreenID].Bounds.Y,
                        _SampleSplit
                        );
                }
                if (_BottomSide.Enabled)
                {
                    MakeNewBlock(
                        (Screen.AllScreens[_ScreenID].Bounds.Width - _BottomSide.Width) + _BottomSide.XOffSet,
                        _BottomSide.Width,
                        _BottomSide.Width + _BottomSide.BlockSpacing,
                        true,
                        _BottomSide.Width,
                        _BottomSide.Height,
                        true,
                        Screen.AllScreens[_ScreenID].Bounds.X,
                        Screen.AllScreens[_ScreenID].Bounds.Y + Screen.AllScreens[_ScreenID].Bounds.Height + _BottomSide.YOffSet - _BottomSide.Height,
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

        public void AutoSetOffsets(AmbilightSide _LeftSide, AmbilightSide _TopSide, AmbilightSide _RightSide, AmbilightSide _BottomSide, int _ScreenID, int _SampleSplit)
        {
            MainFormClass.Opacity = 0;
            Bitmap Screenshot = new Bitmap(Screen.AllScreens[_ScreenID].Bounds.Width, Screen.AllScreens[_ScreenID].Bounds.Height, PixelFormat.Format32bppRgb);
            using (Graphics GFXScreenshot = Graphics.FromImage(Screenshot))
            {
                GFXScreenshot.CopyFromScreen(Screen.AllScreens[_ScreenID].Bounds.X, Screen.AllScreens[_ScreenID].Bounds.Y, 0, 0, new Size(Screenshot.Width, Screenshot.Height), CopyPixelOperation.SourceCopy);
            }
            MainFormClass.Opacity = 1;

            if (_LeftSide.Enabled)
            {
                MainFormClass.AmbiLightModeLeftBlockOffsetYNumericUpDown.Value = FindFirstLightPixel(
                    0,
                    Screen.AllScreens[_ScreenID].Bounds.Width / 2,
                    false,
                    true,
                    0,
                    Screen.AllScreens[_ScreenID].Bounds.Height / 2,
                    Screenshot
                    );
            }

            if (_TopSide.Enabled)
            {
                MainFormClass.AmbiLightModeTopBlockOffsetYNumericUpDown.Value = FindFirstLightPixel(
                    0,
                    Screen.AllScreens[_ScreenID].Bounds.Height / 2,
                    false,
                    false,
                    Screen.AllScreens[_ScreenID].Bounds.Width / 2,
                    0,
                    Screenshot
                    );
            }

            if (_RightSide.Enabled)
            {
                MainFormClass.AmbiLightModeRightBlockOffsetXNumericUpDown.Value = Screen.AllScreens[_ScreenID].Bounds.Width - FindFirstLightPixel(
                    Screen.AllScreens[_ScreenID].Bounds.Width - 1,
                    Screen.AllScreens[_ScreenID].Bounds.Width / 2,
                    true,
                    true,
                    0,
                    Screen.AllScreens[_ScreenID].Bounds.Height / 2,
                    Screenshot
                    );
            }

            if (_BottomSide.Enabled)
            {
                MainFormClass.AmbiLightModeBottomBlockOffsetYNumericUpDown.Value = Screen.AllScreens[_ScreenID].Bounds.Height - FindFirstLightPixel(
                    Screen.AllScreens[_ScreenID].Bounds.Height - 1,
                    Screen.AllScreens[_ScreenID].Bounds.Height / 2,
                    true,
                    false,
                    Screen.AllScreens[_ScreenID].Bounds.Width / 2,
                    0,
                    Screenshot
                    );
            }
            Screenshot.Dispose();

            Application.DoEvents();

            SetSides();

            ShowBlocks(MainFormClass.LeftSide, MainFormClass.TopSide, MainFormClass.RightSide, MainFormClass.BottomSide, _ScreenID, _SampleSplit);

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

        public void StartAmbilight(AmbilightSide _LeftSide, AmbilightSide _TopSide, AmbilightSide _RightSide, AmbilightSide _BottomSide, int _ScreenID, int _SampleSplit, double _GammaValue, double _FadeFactor, int _RefreshRate)
        {
            if (AmbilightTask != null)
                if (AmbilightTask.Status == TaskStatus.Running)
                    StopAmbilight();

            int Highest = 0;
            int Lowest = 0;

            if (_LeftSide.Enabled)
                if (_LeftSide.FromID < Lowest)
                    Lowest = _LeftSide.FromID;

            if (_TopSide.Enabled)
                if (_TopSide.FromID < Lowest)
                    Lowest = _TopSide.FromID;

            if (_RightSide.Enabled)
                if (_RightSide.FromID < Lowest)
                    Lowest = _RightSide.FromID;

            if (_BottomSide.Enabled)
                if (_BottomSide.FromID < Lowest)
                    Lowest = _BottomSide.FromID;

            if (_LeftSide.Enabled)
                if (_LeftSide.ToID < Lowest)
                    Lowest = _LeftSide.ToID;

            if (_TopSide.Enabled)
                if (_TopSide.ToID < Lowest)
                    Lowest = _TopSide.ToID;

            if (_RightSide.Enabled)
                if (_RightSide.ToID < Lowest)
                    Lowest = _RightSide.ToID;

            if (_BottomSide.Enabled)
                if (_BottomSide.ToID < Lowest)
                    Lowest = _BottomSide.ToID;

            if (_LeftSide.Enabled)
                if (_LeftSide.ToID > Highest)
                    Highest = _LeftSide.ToID;

            if (_TopSide.Enabled)
                if (_TopSide.ToID > Highest)
                    Highest = _TopSide.ToID;

            if (_RightSide.Enabled)
                if (_RightSide.ToID > Highest)
                    Highest = _RightSide.ToID;

            if (_BottomSide.Enabled)
                if (_BottomSide.ToID > Highest)
                    Highest = _BottomSide.ToID;

            if (_LeftSide.Enabled)
                if (_LeftSide.FromID > Highest)
                    Highest = _LeftSide.FromID;

            if (_TopSide.Enabled)
                if (_TopSide.FromID > Highest)
                    Highest = _TopSide.FromID;

            if (_RightSide.Enabled)
                if (_RightSide.FromID > Highest)
                    Highest = _RightSide.FromID;

            if (_BottomSide.Enabled)
                if (_BottomSide.FromID > Highest)
                    Highest = _BottomSide.FromID;

            string SerialOut = "6;" + Lowest + ";" + Highest;
            MainFormClass.SendDataBySerial(SerialOut);

            if (AmbilightColorStore.Count != 4)
            {
                AmbilightColorStore.Clear();
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
                AmbilightColorStore.Add(new List<List<int>>());
            }

            MainFormClass.AmbiLightModeWorkingPanel.Enabled = false;

            AmbilightTask = new Task(delegate { AmbilightThread(_LeftSide,_TopSide,_RightSide,_BottomSide, _ScreenID, _SampleSplit, _GammaValue, _FadeFactor, _RefreshRate); });
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

            string[] SerialOutLeft = { "", "", "", "", "" };
            string[] SerialOutTop = { "", "", "", "", "" };
            string[] SerialOutRight = { "", "", "", "", "" };
            string[] SerialOutBottom = { "", "", "", "", "" };
            string[] InnerSerialOutLeft = { "", "", "", "", "" };
            string[] InnerSerialOutTop = { "", "", "", "", "" };
            string[] InnerSerialOutRight = { "", "", "", "", "" };
            string[] InnerSerialOutBottom = { "", "", "", "", "" };

            string[] InnerSerialOutLeft2 = { "", "", "", "", "" };
            string[] InnerSerialOutTop2 = { "", "", "", "", "" };
            string[] InnerSerialOutRight2 = { "", "", "", "", "" };
            string[] InnerSerialOutBottom2 = { "", "", "", "", "" };

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

            Bitmap ImageWindowLeft = new Bitmap(_LeftSide.Width, Screen.AllScreens[_ScreenID].Bounds.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowTop = new Bitmap(Screen.AllScreens[_ScreenID].Bounds.Width, _TopSide.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowRight = new Bitmap(_RightSide.Width, Screen.AllScreens[_ScreenID].Bounds.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowBottom = new Bitmap(Screen.AllScreens[_ScreenID].Bounds.Width, _BottomSide.Height, PixelFormat.Format24bppRgb);
            Graphics GFXScreenshotLeft = Graphics.FromImage(ImageWindowLeft);
            Graphics GFXScreenshotTop = Graphics.FromImage(ImageWindowTop);
            Graphics GFXScreenshotRight = Graphics.FromImage(ImageWindowRight);
            Graphics GFXScreenshotBottom = Graphics.FromImage(ImageWindowBottom);

            Bitmap ImageWindowLeft2 = new Bitmap(_LeftSide.Width, Screen.AllScreens[_ScreenID].Bounds.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowTop2 = new Bitmap(Screen.AllScreens[_ScreenID].Bounds.Width, _TopSide.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowRight2 = new Bitmap(_RightSide.Width, Screen.AllScreens[_ScreenID].Bounds.Height, PixelFormat.Format24bppRgb);
            Bitmap ImageWindowBottom2 = new Bitmap(Screen.AllScreens[_ScreenID].Bounds.Width, _BottomSide.Height, PixelFormat.Format24bppRgb);
            Graphics GFXScreenshotLeft2 = Graphics.FromImage(ImageWindowLeft2);
            Graphics GFXScreenshotTop2 = Graphics.FromImage(ImageWindowTop2);
            Graphics GFXScreenshotRight2 = Graphics.FromImage(ImageWindowRight2);
            Graphics GFXScreenshotBottom2 = Graphics.FromImage(ImageWindowBottom2);

            int LeftCaptureX = Screen.AllScreens[_ScreenID].Bounds.X + _LeftSide.XOffSet;
            int LeftCaptureY = Screen.AllScreens[_ScreenID].Bounds.Y + _LeftSide.YOffSet;
            int LeftCaptureWidth = _LeftSide.Width;
            int LeftCaptureHeight = Screen.AllScreens[_ScreenID].Bounds.Height;
            int LeftFromI = Screen.AllScreens[_ScreenID].Bounds.Height - _LeftSide.Height;
            int LeftAddIWith = _LeftSide.Height + _LeftSide.BlockSpacing;

            int TopCaptureX = Screen.AllScreens[_ScreenID].Bounds.X + _TopSide.XOffSet;
            int TopCaptureY = Screen.AllScreens[_ScreenID].Bounds.Y + _TopSide.YOffSet;
            int TopCaptureWidth = Screen.AllScreens[_ScreenID].Bounds.Width;
            int TopCaptureHeight = _TopSide.Height;
            int TopUntilI = (Screen.AllScreens[_ScreenID].Bounds.Width - _TopSide.Width);
            int TopAddIWith = _TopSide.Width + _TopSide.BlockSpacing;

            int RightCaptureX = (Screen.AllScreens[_ScreenID].Bounds.X + Screen.AllScreens[_ScreenID].Bounds.Width - _RightSide.Width) + _RightSide.XOffSet;
            int RightCaptureY = Screen.AllScreens[_ScreenID].Bounds.Y + _RightSide.YOffSet;
            int RightCaptureWidth = _RightSide.Width;
            int RightCaptureHeight = Screen.AllScreens[_ScreenID].Bounds.Height;
            int RightUntilI = Screen.AllScreens[_ScreenID].Bounds.Height - _RightSide.Height;
            int RightAddIWith = _RightSide.Height + _RightSide.BlockSpacing;

            int BottomCaptureX = Screen.AllScreens[_ScreenID].Bounds.X + _BottomSide.XOffSet;
            int BottomCaptureY = (Screen.AllScreens[_ScreenID].Bounds.Y + Screen.AllScreens[_ScreenID].Bounds.Height - _BottomSide.Height) + _BottomSide.YOffSet;
            int BottomCaptureWidth = Screen.AllScreens[_ScreenID].Bounds.Width;
            int BottomCaptureHeight = _BottomSide.Height;
            int BottomUntilI = Screen.AllScreens[_ScreenID].Bounds.Height - _BottomSide.Height;
            int BottomAddIWith = _BottomSide.Height + _BottomSide.BlockSpacing;

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
                                0,
                                0,
                                false,
                                0,
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
                                0,
                                0,
                                true,
                                1,
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
                                0,
                                0,
                                false,
                                2,
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
                                0,
                                BottomUntilI,
                                BottomAddIWith,
                                false,
                                _BottomSide.Width,
                                _BottomSide.Height,
                                0,
                                0,
                                true,
                                3,
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
                                    0,
                                    0,
                                    false,
                                    0,
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
                                    0,
                                    0,
                                    true,
                                    1,
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
                                    0,
                                    0,
                                    false,
                                    2,
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
                                    0,
                                    BottomUntilI,
                                    BottomAddIWith,
                                    false,
                                    _BottomSide.Width,
                                    _BottomSide.Height,
                                    0,
                                    0,
                                    true,
                                    3,
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
                                if (SerialOutLeft[i] != null)
                                    MainFormClass.SendDataBySerial(SerialOutLeft[i]);
                        }
                        if (_TopSide.Enabled)
                        {
                            for (int i = 0; i < 5; i++)
                                if (SerialOutTop[i] != null)
                                    MainFormClass.SendDataBySerial(SerialOutTop[i]);
                        }
                        if (_RightSide.Enabled)
                        {
                            for (int i = 0; i < 5; i++)
                                if (SerialOutRight[i] != null)
                                    MainFormClass.SendDataBySerial(SerialOutRight[i]);
                        }
                        if (_BottomSide.Enabled)
                            for (int i = 0; i < 5; i++)
                                if (SerialOutBottom[i] != null)
                                    MainFormClass.SendDataBySerial(SerialOutBottom[i]);

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

        private Color GetColorOfSection(Bitmap _InputImage, int _Width, int _Height, int _Xpos, int _Ypos, int _AddBy)
        {
            int Count = 0;
            int AvgR = 0;
            int AvgG = 0;
            int AvgB = 0;

            for (int y = _Ypos; y < _Ypos + _Height; y += _AddBy)
            {
                for (int x = _Xpos; x < _Xpos + _Width; x += _AddBy)
                {
                    Color Pixel = _InputImage.GetPixel(x, y);
                    AvgR += Pixel.R;
                    AvgG += Pixel.G;
                    AvgB += Pixel.B;
                    Count++;
                }
            }

            AvgR = AvgR / Count;
            AvgG = AvgG / Count;
            AvgB = AvgB / Count;

            return Color.FromArgb(AvgR, AvgG, AvgB);
        }

        private bool ProcessSection(
            string[] InnerSerialOut,
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
            int _OffSetX,
            int _OffSetY,
            bool _ILoc,
            int _SideID,
            double _FadeFactor,
            int _AddBy,
            double _GammaValue
            )
        {

            _GFXScreenShot.CopyFromScreen(_CaptureX, _CaptureY, 0, 0, new Size(_CaptureWidth, _CaptureHeight), CopyPixelOperation.SourceCopy);

            int Count = 0;
            InnerSerialOut[_SectionIndex] = "7;" + _FromID + ";" + _ToID + ";" + _PixelsPrBlock + ";";
            if (_WhileILarger)
            {
                for (int i = _FromI; i > _UntilI; i -= _AddToI)
                {
                    _SectionIndex = ProcessSectionInner(
                        _ILoc,
                        _ImageWindow,
                        _ProcessColorWidth,
                        _ProcessColorHeight,
                        _OffSetX,
                        _OffSetY,
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
                        _OffSetX,
                        _OffSetY,
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
            int _OffSetX,
            int _OffSetY,
            int _i,
            int _SideID,
            int _Count,
            string[] _InnerSerialOut,
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
                OutPutColor = GetColorOfSection(_ImageWindow, _ProcessColorWidth, _ProcessColorHeight, _OffSetX + _i, _OffSetY, _AddBy);
            else
                OutPutColor = GetColorOfSection(_ImageWindow, _ProcessColorWidth, _ProcessColorHeight, _OffSetX, _OffSetY + _i, _AddBy);
            if (_FadeFactor != 0)
            {
                if (AmbilightColorStore[_SideID].Count == _Count)
                {
                    AmbilightColorStore[_SideID].Add(new List<int>());
                    AmbilightColorStore[_SideID][_Count].Add(OutPutColor.R);
                    AmbilightColorStore[_SideID][_Count].Add(OutPutColor.G);
                    AmbilightColorStore[_SideID][_Count].Add(OutPutColor.B);
                }
                else
                {
                    AmbilightColorStore[_SideID][_Count][0] = AmbilightColorStore[_SideID][_Count][0] + (int)(((double)OutPutColor.R - (double)AmbilightColorStore[_SideID][_Count][0]) * _FadeFactor);
                    if (AmbilightColorStore[_SideID][_Count][0] > 255)
                        AmbilightColorStore[_SideID][_Count][0] = 255;
                    if (AmbilightColorStore[_SideID][_Count][0] < 0)
                        AmbilightColorStore[_SideID][_Count][0] = 0;
                    AmbilightColorStore[_SideID][_Count][1] = AmbilightColorStore[_SideID][_Count][1] + (int)(((double)OutPutColor.G - (double)AmbilightColorStore[_SideID][_Count][1]) * _FadeFactor);
                    if (AmbilightColorStore[_SideID][_Count][1] > 255)
                        AmbilightColorStore[_SideID][_Count][1] = 255;
                    if (AmbilightColorStore[_SideID][_Count][1] < 0)
                        AmbilightColorStore[_SideID][_Count][1] = 0;
                    AmbilightColorStore[_SideID][_Count][2] = AmbilightColorStore[_SideID][_Count][2] + (int)(((double)OutPutColor.B - (double)AmbilightColorStore[_SideID][_Count][2]) * _FadeFactor);
                    if (AmbilightColorStore[_SideID][_Count][2] > 255)
                        AmbilightColorStore[_SideID][_Count][2] = 255;
                    if (AmbilightColorStore[_SideID][_Count][2] < 0)
                        AmbilightColorStore[_SideID][_Count][2] = 0;
                }
                OutPutColor = GammaCorrection(Color.FromArgb(AmbilightColorStore[_SideID][_Count][0], AmbilightColorStore[_SideID][_Count][1], AmbilightColorStore[_SideID][_Count][2]), _GammaValue);
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

            if (AddString.Length + _InnerSerialOut[_SectionIndex].Length * 2 > 128)
            {
                string[] ChangeToIDString = _InnerSerialOut[_SectionIndex].Split(';');
                if (_FromID < _ToID)
                    ChangeToIDString[2] = (_FromID + _Count).ToString();
                else
                    ChangeToIDString[2] = (_FromID - _Count).ToString();

                _InnerSerialOut[_SectionIndex] = "";

                foreach (String Out in ChangeToIDString)
                {
                    _InnerSerialOut[_SectionIndex] += Out + ";";
                }

                _SectionIndex++;

                if (_FromID < _ToID)
                    _InnerSerialOut[_SectionIndex] = "7;" + (_FromID + _Count) + ";" + _ToID + ";" + _PixelsPrBlock + ";";
                else
                    _InnerSerialOut[_SectionIndex] = "7;" + (_FromID - _Count) + ";" + _ToID + ";" + _PixelsPrBlock + ";";
            }
            _InnerSerialOut[_SectionIndex] += AddString;
            return _SectionIndex;
        }

        private Color GammaCorrection(Color _InputColor, double _GammaValue)
        {
            int OutColorR = (int)(Math.Pow((float)_InputColor.R / (float)255, _GammaValue) * 255 + 0.5);
            if (OutColorR > 255)
                OutColorR = 0;
            if (OutColorR < 0)
                OutColorR = 0;

            int OutColorG = (int)(Math.Pow((float)_InputColor.G / (float)255, _GammaValue) * 255 + 0.5);
            if (OutColorG > 255)
                OutColorG = 0;
            if (OutColorG < 0)
                OutColorG = 0;

            int OutColorB = (int)(Math.Pow((float)_InputColor.B / (float)255, _GammaValue) * 255 + 0.5);
            if (OutColorB > 255)
                OutColorB = 0;
            if (OutColorB < 0)
                OutColorB = 0;

            return Color.FromArgb(OutColorR, OutColorG, OutColorB);
        }

        public void SetSides()
        {
            MainFormClass.LeftSide.Enabled = MainFormClass.AmbiLightModeLeftCheckBox.Checked;
            MainFormClass.LeftSide.Width = (int)MainFormClass.AmbiLightModeLeftBlockWidthNumericUpDown.Value;
            MainFormClass.LeftSide.Height = (int)MainFormClass.AmbiLightModeLeftBlockHeightNumericUpDown.Value;
            MainFormClass.LeftSide.BlockSpacing = (int)MainFormClass.AmbiLightModeLeftBlockSpacingNumericUpDown.Value;
            MainFormClass.LeftSide.XOffSet = (int)MainFormClass.AmbiLightModeLeftBlockOffsetXNumericUpDown.Value;
            MainFormClass.LeftSide.YOffSet = (int)MainFormClass.AmbiLightModeLeftBlockOffsetYNumericUpDown.Value;
            MainFormClass.LeftSide.FromID = (int)MainFormClass.AmbiLightModeLeftFromIDNumericUpDown.Value;
            MainFormClass.LeftSide.ToID = (int)MainFormClass.AmbiLightModeLeftToIDNumericUpDown.Value;
            MainFormClass.LeftSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Value;

            MainFormClass.TopSide.Enabled = MainFormClass.AmbiLightModeTopCheckBox.Checked;
            MainFormClass.TopSide.Width = (int)MainFormClass.AmbiLightModeTopBlockWidthNumericUpDown.Value;
            MainFormClass.TopSide.Height = (int)MainFormClass.AmbiLightModeTopBlockHeightNumericUpDown.Value;
            MainFormClass.TopSide.BlockSpacing = (int)MainFormClass.AmbiLightModeTopBlockSpacingNumericUpDown.Value;
            MainFormClass.TopSide.XOffSet = (int)MainFormClass.AmbiLightModeTopBlockOffsetXNumericUpDown.Value;
            MainFormClass.TopSide.YOffSet = (int)MainFormClass.AmbiLightModeTopBlockOffsetYNumericUpDown.Value;
            MainFormClass.TopSide.FromID = (int)MainFormClass.AmbiLightModeTopFromIDNumericUpDown.Value;
            MainFormClass.TopSide.ToID = (int)MainFormClass.AmbiLightModeTopToIDNumericUpDown.Value;
            MainFormClass.TopSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeTopLEDsPrBlockNumericUpDown.Value;

            MainFormClass.RightSide.Enabled = MainFormClass.AmbiLightModeRightCheckBox.Checked;
            MainFormClass.RightSide.Width = (int)MainFormClass.AmbiLightModeRightBlockWidthNumericUpDown.Value;
            MainFormClass.RightSide.Height = (int)MainFormClass.AmbiLightModeRightBlockHeightNumericUpDown.Value;
            MainFormClass.RightSide.BlockSpacing = (int)MainFormClass.AmbiLightModeRightBlockSpacingNumericUpDown.Value;
            MainFormClass.RightSide.XOffSet = (int)MainFormClass.AmbiLightModeRightBlockOffsetXNumericUpDown.Value;
            MainFormClass.RightSide.YOffSet = (int)MainFormClass.AmbiLightModeRightBlockOffsetYNumericUpDown.Value;
            MainFormClass.RightSide.FromID = (int)MainFormClass.AmbiLightModeRightFromIDNumericUpDown.Value;
            MainFormClass.RightSide.ToID = (int)MainFormClass.AmbiLightModeRightToIDNumericUpDown.Value;
            MainFormClass.RightSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeRightLEDsPrBlockNumericUpDown.Value;

            MainFormClass.BottomSide.Enabled = MainFormClass.AmbiLightModeBottomCheckBox.Checked;
            MainFormClass.BottomSide.Width = (int)MainFormClass.AmbiLightModeBottomBlockWidthNumericUpDown.Value;
            MainFormClass.BottomSide.Height = (int)MainFormClass.AmbiLightModeBottomBlockHeightNumericUpDown.Value;
            MainFormClass.BottomSide.BlockSpacing = (int)MainFormClass.AmbiLightModeBottomBlockSpacingNumericUpDown.Value;
            MainFormClass.BottomSide.XOffSet = (int)MainFormClass.AmbiLightModeBottomBlockOffsetXNumericUpDown.Value;
            MainFormClass.BottomSide.YOffSet = (int)MainFormClass.AmbiLightModeBottomBlockOffsetYNumericUpDown.Value;
            MainFormClass.BottomSide.FromID = (int)MainFormClass.AmbiLightModeBottomFromIDNumericUpDown.Value;
            MainFormClass.BottomSide.ToID = (int)MainFormClass.AmbiLightModeBottomToIDNumericUpDown.Value;
            MainFormClass.BottomSide.LEDsPrBlock = (int)MainFormClass.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Value;
        }
    }
}
