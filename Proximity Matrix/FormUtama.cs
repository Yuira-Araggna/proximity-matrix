using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        List<Person> listOfData = new List<Person>();
        DataTable table;

        public FormUtama()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (listOfData.Count != 0)
            {
                listOfData.Clear();
            }
            open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Comma Separated|*.csv"
            };

            open.ShowDialog();

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
                            listOfData.Add(person);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File Kosong", "Error");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Terjadi sebuah kesalahan. Pesan Error: " + error, "Error");
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCSV.DataSource = null;
                if (open.FileName != "")
                {
                    if (listOfData.Count > 0)
                    {
                        dataGridViewCSV.DataSource = listOfData;
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

        private void FormUtama_Load(object sender, EventArgs e)
        {

        }

        private void buttonProximity_Click(object sender, EventArgs e)
        {
            if (open.FileName != "")
            {
                table = new DataTable();
                double[,] test = ProximityMatrix.mixedProxDist(listOfData);
                    
                  
                for (int j = 0; j < test.GetLength(0); j++)
                {

                    table.Columns.Add();
                }
                    
                for (int k = 0; k < test.GetLength(1); k++)
                {
                    DataRow row = table.NewRow();

                    // iterate over all columns to fill the row
                    for (int i = 0; i < test.GetLength(0); i++)
                    {
                        row[i] = Math.Round( test[i, k],3);
                    } 
                    table.Rows.Add(row);   
                }
                dataGridViewCSV.DataSource = table;

            }
            else
            {
                MessageBox.Show("File Kosong", "Error");
            }
        }

        private void buttonBestSplit_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = BestSplit.FindBestSplit(listOfData).ToString();
        }

        private void buttonSimpanHasil_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save List";
                saveFileDialog.FileName = "Hasil.txt";
                saveFileDialog.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.DefaultExt = ".txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string line = "";
                    line += "\n";
                    foreach (DataColumn dc in table.Columns)
                    {
                        line += dc.ColumnName + "\t";
                    }
                    line += "\n";
                    foreach (DataRow dr in table.Rows)
                    {
                        foreach (DataColumn dc in table.Columns)
                        {
                            line +=  dr[dc].ToString() + "\t" ;
                        }
                        line += "\n";
                    }
                    FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(file, line );
                    file.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
