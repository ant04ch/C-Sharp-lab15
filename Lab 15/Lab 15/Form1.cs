using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Lab_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Result.Text = "";
            label9.Text = "";
            label8.Text = "";
            label7.Text = "";
            label12.Text = "";
            label14.Text = "";
            textBox1.Visible = false;
            button1.Visible = false;
            butOK5.Visible = false;
            textBox3.Visible = false;
            label15.Text = "Введіть число N:";
            label16.Visible = false;
            label17.Visible = false;
            label17.Text = "";
            textBox2.MaxLength = 4;
            textBox1.MaxLength = 6;
            txtbook.MaxLength = 6;
            txtA.MaxLength = 3;
            txtB.MaxLength = 3;
            txtC.MaxLength = 3;
            txtX.MaxLength = 3;
            txtY.MaxLength = 3;
            txtN.MaxLength = 2;
            label20.Visible = false;

        } //ФОРМА
        //task 1
        private void butOK_Click(object sender, EventArgs e) // Обрахунок, та виведення відповіді
        {
            if ((txtX.Text == "") || (txtY.Text == ""))
            {
                Result.Text = "Помилка, заповніть всі поля";
            }
            else
            {
                double x = Convert.ToDouble(txtX.Text);
                double y = Convert.ToDouble(txtY.Text);
                double result = (3 + Math.Exp(y - 1)) / (1 + x * x * Math.Abs(y - Math.Tan(x)));
                double okrresult = Math.Round(result, 4);
                Result.Text = okrresult.ToString();
            }
        }

        private void txtY_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtY.Text.IndexOf(',') != -1)
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
                    txtY.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        } // Захист для поля

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtX.Text.IndexOf(',') != -1)
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
                    txtX.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля
        //task 2
        private void butOK2_Click(object sender, EventArgs e)
        {
            if (((txtA.Text == "") || (txtB.Text == "") || (txtB.Text == "")))
            {
                label7.Text = "Помилка!";
            }
            else
            {
                double a = Convert.ToDouble(txtA.Text); // a
                double b = Convert.ToDouble(txtB.Text); // b
                double c = Convert.ToDouble(txtC.Text); // с
                                                        // знаходимо кути трикутника в радіанах
                double A = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
                double B = Math.Acos((a * a + c * c - b * b) / (2 * a * c));
                double C = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
                label7.Text = Math.Round(A, 4) + " rad".ToString();
                label8.Text = Math.Round(B, 4) + " rad".ToString();
                label9.Text = Math.Round(C, 4) + " rad".ToString();
            }
        }//Кнопка

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (((txtA.Text == "") || (txtB.Text == "") || (txtB.Text == "")))
            {
                label7.Text = "Помилка!";
            }
            else
            {
                double a = Convert.ToDouble(txtA.Text); // a
                double b = Convert.ToDouble(txtB.Text); // b
                double c = Convert.ToDouble(txtC.Text); // с
                double A = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
                double B = Math.Acos((a * a + c * c - b * b) / (2 * a * c));
                double C = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
                // переводимо кути в градуси
                double A_degrees = A * 180 / Math.PI;
                double B_degrees = B * 180 / Math.PI;
                double C_degrees = C * 180 / Math.PI;
                label7.Text = Math.Round(A_degrees, 4) + "°".ToString();
                label8.Text = Math.Round(B_degrees, 4) + "°".ToString();
                label9.Text = Math.Round(C_degrees, 4) + "°".ToString();
            }
        }//
        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtB.Text.IndexOf(',') != -1)
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
                    txtB.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtC.Text.IndexOf(',') != -1)
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
                    txtC.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtA.Text.IndexOf(',') != -1)
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
                    txtA.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля
        //task 3

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    txtA.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void butOK3_Click(object sender, EventArgs e)
        {
            if (txtN.Text == "")
            {
                label12.Text = "Помилка!";
            }
            else
            {
                int N = Convert.ToInt32(txtN.Text);
                bool perevirka = N >= 10 && N <= 99 && N % 2 == 0;

                if (perevirka)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
                label12.Text = perevirka.ToString();
            }
        }//Кнопка

        // task 4
        private void txtbook_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtY.Text.IndexOf(',') != -1)
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
                    txtY.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void butOK4_Click(object sender, EventArgs e)
        {
                double book = Convert.ToDouble(txtbook.Text);
                label14.Text = "Ціна: " + book + "грн".ToString();
                label13.Text = "Будь ласка," + '\n' + "сплатіть за товар:".ToString();
                butOK4.Visible = false;
                txtbook.Visible = false;
                textBox1.Visible = true;
                button1.Visible = true;
                label14.Visible = true;
        }//Кнопка

        private void button1_Click(object sender, EventArgs e)
        {
                double b = Double.Parse(txtbook.Text); // вартість книжок
                double o = Double.Parse(textBox1.Text); // ваша сума
                if (b == o)
                {
                    label13.Text = "Дякуємо за покупку! " + '\n' + "   Приходьте ще!";
                    button1.Visible = false;
                    butOK5.Visible = true;
                    textBox1.Visible = false;
                    txtbook.Visible = false;
                    label14.Visible = false;
                    textBox3.Visible = false;
                }
                else if (b > o)
                {
                    label13.Text = "Вибачте! " + '\n' + "На вашому рахунку " + '\n' + "недостатньо коштів!";
                    textBox3.Visible = true;

                }
                else
                {
                    label13.Text = "Решта: " + '\n' + (b - o) + '\n' + "   Дякуємо за покупку!";
                    button1.Visible = false;
                    butOK5.Visible = true;
                    textBox1.Visible = false;
                    txtbook.Visible = false;
                    label14.Visible = false;
                    textBox3.Visible = false;
                }
        }//Кнопка

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
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
                if (txtY.Text.IndexOf(',') != -1)
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
                    txtY.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void butOK5_Click(object sender, EventArgs e)
        {
                butOK5.Visible = false;
                label13.Text = "Привіт!" + '\n' + "Вкажіть вартість книг:";
                butOK4.Visible = true;
                txtbook.Visible = true;
                textBox1.Visible = false;
                button1.Visible = false;
                textBox1.Text = "";
                txtbook.Text = "";
        }//Кнопка

        private void textBox3_Click(object sender, EventArgs e)
        {
           
                butOK5.Visible = false;
                label13.Text = "Привіт!" + '\n' + "Вкажіть вартість книг:";
                butOK4.Visible = true;
                txtbook.Visible = true;
                textBox1.Visible = false;
                button1.Visible = false;
                textBox3.Visible = false;
                label14.Visible = false;
                textBox1.Text = "";
                txtbook.Text = "";
        }//
        //task 5
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    txtA.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == ""))
            {
                label16.Text = "Помилка!";
            }
            else
            {
                label17.Text = "";
                bool IsPerfect(int doskonal)
                {
                    int sum = 0;
                    for (int i = 1; i < doskonal; i++)
                    {
                        if (doskonal % i == 0)
                        {
                            sum += i;
                        }
                    }
                    return sum == doskonal;
                }
                int n = Convert.ToInt32(textBox2.Text);
                label16.Visible = true;
                label17.Visible = true;
                label16.Text = "Досконалі числа, менші за " + n + ": ";
                for (int i = 2; i < n; i++)
                {
                    if (IsPerfect(i))
                    {
                        label17.Text += i.ToString() + ";" + '\n';
                        // добавляем новий текст
                    }
                }
            }
        }//Кнопка

        //task 6
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if ((e.KeyChar == '.') || (e.KeyChar == ' '))
            {
                // крапку замінемо проб
                e.KeyChar = ' ';
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox4.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    txtY.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label20.Visible = true;
            if ((textBox4.Text == "") || (textBox5.Text == ""))
            {
                label20.Location = new Point(100, 150);
                label20.Text = "Помилка, заповніть поля!";
            }
            else
            {
                string input = textBox4.Text.Trim();
                input = Regex.Replace(input, @"\s+", " ");
                int[] arr = input.Split(' ').Select(int.Parse).ToArray();

                // Получить цифру k из textBox3
                int k = int.Parse(textBox5.Text);

                // Создать новый массив, содержащий элементы, заканчивающиеся на k
                List<int> result = new List<int>();
                foreach (int num in arr)
                {
                    if (num % 10 == k)
                    {
                        result.Add(num);
                    }
                }

                // Отобразить результат в label20
                label20.Text = string.Join(" ", result);
            }
        }
        //task7

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                label21.Text = "Помилка!";
                label22.Text = "Помилка!";
            }
            else
            {
                string input = textBox6.Text;

                // Розбиваємо рядок на масив слів
                string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Знаходимо найдовше та найкоротше слово
                string shortestWord = words[0];
                string longestWord = words[0];
                foreach (string word in words)
                {
                    if (word.Length < shortestWord.Length)
                    {
                        shortestWord = word;
                    }
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
                label21.Text = $"Найкоротше слово: {shortestWord}, його довжина: {shortestWord.Length}.";
                label22.Text = $"Найдовше слово: {longestWord}, його довжина: {longestWord.Length}.";
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ' '))
            {
                // крапку замінемо проб
                e.KeyChar = ' ';
                return;
            }
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }       
