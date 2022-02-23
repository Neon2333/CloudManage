using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.Util.TypeEnum;
using Emgu.CV.Structure;
using Emgu.CV.Dnn;
using Emgu.CV.CvEnum;
using System.Reflection;
using System.Drawing.Imaging;
using VisionSystemClassLibrary.Class;
using DevExpress.XtraEditors;

namespace CloudManage.DeepLearning
{
    public partial class ModelTest : DevExpress.XtraEditors.XtraUserControl
    {
        List<string> typeList = new List<string>();

        Int32[] ImageSize = { 0, 0 };
        Rectangle ROI = new Rectangle(0, 0, 744, 480);

        String defaultfilepath = string.Empty;
        String default_dirtestpath = string.Empty;
        String default_dirtraintestpath = string.Empty;
        String default_model_path = string.Empty;
        String default_model_name = string.Empty;

        string auto_test_path = string.Empty;
        Net net;                 //网络
        Int32 picturecount = 0;  //图片总数
        Int32[] classcount;      //各类图片计数
        Thread thread_dir;          //目录测试线程
        Thread threadGeneralTest; //训练集和验证集测试

        FileSystemWatcher watcher = new FileSystemWatcher();

        private static readonly object lock_ojb = new object();

        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

        AutoResetEvent autoEvent = new AutoResetEvent(false);

        int nMissNum = 0; //漏剔
        int nWrongNum = 0;//误剔

        bool bCudaUsed = false;
        int nIniModelNum = -1;
        int nLast_model_combo_id = -1;
        string iniFilePath = string.Empty;


        model_db md;
        Image<Bgr, Byte> ImagePictureBoxSourse;

