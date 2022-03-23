using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DeepLearning
{
    public partial class DataPreparation : DevExpress.XtraEditors.XtraUserControl
    {
        public static ushort currentPageIndex = 9;

        public string picOKPath = @"C:\Users\eivision\Desktop\OK";    //OK路径
        public string picNGPath = @"C:\Users\eivision\Desktop\NG";    //NG路径

        class Pics
        {
            public string picName { get; set; }

            public string picPath { get; set; }
            public Image pic { get; set; }

            public Pics(string name, string path, Image img)
            {
                this.picName = name;
                this.picPath = path;
                this.pic = img;
            }
        }

        List<Pics> picsOK = new List<Pics>();
        List<Pics> picsNG = new List<Pics>();


        public DataPreparation()
        {
            InitializeComponent();
            initDataPreparation();

            MainForm.deviceOrLineAdditionDeletionReinitDataPreparation += reInitDataPreparation;
        }
        public void reInitDataPreparation(object sender, EventArgs e)
        {

        }

        public void initDataPreparation()
        {
            bindPicsOKToGrid();
            bindPicsNGToGrid();
        }


        public void bindPicsOKToGrid()
        {
            this.gridControl_displayOKPics.BeginUpdate();

            readPicsOKToList();

            this.gridControl_displayOKPics.DataSource = picsOK;

            this.gridControl_displayOKPics.EndUpdate();
        }

        private void readPicsOKToList()
        {
            DirectoryInfo dirPics = new DirectoryInfo(picOKPath);
            FileInfo[] fileInfos = dirPics.GetFiles();

            foreach (var item in fileInfos)
            {
                string itemName = item.Name;
                string itemPath = item.FullName;

                picsOK.Add(new Pics(itemName, itemPath, Image.FromFile(itemPath)));
            }
        }

        public void bindPicsNGToGrid()
        {
            this.gridControl_displayNGPics.BeginUpdate();

            readPicsNGToList();

            this.gridControl_displayNGPics.DataSource = picsNG;

            this.gridControl_displayNGPics.EndUpdate();
        }

        private void readPicsNGToList()
        {
            DirectoryInfo dirPics = new DirectoryInfo(picNGPath);
            FileInfo[] fileInfos = dirPics.GetFiles();
            foreach (var item in fileInfos)
            {
                string itemName = item.Name;
                string itemPath = item.FullName;

                picsNG.Add(new Pics(itemName, itemPath, Image.FromFile(itemPath)));
            }
        }

        private void delPicsInDir(string picPath)
        {
            if (System.IO.File.Exists(picPath))
            {
                System.IO.File.Delete(picPath);
            }
        }

        private void delPicsInDirByListIndex(List<Pics> pics, int[] picIndex)
        {
            foreach (var i in picIndex)
            {
                if (pics.Count >= picIndex.Length)
                {
                    delPicsInDir(pics.ElementAt(i).picPath);
                }
            }
        }

        private void simpleButton_delPicsOK_Click(object sender, EventArgs e)
        {
            this.gridControl_displayOKPics.BeginUpdate();

            int[] delPicsOKIndex = this.winExplorerView_displayPicsOK.GetSelectedRows();
            delPicsInDirByListIndex(picsOK, delPicsOKIndex);            //删除文件夹中图片
            this.winExplorerView_displayPicsOK.DeleteSelectedRows();    //删除控件显示的pic以及DataSource中元素

            this.gridControl_displayOKPics.EndUpdate();

            if (this.winExplorerView_displayPicsOK.RowCount > 0)
            {
                this.winExplorerView_displayPicsOK.SelectRow(0);    //删除当前选中图片后，默认选中index=0的图片
            }
        }

        private void simpleButton_delPicsNG_Click(object sender, EventArgs e)
        {
            this.gridControl_displayNGPics.BeginUpdate();

            int[] delPicsNGIndex = this.winExplorerView_displayPicsNG.GetSelectedRows();
            delPicsInDirByListIndex(picsNG, delPicsNGIndex);
            this.winExplorerView_displayPicsNG.DeleteSelectedRows();

            this.gridControl_displayNGPics.EndUpdate();

            if (this.winExplorerView_displayPicsNG.RowCount > 0)
            {
                this.winExplorerView_displayPicsNG.SelectRow(0);
            }
        }

    }
}
