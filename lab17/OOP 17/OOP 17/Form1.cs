using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OOP_17
{
    public partial class Form1 : Form
    {
        private Triangle currentTriangle;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Площа:";
            label2.Text = "Периметр:";
            radioButton1.Text = "Прямокутний трикутник";
            radioButton2.Text = "Рівнобедренний трикутник";
            radioButton3.Text = "Рівносторонній трикутник";
            button1.Text = "OK";
            button2.Text = "Очистити";
            label3.Text = "Сторона a:";
            label4.Text = "Сторона b:";
            label5.Text = "Кут між ними:";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Отримання даних з текстових полів введення
            double side1, side2, angle;

            // Перевірка правильності введення даних
            if (!double.TryParse(textBox1.Text, out side1) ||
                !double.TryParse(textBox2.Text, out side2) ||
                !double.TryParse(textBox3.Text, out angle))
            {
                // Якщо введені дані неправильно, припиняємо виконання функції
                return;
            }

            // Перевірка вибраного типу трикутника та створення відповідного об'єкту
            if (radioButton1.Checked)
            {
                currentTriangle = new RightTriangle(side1, side2); // Прямокутний трикутник
            }
            else if (radioButton2.Checked)
            {
                currentTriangle = new IsoscelesTriangle(side1, angle);  // Рівнобедрений трикутник

            }
            else if (radioButton3.Checked)
            {
                currentTriangle = new EquilateralTriangle(side1); // Рівносторонній трикутник
            }
            else
            {
                // Якщо тип трикутника не вибраний, припиняємо виконання функції
                return;
            }

            // Обчислення площі та периметру трикутника
            double area = currentTriangle.Area();
            double perimeter = currentTriangle.Perimeter();

            // Виведення результатів на форму
            label1.Text = $"Площа: {area:F2}";
            label2.Text = $"Периметр: {perimeter:F2}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            label1.Text = "Площа:";
            label2.Text = "Периметр:";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox3.Text = "0";
                textBox2.Clear();
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton2.Checked == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = true;
                textBox2.Text = "0";
                textBox1.Clear();
                textBox3.Clear();
            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton3.Checked == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox3.Text = "0";
                textBox2.Text = "0";
                textBox1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox1.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox2.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox3.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox3.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
    }
}