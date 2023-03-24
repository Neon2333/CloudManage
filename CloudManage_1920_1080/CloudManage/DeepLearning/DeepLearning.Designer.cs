
namespace CloudManage.DeepLearning
{
    partial class DeepLearning
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
            this.navigationFrame_deepLearning = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_dataPreparation = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.dataPreparation1 = new CloudManage.DeepLearning.DataPreparation();
            this.navigationPage_modelTraining = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.modelTraining1 = new CloudManage.DeepLearning.ModelTraining();
            this.navigationPage_modelTest = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.modelTest1 = new CloudManage.DeepLearning.ModelTest();
            this.navigationPage_modelUpdate = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.modelUpdate1 = new CloudManage.DeepLearning.ModelUpdate();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_deepLearning)).BeginInit();
            this.navigationFrame_deepLearning.SuspendLayout();
            this.navigationPage_dataPreparation.SuspendLayout();
            this.navigationPage_modelTraining.SuspendLayout();
            this.navigationPage_modelTest.SuspendLayout();
            this.navigationPage_modelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_deepLearning
            // 
            this.navigationFrame_deepLearning.Controls.Add(this.navigationPage_dataPreparation);
            this.navigationFrame_deepLearning.Controls.Add(this.navigationPage_modelTraining);
            this.navigationFrame_deepLearning.Controls.Add(this.navigationPage_modelTest);
            this.navigationFrame_deepLearning.Controls.Add(this.navigationPage_modelUpdate);
            this.navigationFrame_deepLearning.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_deepLearning.Name = "navigationFrame_deepLearning";
            this.navigationFrame_deepLearning.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_dataPreparation,
            this.navigationPage_modelTraining,
            this.navigationPage_modelTest,
            this.navigationPage_modelUpdate});
            this.navigationFrame_deepLearning.SelectedPage = this.navigationPage_dataPreparation;
            this.navigationFrame_deepLearning.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_deepLearning.TabIndex = 0;
            this.navigationFrame_deepLearning.Text = "navigationFrame1";
            this.navigationFrame_deepLearning.TransitionAnimationProperties.FrameCount = 3000;
            this.navigationFrame_deepLearning.TransitionAnimationProperties.FrameInterval = 1000;
            // 
            // navigationPage_dataPreparation
            // 
            this.navigationPage_dataPreparation.Caption = "navigationPage_dataPreparation";
            this.navigationPage_dataPreparation.Controls.Add(this.dataPreparation1);
            this.navigationPage_dataPreparation.Name = "navigationPage_dataPreparation";
            this.navigationPage_dataPreparation.Size = new System.Drawing.Size(1920, 880);
            // 
            // dataPreparation1
            // 
            this.dataPreparation1.Location = new System.Drawing.Point(0, 0);
            this.dataPreparation1.Name = "dataPreparation1";
            this.dataPreparation1.Size = new System.Drawing.Size(1920, 880);
            this.dataPreparation1.TabIndex = 0;
            // 
            // navigationPage_modelTraining
            // 
            this.navigationPage_modelTraining.Caption = "navigationPage_modelTraining";
            this.navigationPage_modelTraining.Controls.Add(this.modelTraining1);
            this.navigationPage_modelTraining.Name = "navigationPage_modelTraining";
            this.navigationPage_modelTraining.Size = new System.Drawing.Size(1920, 880);
            // 
            // modelTraining1
            // 
            this.modelTraining1.Location = new System.Drawing.Point(0, 0);
            this.modelTraining1.Name = "modelTraining1";
            this.modelTraining1.Size = new System.Drawing.Size(1920, 880);
            this.modelTraining1.TabIndex = 0;
            // 
            // navigationPage_modelTest
            // 
            this.navigationPage_modelTest.Caption = "navigationPage_modelTest";
            this.navigationPage_modelTest.Controls.Add(this.modelTest1);
            this.navigationPage_modelTest.Name = "navigationPage_modelTest";
            this.navigationPage_modelTest.Size = new System.Drawing.Size(1920, 880);
            // 
            // modelTest1
            // 
            this.modelTest1.Location = new System.Drawing.Point(0, 0);
            this.modelTest1.Name = "modelTest1";
            this.modelTest1.Size = new System.Drawing.Size(1920, 880);
            this.modelTest1.TabIndex = 0;
            // 
            // navigationPage_modelUpdate
            // 
            this.navigationPage_modelUpdate.Caption = "navigationPage_modelUpdate";
            this.navigationPage_modelUpdate.Controls.Add(this.modelUpdate1);
            this.navigationPage_modelUpdate.Name = "navigationPage_modelUpdate";
            this.navigationPage_modelUpdate.Size = new System.Drawing.Size(1920, 880);
            // 
            // modelUpdate1
            // 
            this.modelUpdate1.Location = new System.Drawing.Point(0, 0);
            this.modelUpdate1.Name = "modelUpdate1";
            this.modelUpdate1.Size = new System.Drawing.Size(1920, 880);
            this.modelUpdate1.TabIndex = 0;
            // 
            // DeepLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_deepLearning);
            this.Name = "DeepLearning";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_deepLearning)).EndInit();
            this.navigationFrame_deepLearning.ResumeLayout(false);
            this.navigationPage_dataPreparation.ResumeLayout(false);
            this.navigationPage_modelTraining.ResumeLayout(false);
            this.navigationPage_modelTest.ResumeLayout(false);
            this.navigationPage_modelUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_deepLearning;
        private DataPreparation dataPreparation1;
        private ModelTraining modelTraining1;
        private ModelTest modelTest1;
        private ModelUpdate modelUpdate1;
    }
}
