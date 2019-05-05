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

namespace SecondLab_C_Octotorp_Variant_11
{
    public partial class Form1 : Form
    {
        Triangle triangle;
        Right_Triangle right_triangle;
        int ID = 0;
        int ID_Second = 0;
        string pathToFile = String.Empty;

        public Form1()
        {
            InitializeComponent();
            var answer = MessageBox.Show("Do you want to open your data file ?", "Reader", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                if (binaryExtractor.ShowDialog() == DialogResult.OK)
                {
                    binaryExtractor.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                    pathToFile = binaryExtractor.FileName;
                    using (FileStream fs = new FileStream(pathToFile, FileMode.Open))
                    {
                        using (BinaryReader stream = new BinaryReader(fs))
                        {
                            try
                            {
                                if (new FileInfo(pathToFile).Length != 0)
                                {
                                    foreach (char item in stream.ReadChars(500))
                                    {
                                        casheBox.Text += item;
                                    }
                                }
                            }
                            catch (EndOfStreamException ex)
                            {
                                casheBox.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                fs.Close();
                                stream.Close();
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("You don't use cached data");
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
            {
            triangle = new Triangle();
            right_triangle = new Right_Triangle();

            if (String.IsNullOrWhiteSpace(firstSideText.Text) == false && String.IsNullOrWhiteSpace(SecondSideText.Text) == false
                && String.IsNullOrWhiteSpace(thirdSideText.Text) == false && String.IsNullOrWhiteSpace(firstKatetText.Text) == false && String.IsNullOrWhiteSpace(secondKatetText.Text) == false
                && String.IsNullOrWhiteSpace(gipatenuzaText.Text) == false)
            {
                triangle.FirstSide = Convert.ToInt32(firstSideText.Text);
                triangle.SecondSide = Convert.ToInt32(SecondSideText.Text);
                triangle.ThirdSide = Convert.ToInt32(thirdSideText.Text);

                right_triangle.FirstKatet = Convert.ToInt32(firstKatetText.Text);
                right_triangle.SecondKatet = Convert.ToInt32(secondKatetText.Text);
                right_triangle.Gipatenuza = Convert.ToInt32(gipatenuzaText.Text);
   
                if (triangle.ExistsCheckTriangle() == true && right_triangle.ExistsCheckRightTriangle() == true)
                {
                    infoBox.Text = "Triangle: \n" + triangle.PrintAngles() + '\n' + triangle.PrintPerimetr() + '\n' +
                        triangle.PrintSides() + '\n' + "Square: " + triangle.PrintSquare();

                    infoBox2.Text = "Right triangle: \n" + right_triangle.PrintInfo_RightTriangle() + '\n' +
    right_triangle.PrintDegreeInfo();

                    dataGridView1.Rows.Add(++ID, triangle.PrintSquare(), triangle.PrintPerimetr(),++ID_Second, right_triangle.FirstKatet, right_triangle.SecondKatet,
                        right_triangle.Gipatenuza);
                }
                else
                {
                    infoBox.Clear();
                    infoBox.Text = "Triangle not exist";
                    infoBox2.Clear();
                    infoBox2.Text = "Right_triangle not exists";
                }
            }
            else
            {
                MessageBox.Show("Write correct numbers in triangle and right_triangle");
            }

            firstSideText.Clear();
            SecondSideText.Clear();
            thirdSideText.Clear();

            firstKatetText.Clear();
            secondKatetText.Clear();
            gipatenuzaText.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {           
            int max = 0;
            int maxGip = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (max < Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value))
                {
                    max = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (maxGip < Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value))
                {
                    maxGip = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                }
            }
           
            MessageBox.Show($"Max Gip = {maxGip.ToString()}\nMax Triangle Square = {max.ToString()}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to cashe your information ?", "Cashe saver", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrWhiteSpace(infoBox.Text) == false && String.IsNullOrWhiteSpace(infoBox2.Text) == false)
                {
                    SaveInformationFromTwoGrid(pathToFile);
                }
                else
                {
                    MessageBox.Show("Something going wrong!");
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void SaveInformationFromTwoGrid(string path)
        {
            if (path != null && File.Exists(path) == true)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    writer.Write(infoBox.Text);
                    writer.Write("\n");
                    writer.Write(infoBox2.Text);
                    writer.Close();
                    MessageBox.Show("All information was wrote");
                }
            }
            else
            {
                MessageBox.Show("Path not exsist");
            }
        }       
    }
}