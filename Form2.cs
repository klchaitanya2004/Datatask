using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using DataDll;

namespace DataTask
{
    public partial class Form2 : Form
    {
        private Form1 _parentForm;
        private List<FormField> formFields;

        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string json = File.ReadAllText("config.json");
                var config = JsonConvert.DeserializeObject<Config>(json);
                formFields = config.FormFields;

                //int y = 20;
                //foreach (var field in formFields)
                //{
                //    Label lbl = new Label
                //    {
                //        Text = field.Label,
                //        Location = new System.Drawing.Point(20, y),
                //        AutoSize = true
                //    };

                //    TextBox txt = new TextBox
                //    {
                //        Name = field.Name,
                //        Location = new System.Drawing.Point(120, y),
                //        Width = 200
                //    };

                //    //this.Controls.Add(lbl);
                //    //this.Controls.Add(txt);
                //    y += 30;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form fields: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();

            foreach (var field in formFields)
            {
                var txtBox = this.Controls.Find(field.Name, true).FirstOrDefault() as TextBox;
                if (txtBox != null)
                {
                    values.Add(txtBox.Text);
                }
            }

            if (values.Count == 3)
            {
                _parentForm.AddDataToGrid(values[0], values[1], values[2]);
            }

            this.Hide();
            _parentForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentForm.Show();
        }
    }
}