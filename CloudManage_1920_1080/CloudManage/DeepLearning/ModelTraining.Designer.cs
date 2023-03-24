
namespace CloudManage.DeepLearning
{
    partial class ModelTraining
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
            this.labelControl_dir = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl_dir
            // 
            this.labelControl_dir.Appearance.BackColor = System.Drawing.Color.Gray;
            this.labelControl_dir.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_dir.Appearance.ForeColor = System.Drawing.Color.White;
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
            this.labelControl_dir.TabIndex = 19;
            this.labelControl_dir.Text = "   模型训练";
            // 
            // ModelTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl_dir);
            this.Name = "ModelTraining";
            this.Size = new System.Drawing.Size(1920, 880);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_dir;
    }
}
