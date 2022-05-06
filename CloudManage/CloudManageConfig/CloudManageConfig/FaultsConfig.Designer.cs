
namespace CloudManageConfig
{
    partial class FaultsConfig
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
            this.textEdit_lineNO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_lineNO = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_deviceNO = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_deviceNO = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_addDeviceNO = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControl_deviceNO = new DevExpress.XtraEditors.ListBoxControl();
            this.simpleButton_delDeviceNO = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_insertFaults1Line = new DevExpress.XtraEditors.SimpleButton();
            this.textBox_faultsName = new System.Windows.Forms.TextBox();
            this.labelControl_faultsCount = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_faultsCount = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_faulsNameOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_insertFaults1Device = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_lineNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_deviceNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_deviceNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_faultsCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_lineNO
            // 
            this.textEdit_lineNO.Location = new System.Drawing.Point(45, 100);
            this.textEdit_lineNO.Name = "textEdit_lineNO";
            this.textEdit_lineNO.Size = new System.Drawing.Size(95, 20);
            this.textEdit_lineNO.TabIndex = 0;
            // 
            // labelControl_lineNO
            // 
            this.labelControl_lineNO.Location = new System.Drawing.Point(45, 68);
            this.labelControl_lineNO.Name = "labelControl_lineNO";
            this.labelControl_lineNO.Size = new System.Drawing.Size(53, 14);
            this.labelControl_lineNO.TabIndex = 1;
            this.labelControl_lineNO.Text = "产线NO：";
            // 
            // labelControl_deviceNO
            // 
            this.labelControl_deviceNO.Location = new System.Drawing.Point(178, 68);
            this.labelControl_deviceNO.Name = "labelControl_deviceNO";
            this.labelControl_deviceNO.Size = new System.Drawing.Size(53, 14);
            this.labelControl_deviceNO.TabIndex = 2;
            this.labelControl_deviceNO.Text = "设备NO：";
            // 
            // textEdit_deviceNO
            // 
            this.textEdit_deviceNO.Location = new System.Drawing.Point(178, 100);
            this.textEdit_deviceNO.Name = "textEdit_deviceNO";
            this.textEdit_deviceNO.Size = new System.Drawing.Size(124, 20);
            this.textEdit_deviceNO.TabIndex = 4;
            // 
            // simpleButton_addDeviceNO
            // 
            this.simpleButton_addDeviceNO.Location = new System.Drawing.Point(178, 148);
            this.simpleButton_addDeviceNO.Name = "simpleButton_addDeviceNO";
            this.simpleButton_addDeviceNO.Size = new System.Drawing.Size(124, 23);
            this.simpleButton_addDeviceNO.TabIndex = 5;
            this.simpleButton_addDeviceNO.Text = "添加一个设备NO >>";
            this.simpleButton_addDeviceNO.Click += new System.EventHandler(this.simpleButton_addDeviceNO_Click);
            // 
            // listBoxControl_deviceNO
            // 
            this.listBoxControl_deviceNO.Location = new System.Drawing.Point(308, 99);
            this.listBoxControl_deviceNO.Name = "listBoxControl_deviceNO";
            this.listBoxControl_deviceNO.Size = new System.Drawing.Size(145, 292);
            this.listBoxControl_deviceNO.TabIndex = 6;
            // 
            // simpleButton_delDeviceNO
            // 
            this.simpleButton_delDeviceNO.Location = new System.Drawing.Point(178, 190);
            this.simpleButton_delDeviceNO.Name = "simpleButton_delDeviceNO";
            this.simpleButton_delDeviceNO.Size = new System.Drawing.Size(124, 23);
            this.simpleButton_delDeviceNO.TabIndex = 7;
            this.simpleButton_delDeviceNO.Text = "删除一个设备NO >>";
            this.simpleButton_delDeviceNO.Click += new System.EventHandler(this.simpleButton_delDeviceNO_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(498, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "故障名：";
            // 
            // simpleButton_insertFaults1Line
            // 
            this.simpleButton_insertFaults1Line.Location = new System.Drawing.Point(308, 498);
            this.simpleButton_insertFaults1Line.Name = "simpleButton_insertFaults1Line";
            this.simpleButton_insertFaults1Line.Size = new System.Drawing.Size(155, 79);
            this.simpleButton_insertFaults1Line.TabIndex = 11;
            this.simpleButton_insertFaults1Line.Text = "配置一条产线的故障";
            this.simpleButton_insertFaults1Line.Click += new System.EventHandler(this.simpleButton_insertFaults1Line_Click);
            // 
            // textBox_faultsName
            // 
            this.textBox_faultsName.Location = new System.Drawing.Point(498, 99);
            this.textBox_faultsName.Multiline = true;
            this.textBox_faultsName.Name = "textBox_faultsName";
            this.textBox_faultsName.Size = new System.Drawing.Size(176, 292);
            this.textBox_faultsName.TabIndex = 16;
            // 
            // labelControl_faultsCount
            // 
            this.labelControl_faultsCount.Location = new System.Drawing.Point(709, 68);
            this.labelControl_faultsCount.Name = "labelControl_faultsCount";
            this.labelControl_faultsCount.Size = new System.Drawing.Size(48, 14);
            this.labelControl_faultsCount.TabIndex = 17;
            this.labelControl_faultsCount.Text = "故障数：";
            // 
            // textEdit_faultsCount
            // 
            this.textEdit_faultsCount.Location = new System.Drawing.Point(709, 100);
            this.textEdit_faultsCount.Name = "textEdit_faultsCount";
            this.textEdit_faultsCount.Size = new System.Drawing.Size(94, 20);
            this.textEdit_faultsCount.TabIndex = 18;
            // 
            // simpleButton_faulsNameOK
            // 
            this.simpleButton_faulsNameOK.Location = new System.Drawing.Point(709, 136);
            this.simpleButton_faulsNameOK.Name = "simpleButton_faulsNameOK";
            this.simpleButton_faulsNameOK.Size = new System.Drawing.Size(94, 23);
            this.simpleButton_faulsNameOK.TabIndex = 20;
            this.simpleButton_faulsNameOK.Text = "确认输入故障名";
            this.simpleButton_faulsNameOK.Click += new System.EventHandler(this.simpleButton_faulsNameOK_Click);
            // 
            // simpleButton_insertFaults1Device
            // 
            this.simpleButton_insertFaults1Device.Location = new System.Drawing.Point(498, 498);
            this.simpleButton_insertFaults1Device.Name = "simpleButton_insertFaults1Device";
            this.simpleButton_insertFaults1Device.Size = new System.Drawing.Size(155, 79);
            this.simpleButton_insertFaults1Device.TabIndex = 21;
            this.simpleButton_insertFaults1Device.Text = "选中设备配置该设备的故障";
            this.simpleButton_insertFaults1Device.Click += new System.EventHandler(this.simpleButton_insertFaults1Device_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(249, 469);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(144, 14);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "所有设备共用相同的故障：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(449, 469);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 14);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "每台设备故障不同：";
            // 
            // FaultsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 642);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton_insertFaults1Device);
            this.Controls.Add(this.simpleButton_faulsNameOK);
            this.Controls.Add(this.textEdit_faultsCount);
            this.Controls.Add(this.labelControl_faultsCount);
            this.Controls.Add(this.textBox_faultsName);
            this.Controls.Add(this.simpleButton_insertFaults1Line);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton_delDeviceNO);
            this.Controls.Add(this.listBoxControl_deviceNO);
            this.Controls.Add(this.simpleButton_addDeviceNO);
            this.Controls.Add(this.textEdit_deviceNO);
            this.Controls.Add(this.labelControl_deviceNO);
            this.Controls.Add(this.labelControl_lineNO);
            this.Controls.Add(this.textEdit_lineNO);
            this.Name = "FaultsConfig";
            this.Text = "FaultsConfig";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_lineNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_deviceNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl_deviceNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_faultsCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_lineNO;
        private DevExpress.XtraEditors.LabelControl labelControl_lineNO;
        private DevExpress.XtraEditors.LabelControl labelControl_deviceNO;
        private DevExpress.XtraEditors.TextEdit textEdit_deviceNO;
        private DevExpress.XtraEditors.SimpleButton simpleButton_addDeviceNO;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl_deviceNO;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delDeviceNO;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_insertFaults1Line;
        private System.Windows.Forms.TextBox textBox_faultsName;
        private DevExpress.XtraEditors.LabelControl labelControl_faultsCount;
        private DevExpress.XtraEditors.TextEdit textEdit_faultsCount;
        private DevExpress.XtraEditors.SimpleButton simpleButton_faulsNameOK;
        private DevExpress.XtraEditors.SimpleButton simpleButton_insertFaults1Device;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}