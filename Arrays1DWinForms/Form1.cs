using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrays1DWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                int n;
                if (int.TryParse(numericUpDownCount.Text, out n))
                {
                    try
                    {
                        dataGridViewTable.ColumnCount = n;
                        dataGridViewTable.RowCount = 1;
                        for (int i = 0; i < n; i++)
                        {
                            dataGridViewTable.Columns[i].HeaderText = i.ToString();
                            dataGridViewTable.Columns[i].Width = 45;
                        }
                        Random rand = new Random();
                        for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                            dataGridViewTable[i, 0].Value = Math.Round(rand.NextDouble() * (16.3 + 12.3) - 12.3, 1);
                       
                        dataGridViewTable.ClearSelection();

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка", "Неправильное количество элементов");
                    }
                }
                else
                    MessageBox.Show("Ошибка", "Неправильное количество элементов");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] array = new double[dataGridViewTable.ColumnCount];
            int totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = double.Parse(dataGridViewTable[i, 0].Value.ToString());
            }
            if (array.Length == 0)
            {
                MessageBox.Show("Ошибка", "Неправильное количество элементов");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < 0 && i % 2 == 0)
                    {
                        totalSum += i;
                    }
                }
                labelSum.Text = "Sum = " + totalSum.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] array = new double[dataGridViewTable.ColumnCount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = double.Parse(dataGridViewTable[i, 0].Value.ToString());
            }
            int first = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    first = i;
                    break;
                }
            }
            int second = 0;
            for (int i = first + 1; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    second = i;
                    break;
                }
            }
            dataGridViewSort.ColumnCount = array.Length;
            dataGridViewSort.RowCount = 1;
            double temp;

            // traverse 0 to array length 
            for (int i = first; i < second - 1; i++)

                // traverse i+1 to array length 

                    // compare array element with  
                    // all next element 
                    if (array[i] < array[i + 1])
                    {

                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
            for (int i = 0; i < array.Length; i++)
            {
                dataGridViewSort.Columns[i].HeaderText = i.ToString();
                dataGridViewSort.Columns[i].Width = 45;
            }

            for (int i = 0; i < array.Length; i++)
            {
                dataGridViewSort[i, 0].Value = array[i];
            }
        }
    }
}
