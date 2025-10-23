using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using DataDll;

namespace DataTask
{
    

    public partial class Form1 : Form
    {
        private Config config;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                string json = File.ReadAllText(@"config.json");
                config = JsonConvert.DeserializeObject<Config>(json);

                foreach (var col in config.DataGridColumns)
                {
                    dataGridView1.Columns.Add(col.Name, col.Header);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading config: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2(this);
            f.Show();
        }

        public void AddDataToGrid(string data1, string data2, string data3)
        {
            dataGridView1.Rows.Add(data1, data2, data3);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
    }
}