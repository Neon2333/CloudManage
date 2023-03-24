
namespace CloudManage.DeepLearning
{
    partial class ModelTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelTest));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.totalImgCountLab = new DevExpress.XtraEditors.LabelControl();
            this.imagnameLab = new DevExpress.XtraEditors.LabelControl();
            this.dirLab = new DevExpress.XtraEditors.LabelControl();
            this.checkBoxRoi = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxSave = new DevExpress.XtraEditors.ComboBoxEdit();
            this.SizeWTb = new HZH_Controls.Controls.UCTextBoxEx();
            this.SizeHTb = new HZH_Controls.Controls.UCTextBoxEx();
            this.textBoxRoiY = new HZH_Controls.Controls.UCTextBoxEx();
            this.textBoxRoiX = new HZH_Controls.Controls.UCTextBoxEx();
            this.textBoxRoiHeight = new HZH_Controls.Controls.UCTextBoxEx();
            this.textBoxRoiWidth = new HZH_Controls.Controls.UCTextBoxEx();
            this.EncrypModelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SingTestBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DeepTestBtn = new DevExpress.XtraEditors.SimpleButton();
            this.readOriModelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.dirTestBtn = new DevExpress.XtraEditors.SimpleButton();
            this.readClassesBtn = new DevExpress.XtraEditors.SimpleButton();
            this.imageBoxShow = new Emgu.CV.UI.ImageBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ThreshTb = new HZH_Controls.Controls.UCTextBoxEx();
            this.PositionLab = new DevExpress.XtraEditors.LabelControl();
            this.labelRGB = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_dir = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dispLab = new DevExpress.XtraEditors.LabelControl();
            this.ucPanelQuote1 = new HZH_Controls.Controls.UCPanelQuote();
            this.ucPanelQuote2 = new HZH_Controls.Controls.UCPanelQuote();
            this.ucPanelQuote3 = new HZH_Controls.Controls.UCPanelQuote();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.labelControl4.Location = new System.Drawing.Point(344, 224);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(153, 23);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "模型尺寸（w，h）：";
            this.labelControl4.ToolTip = "this is a label control";
            // 
            // totalImgCountLab
            // 
            this.totalImgCountLab.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.totalImgCountLab.Appearance.Options.UseFont = true;
            this.totalImgCountLab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.totalImgCountLab.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.totalImgCountLab.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.totalImgCountLab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("totalImgCountLab.ImageOptions.Image")));
            this.totalImgCountLab.Location = new System.Drawing.Point(1169, 146);
            this.totalImgCountLab.Name = "totalImgCountLab";
            this.totalImgCountLab.Size = new System.Drawing.Size(119, 38);
            this.totalImgCountLab.TabIndex = 38;
            this.totalImgCountLab.Text = "图片总数：";
            this.totalImgCountLab.ToolTip = "this is a label control";
            // 
            // imagnameLab
            // 
            this.imagnameLab.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.imagnameLab.Appearance.Options.UseFont = true;
            this.imagnameLab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.imagnameLab.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.imagnameLab.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.imagnameLab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("imagnameLab.ImageOptions.Image")));
            this.imagnameLab.Location = new System.Drawing.Point(286, 146);
            this.imagnameLab.Name = "imagnameLab";
            this.imagnameLab.Size = new System.Drawing.Size(119, 38);
            this.imagnameLab.TabIndex = 37;
            this.imagnameLab.Text = "图片名称：";
            // 
            // dirLab
            // 
            this.dirLab.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dirLab.Appearance.Options.UseFont = true;
            this.dirLab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dirLab.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.dirLab.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.dirLab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dirLab.ImageOptions.Image")));
            this.dirLab.Location = new System.Drawing.Point(286, 90);
            this.dirLab.Name = "dirLab";
            this.dirLab.Size = new System.Drawing.Size(135, 38);
            this.dirLab.TabIndex = 36;
            this.dirLab.Text = "文件夹路径：";
            this.dirLab.ToolTip = "this is a label control";
            // 
            // checkBoxRoi
            // 
            this.checkBoxRoi.Location = new System.Drawing.Point(694, 220);
            this.checkBoxRoi.Name = "checkBoxRoi";
            this.checkBoxRoi.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.checkBoxRoi.Properties.Appearance.Options.UseFont = true;
            this.checkBoxRoi.Properties.Caption = "ROI（x，y，w，h）";
            this.checkBoxRoi.Size = new System.Drawing.Size(239, 44);
            this.checkBoxRoi.TabIndex = 61;
            this.checkBoxRoi.ToolTip = "兴趣区域";
            // 
            // comboBoxSave
            // 
            this.comboBoxSave.EditValue = "不保存图像";
            this.comboBoxSave.Location = new System.Drawing.Point(462, 721);
            this.comboBoxSave.Name = "comboBoxSave";
            this.comboBoxSave.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.comboBoxSave.Properties.Appearance.Options.UseFont = true;
            this.comboBoxSave.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.comboBoxSave.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxSave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxSave.Properties.Items.AddRange(new object[] {
            "不保存图像",
            "保存NG图像",
            "保存OK图像",
            "保存OK/NG图像"});
            this.comboBoxSave.Size = new System.Drawing.Size(247, 44);
            this.comboBoxSave.TabIndex = 62;
            // 
            // SizeWTb
            // 
            this.SizeWTb.BackColor = System.Drawing.Color.Transparent;
            this.SizeWTb.ConerRadius = 5;
            this.SizeWTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SizeWTb.DecLength = 2;
            this.SizeWTb.FillColor = System.Drawing.Color.Empty;
            this.SizeWTb.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.SizeWTb.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SizeWTb.InputText = "224";
            this.SizeWTb.InputType = HZH_Controls.TextInputType.NotControl;
            this.SizeWTb.IsFocusColor = true;
            this.SizeWTb.IsRadius = true;
            this.SizeWTb.IsShowClearBtn = true;
            this.SizeWTb.IsShowKeyboard = true;
            this.SizeWTb.IsShowRect = true;
            this.SizeWTb.IsShowSearchBtn = false;
            this.SizeWTb.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.SizeWTb.Location = new System.Drawing.Point(344, 264);
            this.SizeWTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SizeWTb.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.SizeWTb.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.SizeWTb.Name = "SizeWTb";
            this.SizeWTb.Padding = new System.Windows.Forms.Padding(5);
            this.SizeWTb.PasswordChar = '\0';
            this.SizeWTb.PromptColor = System.Drawing.Color.Gray;
            this.SizeWTb.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SizeWTb.PromptText = "";
            this.SizeWTb.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SizeWTb.RectWidth = 1;
            this.SizeWTb.RegexPattern = "";
            this.SizeWTb.Size = new System.Drawing.Size(115, 42);
            this.SizeWTb.TabIndex = 63;
            this.SizeWTb.TextChanged += new System.EventHandler(this.SizeWTb_TextChanged);
            // 
            // SizeHTb
            // 
            this.SizeHTb.BackColor = System.Drawing.Color.Transparent;
            this.SizeHTb.ConerRadius = 5;
            this.SizeHTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SizeHTb.DecLength = 2;
            this.SizeHTb.FillColor = System.Drawing.Color.Empty;
            this.SizeHTb.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.SizeHTb.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SizeHTb.InputText = "224";
            this.SizeHTb.InputType = HZH_Controls.TextInputType.NotControl;
            this.SizeHTb.IsFocusColor = true;
            this.SizeHTb.IsRadius = true;
            this.SizeHTb.IsShowClearBtn = true;
            this.SizeHTb.IsShowKeyboard = true;
            this.SizeHTb.IsShowRect = true;
            this.SizeHTb.IsShowSearchBtn = false;
            this.SizeHTb.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.SizeHTb.Location = new System.Drawing.Point(496, 264);
            this.SizeHTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SizeHTb.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.SizeHTb.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.SizeHTb.Name = "SizeHTb";
            this.SizeHTb.Padding = new System.Windows.Forms.Padding(5);
            this.SizeHTb.PasswordChar = '\0';
            this.SizeHTb.PromptColor = System.Drawing.Color.Gray;
            this.SizeHTb.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SizeHTb.PromptText = "";
            this.SizeHTb.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SizeHTb.RectWidth = 1;
            this.SizeHTb.RegexPattern = "";
            this.SizeHTb.Size = new System.Drawing.Size(115, 42);
            this.SizeHTb.TabIndex = 64;
            this.SizeHTb.TextChanged += new System.EventHandler(this.SizeHTb_TextChanged);
            // 
            // textBoxRoiY
            // 
            this.textBoxRoiY.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRoiY.ConerRadius = 5;
            this.textBoxRoiY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxRoiY.DecLength = 2;
            this.textBoxRoiY.FillColor = System.Drawing.Color.Empty;
            this.textBoxRoiY.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.textBoxRoiY.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiY.InputText = "0";
            this.textBoxRoiY.InputType = HZH_Controls.TextInputType.NotControl;
            this.textBoxRoiY.IsFocusColor = true;
            this.textBoxRoiY.IsRadius = true;
            this.textBoxRoiY.IsShowClearBtn = true;
            this.textBoxRoiY.IsShowKeyboard = true;
            this.textBoxRoiY.IsShowRect = true;
            this.textBoxRoiY.IsShowSearchBtn = false;
            this.textBoxRoiY.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.textBoxRoiY.Location = new System.Drawing.Point(863, 274);
            this.textBoxRoiY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRoiY.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxRoiY.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxRoiY.Name = "textBoxRoiY";
            this.textBoxRoiY.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxRoiY.PasswordChar = '\0';
            this.textBoxRoiY.PromptColor = System.Drawing.Color.Gray;
            this.textBoxRoiY.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiY.PromptText = "";
            this.textBoxRoiY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxRoiY.RectWidth = 1;
            this.textBoxRoiY.RegexPattern = "";
            this.textBoxRoiY.Size = new System.Drawing.Size(115, 42);
            this.textBoxRoiY.TabIndex = 66;
            this.textBoxRoiY.TextChanged += new System.EventHandler(this.textBoxRoiY_TextChanged);
            // 
            // textBoxRoiX
            // 
            this.textBoxRoiX.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRoiX.ConerRadius = 5;
            this.textBoxRoiX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxRoiX.DecLength = 2;
            this.textBoxRoiX.FillColor = System.Drawing.Color.Empty;
            this.textBoxRoiX.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.textBoxRoiX.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiX.InputText = "0";
            this.textBoxRoiX.InputType = HZH_Controls.TextInputType.NotControl;
            this.textBoxRoiX.IsFocusColor = true;
            this.textBoxRoiX.IsRadius = true;
            this.textBoxRoiX.IsShowClearBtn = true;
            this.textBoxRoiX.IsShowKeyboard = true;
            this.textBoxRoiX.IsShowRect = true;
            this.textBoxRoiX.IsShowSearchBtn = false;
            this.textBoxRoiX.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.textBoxRoiX.Location = new System.Drawing.Point(703, 274);
            this.textBoxRoiX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRoiX.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxRoiX.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxRoiX.Name = "textBoxRoiX";
            this.textBoxRoiX.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxRoiX.PasswordChar = '\0';
            this.textBoxRoiX.PromptColor = System.Drawing.Color.Gray;
            this.textBoxRoiX.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiX.PromptText = "";
            this.textBoxRoiX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxRoiX.RectWidth = 1;
            this.textBoxRoiX.RegexPattern = "";
            this.textBoxRoiX.Size = new System.Drawing.Size(115, 42);
            this.textBoxRoiX.TabIndex = 65;
            this.textBoxRoiX.TextChanged += new System.EventHandler(this.textBoxRoiX_TextChanged);
            this.textBoxRoiX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRoiX_KeyDown);
            // 
            // textBoxRoiHeight
            // 
            this.textBoxRoiHeight.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRoiHeight.ConerRadius = 5;
            this.textBoxRoiHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxRoiHeight.DecLength = 2;
            this.textBoxRoiHeight.FillColor = System.Drawing.Color.Empty;
            this.textBoxRoiHeight.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.textBoxRoiHeight.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiHeight.InputText = "480";
            this.textBoxRoiHeight.InputType = HZH_Controls.TextInputType.NotControl;
            this.textBoxRoiHeight.IsFocusColor = true;
            this.textBoxRoiHeight.IsRadius = true;
            this.textBoxRoiHeight.IsShowClearBtn = true;
            this.textBoxRoiHeight.IsShowKeyboard = true;
            this.textBoxRoiHeight.IsShowRect = true;
            this.textBoxRoiHeight.IsShowSearchBtn = false;
            this.textBoxRoiHeight.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.textBoxRoiHeight.Location = new System.Drawing.Point(863, 348);
            this.textBoxRoiHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRoiHeight.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxRoiHeight.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxRoiHeight.Name = "textBoxRoiHeight";
            this.textBoxRoiHeight.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxRoiHeight.PasswordChar = '\0';
            this.textBoxRoiHeight.PromptColor = System.Drawing.Color.Gray;
            this.textBoxRoiHeight.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiHeight.PromptText = "";
            this.textBoxRoiHeight.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxRoiHeight.RectWidth = 1;
            this.textBoxRoiHeight.RegexPattern = "";
            this.textBoxRoiHeight.Size = new System.Drawing.Size(115, 42);
            this.textBoxRoiHeight.TabIndex = 68;
            this.textBoxRoiHeight.TextChanged += new System.EventHandler(this.textBoxRoiHeight_TextChanged);
            // 
            // textBoxRoiWidth
            // 
            this.textBoxRoiWidth.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRoiWidth.ConerRadius = 5;
            this.textBoxRoiWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxRoiWidth.DecLength = 2;
            this.textBoxRoiWidth.FillColor = System.Drawing.Color.Empty;
            this.textBoxRoiWidth.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.textBoxRoiWidth.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiWidth.InputText = "744";
            this.textBoxRoiWidth.InputType = HZH_Controls.TextInputType.NotControl;
            this.textBoxRoiWidth.IsFocusColor = true;
            this.textBoxRoiWidth.IsRadius = true;
            this.textBoxRoiWidth.IsShowClearBtn = true;
            this.textBoxRoiWidth.IsShowKeyboard = true;
            this.textBoxRoiWidth.IsShowRect = true;
            this.textBoxRoiWidth.IsShowSearchBtn = false;
            this.textBoxRoiWidth.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.textBoxRoiWidth.Location = new System.Drawing.Point(703, 348);
            this.textBoxRoiWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRoiWidth.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxRoiWidth.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.textBoxRoiWidth.Name = "textBoxRoiWidth";
            this.textBoxRoiWidth.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxRoiWidth.PasswordChar = '\0';
            this.textBoxRoiWidth.PromptColor = System.Drawing.Color.Gray;
            this.textBoxRoiWidth.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRoiWidth.PromptText = "";
            this.textBoxRoiWidth.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxRoiWidth.RectWidth = 1;
            this.textBoxRoiWidth.RegexPattern = "";
            this.textBoxRoiWidth.Size = new System.Drawing.Size(115, 42);
            this.textBoxRoiWidth.TabIndex = 67;
            this.textBoxRoiWidth.TextChanged += new System.EventHandler(this.textBoxRoiWidth_TextChanged);
            // 
            // EncrypModelBtn
            // 
            this.EncrypModelBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.EncrypModelBtn.Appearance.Options.UseFont = true;
            this.EncrypModelBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.encrypt;
            this.EncrypModelBtn.Location = new System.Drawing.Point(873, 466);
            this.EncrypModelBtn.Name = "EncrypModelBtn";
            this.EncrypModelBtn.Size = new System.Drawing.Size(159, 60);
            this.EncrypModelBtn.TabIndex = 54;
            this.EncrypModelBtn.Text = "加密模型";
            this.EncrypModelBtn.Click += new System.EventHandler(this.EncrypModelBtn_Click);
            // 
            // SingTestBtn
            // 
            this.SingTestBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.SingTestBtn.Appearance.Options.UseFont = true;
            this.SingTestBtn.Enabled = false;
            this.SingTestBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.image;
            this.SingTestBtn.Location = new System.Drawing.Point(301, 583);
            this.SingTestBtn.Name = "SingTestBtn";
            this.SingTestBtn.Size = new System.Drawing.Size(159, 60);
            this.SingTestBtn.TabIndex = 53;
            this.SingTestBtn.Text = "单张测试";
            this.SingTestBtn.Click += new System.EventHandler(this.Single_Test);
            // 
            // DeepTestBtn
            // 
            this.DeepTestBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.DeepTestBtn.Appearance.Options.UseFont = true;
            this.DeepTestBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.Gallery;
            this.DeepTestBtn.Location = new System.Drawing.Point(873, 583);
            this.DeepTestBtn.Name = "DeepTestBtn";
            this.DeepTestBtn.Size = new System.Drawing.Size(159, 60);
            this.DeepTestBtn.TabIndex = 52;
            this.DeepTestBtn.Text = "训练集测试";
            this.DeepTestBtn.Click += new System.EventHandler(this.DeepTestBtn_Click);
            // 
            // readOriModelBtn
            // 
            this.readOriModelBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.readOriModelBtn.Appearance.Options.UseFont = true;
            this.readOriModelBtn.Enabled = false;
            this.readOriModelBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.model;
            this.readOriModelBtn.Location = new System.Drawing.Point(587, 466);
            this.readOriModelBtn.Name = "readOriModelBtn";
            this.readOriModelBtn.Size = new System.Drawing.Size(159, 60);
            this.readOriModelBtn.TabIndex = 51;
            this.readOriModelBtn.Text = "加载模型";
            this.readOriModelBtn.Click += new System.EventHandler(this.readOriModelBtn_Click);
            // 
            // dirTestBtn
            // 
            this.dirTestBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.dirTestBtn.Appearance.Options.UseFont = true;
            this.dirTestBtn.Enabled = false;
            this.dirTestBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.Folder;
            this.dirTestBtn.Location = new System.Drawing.Point(587, 583);
            this.dirTestBtn.Name = "dirTestBtn";
            this.dirTestBtn.Size = new System.Drawing.Size(159, 60);
            this.dirTestBtn.TabIndex = 50;
            this.dirTestBtn.Text = "目录测试";
            this.dirTestBtn.Click += new System.EventHandler(this.Dir_Test);
            // 
            // readClassesBtn
            // 
            this.readClassesBtn.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.readClassesBtn.Appearance.Options.UseFont = true;
            this.readClassesBtn.ImageOptions.Image = global::CloudManage.Properties.Resources.分类;
            this.readClassesBtn.Location = new System.Drawing.Point(301, 466);
            this.readClassesBtn.Name = "readClassesBtn";
            this.readClassesBtn.Size = new System.Drawing.Size(159, 60);
            this.readClassesBtn.TabIndex = 49;
            this.readClassesBtn.Text = "读取分类";
            this.readClassesBtn.Click += new System.EventHandler(this.Read_Classes);
            // 
            // imageBoxShow
            // 
            this.imageBoxShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxShow.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBoxShow.Location = new System.Drawing.Point(1115, 250);
            this.imageBoxShow.Name = "imageBoxShow";
            this.imageBoxShow.Size = new System.Drawing.Size(744, 480);
            this.imageBoxShow.TabIndex = 48;
            this.imageBoxShow.TabStop = false;
            this.imageBoxShow.Click += new System.EventHandler(this.imageBoxShow_Click);
            this.imageBoxShow.Paint += new System.Windows.Forms.PaintEventHandler(this.imageBoxShow_Paint);
            this.imageBoxShow.DoubleClick += new System.EventHandler(this.imageBoxShow_DoubleClick);
            this.imageBoxShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageBoxShow_MouseDown);
            this.imageBoxShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBoxShow_MouseMove);
            this.imageBoxShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageBoxShow_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "打开图片文件";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.labelControl1.Location = new System.Drawing.Point(344, 336);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 23);
            this.labelControl1.TabIndex = 73;
            this.labelControl1.Text = "阈值：";
            this.labelControl1.ToolTip = "this is a label control";
            // 
            // ThreshTb
            // 
            this.ThreshTb.BackColor = System.Drawing.Color.Transparent;
            this.ThreshTb.ConerRadius = 5;
            this.ThreshTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ThreshTb.DecLength = 2;
            this.ThreshTb.FillColor = System.Drawing.Color.Empty;
            this.ThreshTb.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ThreshTb.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ThreshTb.InputText = "0.01";
            this.ThreshTb.InputType = HZH_Controls.TextInputType.NotControl;
            this.ThreshTb.IsFocusColor = true;
            this.ThreshTb.IsRadius = true;
            this.ThreshTb.IsShowClearBtn = true;
            this.ThreshTb.IsShowKeyboard = true;
            this.ThreshTb.IsShowRect = true;
            this.ThreshTb.IsShowSearchBtn = false;
            this.ThreshTb.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.ThreshTb.Location = new System.Drawing.Point(344, 375);
            this.ThreshTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ThreshTb.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ThreshTb.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ThreshTb.Name = "ThreshTb";
            this.ThreshTb.Padding = new System.Windows.Forms.Padding(5);
            this.ThreshTb.PasswordChar = '\0';
            this.ThreshTb.PromptColor = System.Drawing.Color.Gray;
            this.ThreshTb.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ThreshTb.PromptText = "";
            this.ThreshTb.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ThreshTb.RectWidth = 1;
            this.ThreshTb.RegexPattern = "";
            this.ThreshTb.Size = new System.Drawing.Size(115, 42);
            this.ThreshTb.TabIndex = 74;
            // 
            // PositionLab
            // 
            this.PositionLab.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PositionLab.Appearance.Options.UseFont = true;
            this.PositionLab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PositionLab.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.PositionLab.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.PositionLab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("PositionLab.ImageOptions.Image")));
            this.PositionLab.Location = new System.Drawing.Point(1129, 745);
            this.PositionLab.Name = "PositionLab";
            this.PositionLab.Size = new System.Drawing.Size(104, 38);
            this.PositionLab.TabIndex = 77;
            this.PositionLab.Text = "(X,Y) =";
            this.PositionLab.ToolTip = "this is a label control";
            // 
            // labelRGB
            // 
            this.labelRGB.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.labelRGB.Appearance.Options.UseFont = true;
            this.labelRGB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.labelRGB.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelRGB.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.labelRGB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelRGB.ImageOptions.Image")));
            this.labelRGB.Location = new System.Drawing.Point(1517, 745);
            this.labelRGB.Name = "labelRGB";
            this.labelRGB.Size = new System.Drawing.Size(125, 38);
            this.labelRGB.TabIndex = 78;
            this.labelRGB.Text = "(R,G,B) =";
            this.labelRGB.ToolTip = "this is a label control";
            // 
            // labelControl_dir
            // 
            this.labelControl_dir.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl_dir.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_dir.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl_dir.Appearance.Options.UseBackColor = true;
            this.labelControl_dir.Appearance.Options.UseFont = true;
            this.labelControl_dir.Appearance.Options.UseForeColor = true;
            this.labelControl_dir.Appearance.Options.UseTextOptions = true;
            this.labelControl_dir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_dir.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_dir.Location = new System.Drawing.Point(246, 0);
            this.labelControl_dir.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.labelControl_dir.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl_dir.Name = "labelControl_dir";
            this.labelControl_dir.Size = new System.Drawing.Size(1674, 83);
            this.labelControl_dir.TabIndex = 79;
            this.labelControl_dir.Text = "   模型测试";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(315, 715);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(119, 38);
            this.labelControl2.TabIndex = 80;
            this.labelControl2.Text = "测试结果：";
            // 
            // dispLab
            // 
            this.dispLab.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dispLab.Appearance.Options.UseFont = true;
            this.dispLab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dispLab.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.dispLab.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomRight;
            this.dispLab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dispLab.ImageOptions.Image")));
            this.dispLab.Location = new System.Drawing.Point(315, 793);
            this.dispLab.Name = "dispLab";
            this.dispLab.Size = new System.Drawing.Size(119, 38);
            this.dispLab.TabIndex = 81;
            this.dispLab.Text = "测试结果：";
            // 
            // ucPanelQuote1
            // 
            this.ucPanelQuote1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucPanelQuote1.LeftColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucPanelQuote1.Location = new System.Drawing.Point(329, 327);
            this.ucPanelQuote1.Name = "ucPanelQuote1";
            this.ucPanelQuote1.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.ucPanelQuote1.Size = new System.Drawing.Size(294, 100);
            this.ucPanelQuote1.TabIndex = 82;
            // 
            // ucPanelQuote2
            // 
            this.ucPanelQuote2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucPanelQuote2.LeftColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucPanelQuote2.Location = new System.Drawing.Point(329, 216);
            this.ucPanelQuote2.Name = "ucPanelQuote2";
            this.ucPanelQuote2.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.ucPanelQuote2.Size = new System.Drawing.Size(294, 100);
            this.ucPanelQuote2.TabIndex = 83;
            // 
            // ucPanelQuote3
            // 
            this.ucPanelQuote3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucPanelQuote3.LeftColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucPanelQuote3.Location = new System.Drawing.Point(684, 216);
            this.ucPanelQuote3.Name = "ucPanelQuote3";
            this.ucPanelQuote3.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.ucPanelQuote3.Size = new System.Drawing.Size(310, 211);
            this.ucPanelQuote3.TabIndex = 84;
            // 
            // ModelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dispLab);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl_dir);
            this.Controls.Add(this.labelRGB);
            this.Controls.Add(this.PositionLab);
            this.Controls.Add(this.ThreshTb);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textBoxRoiHeight);
            this.Controls.Add(this.textBoxRoiWidth);
            this.Controls.Add(this.textBoxRoiY);
            this.Controls.Add(this.textBoxRoiX);
            this.Controls.Add(this.SizeHTb);
            this.Controls.Add(this.SizeWTb);
            this.Controls.Add(this.comboBoxSave);
            this.Controls.Add(this.checkBoxRoi);
            this.Controls.Add(this.EncrypModelBtn);
            this.Controls.Add(this.SingTestBtn);
            this.Controls.Add(this.DeepTestBtn);
            this.Controls.Add(this.readOriModelBtn);
            this.Controls.Add(this.dirTestBtn);
            this.Controls.Add(this.readClassesBtn);
            this.Controls.Add(this.imageBoxShow);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.totalImgCountLab);
            this.Controls.Add(this.imagnameLab);
            this.Controls.Add(this.dirLab);
            this.Controls.Add(this.ucPanelQuote1);
            this.Controls.Add(this.ucPanelQuote2);
            this.Controls.Add(this.ucPanelQuote3);
            this.Name = "ModelTest";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl totalImgCountLab;
        private DevExpress.XtraEditors.LabelControl imagnameLab;
        private DevExpress.XtraEditors.LabelControl dirLab;
        private Emgu.CV.UI.ImageBox imageBoxShow;
        private DevExpress.XtraEditors.SimpleButton readClassesBtn;
        private DevExpress.XtraEditors.SimpleButton dirTestBtn;
        private DevExpress.XtraEditors.SimpleButton readOriModelBtn;
        private DevExpress.XtraEditors.SimpleButton DeepTestBtn;
        private DevExpress.XtraEditors.SimpleButton SingTestBtn;
        private DevExpress.XtraEditors.SimpleButton EncrypModelBtn;
        private DevExpress.XtraEditors.CheckEdit checkBoxRoi;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxSave;
        private HZH_Controls.Controls.UCTextBoxEx SizeWTb;
        private HZH_Controls.Controls.UCTextBoxEx SizeHTb;
        private HZH_Controls.Controls.UCTextBoxEx textBoxRoiY;
        private HZH_Controls.Controls.UCTextBoxEx textBoxRoiX;
        private HZH_Controls.Controls.UCTextBoxEx textBoxRoiHeight;
        private HZH_Controls.Controls.UCTextBoxEx textBoxRoiWidth;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HZH_Controls.Controls.UCTextBoxEx ThreshTb;
        private DevExpress.XtraEditors.LabelControl PositionLab;
        private DevExpress.XtraEditors.LabelControl labelRGB;
        private DevExpress.XtraEditors.LabelControl labelControl_dir;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl dispLab;
        private HZH_Controls.Controls.UCPanelQuote ucPanelQuote1;
        private HZH_Controls.Controls.UCPanelQuote ucPanelQuote2;
        private HZH_Controls.Controls.UCPanelQuote ucPanelQuote3;
    }
}
