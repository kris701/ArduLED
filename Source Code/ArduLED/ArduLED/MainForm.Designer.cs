namespace ArduLEDNameSpace
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AudioSourceComboBox = new System.Windows.Forms.ComboBox();
            this.SampleTimeLabel = new System.Windows.Forms.Label();
            this.SampleTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.SampleTimeTopLabel = new System.Windows.Forms.Label();
            this.AudioSampleRateComboBox = new System.Windows.Forms.ComboBox();
            this.AudioSampleRateLabel = new System.Windows.Forms.Label();
            this.SmoothnessLabel = new System.Windows.Forms.Label();
            this.SensitivityLabel = new System.Windows.Forms.Label();
            this.SmoothnessTrackBar = new System.Windows.Forms.TrackBar();
            this.SmoothnessTopLabel = new System.Windows.Forms.Label();
            this.SensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.SensitivityTopLabel = new System.Windows.Forms.Label();
            this.VisualizerTopLabel = new System.Windows.Forms.Label();
            this.VisualizationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.VisualizationTypeLabel = new System.Windows.Forms.Label();
            this.VisualSamplesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VisualSamplesLabel = new System.Windows.Forms.Label();
            this.AudioSourceLabel = new System.Windows.Forms.Label();
            this.SerialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BeatZoneChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BeatZoneFromTrackBar = new System.Windows.Forms.TrackBar();
            this.BeatZoneToTrackBar = new System.Windows.Forms.TrackBar();
            this.BeatZoneFromLabel = new System.Windows.Forms.Label();
            this.BeatZoneToLabel = new System.Windows.Forms.Label();
            this.BeatZoneTopLabel = new System.Windows.Forms.Label();
            this.VisualizerPanel = new System.Windows.Forms.Panel();
            this.VisualizerRPSLabel = new System.Windows.Forms.Label();
            this.VisualizerLoadSettingsButton = new System.Windows.Forms.Button();
            this.VisualizerSaveSettingsButton = new System.Windows.Forms.Button();
            this.VisualizerToSeriesIDLabel = new System.Windows.Forms.Label();
            this.VisualizerToSeriesIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VisualizerFromSeriesIDLabel = new System.Windows.Forms.Label();
            this.VisualizerFromSeriesIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VisualizerCurrentValueLabel = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.AutoTriggerMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoTriggerMinLabel = new System.Windows.Forms.Label();
            this.AutoTriggerMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoTriggerMaxLabel = new System.Windows.Forms.Label();
            this.AutoTriggerDecreseAtLabel = new System.Windows.Forms.Label();
            this.AutoTriggerIncreseAtNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoTriggerIncreseAtLabel = new System.Windows.Forms.Label();
            this.AutoTriggerDecreseAtNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.FullSpectrumPanel = new System.Windows.Forms.Panel();
            this.FullSpectrumLabel = new System.Windows.Forms.Label();
            this.FullSpectrumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FullSpectrumTopLabel = new System.Windows.Forms.Label();
            this.WavePanel = new System.Windows.Forms.Panel();
            this.BeatWaveProgressBar = new System.Windows.Forms.ProgressBar();
            this.WaveAutoScaleValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.WaveTopLabel = new System.Windows.Forms.Label();
            this.UpdateWaveButton = new System.Windows.Forms.Button();
            this.WaveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.WaveBlueLabel = new System.Windows.Forms.Label();
            this.WaveRedTextBox = new System.Windows.Forms.TextBox();
            this.WaveBlueTextBox = new System.Windows.Forms.TextBox();
            this.WaveRedLabel = new System.Windows.Forms.Label();
            this.WaveGreenLabel = new System.Windows.Forms.Label();
            this.WaveGreenTextBox = new System.Windows.Forms.TextBox();
            this.SpectrumPanel = new System.Windows.Forms.Panel();
            this.SpectrumAutoScaleValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.SpectrumTopLabel = new System.Windows.Forms.Label();
            this.UpdateSpectrumButton = new System.Windows.Forms.Button();
            this.SpectrumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpectrumBlueLabel = new System.Windows.Forms.Label();
            this.SpectrumRedTextBox = new System.Windows.Forms.TextBox();
            this.SpectrumBlueTextBox = new System.Windows.Forms.TextBox();
            this.SpectrumRedLabel = new System.Windows.Forms.Label();
            this.SpectrumGreenLabel = new System.Windows.Forms.Label();
            this.SpectrumGreenTextBox = new System.Windows.Forms.TextBox();
            this.BeatZoneTriggerHeightLabel = new System.Windows.Forms.Label();
            this.BeatZoneTriggerHeight = new System.Windows.Forms.TrackBar();
            this.MenuButton = new System.Windows.Forms.Button();
            this.FadeColorsBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.FadeColorsGreenTopLabel = new System.Windows.Forms.Label();
            this.FadeColorsBlueTopLabel = new System.Windows.Forms.Label();
            this.FadeColorsRedTopLabel = new System.Windows.Forms.Label();
            this.FadeColorsRedLabel = new System.Windows.Forms.Label();
            this.FadeColorsRedTrackBar = new System.Windows.Forms.TrackBar();
            this.FadeColorsGreenLabel = new System.Windows.Forms.Label();
            this.FadeColorsGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.FadeColorsBlueLabel = new System.Windows.Forms.Label();
            this.MenuConnectButton = new System.Windows.Forms.Button();
            this.ComPortsComboBox = new System.Windows.Forms.ComboBox();
            this.MenuSelectComDeviceLabel = new System.Windows.Forms.Label();
            this.FadeColorsFadeSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MenuAutoHideCheckBox = new System.Windows.Forms.CheckBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.MenuExitButton = new System.Windows.Forms.Button();
            this.MenuModeLabel = new System.Windows.Forms.Label();
            this.ModeSelectrionComboBox = new System.Windows.Forms.ComboBox();
            this.FadeLEDPanel = new System.Windows.Forms.Panel();
            this.FadeLEDPanelToIDLabel = new System.Windows.Forms.Label();
            this.FadeLEDPanelToIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FadeColorsBrightnessLabel = new System.Windows.Forms.Label();
            this.FadeLEDPanelFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FadeLEDPanelFromIDLabel = new System.Windows.Forms.Label();
            this.FadeColorsFadeFactorLabel = new System.Windows.Forms.Label();
            this.FadeColorsFadeFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FadeColorsFadeSpeedLabel = new System.Windows.Forms.Label();
            this.IndividualLEDPanel = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.IndividualLEDTopLabel = new System.Windows.Forms.Label();
            this.ColorEntireLEDStripCheckBox = new System.Windows.Forms.CheckBox();
            this.IndividalLEDRedTrackBar = new System.Windows.Forms.TrackBar();
            this.IndividalLEDBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.IndividualLEDGreenNameLabel = new System.Windows.Forms.Label();
            this.IndividualLEDBlueNameLabel = new System.Windows.Forms.Label();
            this.IndividualLEDRedNameLabel = new System.Windows.Forms.Label();
            this.IndividalLEDRedLabel = new System.Windows.Forms.Label();
            this.IndividalLEDGreenLabel = new System.Windows.Forms.Label();
            this.IndividalLEDGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.IndividalLEDBlueLabel = new System.Windows.Forms.Label();
            this.IndividualLEDWorkingPanel = new System.Windows.Forms.Panel();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.LoadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InstructionsPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddIndividualLEDPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddIndividualLEDOnPinLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDOnPinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddIndividualLEDAtIDLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDAtIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddIndividualLEDRedTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddIndividualLEDBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddIndividualLEDGreenLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDBlueLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDRedLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDRedValueLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDGreenValueLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddIndividualLEDBlueValueLabel = new System.Windows.Forms.Label();
            this.InstructionsAddIndividualLEDAddButton = new System.Windows.Forms.Button();
            this.InstructionsAddIndividualLEDPanelTopLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddFadeColorsToSeriesIDLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsFadeFactorLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddFadeColorsFromSeriesIDLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsFadeSpeedLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddFadeColorsAddButton = new System.Windows.Forms.Button();
            this.InstructionsAddFadeColorsRedTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddFadeColorsBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddFadeColorsGreenNameLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsBlueNameLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsRedNameLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsRedLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsGreenLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.InstructionsAddFadeColorsBlueLabel = new System.Windows.Forms.Label();
            this.InstructionsAddFadeColorsTopLabel = new System.Windows.Forms.Label();
            this.InstructionStopLoopButton = new System.Windows.Forms.Button();
            this.InstructionsModeLoadButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.InstructionsAddAmbilightButton = new System.Windows.Forms.Button();
            this.InstructionsAddIndividualLEDButton = new System.Windows.Forms.Button();
            this.InstructionsAddVisualizerButton = new System.Windows.Forms.Button();
            this.InstructionsAddFadeColorsButton = new System.Windows.Forms.Button();
            this.InstructionsAddDelayButton = new System.Windows.Forms.Button();
            this.InstructionsModeAddItemsLabel = new System.Windows.Forms.Label();
            this.InstructionsLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.InstructionsModeSaveButton = new System.Windows.Forms.Button();
            this.InstructionStartLoopButton = new System.Windows.Forms.Button();
            this.panel21 = new System.Windows.Forms.Panel();
            this.InstructionsModeTopLabel = new System.Windows.Forms.Label();
            this.InstructionsWorkingPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddAmbilightPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddAmbilightShowHideBlocksCheckBox = new System.Windows.Forms.CheckBox();
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox = new System.Windows.Forms.CheckBox();
            this.InstructionsAddAmbilightStopAmbilightCheckBox = new System.Windows.Forms.CheckBox();
            this.InstructionsAddAmbilightUseAmbilightSettings = new System.Windows.Forms.Button();
            this.InstructionsAddAmbilightAddButton = new System.Windows.Forms.Button();
            this.InstructionsAddAmbilightTopLabel = new System.Windows.Forms.Label();
            this.InstructionsAddVisualizerPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddVisualizerStopVisualizerCheckBox = new System.Windows.Forms.CheckBox();
            this.InstructionsAddVisualizerLoadSetup = new System.Windows.Forms.Button();
            this.InstructionsAddVisualizerPanelAdd = new System.Windows.Forms.Button();
            this.InstructionsAddVisualizerTopLabel = new System.Windows.Forms.Label();
            this.InstructionsAddDelayPanel = new System.Windows.Forms.Panel();
            this.InstructionsAddDelayAddButton = new System.Windows.Forms.Button();
            this.InstructionsAddDelayNoteLabel = new System.Windows.Forms.Label();
            this.InstructionsAddDelayLabel = new System.Windows.Forms.Label();
            this.InstructionsAddDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InstructionsAddDelayTopLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ConfigureSetupRGBColorOrderThirdTextbox = new System.Windows.Forms.TextBox();
            this.ConfigureSetupRGBColorOrderSeccondTextbox = new System.Windows.Forms.TextBox();
            this.ConfigureSetupRGBColorOrderFirstTextbox = new System.Windows.Forms.TextBox();
            this.ConfigureSetupRGBColorOrderThirdLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupRGBColorOrderSeccondLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupRGBColorOrderFirstLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupRGBColorOrderLabel = new System.Windows.Forms.Label();
            this.EnableDataCompressionMode = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfigureSetupClickToSetupSeriesFromIDLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupClickToSetupSeriesCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel20 = new System.Windows.Forms.Panel();
            this.ConfigureSetupTopLabel = new System.Windows.Forms.Label();
            this.SendSetupProgressBar = new System.Windows.Forms.ProgressBar();
            this.SendSetupButton = new System.Windows.Forms.Button();
            this.LoadSetupButton = new System.Windows.Forms.Button();
            this.SaveSetupButton = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.PixelBitstreamComboBoxLabel = new System.Windows.Forms.Label();
            this.PixelBitstreamComboBox = new System.Windows.Forms.ComboBox();
            this.PixelTypeComboBoxLabel = new System.Windows.Forms.Label();
            this.PixelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ConfigureSetupAddStripPinIDLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupAddStripPinID = new System.Windows.Forms.NumericUpDown();
            this.ConfigureSetupAddStripInvertY = new System.Windows.Forms.CheckBox();
            this.ConfigureSetupAddStripInvertX = new System.Windows.Forms.CheckBox();
            this.ConfigureSetupAddStripFromLEDIDLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupAddStripFromLEDID = new System.Windows.Forms.NumericUpDown();
            this.ConfigureSetupAddStripXDir = new System.Windows.Forms.NumericUpDown();
            this.ConfigureSetupAddStripYDirLabel = new System.Windows.Forms.Label();
            this.ConfigureSetupAddStripYDir = new System.Windows.Forms.NumericUpDown();
            this.ConfigureSetupAddStripXDirLabel = new System.Windows.Forms.Label();
            this.AddLEDStripButton = new System.Windows.Forms.Button();
            this.ConfigureSetupWorkingPanel = new System.Windows.Forms.Panel();
            this.ConfigureSetupAutoSendCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigureSetupHiddenProgressBar = new System.Windows.Forms.ProgressBar();
            this.HideTimer = new System.Windows.Forms.Timer(this.components);
            this.AmbiLightModePanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeWorkingPanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeGammaFactorLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeGammaFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeAutosetOffsets = new System.Windows.Forms.Button();
            this.AmbilightModeFPSCounterLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeScreenIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftPanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeLeftPanelLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftLEDsPrBlockLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftBlockWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftBlockWidthLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftBlockHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftBlockHeightLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftBlockSpacingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftToIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftBlockSpacingLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftToIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftFromIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftBlockOffsetXLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeLeftFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftBlockOffsetYLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeScreenIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeFadeFactorLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopPanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeTopPanelLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopLEDsPrBlockLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopBlockWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockWidthLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopBlockHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockHeightLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopBlockSpacingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockSpacingLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopToIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopToIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockOffsetXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopFromIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopBlockOffsetXLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeTopFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockOffsetYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopBlockOffsetYLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBlockSampleSplitLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeFadeFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBlockSampleSplitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.AmbiLightModeRefreshRateLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRefreshRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeTopCheckBox = new System.Windows.Forms.CheckBox();
            this.AmbiLightModeRightCheckBox = new System.Windows.Forms.CheckBox();
            this.AmbiLightModeLoadSetup = new System.Windows.Forms.Button();
            this.AmbiLightModeBottomCheckBox = new System.Windows.Forms.CheckBox();
            this.AmbiLightModeSaveSetup = new System.Windows.Forms.Button();
            this.AmbiLightModeRightPanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeRightPanelLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightLEDsPrBlockLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightBlockWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightBlockWidthLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightBlockHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightBlockHeightLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightBlockSpacingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightToIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightBlockSpacingLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightToIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightBlockOffsetXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightFromIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightBlockOffsetXLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeRightFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightBlockOffsetYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeRightBlockOffsetYLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomPanel = new System.Windows.Forms.Panel();
            this.AmbiLightModeBottomPanelLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomLEDsPrBlockLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomBlockWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockWidthLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomBlockHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockHeightLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomBlockSpacingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockSpacingLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomToIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomToIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomFromIDLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomBlockOffsetXLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeBottomFromIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmbiLightModeBottomBlockOffsetYLabel = new System.Windows.Forms.Label();
            this.AmbiLightModeStopAmbilightButton = new System.Windows.Forms.Button();
            this.AmbiLightModeStartAmbilightButton = new System.Windows.Forms.Button();
            this.AmbiLightModeShowHideBlocksButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AmbiLightModeTopLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SampleTimeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualSamplesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneFromTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneToTrackBar)).BeginInit();
            this.VisualizerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizerToSeriesIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizerFromSeriesIDNumericUpDown)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerMaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerIncreseAtNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerDecreseAtNumericUpDown)).BeginInit();
            this.panel5.SuspendLayout();
            this.FullSpectrumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullSpectrumNumericUpDown)).BeginInit();
            this.WavePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveChart)).BeginInit();
            this.SpectrumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneTriggerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsRedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsGreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsFadeSpeedNumericUpDown)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.FadeLEDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FadeLEDPanelToIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeLEDPanelFromIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsFadeFactorNumericUpDown)).BeginInit();
            this.IndividualLEDPanel.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDRedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDGreenTrackBar)).BeginInit();
            this.InstructionsPanel.SuspendLayout();
            this.InstructionsAddIndividualLEDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDOnPinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDAtIdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDRedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDGreenTrackBar)).BeginInit();
            this.InstructionsAddFadeColorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsToSeriesIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFadeFactorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFadeSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsRedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsGreenTrackBar)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel21.SuspendLayout();
            this.InstructionsAddAmbilightPanel.SuspendLayout();
            this.InstructionsAddVisualizerPanel.SuspendLayout();
            this.InstructionsAddDelayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddDelayNumericUpDown)).BeginInit();
            this.ConfigureSetupPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown)).BeginInit();
            this.panel20.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripPinID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripFromLEDID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripXDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripYDir)).BeginInit();
            this.AmbiLightModePanel.SuspendLayout();
            this.AmbiLightModeWorkingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeGammaFactorNumericUpDown)).BeginInit();
            this.AmbiLightModeLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftLEDsPrBlockNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockSpacingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftToIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockOffsetXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftFromIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockOffsetYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeScreenIDNumericUpDown)).BeginInit();
            this.AmbiLightModeTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopLEDsPrBlockNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockSpacingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopToIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockOffsetXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopFromIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockOffsetYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeFadeFactorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBlockSampleSplitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRefreshRateNumericUpDown)).BeginInit();
            this.AmbiLightModeRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightLEDsPrBlockNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockSpacingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightToIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockOffsetXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightFromIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockOffsetYNumericUpDown)).BeginInit();
            this.AmbiLightModeBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomLEDsPrBlockNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockSpacingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomToIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockOffsetXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomFromIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockOffsetYNumericUpDown)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AudioSourceComboBox
            // 
            this.AudioSourceComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.AudioSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioSourceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioSourceComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioSourceComboBox.ForeColor = System.Drawing.Color.White;
            this.AudioSourceComboBox.FormattingEnabled = true;
            this.AudioSourceComboBox.Location = new System.Drawing.Point(12, 97);
            this.AudioSourceComboBox.Name = "AudioSourceComboBox";
            this.AudioSourceComboBox.Size = new System.Drawing.Size(559, 19);
            this.AudioSourceComboBox.TabIndex = 6;
            this.AudioSourceComboBox.Tag = "Setting";
            this.AudioSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioSourceComboBox_SelectedIndexChanged);
            // 
            // SampleTimeLabel
            // 
            this.SampleTimeLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SampleTimeLabel.Location = new System.Drawing.Point(538, 421);
            this.SampleTimeLabel.Name = "SampleTimeLabel";
            this.SampleTimeLabel.Size = new System.Drawing.Size(41, 16);
            this.SampleTimeLabel.TabIndex = 24;
            this.SampleTimeLabel.Text = "0";
            this.SampleTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SampleTimeTrackBar
            // 
            this.SampleTimeTrackBar.Location = new System.Drawing.Point(17, 407);
            this.SampleTimeTrackBar.Maximum = 250;
            this.SampleTimeTrackBar.Minimum = 1;
            this.SampleTimeTrackBar.Name = "SampleTimeTrackBar";
            this.SampleTimeTrackBar.Size = new System.Drawing.Size(522, 45);
            this.SampleTimeTrackBar.TabIndex = 12;
            this.SampleTimeTrackBar.Tag = "Setting";
            this.SampleTimeTrackBar.TickFrequency = 10;
            this.SampleTimeTrackBar.Value = 25;
            this.SampleTimeTrackBar.Scroll += new System.EventHandler(this.SampleTimeTrackBar_ValueChanged);
            this.SampleTimeTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarUpdateBASSKey);
            this.SampleTimeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarUpdateBASSMouse);
            // 
            // SampleTimeTopLabel
            // 
            this.SampleTimeTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SampleTimeTopLabel.Location = new System.Drawing.Point(13, 381);
            this.SampleTimeTopLabel.Name = "SampleTimeTopLabel";
            this.SampleTimeTopLabel.Size = new System.Drawing.Size(559, 16);
            this.SampleTimeTopLabel.TabIndex = 22;
            this.SampleTimeTopLabel.Text = "Sample Time (def: 25)";
            this.SampleTimeTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AudioSampleRateComboBox
            // 
            this.AudioSampleRateComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.AudioSampleRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioSampleRateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioSampleRateComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioSampleRateComboBox.ForeColor = System.Drawing.Color.White;
            this.AudioSampleRateComboBox.FormattingEnabled = true;
            this.AudioSampleRateComboBox.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192",
            "16384"});
            this.AudioSampleRateComboBox.Location = new System.Drawing.Point(12, 237);
            this.AudioSampleRateComboBox.Name = "AudioSampleRateComboBox";
            this.AudioSampleRateComboBox.Size = new System.Drawing.Size(559, 19);
            this.AudioSampleRateComboBox.TabIndex = 9;
            this.AudioSampleRateComboBox.Tag = "Setting";
            this.AudioSampleRateComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioSampleRateComboBox_SelectedIndexChanged);
            // 
            // AudioSampleRateLabel
            // 
            this.AudioSampleRateLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioSampleRateLabel.Location = new System.Drawing.Point(13, 214);
            this.AudioSampleRateLabel.Name = "AudioSampleRateLabel";
            this.AudioSampleRateLabel.Size = new System.Drawing.Size(559, 16);
            this.AudioSampleRateLabel.TabIndex = 19;
            this.AudioSampleRateLabel.Text = "Audio Samples (def: 16384)";
            this.AudioSampleRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SmoothnessLabel
            // 
            this.SmoothnessLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmoothnessLabel.Location = new System.Drawing.Point(538, 361);
            this.SmoothnessLabel.Name = "SmoothnessLabel";
            this.SmoothnessLabel.Size = new System.Drawing.Size(41, 16);
            this.SmoothnessLabel.TabIndex = 17;
            this.SmoothnessLabel.Text = "0";
            this.SmoothnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SensitivityLabel
            // 
            this.SensitivityLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensitivityLabel.Location = new System.Drawing.Point(538, 298);
            this.SensitivityLabel.Name = "SensitivityLabel";
            this.SensitivityLabel.Size = new System.Drawing.Size(41, 16);
            this.SensitivityLabel.TabIndex = 16;
            this.SensitivityLabel.Text = "0";
            this.SensitivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SmoothnessTrackBar
            // 
            this.SmoothnessTrackBar.Location = new System.Drawing.Point(17, 347);
            this.SmoothnessTrackBar.Maximum = 20;
            this.SmoothnessTrackBar.Minimum = 1;
            this.SmoothnessTrackBar.Name = "SmoothnessTrackBar";
            this.SmoothnessTrackBar.Size = new System.Drawing.Size(522, 45);
            this.SmoothnessTrackBar.TabIndex = 11;
            this.SmoothnessTrackBar.Tag = "Setting";
            this.SmoothnessTrackBar.Value = 1;
            this.SmoothnessTrackBar.Scroll += new System.EventHandler(this.SmoothnessTrackBar_ValueChanged);
            this.SmoothnessTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarUpdateBASSKey);
            this.SmoothnessTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarUpdateBASSMouse);
            // 
            // SmoothnessTopLabel
            // 
            this.SmoothnessTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmoothnessTopLabel.Location = new System.Drawing.Point(13, 324);
            this.SmoothnessTopLabel.Name = "SmoothnessTopLabel";
            this.SmoothnessTopLabel.Size = new System.Drawing.Size(559, 16);
            this.SmoothnessTopLabel.TabIndex = 14;
            this.SmoothnessTopLabel.Text = "Smoothness (def: 1)";
            this.SmoothnessTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SensitivityTrackBar
            // 
            this.SensitivityTrackBar.Location = new System.Drawing.Point(17, 284);
            this.SensitivityTrackBar.Minimum = 1;
            this.SensitivityTrackBar.Name = "SensitivityTrackBar";
            this.SensitivityTrackBar.Size = new System.Drawing.Size(522, 45);
            this.SensitivityTrackBar.TabIndex = 10;
            this.SensitivityTrackBar.Tag = "Setting";
            this.SensitivityTrackBar.Value = 3;
            this.SensitivityTrackBar.Scroll += new System.EventHandler(this.SensitivityTrackBar_ValueChanged);
            this.SensitivityTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarUpdateBASSKey);
            this.SensitivityTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarUpdateBASSMouse);
            // 
            // SensitivityTopLabel
            // 
            this.SensitivityTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensitivityTopLabel.Location = new System.Drawing.Point(13, 261);
            this.SensitivityTopLabel.Name = "SensitivityTopLabel";
            this.SensitivityTopLabel.Size = new System.Drawing.Size(559, 16);
            this.SensitivityTopLabel.TabIndex = 11;
            this.SensitivityTopLabel.Text = "Sensitivity (def: 3)";
            this.SensitivityTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualizerTopLabel
            // 
            this.VisualizerTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerTopLabel.ForeColor = System.Drawing.Color.White;
            this.VisualizerTopLabel.Location = new System.Drawing.Point(1, 0);
            this.VisualizerTopLabel.Name = "VisualizerTopLabel";
            this.VisualizerTopLabel.Size = new System.Drawing.Size(947, 63);
            this.VisualizerTopLabel.TabIndex = 10;
            this.VisualizerTopLabel.Text = "Visualizer Settings";
            this.VisualizerTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualizationTypeComboBox
            // 
            this.VisualizationTypeComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.VisualizationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VisualizationTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisualizationTypeComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizationTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.VisualizationTypeComboBox.FormattingEnabled = true;
            this.VisualizationTypeComboBox.Location = new System.Drawing.Point(12, 144);
            this.VisualizationTypeComboBox.Name = "VisualizationTypeComboBox";
            this.VisualizationTypeComboBox.Size = new System.Drawing.Size(559, 19);
            this.VisualizationTypeComboBox.TabIndex = 7;
            this.VisualizationTypeComboBox.Tag = "Setting";
            this.VisualizationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.VisualizationTypeComboBox_SelectedIndexChanged);
            // 
            // VisualizationTypeLabel
            // 
            this.VisualizationTypeLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizationTypeLabel.Location = new System.Drawing.Point(13, 121);
            this.VisualizationTypeLabel.Name = "VisualizationTypeLabel";
            this.VisualizationTypeLabel.Size = new System.Drawing.Size(559, 16);
            this.VisualizationTypeLabel.TabIndex = 7;
            this.VisualizationTypeLabel.Text = "Visualization type (def: Beat)";
            this.VisualizationTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualSamplesNumericUpDown
            // 
            this.VisualSamplesNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.VisualSamplesNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualSamplesNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.VisualSamplesNumericUpDown.Location = new System.Drawing.Point(12, 191);
            this.VisualSamplesNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.VisualSamplesNumericUpDown.Name = "VisualSamplesNumericUpDown";
            this.VisualSamplesNumericUpDown.Size = new System.Drawing.Size(559, 18);
            this.VisualSamplesNumericUpDown.TabIndex = 8;
            this.VisualSamplesNumericUpDown.Tag = "Setting";
            this.VisualSamplesNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.VisualSamplesNumericUpDown.ValueChanged += new System.EventHandler(this.VisualSamplesNumericUpDown_ValueChanged);
            // 
            // VisualSamplesLabel
            // 
            this.VisualSamplesLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualSamplesLabel.Location = new System.Drawing.Point(12, 168);
            this.VisualSamplesLabel.Name = "VisualSamplesLabel";
            this.VisualSamplesLabel.Size = new System.Drawing.Size(559, 16);
            this.VisualSamplesLabel.TabIndex = 5;
            this.VisualSamplesLabel.Text = "Visual Samples (def: 128)";
            this.VisualSamplesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AudioSourceLabel
            // 
            this.AudioSourceLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioSourceLabel.Location = new System.Drawing.Point(12, 69);
            this.AudioSourceLabel.Name = "AudioSourceLabel";
            this.AudioSourceLabel.Size = new System.Drawing.Size(559, 16);
            this.AudioSourceLabel.TabIndex = 4;
            this.AudioSourceLabel.Text = "Select audio device";
            this.AudioSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialPort1
            // 
            this.SerialPort1.BaudRate = 1000000;
            this.SerialPort1.DtrEnable = true;
            this.SerialPort1.RtsEnable = true;
            this.SerialPort1.WriteTimeout = 500;
            this.SerialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // BeatZoneChart
            // 
            this.BeatZoneChart.BackColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.BeatZoneChart.ChartAreas.Add(chartArea1);
            this.BeatZoneChart.Enabled = false;
            this.BeatZoneChart.Location = new System.Drawing.Point(96, 454);
            this.BeatZoneChart.Name = "BeatZoneChart";
            series1.BorderColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.White;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.BeatZoneChart.Series.Add(series1);
            this.BeatZoneChart.Size = new System.Drawing.Size(475, 154);
            this.BeatZoneChart.TabIndex = 37;
            this.BeatZoneChart.Text = "chart1";
            // 
            // BeatZoneFromTrackBar
            // 
            this.BeatZoneFromTrackBar.Location = new System.Drawing.Point(148, 614);
            this.BeatZoneFromTrackBar.Maximum = 128;
            this.BeatZoneFromTrackBar.Name = "BeatZoneFromTrackBar";
            this.BeatZoneFromTrackBar.Size = new System.Drawing.Size(406, 45);
            this.BeatZoneFromTrackBar.TabIndex = 17;
            this.BeatZoneFromTrackBar.Tag = "Setting";
            this.BeatZoneFromTrackBar.TickFrequency = 10;
            this.BeatZoneFromTrackBar.Scroll += new System.EventHandler(this.BeatZoneFromTrackBar_Scroll);
            this.BeatZoneFromTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarUpdateBASSKey);
            this.BeatZoneFromTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarUpdateBASSMouse);
            // 
            // BeatZoneToTrackBar
            // 
            this.BeatZoneToTrackBar.Location = new System.Drawing.Point(148, 656);
            this.BeatZoneToTrackBar.Maximum = 128;
            this.BeatZoneToTrackBar.Name = "BeatZoneToTrackBar";
            this.BeatZoneToTrackBar.Size = new System.Drawing.Size(406, 45);
            this.BeatZoneToTrackBar.TabIndex = 18;
            this.BeatZoneToTrackBar.Tag = "Setting";
            this.BeatZoneToTrackBar.TickFrequency = 10;
            this.BeatZoneToTrackBar.Value = 128;
            this.BeatZoneToTrackBar.Scroll += new System.EventHandler(this.BeatZoneToTrackBar_Scroll);
            this.BeatZoneToTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackBarUpdateBASSKey);
            this.BeatZoneToTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarUpdateBASSMouse);
            // 
            // BeatZoneFromLabel
            // 
            this.BeatZoneFromLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatZoneFromLabel.Location = new System.Drawing.Point(33, 628);
            this.BeatZoneFromLabel.Name = "BeatZoneFromLabel";
            this.BeatZoneFromLabel.Size = new System.Drawing.Size(108, 15);
            this.BeatZoneFromLabel.TabIndex = 40;
            this.BeatZoneFromLabel.Text = "From: 0";
            this.BeatZoneFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeatZoneToLabel
            // 
            this.BeatZoneToLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatZoneToLabel.Location = new System.Drawing.Point(33, 671);
            this.BeatZoneToLabel.Name = "BeatZoneToLabel";
            this.BeatZoneToLabel.Size = new System.Drawing.Size(108, 15);
            this.BeatZoneToLabel.TabIndex = 41;
            this.BeatZoneToLabel.Text = "To: 128";
            this.BeatZoneToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeatZoneTopLabel
            // 
            this.BeatZoneTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatZoneTopLabel.Location = new System.Drawing.Point(256, 441);
            this.BeatZoneTopLabel.Name = "BeatZoneTopLabel";
            this.BeatZoneTopLabel.Size = new System.Drawing.Size(154, 16);
            this.BeatZoneTopLabel.TabIndex = 43;
            this.BeatZoneTopLabel.Text = "Beat zone";
            this.BeatZoneTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualizerPanel
            // 
            this.VisualizerPanel.BackColor = System.Drawing.Color.DimGray;
            this.VisualizerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisualizerPanel.Controls.Add(this.VisualizerRPSLabel);
            this.VisualizerPanel.Controls.Add(this.VisualizerLoadSettingsButton);
            this.VisualizerPanel.Controls.Add(this.VisualizerSaveSettingsButton);
            this.VisualizerPanel.Controls.Add(this.VisualizerToSeriesIDLabel);
            this.VisualizerPanel.Controls.Add(this.VisualizerToSeriesIDNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.VisualizerFromSeriesIDLabel);
            this.VisualizerPanel.Controls.Add(this.VisualizerFromSeriesIDNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.VisualizerCurrentValueLabel);
            this.VisualizerPanel.Controls.Add(this.panel19);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerMinNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerMinLabel);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerMaxNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerMaxLabel);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerDecreseAtLabel);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerIncreseAtNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerIncreseAtLabel);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerDecreseAtNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.AutoTriggerCheckBox);
            this.VisualizerPanel.Controls.Add(this.panel5);
            this.VisualizerPanel.Controls.Add(this.BeatZoneTriggerHeightLabel);
            this.VisualizerPanel.Controls.Add(this.BeatZoneTriggerHeight);
            this.VisualizerPanel.Controls.Add(this.SmoothnessTopLabel);
            this.VisualizerPanel.Controls.Add(this.BeatZoneTopLabel);
            this.VisualizerPanel.Controls.Add(this.SensitivityTrackBar);
            this.VisualizerPanel.Controls.Add(this.BeatZoneToLabel);
            this.VisualizerPanel.Controls.Add(this.SensitivityTopLabel);
            this.VisualizerPanel.Controls.Add(this.BeatZoneFromLabel);
            this.VisualizerPanel.Controls.Add(this.SensitivityLabel);
            this.VisualizerPanel.Controls.Add(this.BeatZoneToTrackBar);
            this.VisualizerPanel.Controls.Add(this.SmoothnessLabel);
            this.VisualizerPanel.Controls.Add(this.BeatZoneFromTrackBar);
            this.VisualizerPanel.Controls.Add(this.VisualizationTypeComboBox);
            this.VisualizerPanel.Controls.Add(this.BeatZoneChart);
            this.VisualizerPanel.Controls.Add(this.VisualizationTypeLabel);
            this.VisualizerPanel.Controls.Add(this.AudioSampleRateLabel);
            this.VisualizerPanel.Controls.Add(this.VisualSamplesNumericUpDown);
            this.VisualizerPanel.Controls.Add(this.AudioSampleRateComboBox);
            this.VisualizerPanel.Controls.Add(this.VisualSamplesLabel);
            this.VisualizerPanel.Controls.Add(this.AudioSourceComboBox);
            this.VisualizerPanel.Controls.Add(this.SampleTimeTopLabel);
            this.VisualizerPanel.Controls.Add(this.AudioSourceLabel);
            this.VisualizerPanel.Controls.Add(this.SampleTimeTrackBar);
            this.VisualizerPanel.Controls.Add(this.SampleTimeLabel);
            this.VisualizerPanel.Controls.Add(this.SmoothnessTrackBar);
            this.VisualizerPanel.ForeColor = System.Drawing.Color.White;
            this.VisualizerPanel.Location = new System.Drawing.Point(4, 21);
            this.VisualizerPanel.Name = "VisualizerPanel";
            this.VisualizerPanel.Size = new System.Drawing.Size(947, 748);
            this.VisualizerPanel.TabIndex = 44;
            this.VisualizerPanel.Visible = false;
            // 
            // VisualizerRPSLabel
            // 
            this.VisualizerRPSLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerRPSLabel.Location = new System.Drawing.Point(510, 726);
            this.VisualizerRPSLabel.Name = "VisualizerRPSLabel";
            this.VisualizerRPSLabel.Size = new System.Drawing.Size(64, 11);
            this.VisualizerRPSLabel.TabIndex = 65;
            this.VisualizerRPSLabel.Text = "RPS: 0";
            this.VisualizerRPSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualizerLoadSettingsButton
            // 
            this.VisualizerLoadSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.VisualizerLoadSettingsButton.FlatAppearance.BorderSize = 0;
            this.VisualizerLoadSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisualizerLoadSettingsButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerLoadSettingsButton.Location = new System.Drawing.Point(770, 720);
            this.VisualizerLoadSettingsButton.Name = "VisualizerLoadSettingsButton";
            this.VisualizerLoadSettingsButton.Size = new System.Drawing.Size(171, 23);
            this.VisualizerLoadSettingsButton.TabIndex = 64;
            this.VisualizerLoadSettingsButton.Text = "Load settings";
            this.VisualizerLoadSettingsButton.UseVisualStyleBackColor = false;
            this.VisualizerLoadSettingsButton.Click += new System.EventHandler(this.VisualizerLoadSettingsButton_Click);
            // 
            // VisualizerSaveSettingsButton
            // 
            this.VisualizerSaveSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.VisualizerSaveSettingsButton.FlatAppearance.BorderSize = 0;
            this.VisualizerSaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisualizerSaveSettingsButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerSaveSettingsButton.Location = new System.Drawing.Point(580, 720);
            this.VisualizerSaveSettingsButton.Name = "VisualizerSaveSettingsButton";
            this.VisualizerSaveSettingsButton.Size = new System.Drawing.Size(171, 23);
            this.VisualizerSaveSettingsButton.TabIndex = 63;
            this.VisualizerSaveSettingsButton.Text = "Save settings";
            this.VisualizerSaveSettingsButton.UseVisualStyleBackColor = false;
            this.VisualizerSaveSettingsButton.Click += new System.EventHandler(this.VisualizerSaveSettingsButton_Click);
            // 
            // VisualizerToSeriesIDLabel
            // 
            this.VisualizerToSeriesIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerToSeriesIDLabel.Location = new System.Drawing.Point(251, 726);
            this.VisualizerToSeriesIDLabel.Name = "VisualizerToSeriesIDLabel";
            this.VisualizerToSeriesIDLabel.Size = new System.Drawing.Size(202, 11);
            this.VisualizerToSeriesIDLabel.TabIndex = 62;
            this.VisualizerToSeriesIDLabel.Text = "To Series ID";
            this.VisualizerToSeriesIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualizerToSeriesIDNumericUpDown
            // 
            this.VisualizerToSeriesIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.VisualizerToSeriesIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VisualizerToSeriesIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerToSeriesIDNumericUpDown.Location = new System.Drawing.Point(459, 726);
            this.VisualizerToSeriesIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.VisualizerToSeriesIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.VisualizerToSeriesIDNumericUpDown.Name = "VisualizerToSeriesIDNumericUpDown";
            this.VisualizerToSeriesIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.VisualizerToSeriesIDNumericUpDown.TabIndex = 60;
            this.VisualizerToSeriesIDNumericUpDown.Tag = "Setting";
            this.VisualizerToSeriesIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.VisualizerToSeriesIDNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizerToSeriesIDNumericUpDown_KeyDown);
            // 
            // VisualizerFromSeriesIDLabel
            // 
            this.VisualizerFromSeriesIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerFromSeriesIDLabel.Location = new System.Drawing.Point(3, 726);
            this.VisualizerFromSeriesIDLabel.Name = "VisualizerFromSeriesIDLabel";
            this.VisualizerFromSeriesIDLabel.Size = new System.Drawing.Size(194, 11);
            this.VisualizerFromSeriesIDLabel.TabIndex = 61;
            this.VisualizerFromSeriesIDLabel.Text = "From series ID";
            this.VisualizerFromSeriesIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisualizerFromSeriesIDNumericUpDown
            // 
            this.VisualizerFromSeriesIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.VisualizerFromSeriesIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VisualizerFromSeriesIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerFromSeriesIDNumericUpDown.Location = new System.Drawing.Point(200, 725);
            this.VisualizerFromSeriesIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.VisualizerFromSeriesIDNumericUpDown.Name = "VisualizerFromSeriesIDNumericUpDown";
            this.VisualizerFromSeriesIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.VisualizerFromSeriesIDNumericUpDown.TabIndex = 59;
            this.VisualizerFromSeriesIDNumericUpDown.Tag = "Setting";
            this.VisualizerFromSeriesIDNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizerToSeriesIDNumericUpDown_KeyDown);
            // 
            // VisualizerCurrentValueLabel
            // 
            this.VisualizerCurrentValueLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualizerCurrentValueLabel.Location = new System.Drawing.Point(510, 700);
            this.VisualizerCurrentValueLabel.Name = "VisualizerCurrentValueLabel";
            this.VisualizerCurrentValueLabel.Size = new System.Drawing.Size(64, 11);
            this.VisualizerCurrentValueLabel.TabIndex = 58;
            this.VisualizerCurrentValueLabel.Text = "0";
            this.VisualizerCurrentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel19.Controls.Add(this.VisualizerTopLabel);
            this.panel19.Location = new System.Drawing.Point(1, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(947, 63);
            this.panel19.TabIndex = 57;
            // 
            // AutoTriggerMinNumericUpDown
            // 
            this.AutoTriggerMinNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AutoTriggerMinNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AutoTriggerMinNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerMinNumericUpDown.Location = new System.Drawing.Point(33, 566);
            this.AutoTriggerMinNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AutoTriggerMinNumericUpDown.Name = "AutoTriggerMinNumericUpDown";
            this.AutoTriggerMinNumericUpDown.Size = new System.Drawing.Size(43, 14);
            this.AutoTriggerMinNumericUpDown.TabIndex = 15;
            this.AutoTriggerMinNumericUpDown.Tag = "Setting";
            this.AutoTriggerMinNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AutoTriggerMinLabel
            // 
            this.AutoTriggerMinLabel.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerMinLabel.Location = new System.Drawing.Point(6, 568);
            this.AutoTriggerMinLabel.Name = "AutoTriggerMinLabel";
            this.AutoTriggerMinLabel.Size = new System.Drawing.Size(25, 9);
            this.AutoTriggerMinLabel.TabIndex = 56;
            this.AutoTriggerMinLabel.Text = "Min:";
            this.AutoTriggerMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoTriggerMaxNumericUpDown
            // 
            this.AutoTriggerMaxNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AutoTriggerMaxNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AutoTriggerMaxNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerMaxNumericUpDown.Location = new System.Drawing.Point(31, 466);
            this.AutoTriggerMaxNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AutoTriggerMaxNumericUpDown.Name = "AutoTriggerMaxNumericUpDown";
            this.AutoTriggerMaxNumericUpDown.Size = new System.Drawing.Size(43, 14);
            this.AutoTriggerMaxNumericUpDown.TabIndex = 14;
            this.AutoTriggerMaxNumericUpDown.Tag = "Setting";
            this.AutoTriggerMaxNumericUpDown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // AutoTriggerMaxLabel
            // 
            this.AutoTriggerMaxLabel.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerMaxLabel.Location = new System.Drawing.Point(4, 468);
            this.AutoTriggerMaxLabel.Name = "AutoTriggerMaxLabel";
            this.AutoTriggerMaxLabel.Size = new System.Drawing.Size(30, 9);
            this.AutoTriggerMaxLabel.TabIndex = 54;
            this.AutoTriggerMaxLabel.Text = "Max: ";
            this.AutoTriggerMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoTriggerDecreseAtLabel
            // 
            this.AutoTriggerDecreseAtLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerDecreseAtLabel.Location = new System.Drawing.Point(250, 698);
            this.AutoTriggerDecreseAtLabel.Name = "AutoTriggerDecreseAtLabel";
            this.AutoTriggerDecreseAtLabel.Size = new System.Drawing.Size(202, 11);
            this.AutoTriggerDecreseAtLabel.TabIndex = 52;
            this.AutoTriggerDecreseAtLabel.Text = "Decrease trigger level at <";
            this.AutoTriggerDecreseAtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoTriggerIncreseAtNumericUpDown
            // 
            this.AutoTriggerIncreseAtNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AutoTriggerIncreseAtNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AutoTriggerIncreseAtNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerIncreseAtNumericUpDown.Location = new System.Drawing.Point(458, 698);
            this.AutoTriggerIncreseAtNumericUpDown.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.AutoTriggerIncreseAtNumericUpDown.Name = "AutoTriggerIncreseAtNumericUpDown";
            this.AutoTriggerIncreseAtNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AutoTriggerIncreseAtNumericUpDown.TabIndex = 20;
            this.AutoTriggerIncreseAtNumericUpDown.Tag = "Setting";
            this.AutoTriggerIncreseAtNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // AutoTriggerIncreseAtLabel
            // 
            this.AutoTriggerIncreseAtLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerIncreseAtLabel.Location = new System.Drawing.Point(2, 698);
            this.AutoTriggerIncreseAtLabel.Name = "AutoTriggerIncreseAtLabel";
            this.AutoTriggerIncreseAtLabel.Size = new System.Drawing.Size(194, 11);
            this.AutoTriggerIncreseAtLabel.TabIndex = 50;
            this.AutoTriggerIncreseAtLabel.Text = "Increase trigger level at >";
            this.AutoTriggerIncreseAtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoTriggerDecreseAtNumericUpDown
            // 
            this.AutoTriggerDecreseAtNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AutoTriggerDecreseAtNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AutoTriggerDecreseAtNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoTriggerDecreseAtNumericUpDown.Location = new System.Drawing.Point(199, 697);
            this.AutoTriggerDecreseAtNumericUpDown.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.AutoTriggerDecreseAtNumericUpDown.Name = "AutoTriggerDecreseAtNumericUpDown";
            this.AutoTriggerDecreseAtNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AutoTriggerDecreseAtNumericUpDown.TabIndex = 19;
            this.AutoTriggerDecreseAtNumericUpDown.Tag = "Setting";
            this.AutoTriggerDecreseAtNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // AutoTriggerCheckBox
            // 
            this.AutoTriggerCheckBox.AutoSize = true;
            this.AutoTriggerCheckBox.BackColor = System.Drawing.Color.DimGray;
            this.AutoTriggerCheckBox.Checked = true;
            this.AutoTriggerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoTriggerCheckBox.ForeColor = System.Drawing.Color.White;
            this.AutoTriggerCheckBox.Location = new System.Drawing.Point(9, 593);
            this.AutoTriggerCheckBox.Name = "AutoTriggerCheckBox";
            this.AutoTriggerCheckBox.Size = new System.Drawing.Size(84, 17);
            this.AutoTriggerCheckBox.TabIndex = 16;
            this.AutoTriggerCheckBox.Text = "Auto Trigger";
            this.AutoTriggerCheckBox.UseVisualStyleBackColor = false;
            this.AutoTriggerCheckBox.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.FullSpectrumPanel);
            this.panel5.Controls.Add(this.WavePanel);
            this.panel5.Controls.Add(this.SpectrumPanel);
            this.panel5.Location = new System.Drawing.Point(580, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(361, 651);
            this.panel5.TabIndex = 47;
            // 
            // FullSpectrumPanel
            // 
            this.FullSpectrumPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FullSpectrumPanel.Controls.Add(this.FullSpectrumLabel);
            this.FullSpectrumPanel.Controls.Add(this.FullSpectrumNumericUpDown);
            this.FullSpectrumPanel.Controls.Add(this.FullSpectrumTopLabel);
            this.FullSpectrumPanel.Enabled = false;
            this.FullSpectrumPanel.Location = new System.Drawing.Point(4, 588);
            this.FullSpectrumPanel.Name = "FullSpectrumPanel";
            this.FullSpectrumPanel.Size = new System.Drawing.Size(353, 58);
            this.FullSpectrumPanel.TabIndex = 57;
            // 
            // FullSpectrumLabel
            // 
            this.FullSpectrumLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullSpectrumLabel.Location = new System.Drawing.Point(2, 36);
            this.FullSpectrumLabel.Name = "FullSpectrumLabel";
            this.FullSpectrumLabel.Size = new System.Drawing.Size(175, 12);
            this.FullSpectrumLabel.TabIndex = 50;
            this.FullSpectrumLabel.Text = "Sample Spacing";
            this.FullSpectrumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FullSpectrumNumericUpDown
            // 
            this.FullSpectrumNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.FullSpectrumNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullSpectrumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.FullSpectrumNumericUpDown.Location = new System.Drawing.Point(183, 33);
            this.FullSpectrumNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.FullSpectrumNumericUpDown.Name = "FullSpectrumNumericUpDown";
            this.FullSpectrumNumericUpDown.Size = new System.Drawing.Size(162, 18);
            this.FullSpectrumNumericUpDown.TabIndex = 49;
            this.FullSpectrumNumericUpDown.Tag = "Setting";
            this.FullSpectrumNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FullSpectrumTopLabel
            // 
            this.FullSpectrumTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullSpectrumTopLabel.Location = new System.Drawing.Point(5, 1);
            this.FullSpectrumTopLabel.Name = "FullSpectrumTopLabel";
            this.FullSpectrumTopLabel.Size = new System.Drawing.Size(350, 28);
            this.FullSpectrumTopLabel.TabIndex = 48;
            this.FullSpectrumTopLabel.Text = "Full Spectrum Settings";
            this.FullSpectrumTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WavePanel
            // 
            this.WavePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WavePanel.Controls.Add(this.BeatWaveProgressBar);
            this.WavePanel.Controls.Add(this.WaveAutoScaleValuesCheckBox);
            this.WavePanel.Controls.Add(this.WaveTopLabel);
            this.WavePanel.Controls.Add(this.UpdateWaveButton);
            this.WavePanel.Controls.Add(this.WaveChart);
            this.WavePanel.Controls.Add(this.WaveBlueLabel);
            this.WavePanel.Controls.Add(this.WaveRedTextBox);
            this.WavePanel.Controls.Add(this.WaveBlueTextBox);
            this.WavePanel.Controls.Add(this.WaveRedLabel);
            this.WavePanel.Controls.Add(this.WaveGreenLabel);
            this.WavePanel.Controls.Add(this.WaveGreenTextBox);
            this.WavePanel.Location = new System.Drawing.Point(4, 283);
            this.WavePanel.Name = "WavePanel";
            this.WavePanel.Size = new System.Drawing.Size(353, 301);
            this.WavePanel.TabIndex = 56;
            // 
            // BeatWaveProgressBar
            // 
            this.BeatWaveProgressBar.ForeColor = System.Drawing.Color.Red;
            this.BeatWaveProgressBar.Location = new System.Drawing.Point(50, 166);
            this.BeatWaveProgressBar.MarqueeAnimationSpeed = 99999;
            this.BeatWaveProgressBar.Maximum = 765;
            this.BeatWaveProgressBar.Name = "BeatWaveProgressBar";
            this.BeatWaveProgressBar.Size = new System.Drawing.Size(285, 14);
            this.BeatWaveProgressBar.Step = 1;
            this.BeatWaveProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BeatWaveProgressBar.TabIndex = 55;
            // 
            // WaveAutoScaleValuesCheckBox
            // 
            this.WaveAutoScaleValuesCheckBox.AutoSize = true;
            this.WaveAutoScaleValuesCheckBox.BackColor = System.Drawing.Color.Gray;
            this.WaveAutoScaleValuesCheckBox.Checked = true;
            this.WaveAutoScaleValuesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WaveAutoScaleValuesCheckBox.ForeColor = System.Drawing.Color.White;
            this.WaveAutoScaleValuesCheckBox.Location = new System.Drawing.Point(5, 187);
            this.WaveAutoScaleValuesCheckBox.Name = "WaveAutoScaleValuesCheckBox";
            this.WaveAutoScaleValuesCheckBox.Size = new System.Drawing.Size(113, 17);
            this.WaveAutoScaleValuesCheckBox.TabIndex = 56;
            this.WaveAutoScaleValuesCheckBox.Tag = "Setting";
            this.WaveAutoScaleValuesCheckBox.Text = "Auto Scale Values";
            this.WaveAutoScaleValuesCheckBox.UseVisualStyleBackColor = false;
            // 
            // WaveTopLabel
            // 
            this.WaveTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveTopLabel.Location = new System.Drawing.Point(2, 2);
            this.WaveTopLabel.Name = "WaveTopLabel";
            this.WaveTopLabel.Size = new System.Drawing.Size(353, 16);
            this.WaveTopLabel.TabIndex = 47;
            this.WaveTopLabel.Text = "Wave Beat Settings";
            this.WaveTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateWaveButton
            // 
            this.UpdateWaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.UpdateWaveButton.FlatAppearance.BorderSize = 0;
            this.UpdateWaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateWaveButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateWaveButton.Location = new System.Drawing.Point(10, 269);
            this.UpdateWaveButton.Name = "UpdateWaveButton";
            this.UpdateWaveButton.Size = new System.Drawing.Size(340, 23);
            this.UpdateWaveButton.TabIndex = 24;
            this.UpdateWaveButton.Text = "Update";
            this.UpdateWaveButton.UseVisualStyleBackColor = false;
            this.UpdateWaveButton.Click += new System.EventHandler(this.UpdateWaveButton_Click);
            // 
            // WaveChart
            // 
            this.WaveChart.BackColor = System.Drawing.Color.Gray;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.WaveChart.ChartAreas.Add(chartArea2);
            this.WaveChart.Location = new System.Drawing.Point(0, 21);
            this.WaveChart.Name = "WaveChart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.White;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.WaveChart.Series.Add(series2);
            this.WaveChart.Size = new System.Drawing.Size(353, 154);
            this.WaveChart.TabIndex = 46;
            this.WaveChart.Text = "chart3";
            // 
            // WaveBlueLabel
            // 
            this.WaveBlueLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveBlueLabel.Location = new System.Drawing.Point(0, 253);
            this.WaveBlueLabel.Name = "WaveBlueLabel";
            this.WaveBlueLabel.Size = new System.Drawing.Size(128, 13);
            this.WaveBlueLabel.TabIndex = 53;
            this.WaveBlueLabel.Text = "Blue formular:";
            this.WaveBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaveRedTextBox
            // 
            this.WaveRedTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.WaveRedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WaveRedTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveRedTextBox.ForeColor = System.Drawing.Color.White;
            this.WaveRedTextBox.Location = new System.Drawing.Point(134, 211);
            this.WaveRedTextBox.Name = "WaveRedTextBox";
            this.WaveRedTextBox.Size = new System.Drawing.Size(209, 11);
            this.WaveRedTextBox.TabIndex = 21;
            this.WaveRedTextBox.Tag = "Setting";
            this.WaveRedTextBox.Text = "x * 1";
            // 
            // WaveBlueTextBox
            // 
            this.WaveBlueTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.WaveBlueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WaveBlueTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveBlueTextBox.ForeColor = System.Drawing.Color.White;
            this.WaveBlueTextBox.Location = new System.Drawing.Point(134, 251);
            this.WaveBlueTextBox.Name = "WaveBlueTextBox";
            this.WaveBlueTextBox.Size = new System.Drawing.Size(209, 11);
            this.WaveBlueTextBox.TabIndex = 23;
            this.WaveBlueTextBox.Tag = "Setting";
            this.WaveBlueTextBox.Text = "x * 1 - 510";
            // 
            // WaveRedLabel
            // 
            this.WaveRedLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveRedLabel.Location = new System.Drawing.Point(0, 213);
            this.WaveRedLabel.Name = "WaveRedLabel";
            this.WaveRedLabel.Size = new System.Drawing.Size(128, 13);
            this.WaveRedLabel.TabIndex = 49;
            this.WaveRedLabel.Text = "Red formular:";
            this.WaveRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaveGreenLabel
            // 
            this.WaveGreenLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveGreenLabel.Location = new System.Drawing.Point(0, 233);
            this.WaveGreenLabel.Name = "WaveGreenLabel";
            this.WaveGreenLabel.Size = new System.Drawing.Size(128, 13);
            this.WaveGreenLabel.TabIndex = 51;
            this.WaveGreenLabel.Text = "Green formular:";
            this.WaveGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaveGreenTextBox
            // 
            this.WaveGreenTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.WaveGreenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WaveGreenTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveGreenTextBox.ForeColor = System.Drawing.Color.White;
            this.WaveGreenTextBox.Location = new System.Drawing.Point(134, 231);
            this.WaveGreenTextBox.Name = "WaveGreenTextBox";
            this.WaveGreenTextBox.Size = new System.Drawing.Size(209, 11);
            this.WaveGreenTextBox.TabIndex = 22;
            this.WaveGreenTextBox.Tag = "Setting";
            this.WaveGreenTextBox.Text = "x * 1 - 255";
            // 
            // SpectrumPanel
            // 
            this.SpectrumPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpectrumPanel.Controls.Add(this.SpectrumAutoScaleValuesCheckBox);
            this.SpectrumPanel.Controls.Add(this.SpectrumTopLabel);
            this.SpectrumPanel.Controls.Add(this.UpdateSpectrumButton);
            this.SpectrumPanel.Controls.Add(this.SpectrumChart);
            this.SpectrumPanel.Controls.Add(this.SpectrumBlueLabel);
            this.SpectrumPanel.Controls.Add(this.SpectrumRedTextBox);
            this.SpectrumPanel.Controls.Add(this.SpectrumBlueTextBox);
            this.SpectrumPanel.Controls.Add(this.SpectrumRedLabel);
            this.SpectrumPanel.Controls.Add(this.SpectrumGreenLabel);
            this.SpectrumPanel.Controls.Add(this.SpectrumGreenTextBox);
            this.SpectrumPanel.Location = new System.Drawing.Point(4, 3);
            this.SpectrumPanel.Name = "SpectrumPanel";
            this.SpectrumPanel.Size = new System.Drawing.Size(353, 277);
            this.SpectrumPanel.TabIndex = 55;
            // 
            // SpectrumAutoScaleValuesCheckBox
            // 
            this.SpectrumAutoScaleValuesCheckBox.AutoSize = true;
            this.SpectrumAutoScaleValuesCheckBox.BackColor = System.Drawing.Color.Gray;
            this.SpectrumAutoScaleValuesCheckBox.Checked = true;
            this.SpectrumAutoScaleValuesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpectrumAutoScaleValuesCheckBox.ForeColor = System.Drawing.Color.White;
            this.SpectrumAutoScaleValuesCheckBox.Location = new System.Drawing.Point(5, 165);
            this.SpectrumAutoScaleValuesCheckBox.Name = "SpectrumAutoScaleValuesCheckBox";
            this.SpectrumAutoScaleValuesCheckBox.Size = new System.Drawing.Size(113, 17);
            this.SpectrumAutoScaleValuesCheckBox.TabIndex = 57;
            this.SpectrumAutoScaleValuesCheckBox.Tag = "Setting";
            this.SpectrumAutoScaleValuesCheckBox.Text = "Auto Scale Values";
            this.SpectrumAutoScaleValuesCheckBox.UseVisualStyleBackColor = false;
            // 
            // SpectrumTopLabel
            // 
            this.SpectrumTopLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumTopLabel.Location = new System.Drawing.Point(4, 1);
            this.SpectrumTopLabel.Name = "SpectrumTopLabel";
            this.SpectrumTopLabel.Size = new System.Drawing.Size(353, 16);
            this.SpectrumTopLabel.TabIndex = 47;
            this.SpectrumTopLabel.Text = "Spectrum Beat/Wave Settings";
            this.SpectrumTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateSpectrumButton
            // 
            this.UpdateSpectrumButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.UpdateSpectrumButton.FlatAppearance.BorderSize = 0;
            this.UpdateSpectrumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateSpectrumButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateSpectrumButton.Location = new System.Drawing.Point(10, 245);
            this.UpdateSpectrumButton.Name = "UpdateSpectrumButton";
            this.UpdateSpectrumButton.Size = new System.Drawing.Size(340, 23);
            this.UpdateSpectrumButton.TabIndex = 24;
            this.UpdateSpectrumButton.Text = "Update";
            this.UpdateSpectrumButton.UseVisualStyleBackColor = false;
            this.UpdateSpectrumButton.Click += new System.EventHandler(this.UpdateSpectrumButton_Click);
            // 
            // SpectrumChart
            // 
            this.SpectrumChart.BackColor = System.Drawing.Color.Gray;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.Silver;
            chartArea3.Name = "ChartArea1";
            this.SpectrumChart.ChartAreas.Add(chartArea3);
            this.SpectrumChart.Location = new System.Drawing.Point(0, 15);
            this.SpectrumChart.Name = "SpectrumChart";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.White;
            series3.IsVisibleInLegend = false;
            series3.Name = "Series1";
            this.SpectrumChart.Series.Add(series3);
            this.SpectrumChart.Size = new System.Drawing.Size(353, 154);
            this.SpectrumChart.TabIndex = 46;
            this.SpectrumChart.Text = "chart2";
            // 
            // SpectrumBlueLabel
            // 
            this.SpectrumBlueLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumBlueLabel.Location = new System.Drawing.Point(0, 229);
            this.SpectrumBlueLabel.Name = "SpectrumBlueLabel";
            this.SpectrumBlueLabel.Size = new System.Drawing.Size(128, 13);
            this.SpectrumBlueLabel.TabIndex = 53;
            this.SpectrumBlueLabel.Text = "Blue formular:";
            this.SpectrumBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpectrumRedTextBox
            // 
            this.SpectrumRedTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.SpectrumRedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpectrumRedTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumRedTextBox.ForeColor = System.Drawing.Color.White;
            this.SpectrumRedTextBox.Location = new System.Drawing.Point(134, 187);
            this.SpectrumRedTextBox.Name = "SpectrumRedTextBox";
            this.SpectrumRedTextBox.Size = new System.Drawing.Size(209, 11);
            this.SpectrumRedTextBox.TabIndex = 21;
            this.SpectrumRedTextBox.Tag = "Setting";
            this.SpectrumRedTextBox.Text = "x * 1";
            // 
            // SpectrumBlueTextBox
            // 
            this.SpectrumBlueTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.SpectrumBlueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpectrumBlueTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumBlueTextBox.ForeColor = System.Drawing.Color.White;
            this.SpectrumBlueTextBox.Location = new System.Drawing.Point(134, 227);
            this.SpectrumBlueTextBox.Name = "SpectrumBlueTextBox";
            this.SpectrumBlueTextBox.Size = new System.Drawing.Size(209, 11);
            this.SpectrumBlueTextBox.TabIndex = 23;
            this.SpectrumBlueTextBox.Tag = "Setting";
            this.SpectrumBlueTextBox.Text = "x * 3";
            // 
            // SpectrumRedLabel
            // 
            this.SpectrumRedLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumRedLabel.Location = new System.Drawing.Point(0, 189);
            this.SpectrumRedLabel.Name = "SpectrumRedLabel";
            this.SpectrumRedLabel.Size = new System.Drawing.Size(128, 13);
            this.SpectrumRedLabel.TabIndex = 49;
            this.SpectrumRedLabel.Text = "Red formular:";
            this.SpectrumRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpectrumGreenLabel
            // 
            this.SpectrumGreenLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumGreenLabel.Location = new System.Drawing.Point(0, 209);
            this.SpectrumGreenLabel.Name = "SpectrumGreenLabel";
            this.SpectrumGreenLabel.Size = new System.Drawing.Size(128, 13);
            this.SpectrumGreenLabel.TabIndex = 51;
            this.SpectrumGreenLabel.Text = "Green formular:";
            this.SpectrumGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpectrumGreenTextBox
            // 
            this.SpectrumGreenTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.SpectrumGreenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpectrumGreenTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpectrumGreenTextBox.ForeColor = System.Drawing.Color.White;
            this.SpectrumGreenTextBox.Location = new System.Drawing.Point(134, 207);
            this.SpectrumGreenTextBox.Name = "SpectrumGreenTextBox";
            this.SpectrumGreenTextBox.Size = new System.Drawing.Size(209, 11);
            this.SpectrumGreenTextBox.TabIndex = 22;
            this.SpectrumGreenTextBox.Tag = "Setting";
            this.SpectrumGreenTextBox.Text = "x * 2";
            // 
            // BeatZoneTriggerHeightLabel
            // 
            this.BeatZoneTriggerHeightLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatZoneTriggerHeightLabel.Location = new System.Drawing.Point(4, 441);
            this.BeatZoneTriggerHeightLabel.Name = "BeatZoneTriggerHeightLabel";
            this.BeatZoneTriggerHeightLabel.Size = new System.Drawing.Size(212, 16);
            this.BeatZoneTriggerHeightLabel.TabIndex = 45;
            this.BeatZoneTriggerHeightLabel.Text = "Trigger at: 75";
            this.BeatZoneTriggerHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeatZoneTriggerHeight
            // 
            this.BeatZoneTriggerHeight.Enabled = false;
            this.BeatZoneTriggerHeight.Location = new System.Drawing.Point(73, 459);
            this.BeatZoneTriggerHeight.Maximum = 255;
            this.BeatZoneTriggerHeight.Name = "BeatZoneTriggerHeight";
            this.BeatZoneTriggerHeight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.BeatZoneTriggerHeight.Size = new System.Drawing.Size(45, 133);
            this.BeatZoneTriggerHeight.TabIndex = 13;
            this.BeatZoneTriggerHeight.Tag = "Setting";
            this.BeatZoneTriggerHeight.TickFrequency = 10;
            this.BeatZoneTriggerHeight.Value = 75;
            this.BeatZoneTriggerHeight.Scroll += new System.EventHandler(this.BeatZoneTriggerHeight_Scroll);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.Gray;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButton.ForeColor = System.Drawing.Color.White;
            this.MenuButton.Location = new System.Drawing.Point(1336, -1);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(75, 23);
            this.MenuButton.TabIndex = 0;
            this.MenuButton.Text = "ArduLED";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // FadeColorsBlueTrackBar
            // 
            this.FadeColorsBlueTrackBar.BackColor = System.Drawing.Color.DimGray;
            this.FadeColorsBlueTrackBar.Location = new System.Drawing.Point(139, 27);
            this.FadeColorsBlueTrackBar.Maximum = 255;
            this.FadeColorsBlueTrackBar.Name = "FadeColorsBlueTrackBar";
            this.FadeColorsBlueTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FadeColorsBlueTrackBar.Size = new System.Drawing.Size(45, 111);
            this.FadeColorsBlueTrackBar.TabIndex = 8;
            this.FadeColorsBlueTrackBar.Tag = "Setting";
            this.FadeColorsBlueTrackBar.TickFrequency = 10;
            this.FadeColorsBlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FadeColorsBlueTrackBar.Value = 255;
            this.FadeColorsBlueTrackBar.Scroll += new System.EventHandler(this.FadeColorsBlue_ValueChanged);
            this.FadeColorsBlueTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FadeColors_BeginSendData);
            // 
            // FadeColorsGreenTopLabel
            // 
            this.FadeColorsGreenTopLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsGreenTopLabel.Location = new System.Drawing.Point(70, 6);
            this.FadeColorsGreenTopLabel.Name = "FadeColorsGreenTopLabel";
            this.FadeColorsGreenTopLabel.Size = new System.Drawing.Size(52, 15);
            this.FadeColorsGreenTopLabel.TabIndex = 31;
            this.FadeColorsGreenTopLabel.Text = "Green";
            this.FadeColorsGreenTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeColorsBlueTopLabel
            // 
            this.FadeColorsBlueTopLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsBlueTopLabel.Location = new System.Drawing.Point(135, 6);
            this.FadeColorsBlueTopLabel.Name = "FadeColorsBlueTopLabel";
            this.FadeColorsBlueTopLabel.Size = new System.Drawing.Size(52, 15);
            this.FadeColorsBlueTopLabel.TabIndex = 33;
            this.FadeColorsBlueTopLabel.Text = "Blue";
            this.FadeColorsBlueTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeColorsRedTopLabel
            // 
            this.FadeColorsRedTopLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsRedTopLabel.Location = new System.Drawing.Point(5, 6);
            this.FadeColorsRedTopLabel.Name = "FadeColorsRedTopLabel";
            this.FadeColorsRedTopLabel.Size = new System.Drawing.Size(52, 15);
            this.FadeColorsRedTopLabel.TabIndex = 29;
            this.FadeColorsRedTopLabel.Text = "Red";
            this.FadeColorsRedTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeColorsRedLabel
            // 
            this.FadeColorsRedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsRedLabel.Location = new System.Drawing.Point(14, 141);
            this.FadeColorsRedLabel.Name = "FadeColorsRedLabel";
            this.FadeColorsRedLabel.Size = new System.Drawing.Size(34, 15);
            this.FadeColorsRedLabel.TabIndex = 34;
            this.FadeColorsRedLabel.Tag = "";
            this.FadeColorsRedLabel.Text = "255";
            this.FadeColorsRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeColorsRedTrackBar
            // 
            this.FadeColorsRedTrackBar.BackColor = System.Drawing.Color.DimGray;
            this.FadeColorsRedTrackBar.Location = new System.Drawing.Point(9, 27);
            this.FadeColorsRedTrackBar.Maximum = 255;
            this.FadeColorsRedTrackBar.Name = "FadeColorsRedTrackBar";
            this.FadeColorsRedTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FadeColorsRedTrackBar.Size = new System.Drawing.Size(45, 111);
            this.FadeColorsRedTrackBar.TabIndex = 6;
            this.FadeColorsRedTrackBar.Tag = "Setting";
            this.FadeColorsRedTrackBar.TickFrequency = 10;
            this.FadeColorsRedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FadeColorsRedTrackBar.Value = 255;
            this.FadeColorsRedTrackBar.Scroll += new System.EventHandler(this.FadeColorsRed_ValueChanged);
            this.FadeColorsRedTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FadeColors_BeginSendData);
            // 
            // FadeColorsGreenLabel
            // 
            this.FadeColorsGreenLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsGreenLabel.Location = new System.Drawing.Point(79, 141);
            this.FadeColorsGreenLabel.Name = "FadeColorsGreenLabel";
            this.FadeColorsGreenLabel.Size = new System.Drawing.Size(34, 15);
            this.FadeColorsGreenLabel.TabIndex = 35;
            this.FadeColorsGreenLabel.Tag = "";
            this.FadeColorsGreenLabel.Text = "255";
            this.FadeColorsGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeColorsGreenTrackBar
            // 
            this.FadeColorsGreenTrackBar.BackColor = System.Drawing.Color.DimGray;
            this.FadeColorsGreenTrackBar.Location = new System.Drawing.Point(74, 27);
            this.FadeColorsGreenTrackBar.Maximum = 255;
            this.FadeColorsGreenTrackBar.Name = "FadeColorsGreenTrackBar";
            this.FadeColorsGreenTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FadeColorsGreenTrackBar.Size = new System.Drawing.Size(45, 111);
            this.FadeColorsGreenTrackBar.TabIndex = 7;
            this.FadeColorsGreenTrackBar.Tag = "Setting";
            this.FadeColorsGreenTrackBar.TickFrequency = 10;
            this.FadeColorsGreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FadeColorsGreenTrackBar.Value = 255;
            this.FadeColorsGreenTrackBar.Scroll += new System.EventHandler(this.FadeColorsGreen_ValueChanged);
            this.FadeColorsGreenTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FadeColors_BeginSendData);
            // 
            // FadeColorsBlueLabel
            // 
            this.FadeColorsBlueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsBlueLabel.Location = new System.Drawing.Point(144, 141);
            this.FadeColorsBlueLabel.Name = "FadeColorsBlueLabel";
            this.FadeColorsBlueLabel.Size = new System.Drawing.Size(34, 15);
            this.FadeColorsBlueLabel.TabIndex = 36;
            this.FadeColorsBlueLabel.Tag = "";
            this.FadeColorsBlueLabel.Text = "255";
            this.FadeColorsBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuConnectButton
            // 
            this.MenuConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.MenuConnectButton.FlatAppearance.BorderSize = 0;
            this.MenuConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuConnectButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuConnectButton.ForeColor = System.Drawing.Color.White;
            this.MenuConnectButton.Location = new System.Drawing.Point(259, 33);
            this.MenuConnectButton.Name = "MenuConnectButton";
            this.MenuConnectButton.Size = new System.Drawing.Size(109, 22);
            this.MenuConnectButton.TabIndex = 2;
            this.MenuConnectButton.Text = "Connect";
            this.MenuConnectButton.UseVisualStyleBackColor = false;
            this.MenuConnectButton.Click += new System.EventHandler(this.Connect);
            // 
            // ComPortsComboBox
            // 
            this.ComPortsComboBox.BackColor = System.Drawing.Color.Gray;
            this.ComPortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPortsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComPortsComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortsComboBox.ForeColor = System.Drawing.Color.White;
            this.ComPortsComboBox.FormattingEnabled = true;
            this.ComPortsComboBox.Location = new System.Drawing.Point(172, 34);
            this.ComPortsComboBox.Name = "ComPortsComboBox";
            this.ComPortsComboBox.Size = new System.Drawing.Size(76, 19);
            this.ComPortsComboBox.TabIndex = 1;
            this.ComPortsComboBox.Tag = "Setting";
            // 
            // MenuSelectComDeviceLabel
            // 
            this.MenuSelectComDeviceLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSelectComDeviceLabel.ForeColor = System.Drawing.Color.White;
            this.MenuSelectComDeviceLabel.Location = new System.Drawing.Point(169, 9);
            this.MenuSelectComDeviceLabel.Name = "MenuSelectComDeviceLabel";
            this.MenuSelectComDeviceLabel.Size = new System.Drawing.Size(160, 15);
            this.MenuSelectComDeviceLabel.TabIndex = 26;
            this.MenuSelectComDeviceLabel.Text = "Select COM device";
            // 
            // FadeColorsFadeSpeedNumericUpDown
            // 
            this.FadeColorsFadeSpeedNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.FadeColorsFadeSpeedNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsFadeSpeedNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.FadeColorsFadeSpeedNumericUpDown.Location = new System.Drawing.Point(194, 32);
            this.FadeColorsFadeSpeedNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.FadeColorsFadeSpeedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FadeColorsFadeSpeedNumericUpDown.Name = "FadeColorsFadeSpeedNumericUpDown";
            this.FadeColorsFadeSpeedNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.FadeColorsFadeSpeedNumericUpDown.TabIndex = 9;
            this.FadeColorsFadeSpeedNumericUpDown.Tag = "Setting";
            this.FadeColorsFadeSpeedNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.DimGray;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.MenuAutoHideCheckBox);
            this.MenuPanel.Controls.Add(this.LanguageComboBox);
            this.MenuPanel.Controls.Add(this.panel7);
            this.MenuPanel.Controls.Add(this.FadeLEDPanel);
            this.MenuPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MenuPanel.Location = new System.Drawing.Point(950, 21);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(387, 271);
            this.MenuPanel.TabIndex = 46;
            this.MenuPanel.Visible = false;
            // 
            // MenuAutoHideCheckBox
            // 
            this.MenuAutoHideCheckBox.AutoSize = true;
            this.MenuAutoHideCheckBox.BackColor = System.Drawing.Color.DimGray;
            this.MenuAutoHideCheckBox.Checked = true;
            this.MenuAutoHideCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuAutoHideCheckBox.ForeColor = System.Drawing.Color.White;
            this.MenuAutoHideCheckBox.Location = new System.Drawing.Point(6, 248);
            this.MenuAutoHideCheckBox.Name = "MenuAutoHideCheckBox";
            this.MenuAutoHideCheckBox.Size = new System.Drawing.Size(73, 17);
            this.MenuAutoHideCheckBox.TabIndex = 5;
            this.MenuAutoHideCheckBox.Tag = "Setting";
            this.MenuAutoHideCheckBox.Text = "Auto Hide";
            this.MenuAutoHideCheckBox.UseVisualStyleBackColor = false;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.BackColor = System.Drawing.Color.Gray;
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LanguageComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageComboBox.ForeColor = System.Drawing.Color.White;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(338, 247);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(44, 19);
            this.LanguageComboBox.TabIndex = 6;
            this.LanguageComboBox.Tag = "Setting";
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.MenuExitButton);
            this.panel7.Controls.Add(this.MenuConnectButton);
            this.panel7.Controls.Add(this.ComPortsComboBox);
            this.panel7.Controls.Add(this.MenuModeLabel);
            this.panel7.Controls.Add(this.MenuSelectComDeviceLabel);
            this.panel7.Controls.Add(this.ModeSelectrionComboBox);
            this.panel7.Location = new System.Drawing.Point(0, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(387, 64);
            this.panel7.TabIndex = 57;
            // 
            // MenuExitButton
            // 
            this.MenuExitButton.BackColor = System.Drawing.Color.Gray;
            this.MenuExitButton.FlatAppearance.BorderSize = 0;
            this.MenuExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuExitButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuExitButton.ForeColor = System.Drawing.Color.White;
            this.MenuExitButton.Location = new System.Drawing.Point(344, 6);
            this.MenuExitButton.Name = "MenuExitButton";
            this.MenuExitButton.Size = new System.Drawing.Size(24, 22);
            this.MenuExitButton.TabIndex = 3;
            this.MenuExitButton.Text = "X";
            this.MenuExitButton.UseVisualStyleBackColor = false;
            this.MenuExitButton.Click += new System.EventHandler(this.MenuExitButton_Click);
            // 
            // MenuModeLabel
            // 
            this.MenuModeLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuModeLabel.ForeColor = System.Drawing.Color.White;
            this.MenuModeLabel.Location = new System.Drawing.Point(20, 9);
            this.MenuModeLabel.Name = "MenuModeLabel";
            this.MenuModeLabel.Size = new System.Drawing.Size(146, 15);
            this.MenuModeLabel.TabIndex = 50;
            this.MenuModeLabel.Text = "Mode";
            this.MenuModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModeSelectrionComboBox
            // 
            this.ModeSelectrionComboBox.BackColor = System.Drawing.Color.Gray;
            this.ModeSelectrionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeSelectrionComboBox.Enabled = false;
            this.ModeSelectrionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModeSelectrionComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeSelectrionComboBox.ForeColor = System.Drawing.Color.White;
            this.ModeSelectrionComboBox.FormattingEnabled = true;
            this.ModeSelectrionComboBox.Location = new System.Drawing.Point(20, 34);
            this.ModeSelectrionComboBox.Name = "ModeSelectrionComboBox";
            this.ModeSelectrionComboBox.Size = new System.Drawing.Size(146, 19);
            this.ModeSelectrionComboBox.TabIndex = 4;
            this.ModeSelectrionComboBox.Tag = "";
            this.ModeSelectrionComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeSelectrionComboBox_SelectedIndexChanged);
            // 
            // FadeLEDPanel
            // 
            this.FadeLEDPanel.BackColor = System.Drawing.Color.DimGray;
            this.FadeLEDPanel.Controls.Add(this.FadeLEDPanelToIDLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeLEDPanelToIDNumericUpDown);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsBrightnessLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsRedTrackBar);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsBlueTrackBar);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsGreenTopLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeLEDPanelFromIDNumericUpDown);
            this.FadeLEDPanel.Controls.Add(this.FadeLEDPanelFromIDLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsFadeFactorLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsBlueTopLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsFadeFactorNumericUpDown);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsRedTopLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsFadeSpeedLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsRedLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsFadeSpeedNumericUpDown);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsGreenLabel);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsGreenTrackBar);
            this.FadeLEDPanel.Controls.Add(this.FadeColorsBlueLabel);
            this.FadeLEDPanel.Enabled = false;
            this.FadeLEDPanel.ForeColor = System.Drawing.Color.White;
            this.FadeLEDPanel.Location = new System.Drawing.Point(6, 66);
            this.FadeLEDPanel.Name = "FadeLEDPanel";
            this.FadeLEDPanel.Size = new System.Drawing.Size(376, 180);
            this.FadeLEDPanel.TabIndex = 51;
            // 
            // FadeLEDPanelToIDLabel
            // 
            this.FadeLEDPanelToIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeLEDPanelToIDLabel.Location = new System.Drawing.Point(185, 164);
            this.FadeLEDPanelToIDLabel.Name = "FadeLEDPanelToIDLabel";
            this.FadeLEDPanelToIDLabel.Size = new System.Drawing.Size(110, 11);
            this.FadeLEDPanelToIDLabel.TabIndex = 66;
            this.FadeLEDPanelToIDLabel.Text = "To Series ID";
            this.FadeLEDPanelToIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeLEDPanelToIDNumericUpDown
            // 
            this.FadeLEDPanelToIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.FadeLEDPanelToIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FadeLEDPanelToIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeLEDPanelToIDNumericUpDown.Location = new System.Drawing.Point(297, 162);
            this.FadeLEDPanelToIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.FadeLEDPanelToIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.FadeLEDPanelToIDNumericUpDown.Name = "FadeLEDPanelToIDNumericUpDown";
            this.FadeLEDPanelToIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.FadeLEDPanelToIDNumericUpDown.TabIndex = 64;
            this.FadeLEDPanelToIDNumericUpDown.Tag = "Setting";
            this.FadeLEDPanelToIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // FadeColorsBrightnessLabel
            // 
            this.FadeColorsBrightnessLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsBrightnessLabel.Location = new System.Drawing.Point(191, 114);
            this.FadeColorsBrightnessLabel.Name = "FadeColorsBrightnessLabel";
            this.FadeColorsBrightnessLabel.Size = new System.Drawing.Size(171, 15);
            this.FadeColorsBrightnessLabel.TabIndex = 49;
            this.FadeColorsBrightnessLabel.Text = "Brightness:100%";
            this.FadeColorsBrightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeLEDPanelFromIDNumericUpDown
            // 
            this.FadeLEDPanelFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.FadeLEDPanelFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FadeLEDPanelFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeLEDPanelFromIDNumericUpDown.Location = new System.Drawing.Point(130, 162);
            this.FadeLEDPanelFromIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.FadeLEDPanelFromIDNumericUpDown.Name = "FadeLEDPanelFromIDNumericUpDown";
            this.FadeLEDPanelFromIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.FadeLEDPanelFromIDNumericUpDown.TabIndex = 63;
            this.FadeLEDPanelFromIDNumericUpDown.Tag = "Setting";
            // 
            // FadeLEDPanelFromIDLabel
            // 
            this.FadeLEDPanelFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeLEDPanelFromIDLabel.Location = new System.Drawing.Point(19, 164);
            this.FadeLEDPanelFromIDLabel.Name = "FadeLEDPanelFromIDLabel";
            this.FadeLEDPanelFromIDLabel.Size = new System.Drawing.Size(110, 11);
            this.FadeLEDPanelFromIDLabel.TabIndex = 65;
            this.FadeLEDPanelFromIDLabel.Text = "From series ID";
            this.FadeLEDPanelFromIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeColorsFadeFactorLabel
            // 
            this.FadeColorsFadeFactorLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsFadeFactorLabel.Location = new System.Drawing.Point(191, 58);
            this.FadeColorsFadeFactorLabel.Name = "FadeColorsFadeFactorLabel";
            this.FadeColorsFadeFactorLabel.Size = new System.Drawing.Size(171, 15);
            this.FadeColorsFadeFactorLabel.TabIndex = 48;
            this.FadeColorsFadeFactorLabel.Text = "Fade factor";
            this.FadeColorsFadeFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeColorsFadeFactorNumericUpDown
            // 
            this.FadeColorsFadeFactorNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.FadeColorsFadeFactorNumericUpDown.DecimalPlaces = 2;
            this.FadeColorsFadeFactorNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsFadeFactorNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.FadeColorsFadeFactorNumericUpDown.Location = new System.Drawing.Point(194, 83);
            this.FadeColorsFadeFactorNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FadeColorsFadeFactorNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.FadeColorsFadeFactorNumericUpDown.Name = "FadeColorsFadeFactorNumericUpDown";
            this.FadeColorsFadeFactorNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.FadeColorsFadeFactorNumericUpDown.TabIndex = 10;
            this.FadeColorsFadeFactorNumericUpDown.Tag = "Setting";
            this.FadeColorsFadeFactorNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // FadeColorsFadeSpeedLabel
            // 
            this.FadeColorsFadeSpeedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FadeColorsFadeSpeedLabel.Location = new System.Drawing.Point(191, 7);
            this.FadeColorsFadeSpeedLabel.Name = "FadeColorsFadeSpeedLabel";
            this.FadeColorsFadeSpeedLabel.Size = new System.Drawing.Size(171, 15);
            this.FadeColorsFadeSpeedLabel.TabIndex = 46;
            this.FadeColorsFadeSpeedLabel.Text = "Fade speed (ms)";
            this.FadeColorsFadeSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IndividualLEDPanel
            // 
            this.IndividualLEDPanel.BackColor = System.Drawing.Color.DimGray;
            this.IndividualLEDPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndividualLEDPanel.Controls.Add(this.panel22);
            this.IndividualLEDPanel.Controls.Add(this.ColorEntireLEDStripCheckBox);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDRedTrackBar);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDBlueTrackBar);
            this.IndividualLEDPanel.Controls.Add(this.IndividualLEDGreenNameLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividualLEDBlueNameLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividualLEDRedNameLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDRedLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDGreenLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDGreenTrackBar);
            this.IndividualLEDPanel.Controls.Add(this.IndividalLEDBlueLabel);
            this.IndividualLEDPanel.Controls.Add(this.IndividualLEDWorkingPanel);
            this.IndividualLEDPanel.Location = new System.Drawing.Point(81, 21);
            this.IndividualLEDPanel.Name = "IndividualLEDPanel";
            this.IndividualLEDPanel.Size = new System.Drawing.Size(870, 591);
            this.IndividualLEDPanel.TabIndex = 47;
            this.IndividualLEDPanel.Visible = false;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel22.Controls.Add(this.IndividualLEDTopLabel);
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(870, 63);
            this.panel22.TabIndex = 64;
            // 
            // IndividualLEDTopLabel
            // 
            this.IndividualLEDTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualLEDTopLabel.ForeColor = System.Drawing.Color.White;
            this.IndividualLEDTopLabel.Location = new System.Drawing.Point(0, 0);
            this.IndividualLEDTopLabel.Name = "IndividualLEDTopLabel";
            this.IndividualLEDTopLabel.Size = new System.Drawing.Size(870, 63);
            this.IndividualLEDTopLabel.TabIndex = 10;
            this.IndividualLEDTopLabel.Text = "Individual LED Control";
            this.IndividualLEDTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorEntireLEDStripCheckBox
            // 
            this.ColorEntireLEDStripCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorEntireLEDStripCheckBox.ForeColor = System.Drawing.Color.White;
            this.ColorEntireLEDStripCheckBox.Location = new System.Drawing.Point(6, 570);
            this.ColorEntireLEDStripCheckBox.Name = "ColorEntireLEDStripCheckBox";
            this.ColorEntireLEDStripCheckBox.Size = new System.Drawing.Size(261, 15);
            this.ColorEntireLEDStripCheckBox.TabIndex = 9;
            this.ColorEntireLEDStripCheckBox.Tag = "Setting";
            this.ColorEntireLEDStripCheckBox.Text = "Color Entire Strip";
            this.ColorEntireLEDStripCheckBox.UseVisualStyleBackColor = true;
            // 
            // IndividalLEDRedTrackBar
            // 
            this.IndividalLEDRedTrackBar.Location = new System.Drawing.Point(46, 534);
            this.IndividalLEDRedTrackBar.Maximum = 255;
            this.IndividalLEDRedTrackBar.Name = "IndividalLEDRedTrackBar";
            this.IndividalLEDRedTrackBar.Size = new System.Drawing.Size(165, 45);
            this.IndividalLEDRedTrackBar.TabIndex = 6;
            this.IndividalLEDRedTrackBar.Tag = "Setting";
            this.IndividalLEDRedTrackBar.TickFrequency = 10;
            this.IndividalLEDRedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.IndividalLEDRedTrackBar.Value = 255;
            this.IndividalLEDRedTrackBar.Scroll += new System.EventHandler(this.IndividalLEDRedTrackBar_Scroll);
            // 
            // IndividalLEDBlueTrackBar
            // 
            this.IndividalLEDBlueTrackBar.Location = new System.Drawing.Point(641, 534);
            this.IndividalLEDBlueTrackBar.Maximum = 255;
            this.IndividalLEDBlueTrackBar.Name = "IndividalLEDBlueTrackBar";
            this.IndividalLEDBlueTrackBar.Size = new System.Drawing.Size(165, 45);
            this.IndividalLEDBlueTrackBar.TabIndex = 8;
            this.IndividalLEDBlueTrackBar.Tag = "Setting";
            this.IndividalLEDBlueTrackBar.TickFrequency = 10;
            this.IndividalLEDBlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.IndividalLEDBlueTrackBar.Value = 255;
            this.IndividalLEDBlueTrackBar.Scroll += new System.EventHandler(this.IndividalLEDBlueTrackBar_Scroll);
            // 
            // IndividualLEDGreenNameLabel
            // 
            this.IndividualLEDGreenNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualLEDGreenNameLabel.ForeColor = System.Drawing.Color.White;
            this.IndividualLEDGreenNameLabel.Location = new System.Drawing.Point(266, 546);
            this.IndividualLEDGreenNameLabel.Name = "IndividualLEDGreenNameLabel";
            this.IndividualLEDGreenNameLabel.Size = new System.Drawing.Size(75, 15);
            this.IndividualLEDGreenNameLabel.TabIndex = 57;
            this.IndividualLEDGreenNameLabel.Text = "Green";
            this.IndividualLEDGreenNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividualLEDBlueNameLabel
            // 
            this.IndividualLEDBlueNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualLEDBlueNameLabel.ForeColor = System.Drawing.Color.White;
            this.IndividualLEDBlueNameLabel.Location = new System.Drawing.Point(568, 546);
            this.IndividualLEDBlueNameLabel.Name = "IndividualLEDBlueNameLabel";
            this.IndividualLEDBlueNameLabel.Size = new System.Drawing.Size(75, 15);
            this.IndividualLEDBlueNameLabel.TabIndex = 59;
            this.IndividualLEDBlueNameLabel.Text = "Blue";
            this.IndividualLEDBlueNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividualLEDRedNameLabel
            // 
            this.IndividualLEDRedNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualLEDRedNameLabel.ForeColor = System.Drawing.Color.White;
            this.IndividualLEDRedNameLabel.Location = new System.Drawing.Point(-11, 546);
            this.IndividualLEDRedNameLabel.Name = "IndividualLEDRedNameLabel";
            this.IndividualLEDRedNameLabel.Size = new System.Drawing.Size(75, 15);
            this.IndividualLEDRedNameLabel.TabIndex = 55;
            this.IndividualLEDRedNameLabel.Text = "Red";
            this.IndividualLEDRedNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividalLEDRedLabel
            // 
            this.IndividalLEDRedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividalLEDRedLabel.ForeColor = System.Drawing.Color.White;
            this.IndividalLEDRedLabel.Location = new System.Drawing.Point(210, 546);
            this.IndividalLEDRedLabel.Name = "IndividalLEDRedLabel";
            this.IndividalLEDRedLabel.Size = new System.Drawing.Size(38, 15);
            this.IndividalLEDRedLabel.TabIndex = 60;
            this.IndividalLEDRedLabel.Tag = "Setting";
            this.IndividalLEDRedLabel.Text = "255";
            this.IndividalLEDRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividalLEDGreenLabel
            // 
            this.IndividalLEDGreenLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividalLEDGreenLabel.ForeColor = System.Drawing.Color.White;
            this.IndividalLEDGreenLabel.Location = new System.Drawing.Point(516, 546);
            this.IndividalLEDGreenLabel.Name = "IndividalLEDGreenLabel";
            this.IndividalLEDGreenLabel.Size = new System.Drawing.Size(38, 15);
            this.IndividalLEDGreenLabel.TabIndex = 61;
            this.IndividalLEDGreenLabel.Tag = "Setting";
            this.IndividalLEDGreenLabel.Text = "255";
            this.IndividalLEDGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividalLEDGreenTrackBar
            // 
            this.IndividalLEDGreenTrackBar.Location = new System.Drawing.Point(347, 534);
            this.IndividalLEDGreenTrackBar.Maximum = 255;
            this.IndividalLEDGreenTrackBar.Name = "IndividalLEDGreenTrackBar";
            this.IndividalLEDGreenTrackBar.Size = new System.Drawing.Size(165, 45);
            this.IndividalLEDGreenTrackBar.TabIndex = 7;
            this.IndividalLEDGreenTrackBar.Tag = "Setting";
            this.IndividalLEDGreenTrackBar.TickFrequency = 10;
            this.IndividalLEDGreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.IndividalLEDGreenTrackBar.Value = 255;
            this.IndividalLEDGreenTrackBar.Scroll += new System.EventHandler(this.IndividalLEDGreenTrackBar_Scroll);
            // 
            // IndividalLEDBlueLabel
            // 
            this.IndividalLEDBlueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividalLEDBlueLabel.ForeColor = System.Drawing.Color.White;
            this.IndividalLEDBlueLabel.Location = new System.Drawing.Point(812, 546);
            this.IndividalLEDBlueLabel.Name = "IndividalLEDBlueLabel";
            this.IndividalLEDBlueLabel.Size = new System.Drawing.Size(38, 15);
            this.IndividalLEDBlueLabel.TabIndex = 62;
            this.IndividalLEDBlueLabel.Tag = "Setting";
            this.IndividalLEDBlueLabel.Text = "255";
            this.IndividalLEDBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividualLEDWorkingPanel
            // 
            this.IndividualLEDWorkingPanel.BackColor = System.Drawing.Color.Silver;
            this.IndividualLEDWorkingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndividualLEDWorkingPanel.Location = new System.Drawing.Point(20, 71);
            this.IndividualLEDWorkingPanel.Name = "IndividualLEDWorkingPanel";
            this.IndividualLEDWorkingPanel.Size = new System.Drawing.Size(832, 457);
            this.IndividualLEDWorkingPanel.TabIndex = 10;
            this.IndividualLEDWorkingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IndividualLEDWorkingPanel_MouseDown);
            this.IndividualLEDWorkingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IndividualLEDWorkingPanel_MouseMove);
            this.IndividualLEDWorkingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.IndividualLEDWorkingPanel_MouseUp);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "txt";
            this.SaveFileDialog.Filter = "Text File | *.txt";
            // 
            // LoadFileDialog
            // 
            this.LoadFileDialog.DefaultExt = "txt";
            this.LoadFileDialog.FileName = "openFileDialog1";
            this.LoadFileDialog.Filter = "Text File | *.txt";
            // 
            // InstructionsPanel
            // 
            this.InstructionsPanel.BackColor = System.Drawing.Color.DimGray;
            this.InstructionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsPanel.Controls.Add(this.InstructionsAddIndividualLEDPanel);
            this.InstructionsPanel.Controls.Add(this.InstructionsAddFadeColorsPanel);
            this.InstructionsPanel.Controls.Add(this.InstructionStopLoopButton);
            this.InstructionsPanel.Controls.Add(this.InstructionsModeLoadButton);
            this.InstructionsPanel.Controls.Add(this.panel11);
            this.InstructionsPanel.Controls.Add(this.InstructionsLoopCheckBox);
            this.InstructionsPanel.Controls.Add(this.InstructionsModeSaveButton);
            this.InstructionsPanel.Controls.Add(this.InstructionStartLoopButton);
            this.InstructionsPanel.Controls.Add(this.panel21);
            this.InstructionsPanel.Controls.Add(this.InstructionsWorkingPanel);
            this.InstructionsPanel.Controls.Add(this.InstructionsAddAmbilightPanel);
            this.InstructionsPanel.Controls.Add(this.InstructionsAddVisualizerPanel);
            this.InstructionsPanel.Controls.Add(this.InstructionsAddDelayPanel);
            this.InstructionsPanel.Location = new System.Drawing.Point(165, 21);
            this.InstructionsPanel.Name = "InstructionsPanel";
            this.InstructionsPanel.Size = new System.Drawing.Size(786, 710);
            this.InstructionsPanel.TabIndex = 48;
            this.InstructionsPanel.Visible = false;
            // 
            // InstructionsAddIndividualLEDPanel
            // 
            this.InstructionsAddIndividualLEDPanel.BackColor = System.Drawing.Color.Gray;
            this.InstructionsAddIndividualLEDPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDOnPinLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDOnPinNumericUpDown);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDAtIDLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDAtIdNumericUpDown);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDRedTrackBar);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDBlueTrackBar);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDGreenLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDBlueLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDRedLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDRedValueLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDGreenValueLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDGreenTrackBar);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDBlueValueLabel);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDAddButton);
            this.InstructionsAddIndividualLEDPanel.Controls.Add(this.InstructionsAddIndividualLEDPanelTopLabel);
            this.InstructionsAddIndividualLEDPanel.Location = new System.Drawing.Point(219, 495);
            this.InstructionsAddIndividualLEDPanel.Name = "InstructionsAddIndividualLEDPanel";
            this.InstructionsAddIndividualLEDPanel.Size = new System.Drawing.Size(554, 169);
            this.InstructionsAddIndividualLEDPanel.TabIndex = 78;
            this.InstructionsAddIndividualLEDPanel.Visible = false;
            // 
            // InstructionsAddIndividualLEDOnPinLabel
            // 
            this.InstructionsAddIndividualLEDOnPinLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDOnPinLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDOnPinLabel.Location = new System.Drawing.Point(424, 80);
            this.InstructionsAddIndividualLEDOnPinLabel.Name = "InstructionsAddIndividualLEDOnPinLabel";
            this.InstructionsAddIndividualLEDOnPinLabel.Size = new System.Drawing.Size(110, 11);
            this.InstructionsAddIndividualLEDOnPinLabel.TabIndex = 84;
            this.InstructionsAddIndividualLEDOnPinLabel.Text = "On pin:";
            this.InstructionsAddIndividualLEDOnPinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddIndividualLEDOnPinNumericUpDown
            // 
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Location = new System.Drawing.Point(426, 103);
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Name = "InstructionsAddIndividualLEDOnPinNumericUpDown";
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Size = new System.Drawing.Size(110, 14);
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.TabIndex = 83;
            this.InstructionsAddIndividualLEDOnPinNumericUpDown.Tag = "Setting";
            // 
            // InstructionsAddIndividualLEDAtIDLabel
            // 
            this.InstructionsAddIndividualLEDAtIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDAtIDLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDAtIDLabel.Location = new System.Drawing.Point(424, 31);
            this.InstructionsAddIndividualLEDAtIDLabel.Name = "InstructionsAddIndividualLEDAtIDLabel";
            this.InstructionsAddIndividualLEDAtIDLabel.Size = new System.Drawing.Size(110, 11);
            this.InstructionsAddIndividualLEDAtIDLabel.TabIndex = 82;
            this.InstructionsAddIndividualLEDAtIDLabel.Text = "At Hardware ID:";
            this.InstructionsAddIndividualLEDAtIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddIndividualLEDAtIdNumericUpDown
            // 
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Location = new System.Drawing.Point(426, 54);
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Name = "InstructionsAddIndividualLEDAtIdNumericUpDown";
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Size = new System.Drawing.Size(110, 14);
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.TabIndex = 81;
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Tag = "Setting";
            this.InstructionsAddIndividualLEDAtIdNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // InstructionsAddIndividualLEDRedTrackBar
            // 
            this.InstructionsAddIndividualLEDRedTrackBar.Location = new System.Drawing.Point(168, 28);
            this.InstructionsAddIndividualLEDRedTrackBar.Maximum = 255;
            this.InstructionsAddIndividualLEDRedTrackBar.Name = "InstructionsAddIndividualLEDRedTrackBar";
            this.InstructionsAddIndividualLEDRedTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddIndividualLEDRedTrackBar.TabIndex = 72;
            this.InstructionsAddIndividualLEDRedTrackBar.TickFrequency = 10;
            this.InstructionsAddIndividualLEDRedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddIndividualLEDRedTrackBar.Value = 255;
            this.InstructionsAddIndividualLEDRedTrackBar.Scroll += new System.EventHandler(this.InstructionsAddIndividualLEDRedTrackBar_Scroll);
            // 
            // InstructionsAddIndividualLEDBlueTrackBar
            // 
            this.InstructionsAddIndividualLEDBlueTrackBar.Location = new System.Drawing.Point(168, 115);
            this.InstructionsAddIndividualLEDBlueTrackBar.Maximum = 255;
            this.InstructionsAddIndividualLEDBlueTrackBar.Name = "InstructionsAddIndividualLEDBlueTrackBar";
            this.InstructionsAddIndividualLEDBlueTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddIndividualLEDBlueTrackBar.TabIndex = 74;
            this.InstructionsAddIndividualLEDBlueTrackBar.TickFrequency = 10;
            this.InstructionsAddIndividualLEDBlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddIndividualLEDBlueTrackBar.Value = 255;
            this.InstructionsAddIndividualLEDBlueTrackBar.Scroll += new System.EventHandler(this.InstructionsAddIndividualLEDBlueTrackBar_Scroll);
            // 
            // InstructionsAddIndividualLEDGreenLabel
            // 
            this.InstructionsAddIndividualLEDGreenLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDGreenLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDGreenLabel.Location = new System.Drawing.Point(109, 83);
            this.InstructionsAddIndividualLEDGreenLabel.Name = "InstructionsAddIndividualLEDGreenLabel";
            this.InstructionsAddIndividualLEDGreenLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddIndividualLEDGreenLabel.TabIndex = 76;
            this.InstructionsAddIndividualLEDGreenLabel.Text = "Green";
            this.InstructionsAddIndividualLEDGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDBlueLabel
            // 
            this.InstructionsAddIndividualLEDBlueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDBlueLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDBlueLabel.Location = new System.Drawing.Point(109, 126);
            this.InstructionsAddIndividualLEDBlueLabel.Name = "InstructionsAddIndividualLEDBlueLabel";
            this.InstructionsAddIndividualLEDBlueLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddIndividualLEDBlueLabel.TabIndex = 77;
            this.InstructionsAddIndividualLEDBlueLabel.Text = "Blue";
            this.InstructionsAddIndividualLEDBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDRedLabel
            // 
            this.InstructionsAddIndividualLEDRedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDRedLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDRedLabel.Location = new System.Drawing.Point(109, 40);
            this.InstructionsAddIndividualLEDRedLabel.Name = "InstructionsAddIndividualLEDRedLabel";
            this.InstructionsAddIndividualLEDRedLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddIndividualLEDRedLabel.TabIndex = 75;
            this.InstructionsAddIndividualLEDRedLabel.Text = "Red";
            this.InstructionsAddIndividualLEDRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDRedValueLabel
            // 
            this.InstructionsAddIndividualLEDRedValueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDRedValueLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDRedValueLabel.Location = new System.Drawing.Point(379, 38);
            this.InstructionsAddIndividualLEDRedValueLabel.Name = "InstructionsAddIndividualLEDRedValueLabel";
            this.InstructionsAddIndividualLEDRedValueLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddIndividualLEDRedValueLabel.TabIndex = 78;
            this.InstructionsAddIndividualLEDRedValueLabel.Text = "255";
            this.InstructionsAddIndividualLEDRedValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDGreenValueLabel
            // 
            this.InstructionsAddIndividualLEDGreenValueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDGreenValueLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDGreenValueLabel.Location = new System.Drawing.Point(379, 83);
            this.InstructionsAddIndividualLEDGreenValueLabel.Name = "InstructionsAddIndividualLEDGreenValueLabel";
            this.InstructionsAddIndividualLEDGreenValueLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddIndividualLEDGreenValueLabel.TabIndex = 79;
            this.InstructionsAddIndividualLEDGreenValueLabel.Text = "255";
            this.InstructionsAddIndividualLEDGreenValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDGreenTrackBar
            // 
            this.InstructionsAddIndividualLEDGreenTrackBar.Location = new System.Drawing.Point(168, 73);
            this.InstructionsAddIndividualLEDGreenTrackBar.Maximum = 255;
            this.InstructionsAddIndividualLEDGreenTrackBar.Name = "InstructionsAddIndividualLEDGreenTrackBar";
            this.InstructionsAddIndividualLEDGreenTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddIndividualLEDGreenTrackBar.TabIndex = 73;
            this.InstructionsAddIndividualLEDGreenTrackBar.TickFrequency = 10;
            this.InstructionsAddIndividualLEDGreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddIndividualLEDGreenTrackBar.Value = 255;
            this.InstructionsAddIndividualLEDGreenTrackBar.Scroll += new System.EventHandler(this.InstructionsAddIndividualLEDGreenTrackBar_Scroll);
            // 
            // InstructionsAddIndividualLEDBlueValueLabel
            // 
            this.InstructionsAddIndividualLEDBlueValueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDBlueValueLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDBlueValueLabel.Location = new System.Drawing.Point(379, 126);
            this.InstructionsAddIndividualLEDBlueValueLabel.Name = "InstructionsAddIndividualLEDBlueValueLabel";
            this.InstructionsAddIndividualLEDBlueValueLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddIndividualLEDBlueValueLabel.TabIndex = 80;
            this.InstructionsAddIndividualLEDBlueValueLabel.Text = "255";
            this.InstructionsAddIndividualLEDBlueValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddIndividualLEDAddButton
            // 
            this.InstructionsAddIndividualLEDAddButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddIndividualLEDAddButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddIndividualLEDAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddIndividualLEDAddButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDAddButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDAddButton.Location = new System.Drawing.Point(15, 131);
            this.InstructionsAddIndividualLEDAddButton.Name = "InstructionsAddIndividualLEDAddButton";
            this.InstructionsAddIndividualLEDAddButton.Size = new System.Drawing.Size(75, 23);
            this.InstructionsAddIndividualLEDAddButton.TabIndex = 17;
            this.InstructionsAddIndividualLEDAddButton.Text = "Add";
            this.InstructionsAddIndividualLEDAddButton.UseVisualStyleBackColor = false;
            this.InstructionsAddIndividualLEDAddButton.Click += new System.EventHandler(this.InstructionsAddIndividualLEDAddButton_Click);
            // 
            // InstructionsAddIndividualLEDPanelTopLabel
            // 
            this.InstructionsAddIndividualLEDPanelTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDPanelTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDPanelTopLabel.Location = new System.Drawing.Point(4, 3);
            this.InstructionsAddIndividualLEDPanelTopLabel.Name = "InstructionsAddIndividualLEDPanelTopLabel";
            this.InstructionsAddIndividualLEDPanelTopLabel.Size = new System.Drawing.Size(542, 21);
            this.InstructionsAddIndividualLEDPanelTopLabel.TabIndex = 12;
            this.InstructionsAddIndividualLEDPanelTopLabel.Text = "Individual LED Control";
            this.InstructionsAddIndividualLEDPanelTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsPanel
            // 
            this.InstructionsAddFadeColorsPanel.BackColor = System.Drawing.Color.Gray;
            this.InstructionsAddFadeColorsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsToSeriesIDNumericUpDown);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsToSeriesIDLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFadeFactorLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFadeFactorNumericUpDown);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFromSeriesIDLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFadeSpeedLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsFadeSpeedNumericUpDown);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsAddButton);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsRedTrackBar);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsBlueTrackBar);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsGreenNameLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsBlueNameLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsRedNameLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsRedLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsGreenLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsGreenTrackBar);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsBlueLabel);
            this.InstructionsAddFadeColorsPanel.Controls.Add(this.InstructionsAddFadeColorsTopLabel);
            this.InstructionsAddFadeColorsPanel.Location = new System.Drawing.Point(219, 495);
            this.InstructionsAddFadeColorsPanel.Name = "InstructionsAddFadeColorsPanel";
            this.InstructionsAddFadeColorsPanel.Size = new System.Drawing.Size(554, 169);
            this.InstructionsAddFadeColorsPanel.TabIndex = 1;
            this.InstructionsAddFadeColorsPanel.Visible = false;
            // 
            // InstructionsAddFadeColorsToSeriesIDNumericUpDown
            // 
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Location = new System.Drawing.Point(398, 148);
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Name = "InstructionsAddFadeColorsToSeriesIDNumericUpDown";
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.TabIndex = 64;
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Tag = "Setting";
            this.InstructionsAddFadeColorsToSeriesIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // InstructionsAddFadeColorsToSeriesIDLabel
            // 
            this.InstructionsAddFadeColorsToSeriesIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsToSeriesIDLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsToSeriesIDLabel.Location = new System.Drawing.Point(396, 135);
            this.InstructionsAddFadeColorsToSeriesIDLabel.Name = "InstructionsAddFadeColorsToSeriesIDLabel";
            this.InstructionsAddFadeColorsToSeriesIDLabel.Size = new System.Drawing.Size(141, 11);
            this.InstructionsAddFadeColorsToSeriesIDLabel.TabIndex = 66;
            this.InstructionsAddFadeColorsToSeriesIDLabel.Text = "To Series ID";
            this.InstructionsAddFadeColorsToSeriesIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddFadeColorsFadeFactorLabel
            // 
            this.InstructionsAddFadeColorsFadeFactorLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFadeFactorLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFadeFactorLabel.Location = new System.Drawing.Point(395, 51);
            this.InstructionsAddFadeColorsFadeFactorLabel.Name = "InstructionsAddFadeColorsFadeFactorLabel";
            this.InstructionsAddFadeColorsFadeFactorLabel.Size = new System.Drawing.Size(142, 15);
            this.InstructionsAddFadeColorsFadeFactorLabel.TabIndex = 76;
            this.InstructionsAddFadeColorsFadeFactorLabel.Text = "Fade factor";
            this.InstructionsAddFadeColorsFadeFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsFadeFactorNumericUpDown
            // 
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.DecimalPlaces = 2;
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Location = new System.Drawing.Point(398, 74);
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Name = "InstructionsAddFadeColorsFadeFactorNumericUpDown";
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Size = new System.Drawing.Size(120, 14);
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.TabIndex = 16;
            this.InstructionsAddFadeColorsFadeFactorNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // InstructionsAddFadeColorsFromSeriesIDNumericUpDown
            // 
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Location = new System.Drawing.Point(398, 112);
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Name = "InstructionsAddFadeColorsFromSeriesIDNumericUpDown";
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.TabIndex = 63;
            this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Tag = "Setting";
            // 
            // InstructionsAddFadeColorsFromSeriesIDLabel
            // 
            this.InstructionsAddFadeColorsFromSeriesIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFromSeriesIDLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFromSeriesIDLabel.Location = new System.Drawing.Point(396, 98);
            this.InstructionsAddFadeColorsFromSeriesIDLabel.Name = "InstructionsAddFadeColorsFromSeriesIDLabel";
            this.InstructionsAddFadeColorsFromSeriesIDLabel.Size = new System.Drawing.Size(141, 11);
            this.InstructionsAddFadeColorsFromSeriesIDLabel.TabIndex = 65;
            this.InstructionsAddFadeColorsFromSeriesIDLabel.Text = "From series ID";
            this.InstructionsAddFadeColorsFromSeriesIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddFadeColorsFadeSpeedLabel
            // 
            this.InstructionsAddFadeColorsFadeSpeedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFadeSpeedLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFadeSpeedLabel.Location = new System.Drawing.Point(395, 6);
            this.InstructionsAddFadeColorsFadeSpeedLabel.Name = "InstructionsAddFadeColorsFadeSpeedLabel";
            this.InstructionsAddFadeColorsFadeSpeedLabel.Size = new System.Drawing.Size(142, 15);
            this.InstructionsAddFadeColorsFadeSpeedLabel.TabIndex = 74;
            this.InstructionsAddFadeColorsFadeSpeedLabel.Text = "Fade speed (ms)";
            this.InstructionsAddFadeColorsFadeSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsFadeSpeedNumericUpDown
            // 
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Location = new System.Drawing.Point(398, 29);
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Name = "InstructionsAddFadeColorsFadeSpeedNumericUpDown";
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Size = new System.Drawing.Size(120, 14);
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.TabIndex = 15;
            this.InstructionsAddFadeColorsFadeSpeedNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // InstructionsAddFadeColorsAddButton
            // 
            this.InstructionsAddFadeColorsAddButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsAddButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddFadeColorsAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddFadeColorsAddButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsAddButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsAddButton.Location = new System.Drawing.Point(15, 131);
            this.InstructionsAddFadeColorsAddButton.Name = "InstructionsAddFadeColorsAddButton";
            this.InstructionsAddFadeColorsAddButton.Size = new System.Drawing.Size(75, 23);
            this.InstructionsAddFadeColorsAddButton.TabIndex = 17;
            this.InstructionsAddFadeColorsAddButton.Text = "Add";
            this.InstructionsAddFadeColorsAddButton.UseVisualStyleBackColor = false;
            this.InstructionsAddFadeColorsAddButton.Click += new System.EventHandler(this.InstructionsAddFadeColorsAddButton_Click);
            // 
            // InstructionsAddFadeColorsRedTrackBar
            // 
            this.InstructionsAddFadeColorsRedTrackBar.Location = new System.Drawing.Point(148, 30);
            this.InstructionsAddFadeColorsRedTrackBar.Maximum = 255;
            this.InstructionsAddFadeColorsRedTrackBar.Name = "InstructionsAddFadeColorsRedTrackBar";
            this.InstructionsAddFadeColorsRedTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddFadeColorsRedTrackBar.TabIndex = 12;
            this.InstructionsAddFadeColorsRedTrackBar.TickFrequency = 10;
            this.InstructionsAddFadeColorsRedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddFadeColorsRedTrackBar.Value = 255;
            this.InstructionsAddFadeColorsRedTrackBar.Scroll += new System.EventHandler(this.InstructionsAddFadeColorsRedTrackBar_Scroll);
            // 
            // InstructionsAddFadeColorsBlueTrackBar
            // 
            this.InstructionsAddFadeColorsBlueTrackBar.Location = new System.Drawing.Point(148, 117);
            this.InstructionsAddFadeColorsBlueTrackBar.Maximum = 255;
            this.InstructionsAddFadeColorsBlueTrackBar.Name = "InstructionsAddFadeColorsBlueTrackBar";
            this.InstructionsAddFadeColorsBlueTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddFadeColorsBlueTrackBar.TabIndex = 14;
            this.InstructionsAddFadeColorsBlueTrackBar.TickFrequency = 10;
            this.InstructionsAddFadeColorsBlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddFadeColorsBlueTrackBar.Value = 255;
            this.InstructionsAddFadeColorsBlueTrackBar.Scroll += new System.EventHandler(this.InstructionsAddFadeColorsBlueTrackBar_Scroll);
            // 
            // InstructionsAddFadeColorsGreenNameLabel
            // 
            this.InstructionsAddFadeColorsGreenNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsGreenNameLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsGreenNameLabel.Location = new System.Drawing.Point(89, 85);
            this.InstructionsAddFadeColorsGreenNameLabel.Name = "InstructionsAddFadeColorsGreenNameLabel";
            this.InstructionsAddFadeColorsGreenNameLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddFadeColorsGreenNameLabel.TabIndex = 66;
            this.InstructionsAddFadeColorsGreenNameLabel.Text = "Green";
            this.InstructionsAddFadeColorsGreenNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsBlueNameLabel
            // 
            this.InstructionsAddFadeColorsBlueNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsBlueNameLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsBlueNameLabel.Location = new System.Drawing.Point(89, 128);
            this.InstructionsAddFadeColorsBlueNameLabel.Name = "InstructionsAddFadeColorsBlueNameLabel";
            this.InstructionsAddFadeColorsBlueNameLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddFadeColorsBlueNameLabel.TabIndex = 68;
            this.InstructionsAddFadeColorsBlueNameLabel.Text = "Blue";
            this.InstructionsAddFadeColorsBlueNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsRedNameLabel
            // 
            this.InstructionsAddFadeColorsRedNameLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsRedNameLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsRedNameLabel.Location = new System.Drawing.Point(89, 42);
            this.InstructionsAddFadeColorsRedNameLabel.Name = "InstructionsAddFadeColorsRedNameLabel";
            this.InstructionsAddFadeColorsRedNameLabel.Size = new System.Drawing.Size(60, 15);
            this.InstructionsAddFadeColorsRedNameLabel.TabIndex = 64;
            this.InstructionsAddFadeColorsRedNameLabel.Text = "Red";
            this.InstructionsAddFadeColorsRedNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsRedLabel
            // 
            this.InstructionsAddFadeColorsRedLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsRedLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsRedLabel.Location = new System.Drawing.Point(359, 40);
            this.InstructionsAddFadeColorsRedLabel.Name = "InstructionsAddFadeColorsRedLabel";
            this.InstructionsAddFadeColorsRedLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddFadeColorsRedLabel.TabIndex = 69;
            this.InstructionsAddFadeColorsRedLabel.Text = "255";
            this.InstructionsAddFadeColorsRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsGreenLabel
            // 
            this.InstructionsAddFadeColorsGreenLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsGreenLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsGreenLabel.Location = new System.Drawing.Point(359, 85);
            this.InstructionsAddFadeColorsGreenLabel.Name = "InstructionsAddFadeColorsGreenLabel";
            this.InstructionsAddFadeColorsGreenLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddFadeColorsGreenLabel.TabIndex = 70;
            this.InstructionsAddFadeColorsGreenLabel.Text = "255";
            this.InstructionsAddFadeColorsGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsGreenTrackBar
            // 
            this.InstructionsAddFadeColorsGreenTrackBar.Location = new System.Drawing.Point(148, 75);
            this.InstructionsAddFadeColorsGreenTrackBar.Maximum = 255;
            this.InstructionsAddFadeColorsGreenTrackBar.Name = "InstructionsAddFadeColorsGreenTrackBar";
            this.InstructionsAddFadeColorsGreenTrackBar.Size = new System.Drawing.Size(209, 45);
            this.InstructionsAddFadeColorsGreenTrackBar.TabIndex = 13;
            this.InstructionsAddFadeColorsGreenTrackBar.TickFrequency = 10;
            this.InstructionsAddFadeColorsGreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.InstructionsAddFadeColorsGreenTrackBar.Value = 255;
            this.InstructionsAddFadeColorsGreenTrackBar.Scroll += new System.EventHandler(this.InstructionsAddFadeColorsGreenTrackBar_Scroll);
            // 
            // InstructionsAddFadeColorsBlueLabel
            // 
            this.InstructionsAddFadeColorsBlueLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsBlueLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsBlueLabel.Location = new System.Drawing.Point(359, 128);
            this.InstructionsAddFadeColorsBlueLabel.Name = "InstructionsAddFadeColorsBlueLabel";
            this.InstructionsAddFadeColorsBlueLabel.Size = new System.Drawing.Size(41, 15);
            this.InstructionsAddFadeColorsBlueLabel.TabIndex = 71;
            this.InstructionsAddFadeColorsBlueLabel.Text = "255";
            this.InstructionsAddFadeColorsBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddFadeColorsTopLabel
            // 
            this.InstructionsAddFadeColorsTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsTopLabel.Location = new System.Drawing.Point(2, 5);
            this.InstructionsAddFadeColorsTopLabel.Name = "InstructionsAddFadeColorsTopLabel";
            this.InstructionsAddFadeColorsTopLabel.Size = new System.Drawing.Size(387, 21);
            this.InstructionsAddFadeColorsTopLabel.TabIndex = 12;
            this.InstructionsAddFadeColorsTopLabel.Text = "Fade Colors";
            this.InstructionsAddFadeColorsTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionStopLoopButton
            // 
            this.InstructionStopLoopButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionStopLoopButton.FlatAppearance.BorderSize = 0;
            this.InstructionStopLoopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionStopLoopButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionStopLoopButton.ForeColor = System.Drawing.Color.White;
            this.InstructionStopLoopButton.Location = new System.Drawing.Point(89, 640);
            this.InstructionStopLoopButton.Name = "InstructionStopLoopButton";
            this.InstructionStopLoopButton.Size = new System.Drawing.Size(59, 23);
            this.InstructionStopLoopButton.TabIndex = 14;
            this.InstructionStopLoopButton.Text = "Stop";
            this.InstructionStopLoopButton.UseVisualStyleBackColor = false;
            this.InstructionStopLoopButton.Click += new System.EventHandler(this.InstructionStopLoopButton_Click);
            // 
            // InstructionsModeLoadButton
            // 
            this.InstructionsModeLoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.InstructionsModeLoadButton.FlatAppearance.BorderSize = 0;
            this.InstructionsModeLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsModeLoadButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsModeLoadButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsModeLoadButton.Location = new System.Drawing.Point(399, 672);
            this.InstructionsModeLoadButton.Name = "InstructionsModeLoadButton";
            this.InstructionsModeLoadButton.Size = new System.Drawing.Size(374, 23);
            this.InstructionsModeLoadButton.TabIndex = 9;
            this.InstructionsModeLoadButton.Text = "Load instructions";
            this.InstructionsModeLoadButton.UseVisualStyleBackColor = false;
            this.InstructionsModeLoadButton.Click += new System.EventHandler(this.LoadInstructions);
            // 
            // panel11
            // 
            this.panel11.AutoScroll = true;
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.InstructionsAddAmbilightButton);
            this.panel11.Controls.Add(this.InstructionsAddIndividualLEDButton);
            this.panel11.Controls.Add(this.InstructionsAddVisualizerButton);
            this.panel11.Controls.Add(this.InstructionsAddFadeColorsButton);
            this.panel11.Controls.Add(this.InstructionsAddDelayButton);
            this.panel11.Controls.Add(this.InstructionsModeAddItemsLabel);
            this.panel11.Location = new System.Drawing.Point(13, 493);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 143);
            this.panel11.TabIndex = 0;
            // 
            // InstructionsAddAmbilightButton
            // 
            this.InstructionsAddAmbilightButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddAmbilightButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddAmbilightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddAmbilightButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddAmbilightButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightButton.Location = new System.Drawing.Point(3, 126);
            this.InstructionsAddAmbilightButton.Name = "InstructionsAddAmbilightButton";
            this.InstructionsAddAmbilightButton.Size = new System.Drawing.Size(174, 23);
            this.InstructionsAddAmbilightButton.TabIndex = 16;
            this.InstructionsAddAmbilightButton.Text = "Ambilight";
            this.InstructionsAddAmbilightButton.UseVisualStyleBackColor = false;
            this.InstructionsAddAmbilightButton.Click += new System.EventHandler(this.InstructionsAddAmbilightButton_Click);
            // 
            // InstructionsAddIndividualLEDButton
            // 
            this.InstructionsAddIndividualLEDButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddIndividualLEDButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddIndividualLEDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddIndividualLEDButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddIndividualLEDButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddIndividualLEDButton.Location = new System.Drawing.Point(3, 76);
            this.InstructionsAddIndividualLEDButton.Name = "InstructionsAddIndividualLEDButton";
            this.InstructionsAddIndividualLEDButton.Size = new System.Drawing.Size(174, 23);
            this.InstructionsAddIndividualLEDButton.TabIndex = 15;
            this.InstructionsAddIndividualLEDButton.Text = "Individual LEDs";
            this.InstructionsAddIndividualLEDButton.UseVisualStyleBackColor = false;
            this.InstructionsAddIndividualLEDButton.Click += new System.EventHandler(this.InstructionsAddIndividualLEDButton_Click);
            // 
            // InstructionsAddVisualizerButton
            // 
            this.InstructionsAddVisualizerButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddVisualizerButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddVisualizerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddVisualizerButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddVisualizerButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddVisualizerButton.Location = new System.Drawing.Point(3, 101);
            this.InstructionsAddVisualizerButton.Name = "InstructionsAddVisualizerButton";
            this.InstructionsAddVisualizerButton.Size = new System.Drawing.Size(174, 23);
            this.InstructionsAddVisualizerButton.TabIndex = 14;
            this.InstructionsAddVisualizerButton.Text = "Visualizer";
            this.InstructionsAddVisualizerButton.UseVisualStyleBackColor = false;
            this.InstructionsAddVisualizerButton.Click += new System.EventHandler(this.InstructionsAddVisualizerButton_Click);
            // 
            // InstructionsAddFadeColorsButton
            // 
            this.InstructionsAddFadeColorsButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddFadeColorsButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddFadeColorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddFadeColorsButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddFadeColorsButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddFadeColorsButton.Location = new System.Drawing.Point(3, 51);
            this.InstructionsAddFadeColorsButton.Name = "InstructionsAddFadeColorsButton";
            this.InstructionsAddFadeColorsButton.Size = new System.Drawing.Size(174, 23);
            this.InstructionsAddFadeColorsButton.TabIndex = 11;
            this.InstructionsAddFadeColorsButton.Text = "Fade Colors";
            this.InstructionsAddFadeColorsButton.UseVisualStyleBackColor = false;
            this.InstructionsAddFadeColorsButton.Click += new System.EventHandler(this.InstructionsAddFadeColorsButton_Click);
            // 
            // InstructionsAddDelayButton
            // 
            this.InstructionsAddDelayButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddDelayButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddDelayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddDelayButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayButton.Location = new System.Drawing.Point(3, 26);
            this.InstructionsAddDelayButton.Name = "InstructionsAddDelayButton";
            this.InstructionsAddDelayButton.Size = new System.Drawing.Size(174, 23);
            this.InstructionsAddDelayButton.TabIndex = 10;
            this.InstructionsAddDelayButton.Text = "Delay";
            this.InstructionsAddDelayButton.UseVisualStyleBackColor = false;
            this.InstructionsAddDelayButton.Click += new System.EventHandler(this.InstructionsAddDelayButton_Click);
            // 
            // InstructionsModeAddItemsLabel
            // 
            this.InstructionsModeAddItemsLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsModeAddItemsLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsModeAddItemsLabel.Location = new System.Drawing.Point(4, 3);
            this.InstructionsModeAddItemsLabel.Name = "InstructionsModeAddItemsLabel";
            this.InstructionsModeAddItemsLabel.Size = new System.Drawing.Size(174, 21);
            this.InstructionsModeAddItemsLabel.TabIndex = 13;
            this.InstructionsModeAddItemsLabel.Text = "Add items";
            this.InstructionsModeAddItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsLoopCheckBox
            // 
            this.InstructionsLoopCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLoopCheckBox.ForeColor = System.Drawing.Color.White;
            this.InstructionsLoopCheckBox.Location = new System.Drawing.Point(13, 645);
            this.InstructionsLoopCheckBox.Name = "InstructionsLoopCheckBox";
            this.InstructionsLoopCheckBox.Size = new System.Drawing.Size(95, 15);
            this.InstructionsLoopCheckBox.TabIndex = 7;
            this.InstructionsLoopCheckBox.Text = "Loop";
            this.InstructionsLoopCheckBox.UseVisualStyleBackColor = true;
            // 
            // InstructionsModeSaveButton
            // 
            this.InstructionsModeSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.InstructionsModeSaveButton.FlatAppearance.BorderSize = 0;
            this.InstructionsModeSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsModeSaveButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsModeSaveButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsModeSaveButton.Location = new System.Drawing.Point(13, 672);
            this.InstructionsModeSaveButton.Name = "InstructionsModeSaveButton";
            this.InstructionsModeSaveButton.Size = new System.Drawing.Size(374, 23);
            this.InstructionsModeSaveButton.TabIndex = 8;
            this.InstructionsModeSaveButton.Text = "Save instructions";
            this.InstructionsModeSaveButton.UseVisualStyleBackColor = false;
            this.InstructionsModeSaveButton.Click += new System.EventHandler(this.SaveInstructions);
            // 
            // InstructionStartLoopButton
            // 
            this.InstructionStartLoopButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionStartLoopButton.FlatAppearance.BorderSize = 0;
            this.InstructionStartLoopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionStartLoopButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionStartLoopButton.ForeColor = System.Drawing.Color.White;
            this.InstructionStartLoopButton.Location = new System.Drawing.Point(154, 640);
            this.InstructionStartLoopButton.Name = "InstructionStartLoopButton";
            this.InstructionStartLoopButton.Size = new System.Drawing.Size(59, 23);
            this.InstructionStartLoopButton.TabIndex = 6;
            this.InstructionStartLoopButton.Text = "Start";
            this.InstructionStartLoopButton.UseVisualStyleBackColor = false;
            this.InstructionStartLoopButton.Click += new System.EventHandler(this.InstructionStartLoopButton_Click);
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel21.Controls.Add(this.InstructionsModeTopLabel);
            this.panel21.Location = new System.Drawing.Point(0, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(786, 63);
            this.panel21.TabIndex = 69;
            // 
            // InstructionsModeTopLabel
            // 
            this.InstructionsModeTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsModeTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsModeTopLabel.Location = new System.Drawing.Point(0, 0);
            this.InstructionsModeTopLabel.Name = "InstructionsModeTopLabel";
            this.InstructionsModeTopLabel.Size = new System.Drawing.Size(786, 63);
            this.InstructionsModeTopLabel.TabIndex = 10;
            this.InstructionsModeTopLabel.Text = "Instructions Mode";
            this.InstructionsModeTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsWorkingPanel
            // 
            this.InstructionsWorkingPanel.AutoScroll = true;
            this.InstructionsWorkingPanel.BackColor = System.Drawing.Color.Silver;
            this.InstructionsWorkingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsWorkingPanel.Location = new System.Drawing.Point(8, 73);
            this.InstructionsWorkingPanel.Name = "InstructionsWorkingPanel";
            this.InstructionsWorkingPanel.Size = new System.Drawing.Size(768, 414);
            this.InstructionsWorkingPanel.TabIndex = 18;
            // 
            // InstructionsAddAmbilightPanel
            // 
            this.InstructionsAddAmbilightPanel.BackColor = System.Drawing.Color.Gray;
            this.InstructionsAddAmbilightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightShowHideBlocksCheckBox);
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightAutoSetOffsetsCheckBox);
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightStopAmbilightCheckBox);
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightUseAmbilightSettings);
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightAddButton);
            this.InstructionsAddAmbilightPanel.Controls.Add(this.InstructionsAddAmbilightTopLabel);
            this.InstructionsAddAmbilightPanel.Location = new System.Drawing.Point(219, 495);
            this.InstructionsAddAmbilightPanel.Name = "InstructionsAddAmbilightPanel";
            this.InstructionsAddAmbilightPanel.Size = new System.Drawing.Size(554, 169);
            this.InstructionsAddAmbilightPanel.TabIndex = 78;
            this.InstructionsAddAmbilightPanel.Visible = false;
            // 
            // InstructionsAddAmbilightShowHideBlocksCheckBox
            // 
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.Location = new System.Drawing.Point(14, 92);
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.Name = "InstructionsAddAmbilightShowHideBlocksCheckBox";
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.Size = new System.Drawing.Size(226, 17);
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.TabIndex = 22;
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.Tag = "Setting";
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.Text = "Show / hide Blocks";
            this.InstructionsAddAmbilightShowHideBlocksCheckBox.UseVisualStyleBackColor = false;
            // 
            // InstructionsAddAmbilightAutoSetOffsetsCheckBox
            // 
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.Location = new System.Drawing.Point(254, 69);
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.Name = "InstructionsAddAmbilightAutoSetOffsetsCheckBox";
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.Size = new System.Drawing.Size(226, 17);
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.TabIndex = 21;
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.Tag = "Setting";
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.Text = "Autoset offsets";
            this.InstructionsAddAmbilightAutoSetOffsetsCheckBox.UseVisualStyleBackColor = false;
            // 
            // InstructionsAddAmbilightStopAmbilightCheckBox
            // 
            this.InstructionsAddAmbilightStopAmbilightCheckBox.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightStopAmbilightCheckBox.Location = new System.Drawing.Point(15, 69);
            this.InstructionsAddAmbilightStopAmbilightCheckBox.Name = "InstructionsAddAmbilightStopAmbilightCheckBox";
            this.InstructionsAddAmbilightStopAmbilightCheckBox.Size = new System.Drawing.Size(226, 17);
            this.InstructionsAddAmbilightStopAmbilightCheckBox.TabIndex = 19;
            this.InstructionsAddAmbilightStopAmbilightCheckBox.Tag = "Setting";
            this.InstructionsAddAmbilightStopAmbilightCheckBox.Text = "Stop Ambilight";
            this.InstructionsAddAmbilightStopAmbilightCheckBox.UseVisualStyleBackColor = false;
            // 
            // InstructionsAddAmbilightUseAmbilightSettings
            // 
            this.InstructionsAddAmbilightUseAmbilightSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.InstructionsAddAmbilightUseAmbilightSettings.FlatAppearance.BorderSize = 0;
            this.InstructionsAddAmbilightUseAmbilightSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddAmbilightUseAmbilightSettings.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddAmbilightUseAmbilightSettings.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightUseAmbilightSettings.Location = new System.Drawing.Point(15, 36);
            this.InstructionsAddAmbilightUseAmbilightSettings.Name = "InstructionsAddAmbilightUseAmbilightSettings";
            this.InstructionsAddAmbilightUseAmbilightSettings.Size = new System.Drawing.Size(226, 23);
            this.InstructionsAddAmbilightUseAmbilightSettings.TabIndex = 18;
            this.InstructionsAddAmbilightUseAmbilightSettings.Text = "Ambilight settings to use";
            this.InstructionsAddAmbilightUseAmbilightSettings.UseVisualStyleBackColor = false;
            this.InstructionsAddAmbilightUseAmbilightSettings.Click += new System.EventHandler(this.InstructionsAddAmbilightUseAmbilightSettings_Click);
            // 
            // InstructionsAddAmbilightAddButton
            // 
            this.InstructionsAddAmbilightAddButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddAmbilightAddButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddAmbilightAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddAmbilightAddButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddAmbilightAddButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightAddButton.Location = new System.Drawing.Point(15, 131);
            this.InstructionsAddAmbilightAddButton.Name = "InstructionsAddAmbilightAddButton";
            this.InstructionsAddAmbilightAddButton.Size = new System.Drawing.Size(75, 23);
            this.InstructionsAddAmbilightAddButton.TabIndex = 17;
            this.InstructionsAddAmbilightAddButton.Text = "Add";
            this.InstructionsAddAmbilightAddButton.UseVisualStyleBackColor = false;
            this.InstructionsAddAmbilightAddButton.Click += new System.EventHandler(this.InstructionsAddAmbilightAddButton_Click);
            // 
            // InstructionsAddAmbilightTopLabel
            // 
            this.InstructionsAddAmbilightTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddAmbilightTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddAmbilightTopLabel.Location = new System.Drawing.Point(4, 3);
            this.InstructionsAddAmbilightTopLabel.Name = "InstructionsAddAmbilightTopLabel";
            this.InstructionsAddAmbilightTopLabel.Size = new System.Drawing.Size(542, 21);
            this.InstructionsAddAmbilightTopLabel.TabIndex = 12;
            this.InstructionsAddAmbilightTopLabel.Text = "Ambilight";
            this.InstructionsAddAmbilightTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddVisualizerPanel
            // 
            this.InstructionsAddVisualizerPanel.BackColor = System.Drawing.Color.Gray;
            this.InstructionsAddVisualizerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsAddVisualizerPanel.Controls.Add(this.InstructionsAddVisualizerStopVisualizerCheckBox);
            this.InstructionsAddVisualizerPanel.Controls.Add(this.InstructionsAddVisualizerLoadSetup);
            this.InstructionsAddVisualizerPanel.Controls.Add(this.InstructionsAddVisualizerPanelAdd);
            this.InstructionsAddVisualizerPanel.Controls.Add(this.InstructionsAddVisualizerTopLabel);
            this.InstructionsAddVisualizerPanel.Location = new System.Drawing.Point(219, 495);
            this.InstructionsAddVisualizerPanel.Name = "InstructionsAddVisualizerPanel";
            this.InstructionsAddVisualizerPanel.Size = new System.Drawing.Size(554, 169);
            this.InstructionsAddVisualizerPanel.TabIndex = 77;
            this.InstructionsAddVisualizerPanel.Visible = false;
            // 
            // InstructionsAddVisualizerStopVisualizerCheckBox
            // 
            this.InstructionsAddVisualizerStopVisualizerCheckBox.AutoSize = true;
            this.InstructionsAddVisualizerStopVisualizerCheckBox.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddVisualizerStopVisualizerCheckBox.Location = new System.Drawing.Point(15, 69);
            this.InstructionsAddVisualizerStopVisualizerCheckBox.Name = "InstructionsAddVisualizerStopVisualizerCheckBox";
            this.InstructionsAddVisualizerStopVisualizerCheckBox.Size = new System.Drawing.Size(94, 17);
            this.InstructionsAddVisualizerStopVisualizerCheckBox.TabIndex = 19;
            this.InstructionsAddVisualizerStopVisualizerCheckBox.Tag = "Setting";
            this.InstructionsAddVisualizerStopVisualizerCheckBox.Text = "Stop visualizer";
            this.InstructionsAddVisualizerStopVisualizerCheckBox.UseVisualStyleBackColor = false;
            // 
            // InstructionsAddVisualizerLoadSetup
            // 
            this.InstructionsAddVisualizerLoadSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.InstructionsAddVisualizerLoadSetup.FlatAppearance.BorderSize = 0;
            this.InstructionsAddVisualizerLoadSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddVisualizerLoadSetup.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddVisualizerLoadSetup.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddVisualizerLoadSetup.Location = new System.Drawing.Point(15, 36);
            this.InstructionsAddVisualizerLoadSetup.Name = "InstructionsAddVisualizerLoadSetup";
            this.InstructionsAddVisualizerLoadSetup.Size = new System.Drawing.Size(226, 23);
            this.InstructionsAddVisualizerLoadSetup.TabIndex = 18;
            this.InstructionsAddVisualizerLoadSetup.Text = "Visualizer settings to use";
            this.InstructionsAddVisualizerLoadSetup.UseVisualStyleBackColor = false;
            this.InstructionsAddVisualizerLoadSetup.Click += new System.EventHandler(this.InstructionsAddVisualizerLoadSetup_Click);
            // 
            // InstructionsAddVisualizerPanelAdd
            // 
            this.InstructionsAddVisualizerPanelAdd.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddVisualizerPanelAdd.FlatAppearance.BorderSize = 0;
            this.InstructionsAddVisualizerPanelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddVisualizerPanelAdd.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddVisualizerPanelAdd.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddVisualizerPanelAdd.Location = new System.Drawing.Point(15, 131);
            this.InstructionsAddVisualizerPanelAdd.Name = "InstructionsAddVisualizerPanelAdd";
            this.InstructionsAddVisualizerPanelAdd.Size = new System.Drawing.Size(75, 23);
            this.InstructionsAddVisualizerPanelAdd.TabIndex = 17;
            this.InstructionsAddVisualizerPanelAdd.Text = "Add";
            this.InstructionsAddVisualizerPanelAdd.UseVisualStyleBackColor = false;
            this.InstructionsAddVisualizerPanelAdd.Click += new System.EventHandler(this.InstructionsAddVisualizerPanelAdd_Click);
            // 
            // InstructionsAddVisualizerTopLabel
            // 
            this.InstructionsAddVisualizerTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddVisualizerTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddVisualizerTopLabel.Location = new System.Drawing.Point(4, 3);
            this.InstructionsAddVisualizerTopLabel.Name = "InstructionsAddVisualizerTopLabel";
            this.InstructionsAddVisualizerTopLabel.Size = new System.Drawing.Size(542, 21);
            this.InstructionsAddVisualizerTopLabel.TabIndex = 12;
            this.InstructionsAddVisualizerTopLabel.Text = "Visualizer";
            this.InstructionsAddVisualizerTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsAddDelayPanel
            // 
            this.InstructionsAddDelayPanel.BackColor = System.Drawing.Color.Gray;
            this.InstructionsAddDelayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionsAddDelayPanel.Controls.Add(this.InstructionsAddDelayAddButton);
            this.InstructionsAddDelayPanel.Controls.Add(this.InstructionsAddDelayNoteLabel);
            this.InstructionsAddDelayPanel.Controls.Add(this.InstructionsAddDelayLabel);
            this.InstructionsAddDelayPanel.Controls.Add(this.InstructionsAddDelayNumericUpDown);
            this.InstructionsAddDelayPanel.Controls.Add(this.InstructionsAddDelayTopLabel);
            this.InstructionsAddDelayPanel.Location = new System.Drawing.Point(219, 495);
            this.InstructionsAddDelayPanel.Name = "InstructionsAddDelayPanel";
            this.InstructionsAddDelayPanel.Size = new System.Drawing.Size(554, 169);
            this.InstructionsAddDelayPanel.TabIndex = 13;
            // 
            // InstructionsAddDelayAddButton
            // 
            this.InstructionsAddDelayAddButton.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddDelayAddButton.FlatAppearance.BorderSize = 0;
            this.InstructionsAddDelayAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsAddDelayAddButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayAddButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayAddButton.Location = new System.Drawing.Point(15, 135);
            this.InstructionsAddDelayAddButton.Name = "InstructionsAddDelayAddButton";
            this.InstructionsAddDelayAddButton.Size = new System.Drawing.Size(75, 23);
            this.InstructionsAddDelayAddButton.TabIndex = 13;
            this.InstructionsAddDelayAddButton.Text = "Add";
            this.InstructionsAddDelayAddButton.UseVisualStyleBackColor = false;
            this.InstructionsAddDelayAddButton.Click += new System.EventHandler(this.InstructionsAddDelayAddButton_Click);
            // 
            // InstructionsAddDelayNoteLabel
            // 
            this.InstructionsAddDelayNoteLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayNoteLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayNoteLabel.Location = new System.Drawing.Point(12, 62);
            this.InstructionsAddDelayNoteLabel.Name = "InstructionsAddDelayNoteLabel";
            this.InstructionsAddDelayNoteLabel.Size = new System.Drawing.Size(531, 15);
            this.InstructionsAddDelayNoteLabel.TabIndex = 52;
            this.InstructionsAddDelayNoteLabel.Text = "(delay should be no less than 10 ms)";
            this.InstructionsAddDelayNoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddDelayLabel
            // 
            this.InstructionsAddDelayLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayLabel.Location = new System.Drawing.Point(12, 35);
            this.InstructionsAddDelayLabel.Name = "InstructionsAddDelayLabel";
            this.InstructionsAddDelayLabel.Size = new System.Drawing.Size(246, 15);
            this.InstructionsAddDelayLabel.TabIndex = 51;
            this.InstructionsAddDelayLabel.Text = "Select delay (ms)";
            this.InstructionsAddDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsAddDelayNumericUpDown
            // 
            this.InstructionsAddDelayNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.InstructionsAddDelayNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayNumericUpDown.Location = new System.Drawing.Point(264, 33);
            this.InstructionsAddDelayNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.InstructionsAddDelayNumericUpDown.Name = "InstructionsAddDelayNumericUpDown";
            this.InstructionsAddDelayNumericUpDown.Size = new System.Drawing.Size(120, 18);
            this.InstructionsAddDelayNumericUpDown.TabIndex = 12;
            // 
            // InstructionsAddDelayTopLabel
            // 
            this.InstructionsAddDelayTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsAddDelayTopLabel.ForeColor = System.Drawing.Color.White;
            this.InstructionsAddDelayTopLabel.Location = new System.Drawing.Point(-1, 4);
            this.InstructionsAddDelayTopLabel.Name = "InstructionsAddDelayTopLabel";
            this.InstructionsAddDelayTopLabel.Size = new System.Drawing.Size(554, 21);
            this.InstructionsAddDelayTopLabel.TabIndex = 12;
            this.InstructionsAddDelayTopLabel.Text = "Delay";
            this.InstructionsAddDelayTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigureSetupPanel
            // 
            this.ConfigureSetupPanel.BackColor = System.Drawing.Color.DimGray;
            this.ConfigureSetupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigureSetupPanel.Controls.Add(this.panel2);
            this.ConfigureSetupPanel.Controls.Add(this.EnableDataCompressionMode);
            this.ConfigureSetupPanel.Controls.Add(this.panel1);
            this.ConfigureSetupPanel.Controls.Add(this.panel20);
            this.ConfigureSetupPanel.Controls.Add(this.SendSetupProgressBar);
            this.ConfigureSetupPanel.Controls.Add(this.SendSetupButton);
            this.ConfigureSetupPanel.Controls.Add(this.LoadSetupButton);
            this.ConfigureSetupPanel.Controls.Add(this.SaveSetupButton);
            this.ConfigureSetupPanel.Controls.Add(this.panel17);
            this.ConfigureSetupPanel.Controls.Add(this.ConfigureSetupWorkingPanel);
            this.ConfigureSetupPanel.Controls.Add(this.ConfigureSetupAutoSendCheckBox);
            this.ConfigureSetupPanel.Location = new System.Drawing.Point(79, 21);
            this.ConfigureSetupPanel.Name = "ConfigureSetupPanel";
            this.ConfigureSetupPanel.Size = new System.Drawing.Size(871, 715);
            this.ConfigureSetupPanel.TabIndex = 49;
            this.ConfigureSetupPanel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderThirdTextbox);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderSeccondTextbox);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderFirstTextbox);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderThirdLabel);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderSeccondLabel);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderFirstLabel);
            this.panel2.Controls.Add(this.ConfigureSetupRGBColorOrderLabel);
            this.panel2.Location = new System.Drawing.Point(20, 661);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 47);
            this.panel2.TabIndex = 71;
            // 
            // ConfigureSetupRGBColorOrderThirdTextbox
            // 
            this.ConfigureSetupRGBColorOrderThirdTextbox.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupRGBColorOrderThirdTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupRGBColorOrderThirdTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderThirdTextbox.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderThirdTextbox.Location = new System.Drawing.Point(493, 25);
            this.ConfigureSetupRGBColorOrderThirdTextbox.Name = "ConfigureSetupRGBColorOrderThirdTextbox";
            this.ConfigureSetupRGBColorOrderThirdTextbox.Size = new System.Drawing.Size(69, 13);
            this.ConfigureSetupRGBColorOrderThirdTextbox.TabIndex = 58;
            this.ConfigureSetupRGBColorOrderThirdTextbox.Tag = "Setting";
            this.ConfigureSetupRGBColorOrderThirdTextbox.Text = "B";
            this.ConfigureSetupRGBColorOrderThirdTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSetupRGBColorOrderTextboxes_KeyPress);
            // 
            // ConfigureSetupRGBColorOrderSeccondTextbox
            // 
            this.ConfigureSetupRGBColorOrderSeccondTextbox.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupRGBColorOrderSeccondTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderSeccondTextbox.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Location = new System.Drawing.Point(302, 25);
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Name = "ConfigureSetupRGBColorOrderSeccondTextbox";
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Size = new System.Drawing.Size(69, 13);
            this.ConfigureSetupRGBColorOrderSeccondTextbox.TabIndex = 57;
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Tag = "Setting";
            this.ConfigureSetupRGBColorOrderSeccondTextbox.Text = "G";
            this.ConfigureSetupRGBColorOrderSeccondTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSetupRGBColorOrderTextboxes_KeyPress);
            // 
            // ConfigureSetupRGBColorOrderFirstTextbox
            // 
            this.ConfigureSetupRGBColorOrderFirstTextbox.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupRGBColorOrderFirstTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupRGBColorOrderFirstTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderFirstTextbox.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderFirstTextbox.Location = new System.Drawing.Point(111, 25);
            this.ConfigureSetupRGBColorOrderFirstTextbox.Name = "ConfigureSetupRGBColorOrderFirstTextbox";
            this.ConfigureSetupRGBColorOrderFirstTextbox.Size = new System.Drawing.Size(69, 13);
            this.ConfigureSetupRGBColorOrderFirstTextbox.TabIndex = 56;
            this.ConfigureSetupRGBColorOrderFirstTextbox.Tag = "Setting";
            this.ConfigureSetupRGBColorOrderFirstTextbox.Text = "R";
            this.ConfigureSetupRGBColorOrderFirstTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigureSetupRGBColorOrderTextboxes_KeyPress);
            // 
            // ConfigureSetupRGBColorOrderThirdLabel
            // 
            this.ConfigureSetupRGBColorOrderThirdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderThirdLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderThirdLabel.Location = new System.Drawing.Point(385, 24);
            this.ConfigureSetupRGBColorOrderThirdLabel.Name = "ConfigureSetupRGBColorOrderThirdLabel";
            this.ConfigureSetupRGBColorOrderThirdLabel.Size = new System.Drawing.Size(94, 15);
            this.ConfigureSetupRGBColorOrderThirdLabel.TabIndex = 55;
            this.ConfigureSetupRGBColorOrderThirdLabel.Text = "Third:";
            // 
            // ConfigureSetupRGBColorOrderSeccondLabel
            // 
            this.ConfigureSetupRGBColorOrderSeccondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderSeccondLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderSeccondLabel.Location = new System.Drawing.Point(194, 24);
            this.ConfigureSetupRGBColorOrderSeccondLabel.Name = "ConfigureSetupRGBColorOrderSeccondLabel";
            this.ConfigureSetupRGBColorOrderSeccondLabel.Size = new System.Drawing.Size(94, 15);
            this.ConfigureSetupRGBColorOrderSeccondLabel.TabIndex = 54;
            this.ConfigureSetupRGBColorOrderSeccondLabel.Text = "Seccond:";
            // 
            // ConfigureSetupRGBColorOrderFirstLabel
            // 
            this.ConfigureSetupRGBColorOrderFirstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderFirstLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderFirstLabel.Location = new System.Drawing.Point(3, 24);
            this.ConfigureSetupRGBColorOrderFirstLabel.Name = "ConfigureSetupRGBColorOrderFirstLabel";
            this.ConfigureSetupRGBColorOrderFirstLabel.Size = new System.Drawing.Size(94, 15);
            this.ConfigureSetupRGBColorOrderFirstLabel.TabIndex = 53;
            this.ConfigureSetupRGBColorOrderFirstLabel.Text = "First:";
            // 
            // ConfigureSetupRGBColorOrderLabel
            // 
            this.ConfigureSetupRGBColorOrderLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupRGBColorOrderLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupRGBColorOrderLabel.Location = new System.Drawing.Point(3, 3);
            this.ConfigureSetupRGBColorOrderLabel.Name = "ConfigureSetupRGBColorOrderLabel";
            this.ConfigureSetupRGBColorOrderLabel.Size = new System.Drawing.Size(297, 15);
            this.ConfigureSetupRGBColorOrderLabel.TabIndex = 52;
            this.ConfigureSetupRGBColorOrderLabel.Text = "RGB Color order";
            // 
            // EnableDataCompressionMode
            // 
            this.EnableDataCompressionMode.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableDataCompressionMode.ForeColor = System.Drawing.Color.White;
            this.EnableDataCompressionMode.Location = new System.Drawing.Point(609, 651);
            this.EnableDataCompressionMode.Name = "EnableDataCompressionMode";
            this.EnableDataCompressionMode.Size = new System.Drawing.Size(240, 15);
            this.EnableDataCompressionMode.TabIndex = 70;
            this.EnableDataCompressionMode.Tag = "Setting";
            this.EnableDataCompressionMode.Text = "Enable data compression mode";
            this.EnableDataCompressionMode.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ConfigureSetupClickToSetupSeriesFromIDLabel);
            this.panel1.Controls.Add(this.ConfigureSetupClickToSetupSeriesCheckBox);
            this.panel1.Controls.Add(this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown);
            this.panel1.Location = new System.Drawing.Point(20, 624);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 36);
            this.panel1.TabIndex = 54;
            // 
            // ConfigureSetupClickToSetupSeriesFromIDLabel
            // 
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.Location = new System.Drawing.Point(372, 10);
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.Name = "ConfigureSetupClickToSetupSeriesFromIDLabel";
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.Size = new System.Drawing.Size(70, 15);
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.TabIndex = 71;
            this.ConfigureSetupClickToSetupSeriesFromIDLabel.Text = "From ID";
            // 
            // ConfigureSetupClickToSetupSeriesCheckBox
            // 
            this.ConfigureSetupClickToSetupSeriesCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupClickToSetupSeriesCheckBox.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupClickToSetupSeriesCheckBox.Location = new System.Drawing.Point(3, 10);
            this.ConfigureSetupClickToSetupSeriesCheckBox.Name = "ConfigureSetupClickToSetupSeriesCheckBox";
            this.ConfigureSetupClickToSetupSeriesCheckBox.Size = new System.Drawing.Size(363, 15);
            this.ConfigureSetupClickToSetupSeriesCheckBox.TabIndex = 69;
            this.ConfigureSetupClickToSetupSeriesCheckBox.Tag = "Setting";
            this.ConfigureSetupClickToSetupSeriesCheckBox.Text = "Click to setup series ID";
            this.ConfigureSetupClickToSetupSeriesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigureSetupClickToSetupSeriesFromIDNumericUpDown
            // 
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Location = new System.Drawing.Point(446, 10);
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Name = "ConfigureSetupClickToSetupSeriesFromIDNumericUpDown";
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Size = new System.Drawing.Size(120, 14);
            this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.TabIndex = 70;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel20.Controls.Add(this.ConfigureSetupTopLabel);
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(871, 63);
            this.panel20.TabIndex = 68;
            // 
            // ConfigureSetupTopLabel
            // 
            this.ConfigureSetupTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupTopLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupTopLabel.Location = new System.Drawing.Point(0, 0);
            this.ConfigureSetupTopLabel.Name = "ConfigureSetupTopLabel";
            this.ConfigureSetupTopLabel.Size = new System.Drawing.Size(871, 63);
            this.ConfigureSetupTopLabel.TabIndex = 10;
            this.ConfigureSetupTopLabel.Text = "Configure Setup";
            this.ConfigureSetupTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SendSetupProgressBar
            // 
            this.SendSetupProgressBar.Location = new System.Drawing.Point(609, 622);
            this.SendSetupProgressBar.Name = "SendSetupProgressBar";
            this.SendSetupProgressBar.Size = new System.Drawing.Size(240, 23);
            this.SendSetupProgressBar.TabIndex = 67;
            // 
            // SendSetupButton
            // 
            this.SendSetupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.SendSetupButton.FlatAppearance.BorderSize = 0;
            this.SendSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendSetupButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendSetupButton.ForeColor = System.Drawing.Color.White;
            this.SendSetupButton.Location = new System.Drawing.Point(608, 593);
            this.SendSetupButton.Name = "SendSetupButton";
            this.SendSetupButton.Size = new System.Drawing.Size(241, 23);
            this.SendSetupButton.TabIndex = 6;
            this.SendSetupButton.Text = "Send Setup";
            this.SendSetupButton.UseVisualStyleBackColor = false;
            this.SendSetupButton.Click += new System.EventHandler(this.SendSetupButton_Click);
            // 
            // LoadSetupButton
            // 
            this.LoadSetupButton.BackColor = System.Drawing.Color.DarkGray;
            this.LoadSetupButton.FlatAppearance.BorderSize = 0;
            this.LoadSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSetupButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadSetupButton.ForeColor = System.Drawing.Color.White;
            this.LoadSetupButton.Location = new System.Drawing.Point(608, 564);
            this.LoadSetupButton.Name = "LoadSetupButton";
            this.LoadSetupButton.Size = new System.Drawing.Size(241, 23);
            this.LoadSetupButton.TabIndex = 7;
            this.LoadSetupButton.Text = "Load A Setup";
            this.LoadSetupButton.UseVisualStyleBackColor = false;
            this.LoadSetupButton.Click += new System.EventHandler(this.LoadSetup);
            // 
            // SaveSetupButton
            // 
            this.SaveSetupButton.BackColor = System.Drawing.Color.DarkGray;
            this.SaveSetupButton.FlatAppearance.BorderSize = 0;
            this.SaveSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSetupButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveSetupButton.ForeColor = System.Drawing.Color.White;
            this.SaveSetupButton.Location = new System.Drawing.Point(608, 535);
            this.SaveSetupButton.Name = "SaveSetupButton";
            this.SaveSetupButton.Size = new System.Drawing.Size(241, 23);
            this.SaveSetupButton.TabIndex = 8;
            this.SaveSetupButton.Text = "Save Setup";
            this.SaveSetupButton.UseVisualStyleBackColor = false;
            this.SaveSetupButton.Click += new System.EventHandler(this.SaveSetup);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Gray;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.PixelBitstreamComboBoxLabel);
            this.panel17.Controls.Add(this.PixelBitstreamComboBox);
            this.panel17.Controls.Add(this.PixelTypeComboBoxLabel);
            this.panel17.Controls.Add(this.PixelTypeComboBox);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripPinIDLabel);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripPinID);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripInvertY);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripInvertX);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripFromLEDIDLabel);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripFromLEDID);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripXDir);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripYDirLabel);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripYDir);
            this.panel17.Controls.Add(this.ConfigureSetupAddStripXDirLabel);
            this.panel17.Controls.Add(this.AddLEDStripButton);
            this.panel17.Location = new System.Drawing.Point(20, 534);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(580, 89);
            this.panel17.TabIndex = 53;
            // 
            // PixelBitstreamComboBoxLabel
            // 
            this.PixelBitstreamComboBoxLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelBitstreamComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.PixelBitstreamComboBoxLabel.Location = new System.Drawing.Point(359, 33);
            this.PixelBitstreamComboBoxLabel.Name = "PixelBitstreamComboBoxLabel";
            this.PixelBitstreamComboBoxLabel.Size = new System.Drawing.Size(97, 15);
            this.PixelBitstreamComboBoxLabel.TabIndex = 65;
            this.PixelBitstreamComboBoxLabel.Text = "Bitstream";
            // 
            // PixelBitstreamComboBox
            // 
            this.PixelBitstreamComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.PixelBitstreamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PixelBitstreamComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PixelBitstreamComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelBitstreamComboBox.ForeColor = System.Drawing.Color.White;
            this.PixelBitstreamComboBox.FormattingEnabled = true;
            this.PixelBitstreamComboBox.Location = new System.Drawing.Point(460, 32);
            this.PixelBitstreamComboBox.Name = "PixelBitstreamComboBox";
            this.PixelBitstreamComboBox.Size = new System.Drawing.Size(108, 19);
            this.PixelBitstreamComboBox.TabIndex = 14;
            // 
            // PixelTypeComboBoxLabel
            // 
            this.PixelTypeComboBoxLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelTypeComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.PixelTypeComboBoxLabel.Location = new System.Drawing.Point(359, 8);
            this.PixelTypeComboBoxLabel.Name = "PixelTypeComboBoxLabel";
            this.PixelTypeComboBoxLabel.Size = new System.Drawing.Size(97, 15);
            this.PixelTypeComboBoxLabel.TabIndex = 63;
            this.PixelTypeComboBoxLabel.Text = "Pixel Type";
            // 
            // PixelTypeComboBox
            // 
            this.PixelTypeComboBox.BackColor = System.Drawing.Color.DarkGray;
            this.PixelTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PixelTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PixelTypeComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.PixelTypeComboBox.FormattingEnabled = true;
            this.PixelTypeComboBox.Location = new System.Drawing.Point(460, 7);
            this.PixelTypeComboBox.Name = "PixelTypeComboBox";
            this.PixelTypeComboBox.Size = new System.Drawing.Size(108, 19);
            this.PixelTypeComboBox.TabIndex = 13;
            // 
            // ConfigureSetupAddStripPinIDLabel
            // 
            this.ConfigureSetupAddStripPinIDLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripPinIDLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripPinIDLabel.Location = new System.Drawing.Point(159, 33);
            this.ConfigureSetupAddStripPinIDLabel.Name = "ConfigureSetupAddStripPinIDLabel";
            this.ConfigureSetupAddStripPinIDLabel.Size = new System.Drawing.Size(70, 15);
            this.ConfigureSetupAddStripPinIDLabel.TabIndex = 60;
            this.ConfigureSetupAddStripPinIDLabel.Text = "Pin";
            // 
            // ConfigureSetupAddStripPinID
            // 
            this.ConfigureSetupAddStripPinID.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupAddStripPinID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupAddStripPinID.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripPinID.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripPinID.Location = new System.Drawing.Point(233, 32);
            this.ConfigureSetupAddStripPinID.Name = "ConfigureSetupAddStripPinID";
            this.ConfigureSetupAddStripPinID.Size = new System.Drawing.Size(120, 14);
            this.ConfigureSetupAddStripPinID.TabIndex = 12;
            // 
            // ConfigureSetupAddStripInvertY
            // 
            this.ConfigureSetupAddStripInvertY.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripInvertY.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripInvertY.Location = new System.Drawing.Point(143, 61);
            this.ConfigureSetupAddStripInvertY.Name = "ConfigureSetupAddStripInvertY";
            this.ConfigureSetupAddStripInvertY.Size = new System.Drawing.Size(125, 15);
            this.ConfigureSetupAddStripInvertY.TabIndex = 16;
            this.ConfigureSetupAddStripInvertY.Text = "Invert Y";
            this.ConfigureSetupAddStripInvertY.UseVisualStyleBackColor = true;
            // 
            // ConfigureSetupAddStripInvertX
            // 
            this.ConfigureSetupAddStripInvertX.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripInvertX.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripInvertX.Location = new System.Drawing.Point(12, 61);
            this.ConfigureSetupAddStripInvertX.Name = "ConfigureSetupAddStripInvertX";
            this.ConfigureSetupAddStripInvertX.Size = new System.Drawing.Size(125, 15);
            this.ConfigureSetupAddStripInvertX.TabIndex = 15;
            this.ConfigureSetupAddStripInvertX.Text = "Invert X";
            this.ConfigureSetupAddStripInvertX.UseVisualStyleBackColor = true;
            // 
            // ConfigureSetupAddStripFromLEDIDLabel
            // 
            this.ConfigureSetupAddStripFromLEDIDLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripFromLEDIDLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripFromLEDIDLabel.Location = new System.Drawing.Point(159, 8);
            this.ConfigureSetupAddStripFromLEDIDLabel.Name = "ConfigureSetupAddStripFromLEDIDLabel";
            this.ConfigureSetupAddStripFromLEDIDLabel.Size = new System.Drawing.Size(70, 15);
            this.ConfigureSetupAddStripFromLEDIDLabel.TabIndex = 56;
            this.ConfigureSetupAddStripFromLEDIDLabel.Text = "From ID";
            // 
            // ConfigureSetupAddStripFromLEDID
            // 
            this.ConfigureSetupAddStripFromLEDID.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupAddStripFromLEDID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupAddStripFromLEDID.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripFromLEDID.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripFromLEDID.Location = new System.Drawing.Point(233, 7);
            this.ConfigureSetupAddStripFromLEDID.Name = "ConfigureSetupAddStripFromLEDID";
            this.ConfigureSetupAddStripFromLEDID.Size = new System.Drawing.Size(120, 14);
            this.ConfigureSetupAddStripFromLEDID.TabIndex = 11;
            // 
            // ConfigureSetupAddStripXDir
            // 
            this.ConfigureSetupAddStripXDir.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupAddStripXDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupAddStripXDir.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripXDir.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripXDir.Location = new System.Drawing.Point(33, 7);
            this.ConfigureSetupAddStripXDir.Name = "ConfigureSetupAddStripXDir";
            this.ConfigureSetupAddStripXDir.Size = new System.Drawing.Size(120, 14);
            this.ConfigureSetupAddStripXDir.TabIndex = 9;
            // 
            // ConfigureSetupAddStripYDirLabel
            // 
            this.ConfigureSetupAddStripYDirLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripYDirLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripYDirLabel.Location = new System.Drawing.Point(9, 33);
            this.ConfigureSetupAddStripYDirLabel.Name = "ConfigureSetupAddStripYDirLabel";
            this.ConfigureSetupAddStripYDirLabel.Size = new System.Drawing.Size(16, 15);
            this.ConfigureSetupAddStripYDirLabel.TabIndex = 52;
            this.ConfigureSetupAddStripYDirLabel.Text = "Y";
            // 
            // ConfigureSetupAddStripYDir
            // 
            this.ConfigureSetupAddStripYDir.BackColor = System.Drawing.Color.DarkGray;
            this.ConfigureSetupAddStripYDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigureSetupAddStripYDir.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripYDir.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripYDir.Location = new System.Drawing.Point(33, 32);
            this.ConfigureSetupAddStripYDir.Name = "ConfigureSetupAddStripYDir";
            this.ConfigureSetupAddStripYDir.Size = new System.Drawing.Size(120, 14);
            this.ConfigureSetupAddStripYDir.TabIndex = 10;
            // 
            // ConfigureSetupAddStripXDirLabel
            // 
            this.ConfigureSetupAddStripXDirLabel.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAddStripXDirLabel.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAddStripXDirLabel.Location = new System.Drawing.Point(9, 8);
            this.ConfigureSetupAddStripXDirLabel.Name = "ConfigureSetupAddStripXDirLabel";
            this.ConfigureSetupAddStripXDirLabel.Size = new System.Drawing.Size(16, 15);
            this.ConfigureSetupAddStripXDirLabel.TabIndex = 51;
            this.ConfigureSetupAddStripXDirLabel.Text = "X";
            // 
            // AddLEDStripButton
            // 
            this.AddLEDStripButton.BackColor = System.Drawing.Color.DarkGray;
            this.AddLEDStripButton.FlatAppearance.BorderSize = 0;
            this.AddLEDStripButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddLEDStripButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddLEDStripButton.ForeColor = System.Drawing.Color.White;
            this.AddLEDStripButton.Location = new System.Drawing.Point(402, 58);
            this.AddLEDStripButton.Name = "AddLEDStripButton";
            this.AddLEDStripButton.Size = new System.Drawing.Size(166, 25);
            this.AddLEDStripButton.TabIndex = 14;
            this.AddLEDStripButton.Text = "Add strip";
            this.AddLEDStripButton.UseVisualStyleBackColor = false;
            this.AddLEDStripButton.Click += new System.EventHandler(this.AddLEDStrip);
            // 
            // ConfigureSetupWorkingPanel
            // 
            this.ConfigureSetupWorkingPanel.BackColor = System.Drawing.Color.Silver;
            this.ConfigureSetupWorkingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigureSetupWorkingPanel.Location = new System.Drawing.Point(20, 69);
            this.ConfigureSetupWorkingPanel.Name = "ConfigureSetupWorkingPanel";
            this.ConfigureSetupWorkingPanel.Size = new System.Drawing.Size(832, 459);
            this.ConfigureSetupWorkingPanel.TabIndex = 18;
            this.ConfigureSetupWorkingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConfigureSetupWorkingPanel_MouseDown);
            this.ConfigureSetupWorkingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConfigureSetupWorkingPanel_MouseMove);
            this.ConfigureSetupWorkingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ConfigureSetupWorkingPanel_MouseUp);
            // 
            // ConfigureSetupAutoSendCheckBox
            // 
            this.ConfigureSetupAutoSendCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureSetupAutoSendCheckBox.ForeColor = System.Drawing.Color.White;
            this.ConfigureSetupAutoSendCheckBox.Location = new System.Drawing.Point(609, 670);
            this.ConfigureSetupAutoSendCheckBox.Name = "ConfigureSetupAutoSendCheckBox";
            this.ConfigureSetupAutoSendCheckBox.Size = new System.Drawing.Size(240, 36);
            this.ConfigureSetupAutoSendCheckBox.TabIndex = 17;
            this.ConfigureSetupAutoSendCheckBox.Tag = "Setting";
            this.ConfigureSetupAutoSendCheckBox.Text = "Auto send default setup next time";
            this.ConfigureSetupAutoSendCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigureSetupHiddenProgressBar
            // 
            this.ConfigureSetupHiddenProgressBar.Location = new System.Drawing.Point(1336, -1);
            this.ConfigureSetupHiddenProgressBar.Name = "ConfigureSetupHiddenProgressBar";
            this.ConfigureSetupHiddenProgressBar.Size = new System.Drawing.Size(75, 23);
            this.ConfigureSetupHiddenProgressBar.TabIndex = 68;
            this.ConfigureSetupHiddenProgressBar.Visible = false;
            this.ConfigureSetupHiddenProgressBar.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // HideTimer
            // 
            this.HideTimer.Interval = 3000;
            this.HideTimer.Tick += new System.EventHandler(this.HideTimer_Tick);
            // 
            // AmbiLightModePanel
            // 
            this.AmbiLightModePanel.BackColor = System.Drawing.Color.DimGray;
            this.AmbiLightModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AmbiLightModePanel.Controls.Add(this.AmbiLightModeWorkingPanel);
            this.AmbiLightModePanel.Controls.Add(this.AmbiLightModeStopAmbilightButton);
            this.AmbiLightModePanel.Controls.Add(this.AmbiLightModeStartAmbilightButton);
            this.AmbiLightModePanel.Controls.Add(this.AmbiLightModeShowHideBlocksButton);
            this.AmbiLightModePanel.Controls.Add(this.panel3);
            this.AmbiLightModePanel.Location = new System.Drawing.Point(264, 21);
            this.AmbiLightModePanel.Name = "AmbiLightModePanel";
            this.AmbiLightModePanel.Size = new System.Drawing.Size(687, 685);
            this.AmbiLightModePanel.TabIndex = 69;
            this.AmbiLightModePanel.Visible = false;
            // 
            // AmbiLightModeWorkingPanel
            // 
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeGammaFactorLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeGammaFactorNumericUpDown);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeAutosetOffsets);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbilightModeFPSCounterLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeScreenIDLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeLeftPanel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeScreenIDNumericUpDown);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeFadeFactorLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeTopPanel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeBlockSampleSplitLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeFadeFactorNumericUpDown);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeBlockSampleSplitNumericUpDown);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeLeftCheckBox);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeRefreshRateLabel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeRefreshRateNumericUpDown);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeTopCheckBox);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeRightCheckBox);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeLoadSetup);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeBottomCheckBox);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeSaveSetup);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeRightPanel);
            this.AmbiLightModeWorkingPanel.Controls.Add(this.AmbiLightModeBottomPanel);
            this.AmbiLightModeWorkingPanel.Location = new System.Drawing.Point(12, 101);
            this.AmbiLightModeWorkingPanel.Name = "AmbiLightModeWorkingPanel";
            this.AmbiLightModeWorkingPanel.Size = new System.Drawing.Size(654, 570);
            this.AmbiLightModeWorkingPanel.TabIndex = 50;
            // 
            // AmbiLightModeGammaFactorLabel
            // 
            this.AmbiLightModeGammaFactorLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeGammaFactorLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeGammaFactorLabel.Location = new System.Drawing.Point(229, 49);
            this.AmbiLightModeGammaFactorLabel.Name = "AmbiLightModeGammaFactorLabel";
            this.AmbiLightModeGammaFactorLabel.Size = new System.Drawing.Size(195, 17);
            this.AmbiLightModeGammaFactorLabel.TabIndex = 120;
            this.AmbiLightModeGammaFactorLabel.Text = "Gamma factor";
            this.AmbiLightModeGammaFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeGammaFactorNumericUpDown
            // 
            this.AmbiLightModeGammaFactorNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeGammaFactorNumericUpDown.DecimalPlaces = 2;
            this.AmbiLightModeGammaFactorNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeGammaFactorNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeGammaFactorNumericUpDown.Location = new System.Drawing.Point(229, 70);
            this.AmbiLightModeGammaFactorNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AmbiLightModeGammaFactorNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.AmbiLightModeGammaFactorNumericUpDown.Name = "AmbiLightModeGammaFactorNumericUpDown";
            this.AmbiLightModeGammaFactorNumericUpDown.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeGammaFactorNumericUpDown.TabIndex = 119;
            this.AmbiLightModeGammaFactorNumericUpDown.Tag = "Setting";
            this.AmbiLightModeGammaFactorNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AmbiLightModeAutosetOffsets
            // 
            this.AmbiLightModeAutosetOffsets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeAutosetOffsets.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeAutosetOffsets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeAutosetOffsets.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeAutosetOffsets.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeAutosetOffsets.Location = new System.Drawing.Point(5, 70);
            this.AmbiLightModeAutosetOffsets.Name = "AmbiLightModeAutosetOffsets";
            this.AmbiLightModeAutosetOffsets.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeAutosetOffsets.TabIndex = 118;
            this.AmbiLightModeAutosetOffsets.Text = "Autoset Offsets";
            this.AmbiLightModeAutosetOffsets.UseVisualStyleBackColor = false;
            this.AmbiLightModeAutosetOffsets.Click += new System.EventHandler(this.AmbiLightModeAutosetOffsets_Click);
            // 
            // AmbilightModeFPSCounterLabel
            // 
            this.AmbilightModeFPSCounterLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbilightModeFPSCounterLabel.ForeColor = System.Drawing.Color.White;
            this.AmbilightModeFPSCounterLabel.Location = new System.Drawing.Point(5, 49);
            this.AmbilightModeFPSCounterLabel.Name = "AmbilightModeFPSCounterLabel";
            this.AmbilightModeFPSCounterLabel.Size = new System.Drawing.Size(195, 17);
            this.AmbilightModeFPSCounterLabel.TabIndex = 117;
            this.AmbilightModeFPSCounterLabel.Text = "FPS: ";
            this.AmbilightModeFPSCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeScreenIDLabel
            // 
            this.AmbiLightModeScreenIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeScreenIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeScreenIDLabel.Location = new System.Drawing.Point(453, 1);
            this.AmbiLightModeScreenIDLabel.Name = "AmbiLightModeScreenIDLabel";
            this.AmbiLightModeScreenIDLabel.Size = new System.Drawing.Size(195, 15);
            this.AmbiLightModeScreenIDLabel.TabIndex = 114;
            this.AmbiLightModeScreenIDLabel.Text = "Screen ID";
            this.AmbiLightModeScreenIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftPanel
            // 
            this.AmbiLightModeLeftPanel.BackColor = System.Drawing.Color.Gray;
            this.AmbiLightModeLeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftPanelLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftLEDsPrBlockNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftLEDsPrBlockLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockWidthNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockWidthLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockHeightNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockHeightLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockSpacingNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftToIDLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockSpacingLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftToIDNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockOffsetXNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftFromIDLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockOffsetXLabel);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftFromIDNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockOffsetYNumericUpDown);
            this.AmbiLightModeLeftPanel.Controls.Add(this.AmbiLightModeLeftBlockOffsetYLabel);
            this.AmbiLightModeLeftPanel.Enabled = false;
            this.AmbiLightModeLeftPanel.Location = new System.Drawing.Point(3, 334);
            this.AmbiLightModeLeftPanel.Name = "AmbiLightModeLeftPanel";
            this.AmbiLightModeLeftPanel.Size = new System.Drawing.Size(316, 199);
            this.AmbiLightModeLeftPanel.TabIndex = 104;
            // 
            // AmbiLightModeLeftPanelLabel
            // 
            this.AmbiLightModeLeftPanelLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftPanelLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftPanelLabel.Location = new System.Drawing.Point(6, 7);
            this.AmbiLightModeLeftPanelLabel.Name = "AmbiLightModeLeftPanelLabel";
            this.AmbiLightModeLeftPanelLabel.Size = new System.Drawing.Size(300, 15);
            this.AmbiLightModeLeftPanelLabel.TabIndex = 94;
            this.AmbiLightModeLeftPanelLabel.Text = "Left Side";
            this.AmbiLightModeLeftPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmbiLightModeLeftLEDsPrBlockNumericUpDown
            // 
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Location = new System.Drawing.Point(11, 50);
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Name = "AmbiLightModeLeftLEDsPrBlockNumericUpDown";
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.TabIndex = 70;
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftLEDsPrBlockNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftLEDsPrBlockLabel
            // 
            this.AmbiLightModeLeftLEDsPrBlockLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftLEDsPrBlockLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftLEDsPrBlockLabel.Location = new System.Drawing.Point(8, 32);
            this.AmbiLightModeLeftLEDsPrBlockLabel.Name = "AmbiLightModeLeftLEDsPrBlockLabel";
            this.AmbiLightModeLeftLEDsPrBlockLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftLEDsPrBlockLabel.TabIndex = 71;
            this.AmbiLightModeLeftLEDsPrBlockLabel.Text = "LEDs pr Block";
            this.AmbiLightModeLeftLEDsPrBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftBlockWidthNumericUpDown
            // 
            this.AmbiLightModeLeftBlockWidthNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockWidthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Location = new System.Drawing.Point(11, 91);
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Name = "AmbiLightModeLeftBlockWidthNumericUpDown";
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftBlockWidthNumericUpDown.TabIndex = 76;
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftBlockWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftBlockWidthLabel
            // 
            this.AmbiLightModeLeftBlockWidthLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockWidthLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockWidthLabel.Location = new System.Drawing.Point(8, 72);
            this.AmbiLightModeLeftBlockWidthLabel.Name = "AmbiLightModeLeftBlockWidthLabel";
            this.AmbiLightModeLeftBlockWidthLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftBlockWidthLabel.TabIndex = 77;
            this.AmbiLightModeLeftBlockWidthLabel.Text = "Block Width";
            this.AmbiLightModeLeftBlockWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftBlockHeightNumericUpDown
            // 
            this.AmbiLightModeLeftBlockHeightNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockHeightNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Location = new System.Drawing.Point(160, 50);
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Name = "AmbiLightModeLeftBlockHeightNumericUpDown";
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftBlockHeightNumericUpDown.TabIndex = 78;
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftBlockHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftBlockHeightLabel
            // 
            this.AmbiLightModeLeftBlockHeightLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockHeightLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockHeightLabel.Location = new System.Drawing.Point(157, 32);
            this.AmbiLightModeLeftBlockHeightLabel.Name = "AmbiLightModeLeftBlockHeightLabel";
            this.AmbiLightModeLeftBlockHeightLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftBlockHeightLabel.TabIndex = 79;
            this.AmbiLightModeLeftBlockHeightLabel.Text = "Block Height";
            this.AmbiLightModeLeftBlockHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftBlockSpacingNumericUpDown
            // 
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Location = new System.Drawing.Point(160, 91);
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Name = "AmbiLightModeLeftBlockSpacingNumericUpDown";
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.TabIndex = 82;
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftBlockSpacingNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftToIDLabel
            // 
            this.AmbiLightModeLeftToIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftToIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftToIDLabel.Location = new System.Drawing.Point(159, 154);
            this.AmbiLightModeLeftToIDLabel.Name = "AmbiLightModeLeftToIDLabel";
            this.AmbiLightModeLeftToIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeLeftToIDLabel.TabIndex = 92;
            this.AmbiLightModeLeftToIDLabel.Text = "To Series ID";
            this.AmbiLightModeLeftToIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftBlockSpacingLabel
            // 
            this.AmbiLightModeLeftBlockSpacingLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockSpacingLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockSpacingLabel.Location = new System.Drawing.Point(157, 73);
            this.AmbiLightModeLeftBlockSpacingLabel.Name = "AmbiLightModeLeftBlockSpacingLabel";
            this.AmbiLightModeLeftBlockSpacingLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftBlockSpacingLabel.TabIndex = 83;
            this.AmbiLightModeLeftBlockSpacingLabel.Text = "Block Spacing";
            this.AmbiLightModeLeftBlockSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftToIDNumericUpDown
            // 
            this.AmbiLightModeLeftToIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftToIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeLeftToIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftToIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftToIDNumericUpDown.Location = new System.Drawing.Point(159, 172);
            this.AmbiLightModeLeftToIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeLeftToIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.AmbiLightModeLeftToIDNumericUpDown.Name = "AmbiLightModeLeftToIDNumericUpDown";
            this.AmbiLightModeLeftToIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeLeftToIDNumericUpDown.TabIndex = 90;
            this.AmbiLightModeLeftToIDNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftToIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // AmbiLightModeLeftBlockOffsetXNumericUpDown
            // 
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Location = new System.Drawing.Point(11, 131);
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Name = "AmbiLightModeLeftBlockOffsetXNumericUpDown";
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.TabIndex = 85;
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftBlockOffsetXNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftFromIDLabel
            // 
            this.AmbiLightModeLeftFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftFromIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftFromIDLabel.Location = new System.Drawing.Point(9, 155);
            this.AmbiLightModeLeftFromIDLabel.Name = "AmbiLightModeLeftFromIDLabel";
            this.AmbiLightModeLeftFromIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeLeftFromIDLabel.TabIndex = 91;
            this.AmbiLightModeLeftFromIDLabel.Text = "From Series ID";
            this.AmbiLightModeLeftFromIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftBlockOffsetXLabel
            // 
            this.AmbiLightModeLeftBlockOffsetXLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockOffsetXLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockOffsetXLabel.Location = new System.Drawing.Point(8, 114);
            this.AmbiLightModeLeftBlockOffsetXLabel.Name = "AmbiLightModeLeftBlockOffsetXLabel";
            this.AmbiLightModeLeftBlockOffsetXLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftBlockOffsetXLabel.TabIndex = 86;
            this.AmbiLightModeLeftBlockOffsetXLabel.Text = "Block Offset X";
            this.AmbiLightModeLeftBlockOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeLeftFromIDNumericUpDown
            // 
            this.AmbiLightModeLeftFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeLeftFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftFromIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftFromIDNumericUpDown.Location = new System.Drawing.Point(10, 172);
            this.AmbiLightModeLeftFromIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeLeftFromIDNumericUpDown.Name = "AmbiLightModeLeftFromIDNumericUpDown";
            this.AmbiLightModeLeftFromIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeLeftFromIDNumericUpDown.TabIndex = 89;
            this.AmbiLightModeLeftFromIDNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeLeftBlockOffsetYNumericUpDown
            // 
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Location = new System.Drawing.Point(160, 131);
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Name = "AmbiLightModeLeftBlockOffsetYNumericUpDown";
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.TabIndex = 87;
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Tag = "Setting";
            this.AmbiLightModeLeftBlockOffsetYNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftBlockOffsetYLabel
            // 
            this.AmbiLightModeLeftBlockOffsetYLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLeftBlockOffsetYLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftBlockOffsetYLabel.Location = new System.Drawing.Point(157, 113);
            this.AmbiLightModeLeftBlockOffsetYLabel.Name = "AmbiLightModeLeftBlockOffsetYLabel";
            this.AmbiLightModeLeftBlockOffsetYLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeLeftBlockOffsetYLabel.TabIndex = 88;
            this.AmbiLightModeLeftBlockOffsetYLabel.Text = "Block Offset Y";
            this.AmbiLightModeLeftBlockOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeScreenIDNumericUpDown
            // 
            this.AmbiLightModeScreenIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeScreenIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeScreenIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeScreenIDNumericUpDown.Location = new System.Drawing.Point(453, 26);
            this.AmbiLightModeScreenIDNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeScreenIDNumericUpDown.Name = "AmbiLightModeScreenIDNumericUpDown";
            this.AmbiLightModeScreenIDNumericUpDown.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeScreenIDNumericUpDown.TabIndex = 113;
            this.AmbiLightModeScreenIDNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeFadeFactorLabel
            // 
            this.AmbiLightModeFadeFactorLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeFadeFactorLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeFadeFactorLabel.Location = new System.Drawing.Point(453, 49);
            this.AmbiLightModeFadeFactorLabel.Name = "AmbiLightModeFadeFactorLabel";
            this.AmbiLightModeFadeFactorLabel.Size = new System.Drawing.Size(195, 17);
            this.AmbiLightModeFadeFactorLabel.TabIndex = 116;
            this.AmbiLightModeFadeFactorLabel.Text = "Fade factor";
            this.AmbiLightModeFadeFactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopPanel
            // 
            this.AmbiLightModeTopPanel.BackColor = System.Drawing.Color.Gray;
            this.AmbiLightModeTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopPanelLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopLEDsPrBlockNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopLEDsPrBlockLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockWidthNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockWidthLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockHeightNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockHeightLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockSpacingNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockSpacingLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopToIDLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopToIDNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockOffsetXNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopFromIDLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockOffsetXLabel);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopFromIDNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockOffsetYNumericUpDown);
            this.AmbiLightModeTopPanel.Controls.Add(this.AmbiLightModeTopBlockOffsetYLabel);
            this.AmbiLightModeTopPanel.Enabled = false;
            this.AmbiLightModeTopPanel.Location = new System.Drawing.Point(3, 123);
            this.AmbiLightModeTopPanel.Name = "AmbiLightModeTopPanel";
            this.AmbiLightModeTopPanel.Size = new System.Drawing.Size(316, 199);
            this.AmbiLightModeTopPanel.TabIndex = 105;
            // 
            // AmbiLightModeTopPanelLabel
            // 
            this.AmbiLightModeTopPanelLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopPanelLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopPanelLabel.Location = new System.Drawing.Point(6, 7);
            this.AmbiLightModeTopPanelLabel.Name = "AmbiLightModeTopPanelLabel";
            this.AmbiLightModeTopPanelLabel.Size = new System.Drawing.Size(300, 15);
            this.AmbiLightModeTopPanelLabel.TabIndex = 93;
            this.AmbiLightModeTopPanelLabel.Text = "Top Side";
            this.AmbiLightModeTopPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmbiLightModeTopLEDsPrBlockNumericUpDown
            // 
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Location = new System.Drawing.Point(11, 50);
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Name = "AmbiLightModeTopLEDsPrBlockNumericUpDown";
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.TabIndex = 70;
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopLEDsPrBlockNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopLEDsPrBlockLabel
            // 
            this.AmbiLightModeTopLEDsPrBlockLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopLEDsPrBlockLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopLEDsPrBlockLabel.Location = new System.Drawing.Point(8, 32);
            this.AmbiLightModeTopLEDsPrBlockLabel.Name = "AmbiLightModeTopLEDsPrBlockLabel";
            this.AmbiLightModeTopLEDsPrBlockLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopLEDsPrBlockLabel.TabIndex = 71;
            this.AmbiLightModeTopLEDsPrBlockLabel.Text = "LEDs pr Block";
            this.AmbiLightModeTopLEDsPrBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopBlockWidthNumericUpDown
            // 
            this.AmbiLightModeTopBlockWidthNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopBlockWidthNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockWidthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockWidthNumericUpDown.Location = new System.Drawing.Point(11, 91);
            this.AmbiLightModeTopBlockWidthNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockWidthNumericUpDown.Name = "AmbiLightModeTopBlockWidthNumericUpDown";
            this.AmbiLightModeTopBlockWidthNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopBlockWidthNumericUpDown.TabIndex = 76;
            this.AmbiLightModeTopBlockWidthNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopBlockWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopBlockWidthLabel
            // 
            this.AmbiLightModeTopBlockWidthLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockWidthLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockWidthLabel.Location = new System.Drawing.Point(8, 72);
            this.AmbiLightModeTopBlockWidthLabel.Name = "AmbiLightModeTopBlockWidthLabel";
            this.AmbiLightModeTopBlockWidthLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopBlockWidthLabel.TabIndex = 77;
            this.AmbiLightModeTopBlockWidthLabel.Text = "Block Width";
            this.AmbiLightModeTopBlockWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopBlockHeightNumericUpDown
            // 
            this.AmbiLightModeTopBlockHeightNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopBlockHeightNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockHeightNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockHeightNumericUpDown.Location = new System.Drawing.Point(160, 50);
            this.AmbiLightModeTopBlockHeightNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockHeightNumericUpDown.Name = "AmbiLightModeTopBlockHeightNumericUpDown";
            this.AmbiLightModeTopBlockHeightNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopBlockHeightNumericUpDown.TabIndex = 78;
            this.AmbiLightModeTopBlockHeightNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopBlockHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopBlockHeightLabel
            // 
            this.AmbiLightModeTopBlockHeightLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockHeightLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockHeightLabel.Location = new System.Drawing.Point(157, 32);
            this.AmbiLightModeTopBlockHeightLabel.Name = "AmbiLightModeTopBlockHeightLabel";
            this.AmbiLightModeTopBlockHeightLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopBlockHeightLabel.TabIndex = 79;
            this.AmbiLightModeTopBlockHeightLabel.Text = "Block Height";
            this.AmbiLightModeTopBlockHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopBlockSpacingNumericUpDown
            // 
            this.AmbiLightModeTopBlockSpacingNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockSpacingNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Location = new System.Drawing.Point(160, 91);
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Name = "AmbiLightModeTopBlockSpacingNumericUpDown";
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopBlockSpacingNumericUpDown.TabIndex = 80;
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopBlockSpacingNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopBlockSpacingLabel
            // 
            this.AmbiLightModeTopBlockSpacingLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockSpacingLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockSpacingLabel.Location = new System.Drawing.Point(157, 72);
            this.AmbiLightModeTopBlockSpacingLabel.Name = "AmbiLightModeTopBlockSpacingLabel";
            this.AmbiLightModeTopBlockSpacingLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopBlockSpacingLabel.TabIndex = 81;
            this.AmbiLightModeTopBlockSpacingLabel.Text = "Block Spacing";
            this.AmbiLightModeTopBlockSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopToIDLabel
            // 
            this.AmbiLightModeTopToIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopToIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopToIDLabel.Location = new System.Drawing.Point(157, 154);
            this.AmbiLightModeTopToIDLabel.Name = "AmbiLightModeTopToIDLabel";
            this.AmbiLightModeTopToIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeTopToIDLabel.TabIndex = 92;
            this.AmbiLightModeTopToIDLabel.Text = "To Series ID";
            this.AmbiLightModeTopToIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopToIDNumericUpDown
            // 
            this.AmbiLightModeTopToIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopToIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeTopToIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopToIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopToIDNumericUpDown.Location = new System.Drawing.Point(157, 172);
            this.AmbiLightModeTopToIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeTopToIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.AmbiLightModeTopToIDNumericUpDown.Name = "AmbiLightModeTopToIDNumericUpDown";
            this.AmbiLightModeTopToIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeTopToIDNumericUpDown.TabIndex = 90;
            this.AmbiLightModeTopToIDNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopToIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // AmbiLightModeTopBlockOffsetXNumericUpDown
            // 
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Location = new System.Drawing.Point(9, 131);
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Name = "AmbiLightModeTopBlockOffsetXNumericUpDown";
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.TabIndex = 85;
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopBlockOffsetXNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopFromIDLabel
            // 
            this.AmbiLightModeTopFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopFromIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopFromIDLabel.Location = new System.Drawing.Point(7, 155);
            this.AmbiLightModeTopFromIDLabel.Name = "AmbiLightModeTopFromIDLabel";
            this.AmbiLightModeTopFromIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeTopFromIDLabel.TabIndex = 91;
            this.AmbiLightModeTopFromIDLabel.Text = "From Series ID";
            this.AmbiLightModeTopFromIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopBlockOffsetXLabel
            // 
            this.AmbiLightModeTopBlockOffsetXLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockOffsetXLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockOffsetXLabel.Location = new System.Drawing.Point(6, 114);
            this.AmbiLightModeTopBlockOffsetXLabel.Name = "AmbiLightModeTopBlockOffsetXLabel";
            this.AmbiLightModeTopBlockOffsetXLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopBlockOffsetXLabel.TabIndex = 86;
            this.AmbiLightModeTopBlockOffsetXLabel.Text = "Block Offset X";
            this.AmbiLightModeTopBlockOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeTopFromIDNumericUpDown
            // 
            this.AmbiLightModeTopFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeTopFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopFromIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopFromIDNumericUpDown.Location = new System.Drawing.Point(8, 172);
            this.AmbiLightModeTopFromIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeTopFromIDNumericUpDown.Name = "AmbiLightModeTopFromIDNumericUpDown";
            this.AmbiLightModeTopFromIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeTopFromIDNumericUpDown.TabIndex = 89;
            this.AmbiLightModeTopFromIDNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeTopBlockOffsetYNumericUpDown
            // 
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Location = new System.Drawing.Point(160, 131);
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Name = "AmbiLightModeTopBlockOffsetYNumericUpDown";
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.TabIndex = 87;
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Tag = "Setting";
            this.AmbiLightModeTopBlockOffsetYNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeTopBlockOffsetYLabel
            // 
            this.AmbiLightModeTopBlockOffsetYLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopBlockOffsetYLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopBlockOffsetYLabel.Location = new System.Drawing.Point(157, 113);
            this.AmbiLightModeTopBlockOffsetYLabel.Name = "AmbiLightModeTopBlockOffsetYLabel";
            this.AmbiLightModeTopBlockOffsetYLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeTopBlockOffsetYLabel.TabIndex = 88;
            this.AmbiLightModeTopBlockOffsetYLabel.Text = "Block Offset Y";
            this.AmbiLightModeTopBlockOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBlockSampleSplitLabel
            // 
            this.AmbiLightModeBlockSampleSplitLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBlockSampleSplitLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBlockSampleSplitLabel.Location = new System.Drawing.Point(229, 1);
            this.AmbiLightModeBlockSampleSplitLabel.Name = "AmbiLightModeBlockSampleSplitLabel";
            this.AmbiLightModeBlockSampleSplitLabel.Size = new System.Drawing.Size(195, 15);
            this.AmbiLightModeBlockSampleSplitLabel.TabIndex = 109;
            this.AmbiLightModeBlockSampleSplitLabel.Text = "Block Sample Split";
            this.AmbiLightModeBlockSampleSplitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeFadeFactorNumericUpDown
            // 
            this.AmbiLightModeFadeFactorNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeFadeFactorNumericUpDown.DecimalPlaces = 2;
            this.AmbiLightModeFadeFactorNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeFadeFactorNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeFadeFactorNumericUpDown.Location = new System.Drawing.Point(453, 70);
            this.AmbiLightModeFadeFactorNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AmbiLightModeFadeFactorNumericUpDown.Name = "AmbiLightModeFadeFactorNumericUpDown";
            this.AmbiLightModeFadeFactorNumericUpDown.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeFadeFactorNumericUpDown.TabIndex = 115;
            this.AmbiLightModeFadeFactorNumericUpDown.Tag = "Setting";
            this.AmbiLightModeFadeFactorNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            // 
            // AmbiLightModeBlockSampleSplitNumericUpDown
            // 
            this.AmbiLightModeBlockSampleSplitNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBlockSampleSplitNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Location = new System.Drawing.Point(229, 26);
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Name = "AmbiLightModeBlockSampleSplitNumericUpDown";
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeBlockSampleSplitNumericUpDown.TabIndex = 108;
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBlockSampleSplitNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AmbiLightModeLeftCheckBox
            // 
            this.AmbiLightModeLeftCheckBox.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLeftCheckBox.Location = new System.Drawing.Point(3, 95);
            this.AmbiLightModeLeftCheckBox.Name = "AmbiLightModeLeftCheckBox";
            this.AmbiLightModeLeftCheckBox.Size = new System.Drawing.Size(158, 30);
            this.AmbiLightModeLeftCheckBox.TabIndex = 95;
            this.AmbiLightModeLeftCheckBox.Tag = "Setting";
            this.AmbiLightModeLeftCheckBox.Text = "Use left side";
            this.AmbiLightModeLeftCheckBox.UseVisualStyleBackColor = false;
            this.AmbiLightModeLeftCheckBox.CheckedChanged += new System.EventHandler(this.AmbiLightModeCheckBox_CheckedChanged);
            // 
            // AmbiLightModeRefreshRateLabel
            // 
            this.AmbiLightModeRefreshRateLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRefreshRateLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRefreshRateLabel.Location = new System.Drawing.Point(5, 1);
            this.AmbiLightModeRefreshRateLabel.Name = "AmbiLightModeRefreshRateLabel";
            this.AmbiLightModeRefreshRateLabel.Size = new System.Drawing.Size(195, 15);
            this.AmbiLightModeRefreshRateLabel.TabIndex = 103;
            this.AmbiLightModeRefreshRateLabel.Text = "Minimum refresh rate (ms)";
            this.AmbiLightModeRefreshRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRefreshRateNumericUpDown
            // 
            this.AmbiLightModeRefreshRateNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRefreshRateNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRefreshRateNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRefreshRateNumericUpDown.Location = new System.Drawing.Point(5, 26);
            this.AmbiLightModeRefreshRateNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRefreshRateNumericUpDown.Name = "AmbiLightModeRefreshRateNumericUpDown";
            this.AmbiLightModeRefreshRateNumericUpDown.Size = new System.Drawing.Size(195, 18);
            this.AmbiLightModeRefreshRateNumericUpDown.TabIndex = 102;
            this.AmbiLightModeRefreshRateNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeTopCheckBox
            // 
            this.AmbiLightModeTopCheckBox.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopCheckBox.Location = new System.Drawing.Point(161, 95);
            this.AmbiLightModeTopCheckBox.Name = "AmbiLightModeTopCheckBox";
            this.AmbiLightModeTopCheckBox.Size = new System.Drawing.Size(158, 30);
            this.AmbiLightModeTopCheckBox.TabIndex = 95;
            this.AmbiLightModeTopCheckBox.Tag = "Setting";
            this.AmbiLightModeTopCheckBox.Text = "Use top side";
            this.AmbiLightModeTopCheckBox.UseVisualStyleBackColor = false;
            this.AmbiLightModeTopCheckBox.CheckedChanged += new System.EventHandler(this.AmbiLightModeCheckBox_CheckedChanged);
            // 
            // AmbiLightModeRightCheckBox
            // 
            this.AmbiLightModeRightCheckBox.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightCheckBox.Location = new System.Drawing.Point(332, 95);
            this.AmbiLightModeRightCheckBox.Name = "AmbiLightModeRightCheckBox";
            this.AmbiLightModeRightCheckBox.Size = new System.Drawing.Size(158, 30);
            this.AmbiLightModeRightCheckBox.TabIndex = 95;
            this.AmbiLightModeRightCheckBox.Tag = "Setting";
            this.AmbiLightModeRightCheckBox.Text = "Use right side";
            this.AmbiLightModeRightCheckBox.UseVisualStyleBackColor = false;
            this.AmbiLightModeRightCheckBox.CheckedChanged += new System.EventHandler(this.AmbiLightModeCheckBox_CheckedChanged);
            // 
            // AmbiLightModeLoadSetup
            // 
            this.AmbiLightModeLoadSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeLoadSetup.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeLoadSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeLoadSetup.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeLoadSetup.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeLoadSetup.Location = new System.Drawing.Point(332, 537);
            this.AmbiLightModeLoadSetup.Name = "AmbiLightModeLoadSetup";
            this.AmbiLightModeLoadSetup.Size = new System.Drawing.Size(316, 24);
            this.AmbiLightModeLoadSetup.TabIndex = 112;
            this.AmbiLightModeLoadSetup.Text = "Load a Ambilight Setup";
            this.AmbiLightModeLoadSetup.UseVisualStyleBackColor = false;
            this.AmbiLightModeLoadSetup.Click += new System.EventHandler(this.LoadAAmbilightSetup);
            // 
            // AmbiLightModeBottomCheckBox
            // 
            this.AmbiLightModeBottomCheckBox.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomCheckBox.Location = new System.Drawing.Point(490, 95);
            this.AmbiLightModeBottomCheckBox.Name = "AmbiLightModeBottomCheckBox";
            this.AmbiLightModeBottomCheckBox.Size = new System.Drawing.Size(158, 30);
            this.AmbiLightModeBottomCheckBox.TabIndex = 95;
            this.AmbiLightModeBottomCheckBox.Tag = "Setting";
            this.AmbiLightModeBottomCheckBox.Text = "Use bottom side";
            this.AmbiLightModeBottomCheckBox.UseVisualStyleBackColor = false;
            this.AmbiLightModeBottomCheckBox.CheckedChanged += new System.EventHandler(this.AmbiLightModeCheckBox_CheckedChanged);
            // 
            // AmbiLightModeSaveSetup
            // 
            this.AmbiLightModeSaveSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeSaveSetup.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeSaveSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeSaveSetup.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeSaveSetup.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeSaveSetup.Location = new System.Drawing.Point(3, 535);
            this.AmbiLightModeSaveSetup.Name = "AmbiLightModeSaveSetup";
            this.AmbiLightModeSaveSetup.Size = new System.Drawing.Size(316, 24);
            this.AmbiLightModeSaveSetup.TabIndex = 111;
            this.AmbiLightModeSaveSetup.Text = "Save Current Ambilight Setup";
            this.AmbiLightModeSaveSetup.UseVisualStyleBackColor = false;
            this.AmbiLightModeSaveSetup.Click += new System.EventHandler(this.SaveCurrentAmbilightSetup);
            // 
            // AmbiLightModeRightPanel
            // 
            this.AmbiLightModeRightPanel.BackColor = System.Drawing.Color.Gray;
            this.AmbiLightModeRightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightPanelLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightLEDsPrBlockNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightLEDsPrBlockLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockWidthNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockWidthLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockHeightNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockHeightLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockSpacingNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightToIDLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockSpacingLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightToIDNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockOffsetXNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightFromIDLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockOffsetXLabel);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightFromIDNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockOffsetYNumericUpDown);
            this.AmbiLightModeRightPanel.Controls.Add(this.AmbiLightModeRightBlockOffsetYLabel);
            this.AmbiLightModeRightPanel.Enabled = false;
            this.AmbiLightModeRightPanel.Location = new System.Drawing.Point(332, 123);
            this.AmbiLightModeRightPanel.Name = "AmbiLightModeRightPanel";
            this.AmbiLightModeRightPanel.Size = new System.Drawing.Size(316, 199);
            this.AmbiLightModeRightPanel.TabIndex = 106;
            // 
            // AmbiLightModeRightPanelLabel
            // 
            this.AmbiLightModeRightPanelLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightPanelLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightPanelLabel.Location = new System.Drawing.Point(6, 7);
            this.AmbiLightModeRightPanelLabel.Name = "AmbiLightModeRightPanelLabel";
            this.AmbiLightModeRightPanelLabel.Size = new System.Drawing.Size(300, 15);
            this.AmbiLightModeRightPanelLabel.TabIndex = 94;
            this.AmbiLightModeRightPanelLabel.Text = "Right Side";
            this.AmbiLightModeRightPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmbiLightModeRightLEDsPrBlockNumericUpDown
            // 
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Location = new System.Drawing.Point(11, 50);
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Name = "AmbiLightModeRightLEDsPrBlockNumericUpDown";
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.TabIndex = 70;
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightLEDsPrBlockNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightLEDsPrBlockLabel
            // 
            this.AmbiLightModeRightLEDsPrBlockLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightLEDsPrBlockLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightLEDsPrBlockLabel.Location = new System.Drawing.Point(8, 32);
            this.AmbiLightModeRightLEDsPrBlockLabel.Name = "AmbiLightModeRightLEDsPrBlockLabel";
            this.AmbiLightModeRightLEDsPrBlockLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightLEDsPrBlockLabel.TabIndex = 71;
            this.AmbiLightModeRightLEDsPrBlockLabel.Text = "LEDs pr Block";
            this.AmbiLightModeRightLEDsPrBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightBlockWidthNumericUpDown
            // 
            this.AmbiLightModeRightBlockWidthNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightBlockWidthNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockWidthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockWidthNumericUpDown.Location = new System.Drawing.Point(11, 91);
            this.AmbiLightModeRightBlockWidthNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockWidthNumericUpDown.Name = "AmbiLightModeRightBlockWidthNumericUpDown";
            this.AmbiLightModeRightBlockWidthNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightBlockWidthNumericUpDown.TabIndex = 76;
            this.AmbiLightModeRightBlockWidthNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightBlockWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightBlockWidthLabel
            // 
            this.AmbiLightModeRightBlockWidthLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockWidthLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockWidthLabel.Location = new System.Drawing.Point(8, 72);
            this.AmbiLightModeRightBlockWidthLabel.Name = "AmbiLightModeRightBlockWidthLabel";
            this.AmbiLightModeRightBlockWidthLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightBlockWidthLabel.TabIndex = 77;
            this.AmbiLightModeRightBlockWidthLabel.Text = "Block Width";
            this.AmbiLightModeRightBlockWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightBlockHeightNumericUpDown
            // 
            this.AmbiLightModeRightBlockHeightNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightBlockHeightNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockHeightNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockHeightNumericUpDown.Location = new System.Drawing.Point(160, 50);
            this.AmbiLightModeRightBlockHeightNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockHeightNumericUpDown.Name = "AmbiLightModeRightBlockHeightNumericUpDown";
            this.AmbiLightModeRightBlockHeightNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightBlockHeightNumericUpDown.TabIndex = 78;
            this.AmbiLightModeRightBlockHeightNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightBlockHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightBlockHeightLabel
            // 
            this.AmbiLightModeRightBlockHeightLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockHeightLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockHeightLabel.Location = new System.Drawing.Point(157, 32);
            this.AmbiLightModeRightBlockHeightLabel.Name = "AmbiLightModeRightBlockHeightLabel";
            this.AmbiLightModeRightBlockHeightLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightBlockHeightLabel.TabIndex = 79;
            this.AmbiLightModeRightBlockHeightLabel.Text = "Block Height";
            this.AmbiLightModeRightBlockHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightBlockSpacingNumericUpDown
            // 
            this.AmbiLightModeRightBlockSpacingNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockSpacingNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Location = new System.Drawing.Point(160, 91);
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Name = "AmbiLightModeRightBlockSpacingNumericUpDown";
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightBlockSpacingNumericUpDown.TabIndex = 82;
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightBlockSpacingNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightToIDLabel
            // 
            this.AmbiLightModeRightToIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightToIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightToIDLabel.Location = new System.Drawing.Point(158, 154);
            this.AmbiLightModeRightToIDLabel.Name = "AmbiLightModeRightToIDLabel";
            this.AmbiLightModeRightToIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeRightToIDLabel.TabIndex = 92;
            this.AmbiLightModeRightToIDLabel.Text = "To Series ID";
            this.AmbiLightModeRightToIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightBlockSpacingLabel
            // 
            this.AmbiLightModeRightBlockSpacingLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockSpacingLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockSpacingLabel.Location = new System.Drawing.Point(157, 73);
            this.AmbiLightModeRightBlockSpacingLabel.Name = "AmbiLightModeRightBlockSpacingLabel";
            this.AmbiLightModeRightBlockSpacingLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightBlockSpacingLabel.TabIndex = 83;
            this.AmbiLightModeRightBlockSpacingLabel.Text = "Block Spacing";
            this.AmbiLightModeRightBlockSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightToIDNumericUpDown
            // 
            this.AmbiLightModeRightToIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightToIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeRightToIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightToIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightToIDNumericUpDown.Location = new System.Drawing.Point(158, 172);
            this.AmbiLightModeRightToIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeRightToIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.AmbiLightModeRightToIDNumericUpDown.Name = "AmbiLightModeRightToIDNumericUpDown";
            this.AmbiLightModeRightToIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeRightToIDNumericUpDown.TabIndex = 90;
            this.AmbiLightModeRightToIDNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightToIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // AmbiLightModeRightBlockOffsetXNumericUpDown
            // 
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Location = new System.Drawing.Point(10, 131);
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Name = "AmbiLightModeRightBlockOffsetXNumericUpDown";
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.TabIndex = 85;
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightBlockOffsetXNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightFromIDLabel
            // 
            this.AmbiLightModeRightFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightFromIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightFromIDLabel.Location = new System.Drawing.Point(8, 155);
            this.AmbiLightModeRightFromIDLabel.Name = "AmbiLightModeRightFromIDLabel";
            this.AmbiLightModeRightFromIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeRightFromIDLabel.TabIndex = 91;
            this.AmbiLightModeRightFromIDLabel.Text = "From Series ID";
            this.AmbiLightModeRightFromIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightBlockOffsetXLabel
            // 
            this.AmbiLightModeRightBlockOffsetXLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockOffsetXLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockOffsetXLabel.Location = new System.Drawing.Point(7, 114);
            this.AmbiLightModeRightBlockOffsetXLabel.Name = "AmbiLightModeRightBlockOffsetXLabel";
            this.AmbiLightModeRightBlockOffsetXLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightBlockOffsetXLabel.TabIndex = 86;
            this.AmbiLightModeRightBlockOffsetXLabel.Text = "Block Offset X";
            this.AmbiLightModeRightBlockOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeRightFromIDNumericUpDown
            // 
            this.AmbiLightModeRightFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeRightFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightFromIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightFromIDNumericUpDown.Location = new System.Drawing.Point(9, 172);
            this.AmbiLightModeRightFromIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeRightFromIDNumericUpDown.Name = "AmbiLightModeRightFromIDNumericUpDown";
            this.AmbiLightModeRightFromIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeRightFromIDNumericUpDown.TabIndex = 89;
            this.AmbiLightModeRightFromIDNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeRightBlockOffsetYNumericUpDown
            // 
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Location = new System.Drawing.Point(160, 131);
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Name = "AmbiLightModeRightBlockOffsetYNumericUpDown";
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.TabIndex = 87;
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Tag = "Setting";
            this.AmbiLightModeRightBlockOffsetYNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeRightBlockOffsetYLabel
            // 
            this.AmbiLightModeRightBlockOffsetYLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeRightBlockOffsetYLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeRightBlockOffsetYLabel.Location = new System.Drawing.Point(157, 113);
            this.AmbiLightModeRightBlockOffsetYLabel.Name = "AmbiLightModeRightBlockOffsetYLabel";
            this.AmbiLightModeRightBlockOffsetYLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeRightBlockOffsetYLabel.TabIndex = 88;
            this.AmbiLightModeRightBlockOffsetYLabel.Text = "Block Offset Y";
            this.AmbiLightModeRightBlockOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomPanel
            // 
            this.AmbiLightModeBottomPanel.BackColor = System.Drawing.Color.Gray;
            this.AmbiLightModeBottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomPanelLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomLEDsPrBlockNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomLEDsPrBlockLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockWidthNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockWidthLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockHeightNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockHeightLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockSpacingNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockSpacingLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomToIDLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomToIDNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockOffsetXNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomFromIDLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockOffsetXLabel);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomFromIDNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockOffsetYNumericUpDown);
            this.AmbiLightModeBottomPanel.Controls.Add(this.AmbiLightModeBottomBlockOffsetYLabel);
            this.AmbiLightModeBottomPanel.Enabled = false;
            this.AmbiLightModeBottomPanel.Location = new System.Drawing.Point(332, 334);
            this.AmbiLightModeBottomPanel.Name = "AmbiLightModeBottomPanel";
            this.AmbiLightModeBottomPanel.Size = new System.Drawing.Size(316, 199);
            this.AmbiLightModeBottomPanel.TabIndex = 107;
            // 
            // AmbiLightModeBottomPanelLabel
            // 
            this.AmbiLightModeBottomPanelLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomPanelLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomPanelLabel.Location = new System.Drawing.Point(6, 7);
            this.AmbiLightModeBottomPanelLabel.Name = "AmbiLightModeBottomPanelLabel";
            this.AmbiLightModeBottomPanelLabel.Size = new System.Drawing.Size(300, 15);
            this.AmbiLightModeBottomPanelLabel.TabIndex = 94;
            this.AmbiLightModeBottomPanelLabel.Text = "Bottom Side";
            this.AmbiLightModeBottomPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmbiLightModeBottomLEDsPrBlockNumericUpDown
            // 
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Location = new System.Drawing.Point(11, 50);
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Name = "AmbiLightModeBottomLEDsPrBlockNumericUpDown";
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.TabIndex = 70;
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomLEDsPrBlockNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AmbiLightModeBottomLEDsPrBlockLabel
            // 
            this.AmbiLightModeBottomLEDsPrBlockLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomLEDsPrBlockLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomLEDsPrBlockLabel.Location = new System.Drawing.Point(8, 32);
            this.AmbiLightModeBottomLEDsPrBlockLabel.Name = "AmbiLightModeBottomLEDsPrBlockLabel";
            this.AmbiLightModeBottomLEDsPrBlockLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomLEDsPrBlockLabel.TabIndex = 71;
            this.AmbiLightModeBottomLEDsPrBlockLabel.Text = "LEDs pr Block";
            this.AmbiLightModeBottomLEDsPrBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomBlockWidthNumericUpDown
            // 
            this.AmbiLightModeBottomBlockWidthNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockWidthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Location = new System.Drawing.Point(11, 91);
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Name = "AmbiLightModeBottomBlockWidthNumericUpDown";
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomBlockWidthNumericUpDown.TabIndex = 76;
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomBlockWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeBottomBlockWidthLabel
            // 
            this.AmbiLightModeBottomBlockWidthLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockWidthLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockWidthLabel.Location = new System.Drawing.Point(8, 72);
            this.AmbiLightModeBottomBlockWidthLabel.Name = "AmbiLightModeBottomBlockWidthLabel";
            this.AmbiLightModeBottomBlockWidthLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomBlockWidthLabel.TabIndex = 77;
            this.AmbiLightModeBottomBlockWidthLabel.Text = "Block Width";
            this.AmbiLightModeBottomBlockWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomBlockHeightNumericUpDown
            // 
            this.AmbiLightModeBottomBlockHeightNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockHeightNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Location = new System.Drawing.Point(160, 50);
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Name = "AmbiLightModeBottomBlockHeightNumericUpDown";
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomBlockHeightNumericUpDown.TabIndex = 78;
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomBlockHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeBottomBlockHeightLabel
            // 
            this.AmbiLightModeBottomBlockHeightLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockHeightLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockHeightLabel.Location = new System.Drawing.Point(157, 32);
            this.AmbiLightModeBottomBlockHeightLabel.Name = "AmbiLightModeBottomBlockHeightLabel";
            this.AmbiLightModeBottomBlockHeightLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomBlockHeightLabel.TabIndex = 79;
            this.AmbiLightModeBottomBlockHeightLabel.Text = "Block Height";
            this.AmbiLightModeBottomBlockHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomBlockSpacingNumericUpDown
            // 
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Location = new System.Drawing.Point(160, 91);
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Name = "AmbiLightModeBottomBlockSpacingNumericUpDown";
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.TabIndex = 80;
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomBlockSpacingNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeBottomBlockSpacingLabel
            // 
            this.AmbiLightModeBottomBlockSpacingLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockSpacingLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockSpacingLabel.Location = new System.Drawing.Point(157, 72);
            this.AmbiLightModeBottomBlockSpacingLabel.Name = "AmbiLightModeBottomBlockSpacingLabel";
            this.AmbiLightModeBottomBlockSpacingLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomBlockSpacingLabel.TabIndex = 81;
            this.AmbiLightModeBottomBlockSpacingLabel.Text = "Block Spacing";
            this.AmbiLightModeBottomBlockSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomToIDLabel
            // 
            this.AmbiLightModeBottomToIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomToIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomToIDLabel.Location = new System.Drawing.Point(159, 154);
            this.AmbiLightModeBottomToIDLabel.Name = "AmbiLightModeBottomToIDLabel";
            this.AmbiLightModeBottomToIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeBottomToIDLabel.TabIndex = 92;
            this.AmbiLightModeBottomToIDLabel.Text = "To Series ID";
            this.AmbiLightModeBottomToIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomToIDNumericUpDown
            // 
            this.AmbiLightModeBottomToIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomToIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeBottomToIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomToIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomToIDNumericUpDown.Location = new System.Drawing.Point(159, 172);
            this.AmbiLightModeBottomToIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeBottomToIDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.AmbiLightModeBottomToIDNumericUpDown.Name = "AmbiLightModeBottomToIDNumericUpDown";
            this.AmbiLightModeBottomToIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeBottomToIDNumericUpDown.TabIndex = 90;
            this.AmbiLightModeBottomToIDNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomToIDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // AmbiLightModeBottomBlockOffsetXNumericUpDown
            // 
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Location = new System.Drawing.Point(11, 131);
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Name = "AmbiLightModeBottomBlockOffsetXNumericUpDown";
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.TabIndex = 85;
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomBlockOffsetXNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AmbiLightModeBottomFromIDLabel
            // 
            this.AmbiLightModeBottomFromIDLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomFromIDLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomFromIDLabel.Location = new System.Drawing.Point(9, 155);
            this.AmbiLightModeBottomFromIDLabel.Name = "AmbiLightModeBottomFromIDLabel";
            this.AmbiLightModeBottomFromIDLabel.Size = new System.Drawing.Size(147, 11);
            this.AmbiLightModeBottomFromIDLabel.TabIndex = 91;
            this.AmbiLightModeBottomFromIDLabel.Text = "From Series ID";
            this.AmbiLightModeBottomFromIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomBlockOffsetXLabel
            // 
            this.AmbiLightModeBottomBlockOffsetXLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockOffsetXLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockOffsetXLabel.Location = new System.Drawing.Point(8, 114);
            this.AmbiLightModeBottomBlockOffsetXLabel.Name = "AmbiLightModeBottomBlockOffsetXLabel";
            this.AmbiLightModeBottomBlockOffsetXLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomBlockOffsetXLabel.TabIndex = 86;
            this.AmbiLightModeBottomBlockOffsetXLabel.Text = "Block Offset X";
            this.AmbiLightModeBottomBlockOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeBottomFromIDNumericUpDown
            // 
            this.AmbiLightModeBottomFromIDNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomFromIDNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmbiLightModeBottomFromIDNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomFromIDNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomFromIDNumericUpDown.Location = new System.Drawing.Point(10, 172);
            this.AmbiLightModeBottomFromIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AmbiLightModeBottomFromIDNumericUpDown.Name = "AmbiLightModeBottomFromIDNumericUpDown";
            this.AmbiLightModeBottomFromIDNumericUpDown.Size = new System.Drawing.Size(49, 14);
            this.AmbiLightModeBottomFromIDNumericUpDown.TabIndex = 89;
            this.AmbiLightModeBottomFromIDNumericUpDown.Tag = "Setting";
            // 
            // AmbiLightModeBottomBlockOffsetYNumericUpDown
            // 
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Location = new System.Drawing.Point(160, 131);
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Minimum = new decimal(new int[] {
            8192,
            0,
            0,
            -2147483648});
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Name = "AmbiLightModeBottomBlockOffsetYNumericUpDown";
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Size = new System.Drawing.Size(143, 18);
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.TabIndex = 87;
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Tag = "Setting";
            this.AmbiLightModeBottomBlockOffsetYNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            // 
            // AmbiLightModeBottomBlockOffsetYLabel
            // 
            this.AmbiLightModeBottomBlockOffsetYLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeBottomBlockOffsetYLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeBottomBlockOffsetYLabel.Location = new System.Drawing.Point(157, 113);
            this.AmbiLightModeBottomBlockOffsetYLabel.Name = "AmbiLightModeBottomBlockOffsetYLabel";
            this.AmbiLightModeBottomBlockOffsetYLabel.Size = new System.Drawing.Size(143, 15);
            this.AmbiLightModeBottomBlockOffsetYLabel.TabIndex = 88;
            this.AmbiLightModeBottomBlockOffsetYLabel.Text = "Block Offset Y";
            this.AmbiLightModeBottomBlockOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmbiLightModeStopAmbilightButton
            // 
            this.AmbiLightModeStopAmbilightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeStopAmbilightButton.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeStopAmbilightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeStopAmbilightButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeStopAmbilightButton.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeStopAmbilightButton.Location = new System.Drawing.Point(466, 73);
            this.AmbiLightModeStopAmbilightButton.Name = "AmbiLightModeStopAmbilightButton";
            this.AmbiLightModeStopAmbilightButton.Size = new System.Drawing.Size(195, 22);
            this.AmbiLightModeStopAmbilightButton.TabIndex = 110;
            this.AmbiLightModeStopAmbilightButton.Text = "Stop Ambilight";
            this.AmbiLightModeStopAmbilightButton.UseVisualStyleBackColor = false;
            this.AmbiLightModeStopAmbilightButton.Click += new System.EventHandler(this.AmbiLightModeStopAmbilightButton_Click);
            // 
            // AmbiLightModeStartAmbilightButton
            // 
            this.AmbiLightModeStartAmbilightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeStartAmbilightButton.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeStartAmbilightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeStartAmbilightButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeStartAmbilightButton.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeStartAmbilightButton.Location = new System.Drawing.Point(242, 73);
            this.AmbiLightModeStartAmbilightButton.Name = "AmbiLightModeStartAmbilightButton";
            this.AmbiLightModeStartAmbilightButton.Size = new System.Drawing.Size(195, 22);
            this.AmbiLightModeStartAmbilightButton.TabIndex = 101;
            this.AmbiLightModeStartAmbilightButton.Text = "Start Ambilight";
            this.AmbiLightModeStartAmbilightButton.UseVisualStyleBackColor = false;
            this.AmbiLightModeStartAmbilightButton.Click += new System.EventHandler(this.AmbiLightModeStartAmbilightButton_Click);
            // 
            // AmbiLightModeShowHideBlocksButton
            // 
            this.AmbiLightModeShowHideBlocksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.AmbiLightModeShowHideBlocksButton.FlatAppearance.BorderSize = 0;
            this.AmbiLightModeShowHideBlocksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbiLightModeShowHideBlocksButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeShowHideBlocksButton.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeShowHideBlocksButton.Location = new System.Drawing.Point(18, 73);
            this.AmbiLightModeShowHideBlocksButton.Name = "AmbiLightModeShowHideBlocksButton";
            this.AmbiLightModeShowHideBlocksButton.Size = new System.Drawing.Size(195, 22);
            this.AmbiLightModeShowHideBlocksButton.TabIndex = 84;
            this.AmbiLightModeShowHideBlocksButton.Text = "Show/hide Blocks";
            this.AmbiLightModeShowHideBlocksButton.UseVisualStyleBackColor = false;
            this.AmbiLightModeShowHideBlocksButton.Click += new System.EventHandler(this.AmbiLightModeShowHideBlocksButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.AmbiLightModeTopLabel);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 63);
            this.panel3.TabIndex = 69;
            // 
            // AmbiLightModeTopLabel
            // 
            this.AmbiLightModeTopLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmbiLightModeTopLabel.ForeColor = System.Drawing.Color.White;
            this.AmbiLightModeTopLabel.Location = new System.Drawing.Point(0, 0);
            this.AmbiLightModeTopLabel.Name = "AmbiLightModeTopLabel";
            this.AmbiLightModeTopLabel.Size = new System.Drawing.Size(687, 63);
            this.AmbiLightModeTopLabel.TabIndex = 10;
            this.AmbiLightModeTopLabel.Text = "Ambilight Mode";
            this.AmbiLightModeTopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1411, 775);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ConfigureSetupHiddenProgressBar);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.ConfigureSetupPanel);
            this.Controls.Add(this.InstructionsPanel);
            this.Controls.Add(this.AmbiLightModePanel);
            this.Controls.Add(this.IndividualLEDPanel);
            this.Controls.Add(this.VisualizerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1411, 775);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1411, 775);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.Text = "ArduLED";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.ResetToDefaultPosition);
            this.Resize += new System.EventHandler(this.ResetToDefaultPosition);
            ((System.ComponentModel.ISupportInitialize)(this.SampleTimeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualSamplesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneFromTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneToTrackBar)).EndInit();
            this.VisualizerPanel.ResumeLayout(false);
            this.VisualizerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizerToSeriesIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizerFromSeriesIDNumericUpDown)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerMaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerIncreseAtNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoTriggerDecreseAtNumericUpDown)).EndInit();
            this.panel5.ResumeLayout(false);
            this.FullSpectrumPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FullSpectrumNumericUpDown)).EndInit();
            this.WavePanel.ResumeLayout(false);
            this.WavePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveChart)).EndInit();
            this.SpectrumPanel.ResumeLayout(false);
            this.SpectrumPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatZoneTriggerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsRedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsGreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsFadeSpeedNumericUpDown)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.FadeLEDPanel.ResumeLayout(false);
            this.FadeLEDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FadeLEDPanelToIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeLEDPanelFromIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeColorsFadeFactorNumericUpDown)).EndInit();
            this.IndividualLEDPanel.ResumeLayout(false);
            this.IndividualLEDPanel.PerformLayout();
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDRedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividalLEDGreenTrackBar)).EndInit();
            this.InstructionsPanel.ResumeLayout(false);
            this.InstructionsAddIndividualLEDPanel.ResumeLayout(false);
            this.InstructionsAddIndividualLEDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDOnPinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDAtIdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDRedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddIndividualLEDGreenTrackBar)).EndInit();
            this.InstructionsAddFadeColorsPanel.ResumeLayout(false);
            this.InstructionsAddFadeColorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsToSeriesIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFadeFactorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFromSeriesIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsFadeSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsRedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddFadeColorsGreenTrackBar)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.InstructionsAddAmbilightPanel.ResumeLayout(false);
            this.InstructionsAddVisualizerPanel.ResumeLayout(false);
            this.InstructionsAddVisualizerPanel.PerformLayout();
            this.InstructionsAddDelayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsAddDelayNumericUpDown)).EndInit();
            this.ConfigureSetupPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripPinID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripFromLEDID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripXDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigureSetupAddStripYDir)).EndInit();
            this.AmbiLightModePanel.ResumeLayout(false);
            this.AmbiLightModeWorkingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeGammaFactorNumericUpDown)).EndInit();
            this.AmbiLightModeLeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftLEDsPrBlockNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockSpacingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftToIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockOffsetXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftFromIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeLeftBlockOffsetYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeScreenIDNumericUpDown)).EndInit();
            this.AmbiLightModeTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopLEDsPrBlockNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockSpacingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopToIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockOffsetXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopFromIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeTopBlockOffsetYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeFadeFactorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBlockSampleSplitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRefreshRateNumericUpDown)).EndInit();
            this.AmbiLightModeRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightLEDsPrBlockNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockSpacingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightToIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockOffsetXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightFromIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeRightBlockOffsetYNumericUpDown)).EndInit();
            this.AmbiLightModeBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomLEDsPrBlockNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockSpacingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomToIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockOffsetXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomFromIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbiLightModeBottomBlockOffsetYNumericUpDown)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label AudioSourceLabel;
        private System.Windows.Forms.Label VisualSamplesLabel;
        private System.Windows.Forms.ComboBox VisualizationTypeComboBox;
        private System.Windows.Forms.Label VisualizationTypeLabel;
        private System.Windows.Forms.Label VisualizerTopLabel;
        private System.Windows.Forms.Label SensitivityTopLabel;
        private System.Windows.Forms.Label SmoothnessLabel;
        private System.Windows.Forms.Label SensitivityLabel;
        private System.Windows.Forms.Label SmoothnessTopLabel;
        private System.Windows.Forms.Label AudioSampleRateLabel;
        private System.Windows.Forms.Label SampleTimeLabel;
        private System.Windows.Forms.Label SampleTimeTopLabel;
        private System.Windows.Forms.Label BeatZoneFromLabel;
        private System.Windows.Forms.Label BeatZoneToLabel;
        private System.Windows.Forms.Label BeatZoneTopLabel;
        private System.Windows.Forms.Panel VisualizerPanel;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.TrackBar FadeColorsBlueTrackBar;
        private System.Windows.Forms.Label FadeColorsGreenTopLabel;
        private System.Windows.Forms.Label FadeColorsBlueTopLabel;
        private System.Windows.Forms.Label FadeColorsRedTopLabel;
        private System.Windows.Forms.Label FadeColorsRedLabel;
        private System.Windows.Forms.TrackBar FadeColorsRedTrackBar;
        private System.Windows.Forms.Label FadeColorsGreenLabel;
        private System.Windows.Forms.TrackBar FadeColorsGreenTrackBar;
        private System.Windows.Forms.Label FadeColorsBlueLabel;
        private System.Windows.Forms.Button MenuConnectButton;
        private System.Windows.Forms.ComboBox ComPortsComboBox;
        private System.Windows.Forms.Label MenuSelectComDeviceLabel;
        private System.Windows.Forms.NumericUpDown FadeColorsFadeSpeedNumericUpDown;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Label FadeColorsFadeFactorLabel;
        private System.Windows.Forms.NumericUpDown FadeColorsFadeFactorNumericUpDown;
        private System.Windows.Forms.Label FadeColorsFadeSpeedLabel;
        private System.Windows.Forms.Panel FadeLEDPanel;
        private System.Windows.Forms.Label MenuModeLabel;
        private System.Windows.Forms.ComboBox ModeSelectrionComboBox;
        private System.Windows.Forms.Panel IndividualLEDPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label SpectrumBlueLabel;
        private System.Windows.Forms.TextBox SpectrumBlueTextBox;
        private System.Windows.Forms.Label SpectrumGreenLabel;
        private System.Windows.Forms.TextBox SpectrumGreenTextBox;
        private System.Windows.Forms.Label SpectrumRedLabel;
        private System.Windows.Forms.TextBox SpectrumRedTextBox;
        private System.Windows.Forms.Label SpectrumTopLabel;
        private System.Windows.Forms.Button UpdateSpectrumButton;
        private System.Windows.Forms.Panel IndividualLEDWorkingPanel;
        private System.Windows.Forms.TrackBar IndividalLEDRedTrackBar;
        private System.Windows.Forms.TrackBar IndividalLEDBlueTrackBar;
        private System.Windows.Forms.Label IndividualLEDGreenNameLabel;
        private System.Windows.Forms.Label IndividualLEDBlueNameLabel;
        private System.Windows.Forms.Label IndividualLEDRedNameLabel;
        private System.Windows.Forms.Label IndividalLEDRedLabel;
        private System.Windows.Forms.Label IndividalLEDGreenLabel;
        private System.Windows.Forms.TrackBar IndividalLEDGreenTrackBar;
        private System.Windows.Forms.Label IndividalLEDBlueLabel;
        private System.Windows.Forms.Label FadeColorsBrightnessLabel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog LoadFileDialog;
        private System.Windows.Forms.Panel InstructionsPanel;
        private System.Windows.Forms.Panel InstructionsWorkingPanel;
        private System.Windows.Forms.Button InstructionStartLoopButton;
        private System.Windows.Forms.CheckBox InstructionsLoopCheckBox;
        private System.Windows.Forms.Panel InstructionsAddFadeColorsPanel;
        private System.Windows.Forms.Label InstructionsAddFadeColorsTopLabel;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button InstructionsAddFadeColorsButton;
        private System.Windows.Forms.Button InstructionsAddDelayButton;
        private System.Windows.Forms.Label InstructionsModeAddItemsLabel;
        private System.Windows.Forms.Panel InstructionsAddDelayPanel;
        private System.Windows.Forms.Label InstructionsAddDelayNoteLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddDelayNumericUpDown;
        private System.Windows.Forms.Label InstructionsAddDelayTopLabel;
        private System.Windows.Forms.Button InstructionsAddDelayAddButton;
        private System.Windows.Forms.Label InstructionsAddFadeColorsFadeFactorLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddFadeColorsFadeFactorNumericUpDown;
        private System.Windows.Forms.Label InstructionsAddFadeColorsFadeSpeedLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddFadeColorsFadeSpeedNumericUpDown;
        private System.Windows.Forms.Button InstructionsAddFadeColorsAddButton;
        private System.Windows.Forms.TrackBar InstructionsAddFadeColorsRedTrackBar;
        private System.Windows.Forms.TrackBar InstructionsAddFadeColorsBlueTrackBar;
        private System.Windows.Forms.Label InstructionsAddFadeColorsGreenNameLabel;
        private System.Windows.Forms.Label InstructionsAddFadeColorsBlueNameLabel;
        private System.Windows.Forms.Label InstructionsAddFadeColorsRedNameLabel;
        private System.Windows.Forms.Label InstructionsAddFadeColorsRedLabel;
        private System.Windows.Forms.Label InstructionsAddFadeColorsGreenLabel;
        private System.Windows.Forms.TrackBar InstructionsAddFadeColorsGreenTrackBar;
        private System.Windows.Forms.Label InstructionsAddFadeColorsBlueLabel;
        private System.Windows.Forms.Panel WavePanel;
        private System.Windows.Forms.Label WaveTopLabel;
        private System.Windows.Forms.Button UpdateWaveButton;
        private System.Windows.Forms.Label WaveBlueLabel;
        private System.Windows.Forms.TextBox WaveRedTextBox;
        private System.Windows.Forms.TextBox WaveBlueTextBox;
        private System.Windows.Forms.Label WaveRedLabel;
        private System.Windows.Forms.Label WaveGreenLabel;
        private System.Windows.Forms.TextBox WaveGreenTextBox;
        private System.Windows.Forms.Panel SpectrumPanel;
        private System.Windows.Forms.Label AutoTriggerDecreseAtLabel;
        private System.Windows.Forms.Label AutoTriggerIncreseAtLabel;
        private System.Windows.Forms.Panel ConfigureSetupPanel;
        private System.Windows.Forms.Button LoadSetupButton;
        private System.Windows.Forms.Button SaveSetupButton;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label ConfigureSetupAddStripPinIDLabel;
        private System.Windows.Forms.NumericUpDown ConfigureSetupAddStripPinID;
        private System.Windows.Forms.CheckBox ConfigureSetupAddStripInvertY;
        private System.Windows.Forms.CheckBox ConfigureSetupAddStripInvertX;
        private System.Windows.Forms.Label ConfigureSetupAddStripFromLEDIDLabel;
        private System.Windows.Forms.NumericUpDown ConfigureSetupAddStripFromLEDID;
        private System.Windows.Forms.NumericUpDown ConfigureSetupAddStripXDir;
        private System.Windows.Forms.Label ConfigureSetupAddStripYDirLabel;
        private System.Windows.Forms.NumericUpDown ConfigureSetupAddStripYDir;
        private System.Windows.Forms.Label ConfigureSetupAddStripXDirLabel;
        private System.Windows.Forms.Button AddLEDStripButton;
        private System.Windows.Forms.Panel ConfigureSetupWorkingPanel;
        private System.Windows.Forms.Button SendSetupButton;
        private System.Windows.Forms.Button MenuExitButton;
        private System.Windows.Forms.ProgressBar SendSetupProgressBar;
        private System.Windows.Forms.CheckBox ColorEntireLEDStripCheckBox;
        private System.Windows.Forms.Label AutoTriggerMinLabel;
        private System.Windows.Forms.Label AutoTriggerMaxLabel;
        private System.Windows.Forms.Label PixelBitstreamComboBoxLabel;
        private System.Windows.Forms.ComboBox PixelBitstreamComboBox;
        private System.Windows.Forms.Label PixelTypeComboBoxLabel;
        private System.Windows.Forms.ComboBox PixelTypeComboBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label ConfigureSetupTopLabel;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label InstructionsModeTopLabel;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label IndividualLEDTopLabel;
        private System.Windows.Forms.Button InstructionsModeLoadButton;
        private System.Windows.Forms.Button InstructionsModeSaveButton;
        private System.IO.Ports.SerialPort SerialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpectrumChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart WaveChart;
        private System.Windows.Forms.ProgressBar BeatWaveProgressBar;
        private System.Windows.Forms.NumericUpDown AutoTriggerIncreseAtNumericUpDown;
        private System.Windows.Forms.NumericUpDown AutoTriggerDecreseAtNumericUpDown;
        private System.Windows.Forms.CheckBox AutoTriggerCheckBox;
        private System.Windows.Forms.TrackBar BeatZoneTriggerHeight;
        private System.Windows.Forms.Label BeatZoneTriggerHeightLabel;
        private System.Windows.Forms.NumericUpDown AutoTriggerMinNumericUpDown;
        private System.Windows.Forms.NumericUpDown AutoTriggerMaxNumericUpDown;
        private System.Windows.Forms.ComboBox AudioSourceComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart BeatZoneChart;
        private System.Windows.Forms.TrackBar SensitivityTrackBar;
        private System.Windows.Forms.TrackBar SmoothnessTrackBar;
        private System.Windows.Forms.TrackBar SampleTimeTrackBar;
        private System.Windows.Forms.TrackBar BeatZoneFromTrackBar;
        private System.Windows.Forms.TrackBar BeatZoneToTrackBar;
        private System.Windows.Forms.NumericUpDown VisualSamplesNumericUpDown;
        private System.Windows.Forms.ComboBox AudioSampleRateComboBox;
        private System.Windows.Forms.Label InstructionsAddDelayLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.ProgressBar ConfigureSetupHiddenProgressBar;
        private System.Windows.Forms.CheckBox ConfigureSetupAutoSendCheckBox;
        private System.Windows.Forms.Label VisualizerCurrentValueLabel;
        private System.Windows.Forms.Button InstructionStopLoopButton;
        private System.Windows.Forms.Panel FullSpectrumPanel;
        private System.Windows.Forms.Label FullSpectrumTopLabel;
        private System.Windows.Forms.Label FullSpectrumLabel;
        private System.Windows.Forms.NumericUpDown FullSpectrumNumericUpDown;
        private System.Windows.Forms.CheckBox WaveAutoScaleValuesCheckBox;
        private System.Windows.Forms.CheckBox SpectrumAutoScaleValuesCheckBox;
        private System.Windows.Forms.Label ConfigureSetupClickToSetupSeriesFromIDLabel;
        private System.Windows.Forms.NumericUpDown ConfigureSetupClickToSetupSeriesFromIDNumericUpDown;
        private System.Windows.Forms.CheckBox ConfigureSetupClickToSetupSeriesCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label VisualizerToSeriesIDLabel;
        private System.Windows.Forms.NumericUpDown VisualizerToSeriesIDNumericUpDown;
        private System.Windows.Forms.Label VisualizerFromSeriesIDLabel;
        private System.Windows.Forms.NumericUpDown VisualizerFromSeriesIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown InstructionsAddFadeColorsToSeriesIDNumericUpDown;
        private System.Windows.Forms.Label InstructionsAddFadeColorsToSeriesIDLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddFadeColorsFromSeriesIDNumericUpDown;
        private System.Windows.Forms.Label InstructionsAddFadeColorsFromSeriesIDLabel;
        private System.Windows.Forms.Button VisualizerLoadSettingsButton;
        private System.Windows.Forms.Button VisualizerSaveSettingsButton;
        private System.Windows.Forms.Timer HideTimer;
        private System.Windows.Forms.CheckBox MenuAutoHideCheckBox;
        private System.Windows.Forms.CheckBox EnableDataCompressionMode;
        private System.Windows.Forms.Panel AmbiLightModePanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label AmbiLightModeTopLabel;
        private System.Windows.Forms.Label AmbiLightModeLeftLEDsPrBlockLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftLEDsPrBlockNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftBlockHeightLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftBlockHeightNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftBlockWidthLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftBlockWidthNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftBlockSpacingLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftBlockSpacingNumericUpDown;
        private System.Windows.Forms.Button AmbiLightModeShowHideBlocksButton;
        private System.Windows.Forms.Label AmbiLightModeLeftBlockOffsetYLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftBlockOffsetYNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftBlockOffsetXLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftBlockOffsetXNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftToIDLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftToIDNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeLeftFromIDLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeLeftFromIDNumericUpDown;
        private System.Windows.Forms.CheckBox AmbiLightModeLeftCheckBox;
        private System.Windows.Forms.Button AmbiLightModeStartAmbilightButton;
        private System.Windows.Forms.Label AmbiLightModeRefreshRateLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRefreshRateNumericUpDown;
        private System.Windows.Forms.Panel AmbiLightModeLeftPanel;
        private System.Windows.Forms.Panel AmbiLightModeTopPanel;
        private System.Windows.Forms.CheckBox AmbiLightModeTopCheckBox;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopLEDsPrBlockNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopLEDsPrBlockLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopBlockWidthNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopBlockWidthLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopBlockHeightNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopBlockHeightLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopBlockSpacingNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopBlockSpacingLabel;
        private System.Windows.Forms.Label AmbiLightModeTopToIDLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopToIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopBlockOffsetXNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopFromIDLabel;
        private System.Windows.Forms.Label AmbiLightModeTopBlockOffsetXLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopFromIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeTopBlockOffsetYNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeTopBlockOffsetYLabel;
        private System.Windows.Forms.CheckBox AmbiLightModeBottomCheckBox;
        private System.Windows.Forms.CheckBox AmbiLightModeRightCheckBox;
        private System.Windows.Forms.Panel AmbiLightModeBottomPanel;
        private System.Windows.Forms.Label AmbiLightModeBottomPanelLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomLEDsPrBlockNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomLEDsPrBlockLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomBlockWidthNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomBlockWidthLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomBlockHeightNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomBlockHeightLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomBlockSpacingNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomBlockSpacingLabel;
        private System.Windows.Forms.Label AmbiLightModeBottomToIDLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomToIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomBlockOffsetXNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomFromIDLabel;
        private System.Windows.Forms.Label AmbiLightModeBottomBlockOffsetXLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomFromIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBottomBlockOffsetYNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeBottomBlockOffsetYLabel;
        private System.Windows.Forms.Panel AmbiLightModeRightPanel;
        private System.Windows.Forms.Label AmbiLightModeRightPanelLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightLEDsPrBlockNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightLEDsPrBlockLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightBlockWidthNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightBlockWidthLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightBlockHeightNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightBlockHeightLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightBlockSpacingNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightToIDLabel;
        private System.Windows.Forms.Label AmbiLightModeRightBlockSpacingLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightToIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightBlockOffsetXNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightFromIDLabel;
        private System.Windows.Forms.Label AmbiLightModeRightBlockOffsetXLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightFromIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmbiLightModeRightBlockOffsetYNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeRightBlockOffsetYLabel;
        private System.Windows.Forms.Label AmbiLightModeTopPanelLabel;
        private System.Windows.Forms.Label AmbiLightModeLeftPanelLabel;
        private System.Windows.Forms.Label AmbiLightModeBlockSampleSplitLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeBlockSampleSplitNumericUpDown;
        private System.Windows.Forms.Button AmbiLightModeStopAmbilightButton;
        private System.Windows.Forms.Button AmbiLightModeLoadSetup;
        private System.Windows.Forms.Button AmbiLightModeSaveSetup;
        private System.Windows.Forms.Label AmbiLightModeScreenIDLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeScreenIDNumericUpDown;
        private System.Windows.Forms.Label AmbiLightModeFadeFactorLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeFadeFactorNumericUpDown;
        private System.Windows.Forms.Label AmbilightModeFPSCounterLabel;
        private System.Windows.Forms.Panel AmbiLightModeWorkingPanel;
        private System.Windows.Forms.Label FadeLEDPanelToIDLabel;
        private System.Windows.Forms.NumericUpDown FadeLEDPanelToIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown FadeLEDPanelFromIDNumericUpDown;
        private System.Windows.Forms.Label FadeLEDPanelFromIDLabel;
        private System.Windows.Forms.Button InstructionsAddVisualizerButton;
        private System.Windows.Forms.Panel InstructionsAddVisualizerPanel;
        private System.Windows.Forms.Button InstructionsAddVisualizerPanelAdd;
        private System.Windows.Forms.Label InstructionsAddVisualizerTopLabel;
        private System.Windows.Forms.Button InstructionsAddVisualizerLoadSetup;
        private System.Windows.Forms.CheckBox InstructionsAddVisualizerStopVisualizerCheckBox;
        private System.Windows.Forms.Panel InstructionsAddIndividualLEDPanel;
        private System.Windows.Forms.Button InstructionsAddIndividualLEDAddButton;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDPanelTopLabel;
        private System.Windows.Forms.Button InstructionsAddIndividualLEDButton;
        private System.Windows.Forms.TrackBar InstructionsAddIndividualLEDRedTrackBar;
        private System.Windows.Forms.TrackBar InstructionsAddIndividualLEDBlueTrackBar;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDGreenLabel;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDBlueLabel;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDRedLabel;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDRedValueLabel;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDGreenValueLabel;
        private System.Windows.Forms.TrackBar InstructionsAddIndividualLEDGreenTrackBar;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDBlueValueLabel;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDAtIDLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddIndividualLEDAtIdNumericUpDown;
        private System.Windows.Forms.Label InstructionsAddIndividualLEDOnPinLabel;
        private System.Windows.Forms.NumericUpDown InstructionsAddIndividualLEDOnPinNumericUpDown;
        private System.Windows.Forms.Panel InstructionsAddAmbilightPanel;
        private System.Windows.Forms.CheckBox InstructionsAddAmbilightAutoSetOffsetsCheckBox;
        private System.Windows.Forms.CheckBox InstructionsAddAmbilightStopAmbilightCheckBox;
        private System.Windows.Forms.Button InstructionsAddAmbilightUseAmbilightSettings;
        private System.Windows.Forms.Button InstructionsAddAmbilightAddButton;
        private System.Windows.Forms.Label InstructionsAddAmbilightTopLabel;
        private System.Windows.Forms.Button InstructionsAddAmbilightButton;
        private System.Windows.Forms.CheckBox InstructionsAddAmbilightShowHideBlocksCheckBox;
        private System.Windows.Forms.Button AmbiLightModeAutosetOffsets;
        private System.Windows.Forms.Label VisualizerRPSLabel;
        private System.Windows.Forms.Label AmbiLightModeGammaFactorLabel;
        private System.Windows.Forms.NumericUpDown AmbiLightModeGammaFactorNumericUpDown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ConfigureSetupRGBColorOrderLabel;
        private System.Windows.Forms.Label ConfigureSetupRGBColorOrderThirdLabel;
        private System.Windows.Forms.Label ConfigureSetupRGBColorOrderSeccondLabel;
        private System.Windows.Forms.Label ConfigureSetupRGBColorOrderFirstLabel;
        private System.Windows.Forms.TextBox ConfigureSetupRGBColorOrderThirdTextbox;
        private System.Windows.Forms.TextBox ConfigureSetupRGBColorOrderSeccondTextbox;
        private System.Windows.Forms.TextBox ConfigureSetupRGBColorOrderFirstTextbox;
    }
}