        Point start; //画框的起始点
        Point end;//画框的结束点
        bool blnDraw;//判断是否绘制
        Rectangle process_rect;
        public ModelTest()
        {
            InitializeComponent();

            VisionSystemClassLibrary.Class.System.InitClassLog("\\log_cfg");

            dispLab.Text = "";
            defaultfilepath = "";
            comboBoxSave.SelectedIndex = 0;



            ImageSize[0] = Convert.ToInt32(SizeWTb.InputText);
            ImageSize[1] = Convert.ToInt32(SizeHTb.InputText);



            tm.Interval = 1;
            tm.Tick += new EventHandler(tm_Tick);


            string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
            iniFilePath = assemblyDirPath + "\\boot";

            try
            {
                if (File.Exists(iniFilePath))//存在该文件
                {
                    var cuda_state = INIFile.Read("System", "CUDA", null, iniFilePath);//读取数值
                    if (!String.IsNullOrEmpty(cuda_state))//不为空
                    {
                        switch (cuda_state.ToUpper())//筛选
                        {
                            case "TRUE":
                                bCudaUsed = true;
                                break;
                            case "FALSE":
                                bCudaUsed = false;
                                break;
                            default:
                                break;
                        }
                    }

                    defaultfilepath = INIFile.Read("System", "last_file_path", "", iniFilePath);
                    default_model_path = INIFile.Read("System", "last_model_path", "", iniFilePath);
                    default_model_name = INIFile.Read("System", "default_model_name", "", iniFilePath);
                    default_dirtestpath = INIFile.Read("System", "last_dir_test_path", "", iniFilePath);
                    default_dirtraintestpath = INIFile.Read("System", "last_train_test_path", "", iniFilePath);

                    var model_num = INIFile.Read("System", "model_num", null, iniFilePath);//读取数值

                    if (!String.IsNullOrEmpty(model_num))//不为空
                    {
                        nIniModelNum = Convert.ToInt16(model_num);

                        md = new model_db();

                        md.mdata = new model[nIniModelNum];
                        for (int i = 0; i < nIniModelNum; i++)
                        {
                            md.mdata[i] = new model();
                        }

                        for (int i = 1; i <= nIniModelNum; i++)
                        {
                            string key = "model_" + i + "_w";
                            md.mdata[i - 1].model_w = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_h";
                            md.mdata[i - 1].model_h = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_img_x";
                            md.mdata[i - 1].model_img_x = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_img_y";
                            md.mdata[i - 1].model_img_y = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_img_w";
                            md.mdata[i - 1].model_img_w = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_img_h";
                            md.mdata[i - 1].model_img_h = Convert.ToInt16(INIFile.Read("System", key, null, iniFilePath));
                            key = "model_" + i + "_name";
                         


                        }

                        string str_model_last_combo_id = INIFile.Read("System", "last_model_combo_id", "", iniFilePath);
                        if (!String.IsNullOrEmpty(str_model_last_combo_id))
                        {
                            nLast_model_combo_id = Convert.ToInt32(str_model_last_combo_id);
    

                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            StreamReader sr = new StreamReader("classes.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                typeList.Add(line);
            }

            if (typeList == null)
            {
                dispLab.Text = "分类文件为空！";
            }
            else
            {
                classcount = new Int32[typeList.Count];

                dispLab.Text = "已打开分类文件,请加载模型后开始测试";
                readOriModelBtn.Enabled = true;
            }
            
        
        }

        //计时器 事件
        void tm_Tick(object sender, EventArgs e)
        {
            autoEvent.Set(); 
        }


        private void Read_Classes(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.Title = "打开分类文件";


            if (openFileDialog.ShowDialog() == DialogResult.OK)  //当点击文件对话框的确定按钮时打开相应的文件
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    typeList.Add(line);
                }

                if (typeList == null)
                {
                    dispLab.Text = "分类文件为空！";
                }
                else
                {
                    classcount = new Int32[typeList.Count];

                    dispLab.Text = "已打开分类文件";
                    readOriModelBtn.Enabled = true;
                }
            }
            else
            {
                return;
            }
        }

       
        //读取原始模型
        private void readOriModelBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "模型文件|*.pb";
            openFileDialog.FileName = "";
            openFileDialog.Title = "打开原始模型文件";

            if (default_model_path != "")
            {
                openFileDialog.InitialDirectory = default_model_path;
            }
            else
            {
                openFileDialog.InitialDirectory = Application.StartupPath + "\\deeplearning\\model\\";
            }
            Mat imgfirst;  //待测试图片

            if (openFileDialog.ShowDialog() == DialogResult.OK)  //当点击文件对话框的确定按钮时打开相应的文件
            {
                default_model_path = Path.GetDirectoryName(openFileDialog.FileName);
                default_model_name = openFileDialog.FileName;
                INIFile.Write("System", "last_model_path", default_model_path, iniFilePath);
                INIFile.Write("System", "default_model_name", default_model_name, iniFilePath);

                // 加载网络
                String tf_pb_file = openFileDialog.FileName;

                try
                {

                    net = DnnInvoke.ReadNetFromTensorflow(tf_pb_file);

                    if (bCudaUsed)
                    {
                        net.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
                        net.SetPreferableTarget(Target.Cuda);
                    }
                    else
                    {
                        net.SetPreferableBackend(Emgu.CV.Dnn.Backend.InferenceEngine);
                        net.SetPreferableTarget(Target.Cpu);
                    }

                    if (net.Empty)
                    {
                        dispLab.Text = "请确认模型文件是否为空文件";
                        return;
                    }

                    imgfirst = new Mat(ImageSize[0], ImageSize[1], DepthType.Cv8U, 3);

                    Mat blobfirst = DnnInvoke.BlobFromImage(imgfirst, 1.0f, new Size(ImageSize[0], ImageSize[1]), new MCvScalar(), true, false);

                    net.SetInput(blobfirst);
                    net.Forward();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误！模型尺寸可能存在问题！" + ex.ToString(), "错误");
                    return;
                }

                dispLab.Text = "已加载原始模型文件" + default_model_name;
                SingTestBtn.Enabled = true;
                dirTestBtn.Enabled = true;
                DeepTestBtn.Enabled = true;

            }
            else
            {
            }
        }


        //加密模型
        private void EncrypModelBtn_Click(object sender, EventArgs e)
        {
            if (default_model_path != "")
            {
                openFileDialog.InitialDirectory = default_model_path;

            }
            else
            {
                openFileDialog.InitialDirectory = Application.StartupPath + "\\model\\";

            }
            openFileDialog.Filter = "模型文件|*.pb";
            openFileDialog.FileName = "";
            openFileDialog.Title = "打开待加密模型文件";


            if (openFileDialog.ShowDialog() == DialogResult.OK)  //当点击文件对话框的确定按钮时打开相应的文件
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();
                SimpleEncryption(openFileDialog.FileName);
                TimeSpan ts = sw.Elapsed;
                dispLab.Text = "模型加密时间:" + ts.ToString();
                return;
            }
            else
            {
                return;
            }
        }
        public void SimpleEncryption(string filePath)
        {
            FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[readFileStream.Length];
            readFileStream.Read(bytes, 0, bytes.Length);
            readFileStream.Close();

            for (int i = 0; i < bytes.Length; i++)
            {
                ++bytes[i];
            }

            string[] strA = filePath.Insert(filePath.IndexOf('.'), "_En").Split('\\');
            string newPath = Path.GetDirectoryName(filePath) + "\\" + strA[strA.Length - 1];
            FileStream writeFileStream = new FileStream(newPath, FileMode.Create, FileAccess.Write);
            writeFileStream.Write(bytes, 0, bytes.Length);
            writeFileStream.Close();

        }
        //单张测试
        private void Single_Test(object sender, EventArgs e)
        {
            if (typeList.Count == 0)
            {
                MessageBox.Show("请选择分类文件先！");
                return;
            }
            openFileDialog.Filter = "图片文件|*.jpg|图片文件|*.jpeg|图片文件|*.png|图片文件|*.bmp";
            openFileDialog.FileName = "";
            openFileDialog.Title = "打开图片文件";


            for (int i = 0; i < classcount.Length; i++)
            {
                classcount[i] = 0;
            }
            if (defaultfilepath != "")
            {
                openFileDialog.InitialDirectory = defaultfilepath;
            }
            else
            {
                openFileDialog.InitialDirectory = Application.StartupPath + "\\deeplearning\\test\\"; ;
            }

            openFileDialog.FileName = "";


            if (openFileDialog.ShowDialog() == DialogResult.OK)  //当点击文件对话框的确定按钮时打开相应的文件
            {
                defaultfilepath = Path.GetDirectoryName(openFileDialog.FileName);
                INIFile.Write("System", "last_file_path", defaultfilepath, iniFilePath);
                try
                {
                    ImageProcessingOne(openFileDialog.FileName);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

            }
            else
            {
                return;
            }
        }

        //目录测试
        private void Dir_Test(object sender, EventArgs e)
        {
           
            if (typeList.Count == 0)
            {
                MessageBox.Show("请选择分类文件先！");
                return;
            }

            picturecount = 0;

            for (int i = 0; i < classcount.Length; i++)
            {
                classcount[i] = 0;
            }

            if (default_dirtestpath != "")
            {
                folderBrowserDialog.SelectedPath = default_dirtestpath;
            }
            else
            {
                folderBrowserDialog.SelectedPath = Application.StartupPath;
            }


            try
            {
                if (dirTestBtn.Text == "目录测试")
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        dirTestBtn.Text = "立刻停止";
                        tm.Start();
                        default_dirtestpath = folderBrowserDialog.SelectedPath;
                        INIFile.Write("System", "last_dir_test_path", default_dirtestpath, iniFilePath);

                        thread_dir = new Thread(new ThreadStart(ImageProcessingAll));
                        thread_dir.Start();


                    }
                    else
                    {
                        dirTestBtn.Text = "目录测试";
                    }
                }
                else
                {
                    dirTestBtn.Text = "目录测试";
                    thread_dir.Abort();
                    tm.Stop();
                }
            }
            catch (Exception ex)
            {
                dispLab.Text = ex.ToString();
            }
        }
        //单张测试函数
        private void ImageProcessingOne(String filename)    //处理指定的单张图片
        {
            Image<Bgr, Byte> imageSource = new Image<Bgr, byte>(filename);
            ImagePictureBoxSourse = imageSource.Copy();

            //统一格式，与部署程序保持预测前格式相同
            //Image<Bgr, Byte> imageSource = _ReadImage(filename);

            Mat imgSave; //保存使用

          
            Mat imgShow = imageSource.Mat; //显示使用
            if (imgShow.IsEmpty)
            {
                dispLab.Text = "无法加载文件！";
                return;
            }

            if (checkBoxRoi.Checked) //选择兴趣区域
            {
                imgSave = new Mat(imageSource.Mat, new Rectangle(ROI.X, ROI.Y, ROI.Width, ROI.Height));

            }
            else
            {
                imgSave = imageSource.Mat;
            }

            //统一格式，与部署程序保持预测前格式相同
            MemoryStream stream = new MemoryStream();
            if (checkBoxRoi.Checked)//选择兴趣区域
            {

                imageSource.Copy(ROI).ToBitmap().Save(stream, ImageFormat.Jpeg);

            }
            else
            {
                imageSource.ToBitmap().Save(stream, ImageFormat.Jpeg);
            }

            Image<Bgr, Byte> imageOUT = null;
            Bitmap bitmapTemp = new Bitmap(stream);
            BitmapData bitmapData = bitmapTemp.LockBits(new Rectangle(0, 0, bitmapTemp.Width, bitmapTemp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmapTemp.Width, bitmapTemp.Height, bitmapData.Stride, bitmapData.Scan0);
            imageOUT = image.Copy();
            bitmapTemp.UnlockBits(bitmapData);
            //bitmapTemp.Save("test.jpg");

            imgSave = imageOUT.Mat;


            if (checkBoxRoi.Checked)//显示兴趣区域
            {
                CvInvoke.Rectangle(imgShow, ROI, new MCvScalar(0, 255, 0), 2);
            }

            double dThreValue = Convert.ToDouble(ThreshTb.InputText);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Mat blob = DnnInvoke.BlobFromImage(imgSave, 1.0f, new Size(ImageSize[0], ImageSize[1]), new MCvScalar(), true, false);

            Mat prob;

            net.SetInput(blob);
            prob = net.Forward();

            Mat probMat = prob.Reshape(1, 1);
            double minVal = 0;  
            double maxVal = 0; 
            Point minLoc = new Point();
            Point maxLoc = new Point();

            CvInvoke.MinMaxLoc(probMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            double classProb = maxVal;     //最大可能性
            Point classNumber = maxLoc;    //最大可能性位置

            string typeName = string.Empty;

            stopwatch.Stop();  
            long timespan = stopwatch.ElapsedMilliseconds;  //获取当前实例测量得出的总时间

            classcount[classNumber.X]++;
            picturecount++;


            dirLab.Text = "文件夹路径：" + Path.GetDirectoryName(filename);
            dirLab.Refresh();
            imagnameLab.Text = "图片名称：" + Path.GetFileName(filename);
            imagnameLab.Refresh();

            totalImgCountLab.Text = "图片总数：" + picturecount.ToString();
            totalImgCountLab.Refresh();

            typeName = (classProb > dThreValue) ? "OK" : "NG";
        

            if (comboBoxSave.SelectedIndex == 1)    //保存NG图像
            {
                if (typeName == "NG")
                {
                    CvInvoke.Imwrite("deeplearning/test_result/NG/" + Path.GetFileName(filename), imgSave);
                }
            }
            else if (comboBoxSave.SelectedIndex == 2)    //保存OK图像
            {
                if (typeName == "OK")
                {
                    CvInvoke.Imwrite("deeplearning/test_result/OK/" + Path.GetFileName(filename), imgSave);
                }
            }
            else if (comboBoxSave.SelectedIndex == 3)
            {
                if (typeName == "NG")
                {
                    CvInvoke.Imwrite("deeplearning/test_result/NG/" + Path.GetFileName(filename), imgSave);
                }
                else if (typeName == "OK")
                {
                    CvInvoke.Imwrite("deeplearning/test_result/OK/" + Path.GetFileName(filename), imgSave);
                }
            }

            imageBoxShow.Image = imgShow;

            dispLab.Text = "图片测试结果为：" + typeName + "  可能性为：" + classProb.ToString("0.00000") + "  处理总时间为：" + timespan.ToString() + "ms";
            dispLab.Refresh();
        }

        //目录测试函数

        public Image<Bgr, Byte> _ReadImage(string filename)
        {
            Image<Bgr, Byte> imageOUT = null;
            Bitmap bitmap = new Bitmap(filename);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmap.Width, bitmap.Height, bitmapData.Stride, bitmapData.Scan0);
            imageOUT = image.Copy();//更新数值
            bitmap.UnlockBits(bitmapData);

            return imageOUT;
        }

        private void ImageProcessingAll()   //处理文件指定文件夹下所有图片
        {
    
            double dThreValue = Convert.ToDouble(ThreshTb.InputText); //阈值

            int ngNum = 0;
            int okNum = 0;

            //Mat img;  //待测试图片
            DirectoryInfo folder;

            folder = new DirectoryInfo(default_dirtestpath);

            Invoke((EventHandler)delegate { dirLab.Text = "文件夹路径：" + folderBrowserDialog.SelectedPath; });
            Invoke((EventHandler)delegate { dirLab.Refresh(); });


            Mat imgSave; //保存使用
            try
            {

                double minVal = 0;  //最小可能性
                double maxVal = 0;  //最大可能性

                long timespan;
                string typeName = string.Empty;
                bool bFoundImag = false;

                foreach (FileInfo nextfile in folder.GetFiles())
                {
                    autoEvent.WaitOne();  
                    int i = nextfile.FullName.LastIndexOf(".");
                    if (i > 0)
                    {
                        string StrType = nextfile.FullName.Substring(i).ToLower();
                        if (StrType == ".jpg" || StrType == ".gif" || StrType == ".jpeg" || StrType == ".png")
                        {

                            bFoundImag = true;
                            Invoke((EventHandler)delegate { imagnameLab.Text = "图片名称：" + Path.GetFileName(nextfile.FullName); });
                            Invoke((EventHandler)delegate { imagnameLab.Refresh(); });

                            Image<Bgr, Byte> imageSource = _ReadImage(nextfile.FullName);
                            ImagePictureBoxSourse = imageSource.Copy();


                            Mat imgShow;

                            imgShow = imageSource.Mat; 
                            if (imgShow.IsEmpty)
                            {
                                Invoke((EventHandler)delegate { dispLab.Text = "无法加载文件！"; });
                                Invoke((EventHandler)delegate { dispLab.Refresh(); });
                                return;
                            }

                            if (checkBoxRoi.Checked)
                            {
                                imgSave = imageSource.Copy(ROI).Mat;  
                            }
                            else
                            {
                                imgSave = imageSource.Mat;  
                            }

                            MemoryStream stream = new MemoryStream();


                            if (checkBoxRoi.Checked)
                            {

                                imageSource.Copy(ROI).ToBitmap().Save(stream, ImageFormat.Jpeg);
                            }
                            else
                            {
                                imageSource.ToBitmap().Save(stream, ImageFormat.Jpeg);

                            }


                            Image<Bgr, Byte> imageOUT = null;
                            Bitmap bitmapTemp = new Bitmap(stream);
                            BitmapData bitmapData = bitmapTemp.LockBits(new Rectangle(0, 0, bitmapTemp.Width, bitmapTemp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                            Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmapTemp.Width, bitmapTemp.Height, bitmapData.Stride, bitmapData.Scan0);
                            imageOUT = image.Copy();
                            bitmapTemp.UnlockBits(bitmapData);
                            //bitmapTemp.Save("test.jpg");

                            imgSave = imageOUT.Mat;


                            if (checkBoxRoi.Checked)//显示兴趣区域
                            {
                                CvInvoke.Rectangle(imgShow, ROI, new MCvScalar(0, 255, 0), 2);
                            }


                            //开始时间
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();   //开始监视代码运行时间

                            //对输入图像数据进行处理
                            Mat blob = DnnInvoke.BlobFromImage(imgSave, 1.0f, new Size(ImageSize[0], ImageSize[1]), new MCvScalar(), true, false);
                            Mat prob;
                            net.SetInput(blob);      
                            prob = net.Forward();    

                            Mat probMat = prob.Reshape(1, 1);

                            Point minLoc = new Point();
                            Point maxLoc = new Point();

                            CvInvoke.MinMaxLoc(probMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                            double classProb = maxVal;     //最大可能性
                            Point classNumber = maxLoc;    //最大可能性位置

                            //  string typeName = typeList[classNumber.X];

                            stopwatch.Stop();  //  停止监视
                            timespan = stopwatch.ElapsedMilliseconds;  //获取当前实例测量得出的总时间

                            classcount[classNumber.X]++;
                            picturecount++;

                            if (maxVal < dThreValue)
                            {
                                ngNum++;
                            }
                            if (maxVal > dThreValue)
                            {
                                okNum++;
                            }
                            typeName = (classProb > dThreValue) ? "OK" : "NG";


                            if (comboBoxSave.SelectedIndex == 1)    //保存NG图像
                            {


                                if (maxVal < dThreValue)
                                {
                                    CvInvoke.Imwrite("deeplearning/test_result/NG/" + Path.GetFileName(nextfile.FullName), imgSave);

                                }


                            }
                            else if (comboBoxSave.SelectedIndex == 2)    //保存OK图像
                            {

                                if (maxVal > dThreValue)
                                {
                                    CvInvoke.Imwrite("deeplearning/test_result/OK/" + Path.GetFileName(nextfile.FullName), imgSave);

                                }
                            }
                            else if (comboBoxSave.SelectedIndex == 3)
                            {

                                if (typeName == "NG")
                                {
                                    CvInvoke.Imwrite("deeplearning/test_result/NG/" + Path.GetFileName(nextfile.FullName), imgSave);
                                }
                                else if (typeName == "OK")
                                {
                                    CvInvoke.Imwrite("deeplearning/test_result/OK/" + Path.GetFileName(nextfile.FullName), imgSave);
                                }
                            }

                            Invoke((EventHandler)delegate { totalImgCountLab.Text = "图片总数：" + picturecount.ToString(); });
                            Invoke((EventHandler)delegate { totalImgCountLab.Refresh(); });


                            //检测内容
                            Invoke((EventHandler)delegate { imageBoxShow.Image = imgShow; });
                            Invoke((EventHandler)delegate { imageBoxShow.Refresh(); });
                            Invoke((EventHandler)delegate { dispLab.Text = "图片测试结果为：" + typeName + "  可能性为：" + classProb.ToString("0.00000") + "  处理总时间为：" + timespan.ToString() + "ms"; });
                            Invoke((EventHandler)delegate { dispLab.Refresh(); });
                        }
                    }
                 

                }
                if (bFoundImag)
                {

                    XtraMessageBox.Show("当前目录测试完成           \n\n" + "NG：" + ngNum + ",OK：" + okNum + "        \n\n请再接再厉！", "注意");
                    dirTestBtn.Text = "目录测试";
                    LogHelper.Info("当前目录测试完成,模型文件" + default_model_name + ",测试目录" + default_dirtestpath + ",NG：" + ngNum + ",OK：" + okNum);

                }
                else
                {

                    XtraMessageBox.Show("该文件夹下没有图片文件!", "错误", MessageBoxButtons.OK);
                
                    dirTestBtn.Text = "目录测试";

                }
            }
            catch (ThreadAbortException ex)
            {
                dirTestBtn.Text = "目录测试";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                dirTestBtn.Text = "目录测试";

            }


        }

        private void textBoxRoiX_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void imageBoxShow_Click(object sender, EventArgs e)
        {

            tm.Stop();

        }

        private void imageBoxShow_DoubleClick(object sender, EventArgs e)
        {
            tm.Start();
        }

        private void imageBoxShow_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point();
            pt.X = (int)(e.Location.X / (float)imageBoxShow.ZoomScale);
            pt.Y = (int)(e.Location.Y / (float)imageBoxShow.ZoomScale);
            int horizontalScrollBarValue = imageBoxShow.HorizontalScrollBar.Visible ? (int)imageBoxShow.HorizontalScrollBar.Value : 0;
            int verticalScrollBarValue = imageBoxShow.VerticalScrollBar.Visible ? (int)imageBoxShow.VerticalScrollBar.Value : 0;
            pt.X += horizontalScrollBarValue;
            pt.Y += verticalScrollBarValue;

            start = pt;

            try
            {
                PositionLab.Text = "(X,Y) = (" + pt.X.ToString() + "," + pt.Y.ToString() + ")";
                labelRGB.Text = "(R,G,B) = (" + ImagePictureBoxSourse[pt.Y, pt.X].Red.ToString() + "，" + ImagePictureBoxSourse[pt.Y, pt.X].Green.ToString() + "，" + ImagePictureBoxSourse[pt.Y, pt.X].Blue.ToString() + ")";
            }
            catch (Exception ex)
            {

            }
            Invalidate();
            blnDraw = true;
        }

        private void imageBoxShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                if (e.Button != MouseButtons.Left)//判断是否按下左键
                    return;
                Point tempEndPoint = e.Location; //记录框的位置和大小

                Point pt = new Point();
                pt.X = (int)(e.Location.X / (float)imageBoxShow.ZoomScale);
                pt.Y = (int)(e.Location.Y / (float)imageBoxShow.ZoomScale);
                int horizontalScrollBarValue = imageBoxShow.HorizontalScrollBar.Visible ? (int)imageBoxShow.HorizontalScrollBar.Value : 0;
                int verticalScrollBarValue = imageBoxShow.VerticalScrollBar.Visible ? (int)imageBoxShow.VerticalScrollBar.Value : 0;
                pt.X += horizontalScrollBarValue;
                pt.Y += verticalScrollBarValue;

                tempEndPoint = pt;

                process_rect.Location = new Point(
                Math.Min(start.X, tempEndPoint.X),
                Math.Min(start.Y, tempEndPoint.Y));
                process_rect.Size = new Size(
                Math.Abs(start.X - tempEndPoint.X),
                Math.Abs(start.Y - tempEndPoint.Y));
                imageBoxShow.Invalidate();
            }
        }

