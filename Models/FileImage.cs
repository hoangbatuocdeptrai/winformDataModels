using Model;
using Models.Entity;
using Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Models
{
    public partial class FileImage : Form
    {
        private readonly IModelsService _modelsServices;
        private readonly IFileImageService _fileImage;
        public FileImage(IModelsService modelsServices, IFileImageService fileImage)
        {
            InitializeComponent();
            _modelsServices = modelsServices;
            _fileImage = fileImage;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex != -1)
            //{
            //    string[] imgFile = Directory.GetFiles(projectPathImage, "*.*", SearchOption.AllDirectories);
            //    List<Entity.Path> files = new List<Entity.Path>();
            //    for (int i = 0; i < imgFile.Length; i++)
            //    {
            //        files.Add(imgFile[i]);
            //    }

            //    //string selectedFileName = listBox1.SelectedItem.ToString();
            //    //string fullPath = Path.Combine(item, selectedFileName);
            //    //Path.Combine(item, selectedFileName);


            //    string selectedFileName = listBox1.SelectedItem.ToString();
            //    string fullPath = Path.Combine(files.ToString(), selectedFileName);
            //    string fileName = Path.GetFileName(fullPath);
            //    if (File.Exists(fileName))
            //    {
            //        pictureBox1.ImageLocation = fileName;
            //    }
            //    else
            //    {
            //        MessageBox.Show("không tìm thấy tệp ảnh nào!");
            //    }


            //}
        }

        string projectPathImage = @"C:\Users\ASUS-VivoBook\source\repos\Models\Models\Data\";
        private async void btnError_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(projectPathImage))
            {

                string[] imgExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };
                string[] imgFile = Directory.GetFiles(projectPathImage, "*.*", SearchOption.AllDirectories);

                //var data =  PostgresHelper.GetAll<Modelss>();
                var data = await _modelsServices.GetAllModels();
                foreach (string file in imgFile)
                {
                    string fileName = Path.GetFileName(file);
                    if (!listBox1.ToString().Contains(fileName))
                    {
                        string[] fileNameParts = fileName.Split('_');
                        string modelName = fileNameParts[0];
                        string barCode = fileNameParts[1];

                        listBox1.Items.Add(fileName);

                        var detailModels = new DetailModels();
                        //var model = data.FirstOrDefault(x=>x.modelsname == modelName);
                        var model = await _modelsServices.GetModelssByName(modelName);
                        if (model != null)
                        {
                            detailModels.modelid = model.id;
                        }
                        detailModels.barcode = barCode;
                        detailModels.pathimage = file;
                        if (imgFile.Contains("Ok"))
                        {
                            detailModels.status = 1;
                        }
                        else
                        {
                            detailModels.status = 2;
                        }
                        detailModels.created_at = DateTime.Now;

                        //var abc = PostgresHelper.GetAll<DetailModels>().Where(x => x.barcode == detailModels.barcode);
                        var abc = await _fileImage.CheckName(detailModels.barcode);
                        if (abc == true)
                        {
                            MessageBox.Show("Loi!!");
                            return;

                        }
                        else
                        {
                            //PostgresHelper.Insert(detailModels);
                            await _fileImage.CreateDetailModels(detailModels);
                        }
                        //}
                    }
                }
            }
            else
            {
                MessageBox.Show("Thuc muc khong ton tai!");
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var abc = txtBox1.Text.Trim();
            var s = await _fileImage.GetImageByBarcode(abc);
            string[] imgFile = Directory.GetFiles(projectPathImage, "*.*", SearchOption.AllDirectories);
            //foreach (var file in imgFile)
            //{
            string fileName = Path.GetFileName(s.pathimage);
                string[] fileNameParts = fileName.Split('_');
            //string modelName = fileNameParts[0];
            string fullPath = Path.Combine(s.pathimage);
            //    string fileName = Path.GetFileName(fullPath);
            string barCode = fileNameParts[1];

            //if (File.Exists(fullPath))
            //{
                if (s.pathimage.Contains(barCode))
                    {
                        pictureBox1.ImageLocation = fullPath;
                    }
            //}
            //}
        }
    }
}
