using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Proximity_Matrix_LIB;

namespace Proximity_Matrix
{
    public partial class FormUtama : Form
    {
        OpenFileDialog open;
        public FormUtama()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            
            open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Comma Separated|*.csv"
            };

            open.ShowDialog();
        
           
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            try
            {

                if (open.FileName != "")
                {
                    using (TextFieldParser csvParser = new TextFieldParser(open.FileName))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        csvParser.ReadLine();



                        while (!csvParser.EndOfData)
                        {
                            string[] fields = csvParser.ReadFields();
                            Person person = new Person(fields[0], fields[1], int.Parse(fields[2]), fields[3]);
                            list.Add(person);
                        }


                    }

                    if (list.Count > 0)
                    {
                        dataGridViewCSV.DataSource = list;
                    }



                }
                else
                {
                    MessageBox.Show("File Kosong", "Error");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Tidak Bisa Menampilkan File. Pesan Error: " + error , "Error");
            }
            
           
        }
    }
}