        private void imageBoxShow_MouseUp(object sender, MouseEventArgs e)
        {
            blnDraw = false; 
            //preprocessTb.Text = process_rect.X + "," + process_rect.Y + "," + process_rect.Width + "," + process_rect.Height;
        }

     

        private void imageBoxShow_Paint(object sender, PaintEventArgs e)
        {
            if (blnDraw)
            {
                if (imageBoxShow.Image != null)
                {
                    if (process_rect != null && process_rect.Width > 0 && process_rect.Height > 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Red, 3), process_rect);//重新绘制颜色为红色
                    }
                }
            }
        }

        private void DeepTestBtn_Click(object sender, EventArgs e)
        {
            if (typeList.Count == 0)
            {
                MessageBox.Show("请选择分类文件先！");
                return;
            }

            checkBoxRoi.Checked = false;

            try
            {
                if (DeepTestBtn.Text == "训练集测试")
                {
                    DeepTestBtn.Text = "立刻停止";
                    tm.Start();

                    if (default_dirtraintestpath == "")
                    {
                        folderBrowserDialog.SelectedPath = Application.StartupPath;

                    }
                    else
                    {
                        folderBrowserDialog.SelectedPath = default_dirtraintestpath;

                    }

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        default_dirtraintestpath = folderBrowserDialog.SelectedPath;
                        INIFile.Write("System", "last_train_test_path", default_dirtraintestpath, iniFilePath);


                        if (default_model_name != "")
                        {
                            net = DnnInvoke.ReadNetFromTensorflow(default_model_name);
                            if (bCudaUsed)
                            {
                                net.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
                                net.SetPreferableTarget(Target.Cuda);
                            }
                            else
                            {
                                net.SetPreferableBackend(Emgu.CV.Dnn.Backend.InferenceEngine);
                                net.SetPreferableTarget(Target.Cpu);
                            }
                        }

                        threadGeneralTest = new Thread(ImageProcessingGeneralAll);
                        if (default_model_name != "")
                        {
                            threadGeneralTest.Start(default_model_name);
                        }
                        else
                        {
                            MessageBox.Show("模型路径为空");
                        }


                    }
                    else
                    {
                        DeepTestBtn.Text = "训练集测试";
                    }
                }
                else
                {
                    DeepTestBtn.Text = "训练集测试";
                    threadGeneralTest.Abort();
                    tm.Stop();
                }
            }
            catch (Exception ex)
            {
                dispLab.Text = ex.ToString();
            }

        }

        private void ImageProcessingGeneralAll(object obj)   //处理文件指定文件夹下所有图片
        {

            lock (lock_ojb)
            {


                nMissNum = 0;
                nWrongNum = 0;

                picturecount = 0;


                DirectoryInfo folder;
                DirectoryInfo folderTrainOK;
                DirectoryInfo folderTrainNG;
                DirectoryInfo folderTestOK;
                DirectoryInfo folderTestNG;

                folder = new DirectoryInfo(default_dirtraintestpath);
                folderTrainOK = new DirectoryInfo(folder.FullName + "\\train\\OK");
                folderTestOK = new DirectoryInfo(folder.FullName + "\\test\\OK");


                folderTrainNG = new DirectoryInfo(folder.FullName + "\\train\\NG");
                folderTestNG = new DirectoryInfo(folder.FullName + "\\test\\NG");



                if (folderTrainOK.Exists && folderTestOK.Exists && folderTrainNG.Exists && folderTestNG.Exists)
                {
                    try
                    {
                        GeneralAllOKImage(folderTrainOK);
                        GeneralAllOKImage(folderTestOK);
                        GeneralAllNGImage(folderTrainNG);
                        GeneralAllNGImage(folderTestNG);
                    }
                    catch (ThreadAbortException ex)
                    {
                        LogHelper.error("ThreadAbortException", ex);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        LogHelper.error("", ex);
                    }




                    if (XtraMessageBox.Show("全测试完成\n" + "误剔：" + nWrongNum + ", 漏剔：" + nMissNum + "\n现在查看测试结果??", "注意", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string v_OpenFolderPath = "deeplearning\\test_result";
                        System.Diagnostics.Process.Start("explorer.exe", v_OpenFolderPath);
                        LogHelper.Info("手动测试完成," + "模型文件" + (string)obj + "测试目录" + default_dirtraintestpath + ",误剔：" + nWrongNum + ", 漏剔：" + nMissNum);

                    }
                    DeepTestBtn.Text = "训练集测试";


                }
                else
                {
                    MessageBox.Show("当前选择非训练验证目录，请重新选择！", "注意");
                    DeepTestBtn.Text = "训练集测试";
                }
            }




        }

        private void GeneralAllOKImage(DirectoryInfo folder)
        {

            Invoke((EventHandler)delegate { dirLab.Text = "文件夹路径：" + folder.FullName; });
            Invoke((EventHandler)delegate { dirLab.Refresh(); });
            double dThreValue = Convert.ToDouble(ThreshTb.InputText);

            Mat imgSave; //保存使用
            Mat imgShow;//显示使用
            foreach (FileInfo nextfile in folder.GetFiles())
            {
                int i = nextfile.FullName.LastIndexOf(".");
                if (i > 0)
                {
                    string StrType = nextfile.FullName.Substring(i).ToLower();
                    if (StrType == ".jpg" || StrType == ".gif" || StrType == ".jpeg" || StrType == ".png")
                    {

                        autoEvent.WaitOne();
                        Invoke((EventHandler)delegate { imagnameLab.Text = "图片名称：" + Path.GetFileName(nextfile.FullName); });
                        Invoke((EventHandler)delegate { imagnameLab.Refresh(); });

                        // Image<Bgr, Byte> imageSource = new Image<Bgr, byte>(nextfile.FullName);

                        Image<Bgr, Byte> imageSource = _ReadImage(nextfile.FullName);
                        ImagePictureBoxSourse = imageSource.Copy();

                     
                        imgShow = imageSource.Mat; //显示使用

                        if (imgShow.IsEmpty)
                        {
                            Invoke((EventHandler)delegate { dispLab.Text = "无法加载文件！"; });
                            Invoke((EventHandler)delegate { dispLab.Refresh(); });
                            return;
                        }


                        if (checkBoxRoi.Checked)
                        {
                            imgSave = imageSource.Copy(ROI).Mat;
                        }
                        else
                        {
                            imgSave = imageSource.Mat;
                        }

                        //统一格式
                        MemoryStream stream = new MemoryStream();

                        if (checkBoxRoi.Checked)
                        {

                            imageSource.Copy(ROI).ToBitmap().Save(stream, ImageFormat.Jpeg);
                        }
                        else
                        {
                            imageSource.ToBitmap().Save(stream, ImageFormat.Jpeg);

                        }


                        Image<Bgr, Byte> imageOUT = null;
                        Bitmap bitmapTemp = new Bitmap(stream);
                        BitmapData bitmapData = bitmapTemp.LockBits(new Rectangle(0, 0, bitmapTemp.Width, bitmapTemp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                        Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmapTemp.Width, bitmapTemp.Height, bitmapData.Stride, bitmapData.Scan0);
                        imageOUT = image.Copy();//更新数值
                        bitmapTemp.UnlockBits(bitmapData);
                        //bitmapTemp.Save("test.jpg");

                        imgSave = imageOUT.Mat;

                        if (checkBoxRoi.Checked)//显示兴趣区域
                        {
                            CvInvoke.Rectangle(imgShow, ROI, new MCvScalar(0, 255, 0), 2);
                        }

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();   

                        Mat blob = DnnInvoke.BlobFromImage(imgSave, 1.0f, new Size(ImageSize[0], ImageSize[1]), new MCvScalar(), true, false);

                        Mat prob;

                        net.SetInput(blob);      
                        prob = net.Forward();    

                        Mat probMat = prob.Reshape(1, 1);
                        double minVal = 0;  
                        double maxVal = 0;  
                        Point minLoc = new Point();
                        Point maxLoc = new Point();

                        CvInvoke.MinMaxLoc(probMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                        double classProb = maxVal;    
                        Point classNumber = maxLoc;   

                        stopwatch.Stop();  
                        long timespan = stopwatch.ElapsedMilliseconds;  

                        classcount[classNumber.X]++;
                        picturecount++;

                        string typeName = (classProb > dThreValue) ? "OK" : "NG";

                        if (maxVal < dThreValue)
                        {
                           
                            CvInvoke.Imwrite("deeplearning/test_result/NG/" + Path.GetFileName(nextfile.FullName), imgSave);
                            nWrongNum++;//误剔
                        }

                        Invoke((EventHandler)delegate { totalImgCountLab.Text = "图片总数：" + picturecount.ToString(); });
                        Invoke((EventHandler)delegate { totalImgCountLab.Refresh(); });

                        //typeName = (classProb > dThreValue) ? "OK" : "NG";
                        //CvInvoke.PutText(imgSave, typeName, new Point(100, 30), FontFace.HersheySimplex, 1, new MCvScalar(255, 255, 0), 2);
                        //检测内容
                        Invoke((EventHandler)delegate { imageBoxShow.Image = imgShow; });
                        Invoke((EventHandler)delegate { imageBoxShow.Refresh(); });
                        Invoke((EventHandler)delegate { dispLab.Text = "图片测试结果为：" + typeName + "  可能性为：" + classProb.ToString("0.00000") + "  处理总时间为：" + timespan.ToString() + "ms"; });
                        Invoke((EventHandler)delegate { dispLab.Refresh(); });
                    }
                }


            }
        }

        private void GeneralAllNGImage(DirectoryInfo folder)
        {
            Invoke((EventHandler)delegate { dirLab.Text = "文件夹路径：" + folder.FullName; });
            Invoke((EventHandler)delegate { dirLab.Refresh(); });

            double dThreValue = Convert.ToDouble(ThreshTb.InputText);
            Mat imgSave; //保存使用
            Mat imgShow;//显示使用
            foreach (FileInfo nextfile in folder.GetFiles())
            {
                int i = nextfile.FullName.LastIndexOf(".");
                if (i > 0)
                {
                    string StrType = nextfile.FullName.Substring(i).ToLower();
                    if (StrType == ".jpg" || StrType == ".gif" || StrType == ".jpeg" || StrType == ".png")
                    {
                        autoEvent.WaitOne();
                        Invoke((EventHandler)delegate { imagnameLab.Text = "图片名称：" + Path.GetFileName(nextfile.FullName); });
                        Invoke((EventHandler)delegate { imagnameLab.Refresh(); });

                        //  Image<Bgr, Byte> imageSource = new Image<Bgr, byte>(nextfile.FullName);
                        Image<Bgr, Byte> imageSource = _ReadImage(nextfile.FullName);
                        ImagePictureBoxSourse = imageSource.Copy();

                      
                        imgShow = imageSource.Mat; 
                        if (imgShow.IsEmpty)
                        {
                            Invoke((EventHandler)delegate { dispLab.Text = "无法加载文件！"; });
                            Invoke((EventHandler)delegate { dispLab.Refresh(); });
                            return;
                        }

                        if (checkBoxRoi.Checked)
                        {
                            imgSave = new Mat(imageSource.Mat, new Rectangle(ROI.X, ROI.Y, ROI.Width, ROI.Height));

                        }
                        else
                        {
                            imgSave = imageSource.Mat;  
                        }

                        //统一格式
                        MemoryStream stream = new MemoryStream();


                        if (checkBoxRoi.Checked)
                        {

                            imageSource.Copy(ROI).ToBitmap().Save(stream, ImageFormat.Jpeg);
                        }
                        else
                        {
                            imageSource.ToBitmap().Save(stream, ImageFormat.Jpeg);

                        }


                        Image<Bgr, Byte> imageOUT = null;
                        Bitmap bitmapTemp = new Bitmap(stream);
                        BitmapData bitmapData = bitmapTemp.LockBits(new Rectangle(0, 0, bitmapTemp.Width, bitmapTemp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                        Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmapTemp.Width, bitmapTemp.Height, bitmapData.Stride, bitmapData.Scan0);
                        imageOUT = image.Copy();
                        bitmapTemp.UnlockBits(bitmapData);
                        //bitmapTemp.Save("test.jpg");

                        imgSave = imageOUT.Mat;
                        //img = CvInvoke.Imread(nextfile.FullName, Emgu.CV.CvEnum.ImreadModes.Color);

                        if (checkBoxRoi.Checked)//显示兴趣区域
                        {
                            CvInvoke.Rectangle(imgShow, ROI, new MCvScalar(0, 255, 0), 2);
                        }

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();   

                        Mat blob = DnnInvoke.BlobFromImage(imgSave, 1.0f, new Size(ImageSize[0], ImageSize[1]), new MCvScalar(), true, false);

                        Mat prob;

                        net.SetInput(blob);     
                        prob = net.Forward();   

                        Mat probMat = prob.Reshape(1, 1);
                        double minVal = 0;  
                        double maxVal = 0;  
                        Point minLoc = new Point();
                        Point maxLoc = new Point();

                        CvInvoke.MinMaxLoc(probMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                        double classProb = maxVal;    
                        Point classNumber = maxLoc;    



                        string typeName = typeList[classNumber.X];

                        stopwatch.Stop(); 
                        long timespan = stopwatch.ElapsedMilliseconds;  

                        classcount[classNumber.X]++;
                        picturecount++;



                        if (maxVal >= dThreValue)
                        {
                           
                            CvInvoke.Imwrite("deeplearning/test_result/OK/" + Path.GetFileName(nextfile.FullName), imgSave);
                            nMissNum++; //漏剔
                        }


                        Invoke((EventHandler)delegate { totalImgCountLab.Text = "图片总数：" + picturecount.ToString(); });
                        Invoke((EventHandler)delegate { totalImgCountLab.Refresh(); });

                        Invoke((EventHandler)delegate { imageBoxShow.Image = imgShow; });
                        Invoke((EventHandler)delegate { imageBoxShow.Refresh(); });
                        Invoke((EventHandler)delegate { dispLab.Text = "图片测试结果为：" + typeName + "  可能性为：" + classProb.ToString("0.00000") + "  处理总时间为：" + timespan.ToString() + "ms"; });
                        Invoke((EventHandler)delegate { dispLab.Refresh(); });
                    }
                }
            }
        }

        Rectangle rt = new Rectangle(0, 0, 0, 0);

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SizeWTb_TextChanged(object sender, EventArgs e)
        {
            if(SizeWTb.InputText != "")
            {
                try
                {
                    ImageSize[0] = Convert.ToInt32(SizeWTb.InputText);

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);
                }
            }
           
        }

        private void SizeHTb_TextChanged(object sender, EventArgs e)
        {
            if (SizeHTb.InputText != "")
            {
                try
                {
                    ImageSize[1] = Convert.ToInt32(SizeHTb.InputText);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);
                }
            }

           
        }

        private void textBoxRoiX_TextChanged(object sender, EventArgs e)
        {
            if(textBoxRoiX.InputText != "")
            {
                try
                {
                    ROI.X = Convert.ToInt32(textBoxRoiX.InputText);

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);

                }
            }
        }

        private void textBoxRoiY_TextChanged(object sender, EventArgs e)
        {
            if(textBoxRoiY.InputText != "")
            {
                try
                {
                    ROI.Y = Convert.ToInt32(textBoxRoiY.InputText);

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);
                }
            }

        }

        private void textBoxRoiWidth_TextChanged(object sender, EventArgs e)
        {
            if(textBoxRoiWidth.InputText != "")
            {
                try
                {
                    ROI.Width = Convert.ToInt32(textBoxRoiWidth.InputText);

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);

                }
            }

        }

        private void textBoxRoiHeight_TextChanged(object sender, EventArgs e)
        {
            if(textBoxRoiHeight.InputText != "")
            {
                try
                {
                    ROI.Height = Convert.ToInt32(textBoxRoiHeight.InputText);

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("输入不正确", "错误", MessageBoxButtons.OK);

                }
            }

        }
    }

    public partial class model
    {

        public int model_w;
        public int model_h;
        public int model_img_x;
        public int model_img_y;
        public int model_img_w;
        public int model_img_h;
    }
    public partial class model_db
    {
        public int index;
        public model[] mdata;
    }
}
