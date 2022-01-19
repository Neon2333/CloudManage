
namespace CloudManage.SystemConfig
{
    partial class SystemConfig
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
            this.navigationFrame_systemConfig = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_productionLineAdditionDeletion = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_reserve1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.productionLineAdditionDeletion1 = new CloudManage.SystemConfig.ProductionLineAdditionDeletion();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_systemConfig)).BeginInit();
            this.navigationFrame_systemConfig.SuspendLayout();
            this.navigationPage_productionLineAdditionDeletion.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_systemConfig
            // 
            this.navigationFrame_systemConfig.Controls.Add(this.navigationPage_productionLineAdditionDeletion);
            this.navigationFrame_systemConfig.Controls.Add(this.navigationPage_reserve1);
            this.navigationFrame_systemConfig.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_systemConfig.Name = "navigationFrame_systemConfig";
            this.navigationFrame_systemConfig.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_productionLineAdditionDeletion,
            this.navigationPage_reserve1});
            this.navigationFrame_systemConfig.SelectedPage = this.navigationPage_productionLineAdditionDeletion;
            this.navigationFrame_systemConfig.Size = new System.Drawing.Size(1920, 880);
            this.navigationFrame_systemConfig.TabIndex = 0;
            this.navigationFrame_systemConfig.Text = "navigationFrame1";
            // 
            // navigationPage_productionLineAdditionDeletion
            // 
            this.navigationPage_productionLineAdditionDeletion.Controls.Add(this.productionLineAdditionDeletion1);
            this.navigationPage_productionLineAdditionDeletion.Name = "navigationPage_productionLineAdditionDeletion";
            this.navigationPage_productionLineAdditionDeletion.Size = new System.Drawing.Size(1920, 880);
            // 
            // navigationPage_reserve1
            // 
            this.navigationPage_reserve1.Name = "navigationPage_reserve1";
            this.navigationPage_reserve1.Size = new System.Drawing.Size(1920, 880);
            // 
            // productionLineAdditionDeletion1
            // 
            this.productionLineAdditionDeletion1.Location = new System.Drawing.Point(0, 0);
            this.productionLineAdditionDeletion1.Name = "productionLineAdditionDeletion1";
            this.productionLineAdditionDeletion1.Size = new System.Drawing.Size(1920, 880);
            this.productionLineAdditionDeletion1.TabIndex = 0;
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_systemConfig);
            this.Name = "SystemConfig";
            this.Size = new System.Drawing.Size(1920, 880);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_systemConfig)).EndInit();
            this.navigationFrame_systemConfig.ResumeLayout(false);
            this.navigationPage_productionLineAdditionDeletion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_systemConfig;
        private ProductionLineAdditionDeletion productionLineAdditionDeletion1;
    }
}
