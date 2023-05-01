using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Calc_button_Click(object sender, EventArgs e)
        {
            string x = richTextBox1.Text;
            if (x != "" && !double.TryParse(x, out double res))
                MessageBox.Show("Значение X должно содержать только 1 число!\nДля ввода дробного используйте запятую", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            string expression = richTextBox2.Text.Replace("X", x);
            try
            {
                richTextBox3.Text = Solve_brackets(expression);
            }
            catch
            {
                MessageBox.Show("Неправильно введено выражение!\nДля ввода дробного используйте запятую", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        string Solve_brackets(string str)
        {
            if (str[0] == 42 || str[0] == 43 || str[0] == 47 || str[0] == 94
                || str[str.Length - 1] == 42 || str[str.Length - 1] == 43 || str[str.Length - 1] == 45 || str[str.Length - 1] == 47 || str[str.Length - 1] == 94) // символы   * + - / ^        (в начале может быть знак -)
            {
                throw new InvalidOperationException();
            }

        start1:
            bool brackets = false;
            int br_counter = 0;

            int left_i = 0, right_i = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    brackets = true;
                    br_counter++;

                    if (br_counter == 1)
                        left_i = i;
                }
                else if (str[i] == ')')
                {
                    if (brackets)
                    {
                        br_counter--;
                        if (br_counter == 0)
                        {
                            right_i = i;
                            break;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }




            if (brackets)
            {
                if (!Check_Right(str, right_i))
                {
                    throw new InvalidOperationException();
                }

                if (Check_Left(str, left_i))
                {
                    str = Replace_str(str, left_i, right_i, Solve_brackets(str.Substring(left_i + 1, right_i - left_i - 1))).Replace("--", "+");
                    if (str[0] == '+')
                        str = str.Substring(1);
                }
                else
                {
                    left_i -= 3;
                    if (str[left_i] == 's' && str[left_i + 1] == 'i' && str[left_i + 2] == 'n' && left_i >= 0 && Check_Left(str, left_i))
                    {
                        str = Replace_str(str, left_i, right_i, Math.Sin(Convert.ToDouble(Solve_brackets(str.Substring(left_i + 4, right_i - left_i - 4)))).ToString()).Replace("--", "+");
                        if (str[0] == '+')
                            str = str.Substring(1);
                    }
                    else if (str[left_i] == 'c' && str[left_i + 1] == 'o' && str[left_i + 2] == 's' && left_i >= 0 && Check_Left(str, left_i))
                    {
                        str = Replace_str(str, left_i, right_i, Math.Cos(Convert.ToDouble(Solve_brackets(str.Substring(left_i + 4, right_i - left_i - 4)))).ToString()).Replace("--", "+");
                        if (str[0] == '+')
                            str = str.Substring(1);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }

                goto start1;
            }



            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9' && str[i] != ',' && str[i] != '^' && str[i] != '*'
                    && str[i] != '/' && str[i] != '+' && str[i] != '-')
                    throw new InvalidOperationException();
            }
			
			
			
			
			str = str.Replace("--", "+");
			if (str[0] == '+')
				str = str.Substring(1);
			
        start2:
            left_i = 0; right_i = 0;
            int left_i2 = 0, right_i2 = 0;


            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '^')
                {
                    right_i = i - 1;
                    left_i = right_i;
                    while (left_i >= 0 && (str[left_i] == '0' || str[left_i] == '1' || str[left_i] == '2' || str[left_i] == '3' || str[left_i] == '4' || str[left_i] == '5' || str[left_i] == '6' || str[left_i] == '7'
                        || str[left_i] == '8' || str[left_i] == '9' || str[left_i] == ','))
                    {
                        left_i--;
                    }

                    if (left_i < 0 || str[left_i] != '-' || !Check_Left(str, left_i))
                        left_i++;

                    


                    left_i2 = i + 1;
                    right_i2 = left_i2;
                    while (right_i2 < str.Length && (str[right_i2] == '0' || str[right_i2] == '1' || str[right_i2] == '2' || str[right_i2] == '3' || str[right_i2] == '4' || str[right_i2] == '5' || str[right_i2] == '6' || str[right_i2] == '7'
                        || str[right_i2] == '8' || str[right_i2] == '9' || str[right_i2] == ',' || (str[right_i2] == '-' && right_i2 == left_i2)))
                    {
                        right_i2++;
                    }
                    right_i2--;



                    str = Replace_str(str, left_i, right_i2, Calc(Convert.ToDouble(str.Substring(left_i, right_i - left_i + 1)), Convert.ToDouble(str.Substring(left_i2, right_i2 - left_i2 + 1)), str[i])).Replace("--", "+");
                    if (str[0] == '+')
                        str = str.Substring(1);

                    goto start2;
                }
            }

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '*' || str[i] == '/')
                {
                    right_i = i - 1;
                    left_i = right_i;
                    while (left_i >= 0 && (str[left_i] == '0' || str[left_i] == '1' || str[left_i] == '2' || str[left_i] == '3' || str[left_i] == '4' || str[left_i] == '5' || str[left_i] == '6' || str[left_i] == '7'
                        || str[left_i] == '8' || str[left_i] == '9' || str[left_i] == ','))
                    {
                        left_i--;
                    }

                    if (left_i < 0 || str[left_i] != '-' || !Check_Left(str, left_i))
                        left_i++;




                    left_i2 = i + 1;
                    right_i2 = left_i2;
                    while (right_i2 < str.Length && (str[right_i2] == '0' || str[right_i2] == '1' || str[right_i2] == '2' || str[right_i2] == '3' || str[right_i2] == '4' || str[right_i2] == '5' || str[right_i2] == '6' || str[right_i2] == '7'
                        || str[right_i2] == '8' || str[right_i2] == '9' || str[right_i2] == ',' || (str[right_i2] == '-' && right_i2 == left_i2)))
                    {
                        right_i2++;
                    }
                    right_i2--;



                    str = Replace_str(str, left_i, right_i2, Calc(Convert.ToDouble(str.Substring(left_i, right_i - left_i + 1)), Convert.ToDouble(str.Substring(left_i2, right_i2 - left_i2 + 1)), str[i])).Replace("--", "+");
                    if (str[0] == '+')
                        str = str.Substring(1);


                    goto start2;
                }
            }

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '+')
                {
                    right_i = i - 1;
                    left_i = 0;


                    left_i2 = i + 1;
                    right_i2 = left_i2;
                    while (right_i2 < str.Length && (str[right_i2] == '0' || str[right_i2] == '1' || str[right_i2] == '2' || str[right_i2] == '3' || str[right_i2] == '4' || str[right_i2] == '5' || str[right_i2] == '6' || str[right_i2] == '7'
                        || str[right_i2] == '8' || str[right_i2] == '9' || str[right_i2] == ',' || (str[right_i2] == '-' && right_i2 == left_i2)))
                    {
                        right_i2++;
                    }
                    right_i2--;
					
					
					str = Replace_str(str, left_i, right_i2, Calc(Convert.ToDouble(str.Substring(left_i, right_i - left_i + 1)), Convert.ToDouble(str.Substring(left_i2, right_i2 - left_i2 + 1)), str[i]));

                    goto start2;
                }
				
				if (str[i] == '-')
                {
                    right_i = i - 1;
                    left_i = 0;


                    left_i2 = i + 1;
                    right_i2 = left_i2;
                    while (right_i2 < str.Length && (str[right_i2] == '0' || str[right_i2] == '1' || str[right_i2] == '2' || str[right_i2] == '3' || str[right_i2] == '4' || str[right_i2] == '5' || str[right_i2] == '6' || str[right_i2] == '7'
                        || str[right_i2] == '8' || str[right_i2] == '9' || str[right_i2] == ',' || (str[right_i2] == '-' && right_i2 == left_i2)))
                    {
                        right_i2++;
                    }
                    right_i2--;
					
					
					str = Replace_str(str, left_i, right_i2, Calc(Convert.ToDouble(str.Substring(left_i, right_i - left_i + 1)), Convert.ToDouble(str.Substring(left_i2, right_i2 - left_i2 + 1)), str[i]));

                    goto start2;
                }
            }


            return str;
        }


        bool Check_Left(string str, int i) =>
            i == 0 || str[i - 1] == 40 || str[i - 1] == 42 || str[i - 1] == 43 || str[i - 1] == 45 || str[i - 1] == 47 || str[i - 1] == 94; // true, если это первый символ или слева один из следующих: ( * + - / ^

        bool Check_Right(string str, int i) =>
            i == str.Length-1 || str[i + 1] == 41 || str[i + 1] == 42 || str[i + 1] == 43 || str[i + 1] == 45 || str[i + 1] == 47 || str[i + 1] == 94; // true, если это последний символ или справа один из следующих: ) * + - / ^

        string Replace_str(string str, int left_i, int right_i, string new_str) =>
            str.Substring(0, left_i) + new_str + str.Substring(right_i + 1); //заменить все, что между left_i и right_i в str (включая left_i и right_i) на new_str


        string Calc(double left, double right, char symb)
        {
            switch (symb)
            {
                case '^': return Math.Pow(left, right).ToString();
                case '*': return (left * right).ToString();
                case '/': return (left*1.0 / right).ToString();
                case '+': return (left + right).ToString();
                case '-': return (left - right).ToString();

                default: throw new InvalidOperationException();
            }
        }
    }
}
