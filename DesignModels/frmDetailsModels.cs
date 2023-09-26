using DesignModels.Entity;
using DesignModels.Services;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DesignModels
{
    public partial class frmDetailsModels : DevExpress.XtraEditors.XtraForm
    {
        private readonly IModelsService _modelsServices;
        private readonly IFileImageService _fileImage;
        private SerialPort serialPort;
        private delegate void SetTextDeleg(string text);

        public frmDetailsModels(IModelsService modelsServices, IFileImageService fileImage)
        {
            InitializeComponent();
            InitializeTimer();
            _modelsServices = modelsServices;
            _fileImage = fileImage;

            //add_comboxAsync();

            //serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            // Khởi tạo đối tượng SerialPort
            //string name;
            //string message;
            //StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            //Thread readThread = new Thread(Read);

            serialPort = new SerialPort();
            serialPort.PortName = "COM1"; // Thay thế COM1 bằng cổng COM thực tế của bạn
            serialPort.BaudRate = 9600; // Tốc độ truyền dữ liệu
            serialPort.DataBits = 8; // Số bits dữ liệu
            serialPort.Parity = Parity.None; // Kiểm tra lỗi: None
            serialPort.StopBits = StopBits.One; // Số stop bits: 1

            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            // Mở cổng COM
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi mở cổng COM: " + ex.Message);
                return;
            }
        }
        //void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Thread.Sleep(500);
        //    string data = serialPort.ReadLine();
        //    this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        //}

        //private void si_DataReceived(string data)
        //{
        //    txtTrayThicknessMm.Text = data.Trim();
        //    txtTrayCount.Text = data.Trim();
        //}

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(projectPathImage))
            {

                string[] imgExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };
                string[] imgFile = Directory.GetFiles(projectPathImage, "*.*", SearchOption.AllDirectories);

                //var data = await _modelsServices.GetAllModels();
                foreach (string file in imgFile)
                {
                    string fileName = Path.GetFileName(file);
                    if (!listBox1.ToString().Contains(fileName))
                    {
                        string[] fileNameParts = fileName.Split('_');
                        string modelName = fileNameParts[0];
                        string barCode = fileNameParts[1];



                        var detailModels = new DetailModels();
                        var model = await _modelsServices.GetModelssByName(modelName);
                        if (model != null)
                        {
                            detailModels.modelid = model.id;
                        }
                        detailModels.barcode = barCode;
                        detailModels.pathimage = file;
                        if (file.Contains("Ok"))
                        {
                            detailModels.status = 1;
                        }
                        else
                        {
                            detailModels.status = 2;
                        }
                        detailModels.created_at = DateTime.Now;

                        var abc = await _fileImage.CheckName(detailModels.barcode);
                        if (abc == true)
                        {
                            continue;
                        }
                        else
                        {
                            splashScreenManager1.ShowWaitForm();
                            bool a = await _fileImage.CreateDetailModels(detailModels);
                            if (a == true)
                            {
                                string extractedPath = Path.GetRelativePath(projectPathImage, file); //2023/....
                                string files = fileName.ToString(); //ten file
                                string sourcePath = Path.Combine(file);//tep cu
                                string destinationPath = Path.Combine(destinationFolder, extractedPath); //tep moi
                                string destinationDirectory = Path.GetDirectoryName(destinationPath);
                                if (!Directory.Exists(destinationDirectory))
                                {
                                    Directory.CreateDirectory(Path.Combine(destinationDirectory));
                                }
                                File.Move(sourcePath, destinationPath);
                                listBox1.Items.Add(files);
                            }
                            splashScreenManager1.CloseWaitForm();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Thuc muc khong ton tai!");
            }
        }

        //form load ở đây
        private async void frmDetailsModels_Load(object sender, EventArgs e)
        {
            var listDetailsModels = await _fileImage.GetAllDetailModels();
            foreach (var item in listDetailsModels)
            {
                string fileName = Path.GetFileName(item.pathimage);
                listBox1.Items.Add(fileName);
            }

            cboModel.Items.Add("Mời bạn chọn");
            //cboModel.SelectedIndex = 0; // Đặt mục đầu tiên là mục được chọn
            var model = await _modelsServices.GetAllModels();
            foreach (var modelItem in model)
            {
                cboModel.Items.Add(modelItem.modelsname);
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullPath = null;
            string[] imgFile = Directory.GetFiles(destinationFolder, "*.*", SearchOption.AllDirectories);
            string selectPath = listBox1.SelectedItem.ToString();

            foreach (var item in imgFile)
            {
                string file = Path.GetFileName(item);
                if (file.Equals(selectPath))
                {
                    fullPath = Path.Combine(item);
                }
            }
            pictureBox1.ImageLocation = fullPath;



        }

        private Timer timer;
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        string projectPathImage = @"C:\Users\ASUS-VivoBook\source\repos\Models\DesignModels\Data\";
        string destinationFolder = @"C:\Users\ASUS-VivoBook\source\repos\Models\DesignModels\AddOk\"; // sau khi move den

        private async void btnAddDatabase_Click(object sender, EventArgs e)
        {
            //if (Directory.Exists(projectPathImage))
            //{


            //    string[] imgExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };
            //    string[] imgFile = Directory.GetFiles(projectPathImage, "*.*", SearchOption.AllDirectories);

            //    //var data =  PostgresHelper.GetAll<Modelss>();
            //    var data = await _modelsServices.GetAllModels();
            //    foreach (string file in imgFile)
            //    {
            //        string fileName = Path.GetFileName(file);
            //        if (!listBox1.ToString().Contains(fileName))
            //        {
            //            string[] fileNameParts = fileName.Split('_');
            //            string modelName = fileNameParts[0];
            //            string barCode = fileNameParts[1];



            //            var detailModels = new DetailModels();
            //            var model = await _modelsServices.GetModelssByName(modelName);
            //            if (model != null)
            //            {
            //                detailModels.modelid = model.id;
            //            }
            //            detailModels.barcode = barCode;
            //            detailModels.pathimage = file;
            //            if (file.Contains("Ok"))
            //            {
            //                detailModels.status = 1;
            //            }
            //            else
            //            {
            //                detailModels.status = 2;
            //            }
            //            detailModels.created_at = DateTime.Now;

            //            var abc = await _fileImage.CheckName(detailModels.barcode);
            //            if (abc == true)
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                splashScreenManager1.ShowWaitForm();
            //                bool a = await _fileImage.CreateDetailModels(detailModels);
            //                if (a == true)
            //                {
            //                    string files = fileName.ToString();
            //                    string sourcePath = Path.Combine(file);
            //                    string destinationPath = Path.Combine(destinationFolder, files);
            //                    File.Move(sourcePath, destinationPath);
            //                    listBox1.Items.Add(files);
            //                }
            //                splashScreenManager1.CloseWaitForm();
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Thuc muc khong ton tai!");
            //}
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var abc = txtBox1.Text.Trim();
            string a = null;
            string fullPath = null;
            string[] imgFile = Directory.GetFiles(destinationFolder, "*.*", SearchOption.AllDirectories);

            foreach (var item in imgFile)
            {
                string file = Path.GetFileName(item);
                string[] fileNameParts = file.Split('_');
                string barCode = fileNameParts[1];

                if (abc.Contains(barCode))
                {
                    a = item;
                    fullPath = Path.Combine(a);
                }
            }
            if (a != null)
            {
                splashScreenManager1.ShowWaitForm();
                pictureBox1.Image = Image.FromFile(fullPath);
                splashScreenManager1.CloseWaitForm();
            }
            else
            {
                MessageBox.Show("Khong tim thay!!");
            }
            #region
            //var s = await _fileImage.GetImageByBarcode(abc);
            //string fileName = Path.GetFileName(imgFile);
            //string[] fileNameParts = fileName.Split('_');
            //string fullPath = Path.Combine(s.pathimage);
            //string barCode = fileNameParts[1];

            //if (abc.Contains(barCode))
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    pictureBox1.ImageLocation = fullPath;
            //    splashScreenManager1.CloseWaitForm();
            //}
            //else
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    MessageBox.Show("Mã code không tồn tại...");
            //    splashScreenManager1.CloseWaitForm();
            //}
            //}
            //}
            #endregion
        }

        int DoTuongDong(string chuoi1, string chuoi2)
        {
            int doTuongDong = 0;
            int chieuDaiChuoi1 = chuoi1.Length;
            int chieuDaiChuoi2 = chuoi2.Length;

            for (int i = 0; i < chieuDaiChuoi1 && i < chieuDaiChuoi2; i++)
            {
                if (chuoi1[i] == chuoi2[i])
                {
                    doTuongDong++;
                }
                else
                {
                    break;
                }
            }


            return doTuongDong;
        }

        private void txtBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer = new Timer();
            //timer.Interval = 3000;
            //splashScreenManager1.ShowWaitForm();
            //timer.Tick += Timer_Tick;
            //timer.Start();
            //splashScreenManager1.CloseWaitForm();
        }

        private async void add_comboxAsync()
        {
            cboModel.Items.Add("Mời bạn chọn");
            cboModel.SelectedIndex = 0; // Đặt mục đầu tiên là mục được chọn
            var model = await _modelsServices.GetAllModels();
            foreach (var modelItem in model)
            {
                cboModel.Items.Add(modelItem.modelsname);
            }
        }

        private async void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
                serialPort.Open();
            var model = await _modelsServices.GetAllModels();

            string selectedModelName = cboModel.SelectedItem.ToString();
            if (selectedModelName != "Mời bạn chọn")
            {
                foreach (var models in model)
                {
                    if (models.modelsname == selectedModelName)
                    {
                        MessageBox.Show("OK");
                        serialPort.WriteLine("So khay: " + models.traycount + "Do day" + models.traythicknessmm);

                        return;
                    }
                }
                //MessageBox.Show("Không tìm thấy đối tượng có tên: " + selectedModelName);
            }



        }
    }
}