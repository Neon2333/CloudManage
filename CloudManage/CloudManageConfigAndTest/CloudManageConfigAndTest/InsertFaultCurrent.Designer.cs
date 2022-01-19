
namespace CloudManageConfigAndTest
{
    partial class InsertFaultCurrent
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
            this.simpleButton_startInsert = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox_faultNO = new System.Windows.Forms.ComboBox();
            this.timer_insertFaultsCurrent = new System.Windows.Forms.Timer(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label_totalInsert = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_deviceNO = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_deviceNO = new System.Windows.Forms.ComboBox();
            this.labelControl_lineNO = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_lineNO = new System.Windows.Forms.ComboBox();
            this.labelControl_faultNO = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_stopInsert = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton_startInsert
            // 
            this.simpleButton_startInsert.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_startInsert.Appearance.Options.UseFont = true;
            this.simpleButton_startInsert.Location = new System.Drawing.Point(11, 136);
            this.simpleButton_startInsert.Name = "simpleButton_startInsert";
            this.simpleButton_startInsert.Size = new System.Drawing.Size(106, 69);
            this.simpleButton_startInsert.TabIndex = 0;
            this.simpleButton_startInsert.Text = "开始";
            this.simpleButton_startInsert.Click += new System.EventHandler(this.simpleButton_insertFaultCurrent_Click);
            // 
            // comboBox_faultNO
            // 
            this.comboBox_faultNO.Enabled = false;
            this.comboBox_faultNO.FormattingEnabled = true;
            this.comboBox_faultNO.Location = new System.Drawing.Point(116, 92);
            this.comboBox_faultNO.Name = "comboBox_faultNO";
            this.comboBox_faultNO.Size = new System.Drawing.Size(134, 22);
            this.comboBox_faultNO.TabIndex = 2;
            // 
            // timer_insertFaultsCurrent
            // 
            this.timer_insertFaultsCurrent.Interval = 3000;
            this.timer_insertFaultsCurrent.Tick += new System.EventHandler(this.timer_insertFaultsCurrent_Tick);
            // 
            // panelControl1
            // 
            this.panelControl1.AccessibleDescription = "";
            this.panelControl1.Controls.Add(this.simpleButton_stopInsert);
            this.panelControl1.Controls.Add(this.label_totalInsert);
            this.panelControl1.Controls.Add(this.labelControl_deviceNO);
            this.panelControl1.Controls.Add(this.comboBox_deviceNO);
            this.panelControl1.Controls.Add(this.simpleButton_startInsert);
            this.panelControl1.Controls.Add(this.labelControl_lineNO);
            this.panelControl1.Controls.Add(this.comboBox_lineNO);
            this.panelControl1.Controls.Add(this.labelControl_faultNO);
            this.panelControl1.Controls.Add(this.comboBox_faultNO);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(263, 278);
            this.panelControl1.TabIndex = 6;
            this.panelControl1.Tag = "";
            // 
            // label_totalInsert
            // 
            this.label_totalInsert.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalInsert.Appearance.Options.UseFont = true;
            this.label_totalInsert.Appearance.Options.UseTextOptions = true;
            this.label_totalInsert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.label_totalInsert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.label_totalInsert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label_totalInsert.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.label_totalInsert.Location = new System.Drawing.Point(11, 225);
            this.label_totalInsert.Name = "label_totalInsert";
            this.label_totalInsert.Size = new System.Drawing.Size(239, 35);
            this.label_totalInsert.TabIndex = 8;
            this.label_totalInsert.Text = "插入条数：";
            // 
            // labelControl_deviceNO
            // 
            this.labelControl_deviceNO.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_deviceNO.Appearance.Options.UseFont = true;
            this.labelControl_deviceNO.Appearance.Options.UseTextOptions = true;
            this.labelControl_deviceNO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_deviceNO.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_deviceNO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_deviceNO.Location = new System.Drawing.Point(11, 52);
            this.labelControl_deviceNO.Name = "labelControl_deviceNO";
            this.labelControl_deviceNO.Size = new System.Drawing.Size(99, 23);
            this.labelControl_deviceNO.TabIndex = 7;
            this.labelControl_deviceNO.Text = "设备：";
            // 
            // comboBox_deviceNO
            // 
            this.comboBox_deviceNO.Enabled = false;
            this.comboBox_deviceNO.FormattingEnabled = true;
            this.comboBox_deviceNO.Location = new System.Drawing.Point(116, 53);
            this.comboBox_deviceNO.Name = "comboBox_deviceNO";
            this.comboBox_deviceNO.Size = new System.Drawing.Size(134, 22);
            this.comboBox_deviceNO.TabIndex = 6;
            this.comboBox_deviceNO.SelectedValueChanged += new System.EventHandler(this.comboBox_deviceNO_SelectedValueChanged);
            // 
            // labelControl_lineNO
            // 
            this.labelControl_lineNO.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_lineNO.Appearance.Options.UseFont = true;
            this.labelControl_lineNO.Appearance.Options.UseTextOptions = true;
            this.labelControl_lineNO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_lineNO.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_lineNO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_lineNO.Location = new System.Drawing.Point(11, 15);
            this.labelControl_lineNO.Name = "labelControl_lineNO";
            this.labelControl_lineNO.Size = new System.Drawing.Size(99, 23);
            this.labelControl_lineNO.TabIndex = 5;
            this.labelControl_lineNO.Text = "产线：";
            // 
            // comboBox_lineNO
            // 
            this.comboBox_lineNO.FormattingEnabled = true;
            this.comboBox_lineNO.Location = new System.Drawing.Point(116, 16);
            this.comboBox_lineNO.Name = "comboBox_lineNO";
            this.comboBox_lineNO.Size = new System.Drawing.Size(134, 22);
            this.comboBox_lineNO.TabIndex = 4;
            this.comboBox_lineNO.SelectedValueChanged += new System.EventHandler(this.comboBox_lineNO_SelectedValueChanged);
            // 
            // labelControl_faultNO
            // 
            this.labelControl_faultNO.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_faultNO.Appearance.Options.UseFont = true;
            this.labelControl_faultNO.Appearance.Options.UseTextOptions = true;
            this.labelControl_faultNO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_faultNO.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_faultNO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_faultNO.Location = new System.Drawing.Point(11, 91);
            this.labelControl_faultNO.Name = "labelControl_faultNO";
            this.labelControl_faultNO.Size = new System.Drawing.Size(99, 23);
            this.labelControl_faultNO.TabIndex = 3;
            this.labelControl_faultNO.Text = "故障类型：";
            // 
            // simpleButton_stopInsert
            // 
            this.simpleButton_stopInsert.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_stopInsert.Appearance.Options.UseFont = true;
            this.simpleButton_stopInsert.Location = new System.Drawing.Point(144, 136);
            this.simpleButton_stopInsert.Name = "simpleButton_stopInsert";
            this.simpleButton_stopInsert.Size = new System.Drawing.Size(106, 69);
            this.simpleButton_stopInsert.TabIndex = 9;
            this.simpleButton_stopInsert.Text = "停止";
            this.simpleButton_stopInsert.Click += new System.EventHandler(this.simpleButton_stopInsert_Click);
            // 
            // InsertFaultCurrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 673);
            this.Controls.Add(this.panelControl1);
            this.Name = "InsertFaultCurrent";
            this.Text = "InsertFaultCurrent";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_startInsert;
        private System.Windows.Forms.ComboBox comboBox_faultNO;
        private System.Windows.Forms.Timer timer_insertFaultsCurrent;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl label_totalInsert;
        private DevExpress.XtraEditors.LabelControl labelControl_deviceNO;
        private System.Windows.Forms.ComboBox comboBox_deviceNO;
        private DevExpress.XtraEditors.LabelControl labelControl_lineNO;
        private System.Windows.Forms.ComboBox comboBox_lineNO;
        private DevExpress.XtraEditors.LabelControl labelControl_faultNO;
        private DevExpress.XtraEditors.SimpleButton simpleButton_stopInsert;
    }
}