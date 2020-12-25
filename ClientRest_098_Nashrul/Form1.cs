using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRest_098_Nashrul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonJumlah_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:1909/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            int length = data.Count();
            labelJumlah.Text = Convert.ToString(length);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxNIM.Text != "" &&
              textBoxNama.Text != "" &&
              textBoxProdi.Text != "" &&
              textBoxAngkatan.Text != "")
            {
                if (textBoxNIM.Text.Length <= 12 &&
                textBoxAngkatan.Text.Length <= 4 &&
                textBoxProdi.Text.Length <= 30 &&
                textBoxNama.Text.Length <= 20)
                {
                    try
                    {
                        Mahasiswa mhs = new Mahasiswa();
                        mhs.nim = textBoxNIM.Text;
                        mhs.nama = textBoxNama.Text;
                        mhs.prodi = textBoxProdi.Text;
                        mhs.angkatan = textBoxAngkatan.Text;

                        ClassData classData = new ClassData();
                        classData.updateDatabase(mhs);
                        MessageBox.Show("Data successfuly updated");

                        dataGridView1.DataSource = classData.getAllData();
                    }
                    catch
                    {
                        labelKeterangan.Text = "Server Error";
                    }
                }
                else
                {
                    MessageBox.Show("Please check your data");
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
        }
    }
}
