
namespace CloudManage.TwinDetection
{
    partial class TwinDetection
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
            this.navigationFrame_twinDetection = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_paraSynchronize = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_intelligentReasoning = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_paraUpdate = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.paraSynchronize1 = new CloudManage.TwinDetection.ParaSynchronize();
            this.intelligentReasoning1 = new CloudManage.TwinDetection.IntelligentReasoning();
            this.paraUpdate1 = new CloudManage.TwinDetection.ParaUpdate();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_twinDetection)).BeginInit();
            this.navigationFrame_twinDetection.SuspendLayout();
            this.navigationPage_paraSynchronize.SuspendLayout();
            this.navigationPage_intelligentReasoning.SuspendLayout();
            this.navigationPage_paraUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_twinDetection
            // 
            this.navigationFrame_twinDetection.Controls.Add(this.navigationPage_paraSynchronize);
            this.navigationFrame_twinDetection.Controls.Add(this.navigationPage_intelligentReasoning);
            this.navigationFrame_twinDetection.Controls.Add(this.navigationPage_paraUpdate);
            this.navigationFrame_twinDetection.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_twinDetection.Name = "navigationFrame_twinDetection";
            this.navigationFrame_twinDetection.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_paraSynchronize,
            this.navigationPage_intelligentReasoning,
            this.navigationPage_paraUpdate});
            this.navigationFrame_twinDetection.SelectedPage = this.navigationPage_paraSynchronize;
            this.navigationFrame_twinDetection.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_twinDetection.TabIndex = 0;
            this.navigationFrame_twinDetection.Text = "navigationFrame1";
            this.navigationFrame_twinDetection.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage_paraSynchronize
            // 
            this.navigationPage_paraSynchronize.Caption = "navigationPage_paraSynchronize";
            this.navigationPage_paraSynchronize.Controls.Add(this.paraSynchronize1);
            this.navigationPage_paraSynchronize.Name = "navigationPage_paraSynchronize";
            this.navigationPage_paraSynchronize.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_intelligentReasoning
            // 
            this.navigationPage_intelligentReasoning.Caption = "navigationPage_intelligentReasoning";
            this.navigationPage_intelligentReasoning.Controls.Add(this.intelligentReasoning1);
            this.navigationPage_intelligentReasoning.Name = "navigationPage_intelligentReasoning";
            this.navigationPage_intelligentReasoning.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_paraUpdate
            // 
            this.navigationPage_paraUpdate.Caption = "navigationPage_paraUpdate";
            this.navigationPage_paraUpdate.Controls.Add(this.paraUpdate1);
            this.navigationPage_paraUpdate.Name = "navigationPage_paraUpdate";
            this.navigationPage_paraUpdate.Size = new System.Drawing.Size(1920, 880);
            // 
            // paraSynchronize1
            // 
            this.paraSynchronize1.Location = new System.Drawing.Point(0, 0);
            this.paraSynchronize1.Name = "paraSynchronize1";
            this.paraSynchronize1.Size = new System.Drawing.Size(1920, 880);
            this.paraSynchronize1.TabIndex = 0;
            // 
            // intelligentReasoning1
            // 
            this.intelligentReasoning1.Location = new System.Drawing.Point(0, 0);
            this.intelligentReasoning1.Name = "intelligentReasoning1";
            this.intelligentReasoning1.Size = new System.Drawing.Size(1920, 880);
            this.intelligentReasoning1.TabIndex = 0;
            // 
            // paraUpdate1
            // 
            this.paraUpdate1.Location = new System.Drawing.Point(0, 0);
            this.paraUpdate1.Name = "paraUpdate1";
            this.paraUpdate1.Size = new System.Drawing.Size(1920, 880);
            this.paraUpdate1.TabIndex = 0;
            // 
            // TwinDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_twinDetection);
            this.Name = "TwinDetection";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_twinDetection)).EndInit();
            this.navigationFrame_twinDetection.ResumeLayout(false);
            this.navigationPage_paraSynchronize.ResumeLayout(false);
            this.navigationPage_intelligentReasoning.ResumeLayout(false);
            this.navigationPage_paraUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_twinDetection;
        private ParaSynchronize paraSynchronize1;
        private IntelligentReasoning intelligentReasoning1;
        private ParaUpdate paraUpdate1;
    }
}
