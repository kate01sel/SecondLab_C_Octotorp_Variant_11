using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
            
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            triangle = new Triangle();
            right_triangle = new Right_Triangle();
            if (String.IsNullOrWhiteSpace(firstSideText.Text) == false && String.IsNullOrWhiteSpace(SecondSideText.Text) == false
                && String.IsNullOrWhiteSpace(thirdSideText.Text) == false)
            {
                triangle.FirstSide = Convert.ToInt32(firstSideText.Text);
                triangle.SecondSide = Convert.ToInt32(SecondSideText.Text);
                triangle.ThirdSide = Convert.ToInt32(thirdSideText.Text);

                if (triangle.ExistsCheckTriangle() == true)
                {
                    infoBox.Text = "Triangle: \n" + triangle.PrintAngles() + '\n' + triangle.PrintPerimetr() + '\n' +
                        triangle.PrintSides() + '\n' + "Square: " + triangle.PrintSquare();
                    dataGridView1.Rows.Add(++ID, triangle.PrintSquare(), triangle.PrintPerimetr());
                }
                else
                {
                    // вот здесь я добавил очистку информационного поля, чтоб корректно выводилось сведенье о не существование 
                    // треугольника
                    infoBox.Clear();
                    Console.WriteLine("Triangle not exists");
                }
            }
            else
            {
                MessageBox.Show("Write correct numbers in triangle");
            }

            if(String.IsNullOrWhiteSpace(firstKatetText.Text) == false && String.IsNullOrWhiteSpace(secondKatetText.Text) == false
                && String.IsNullOrWhiteSpace(gipatenuzaText.Text) == false)
            {
                right_triangle.FirstKatet = Convert.ToInt32(firstKatetText.Text);
                right_triangle.SecondKatet = Convert.ToInt32(secondKatetText.Text);
                right_triangle.Gipatenuza = Convert.ToInt32(gipatenuzaText.Text);

                if (right_triangle.ExistsCheckRightTriangle() == true)
                {
                    infoBox2.Text = "Right triangle: \n" + right_triangle.PrintInfo_RightTriangle() + '\n' +
                        right_triangle.PrintDegreeInfo();

                    dataGridView2.Rows.Add(++ID_Second, right_triangle.FirstKatet, right_triangle.SecondKatet,
                        right_triangle.Gipatenuza);
                }
                else
                {
                    // здесь анологично первому замечанию
                    infoBox2.Clear();
                    Console.WriteLine("Right_triangle not exists");
                }
            }
            else
            {
                MessageBox.Show("Write correct numbers in right triangle");
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
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                //а здесь я просто указывал не ту таблицу, вот и была ошибка(надо было указать 2 таблицу для прямоугольного треугольника)
                if (maxGip < Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value))
                {
                    maxGip = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
                }
            }
            MessageBox.Show($"Max Gip = {maxGip.ToString()}\nMax Triangle Square = {max.ToString()}");
        }
    }
}

