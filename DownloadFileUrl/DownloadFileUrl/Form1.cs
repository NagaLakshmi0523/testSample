using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadFileUrl
{
    public partial class Form1 : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            open.Filter = "Text Files(*.png)|*.png";     
            if(open.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text=Path.GetFileName(open.FileName);
                uploadFile(open.FileName);
            }
        }

        private void uploadFile(string fileName)
        {
            try
            {
                var client = new WebClient();

                var uri = new Uri("http://localhost:8080/download/index.php/");
                {
                    client.Headers.Add("fileName", System.IO.Path.GetFileName(fileName));
                    client.UploadFileAsync(uri, fileName);
                    MessageBox.Show("Upload file successfully!");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
