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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        My_Figure my_figure;
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        bool flag = true;
        string name;
        ShapeContainer shapecontainer;

        public Form1()
        {
            InitializeComponent();
            shapecontainer = new ShapeContainer();
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.Black, 1);
            Init.bitmap = bitmap;
            Init.pen = pen;
            Init.pictureBox1 = pictureBox1;
            pictureBox1.BackColor = Color.LightSteelBlue;

        }
        private bool IsNotOperation(char item)
        {
            if (!(item == 'O' || item == 'M' || item == 'D' || item == ',' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ConvertCharToInt(object item)
        {
            return Convert.ToInt32(Convert.ToString(item));
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operators = new Stack<Operator>();
                operands = new Stack<Operand>();
                for (int i = 0; i < textBoxInputString.Text.Length; i++)
                {
                    if (IsNotOperation(textBoxInputString.Text[i]))
                    {
                        if (!(Char.IsDigit(textBoxInputString.Text[i])))
                        {
                            this.operands.Push(new Operand(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (Char.IsDigit(textBoxInputString.Text[i]))
                        {
                            if (flag)
                            {
                                this.operands.Push(new Operand(textBoxInputString.Text[i]));
                            }
                            else
                            {
                                if (!(Char.IsDigit(textBoxInputString.Text[i - 1])))
                                {
                                    this.operands.Push(new Operand(ConvertCharToInt(textBoxInputString.Text[i])));
                                    continue;
                                }
                                this.operands.Push(new Operand(ConvertCharToInt(this.operands.Pop().value) * 10 + ConvertCharToInt(textBoxInputString.Text[i])));
                            }
                            flag = false;
                            continue;
                        }
                    }
                    else if (textBoxInputString.Text[i] == ',')
                    {
                        flag = true;
                        continue;
                    }

                    else if (textBoxInputString.Text[i] == 'O')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'M')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'D')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == '(')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == ')')
                    {
                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }
                try
                {
                    this.SelectingPerformingOperation(operators.Peek());
                }

                catch
                {
                    MessageBox.Show("Проверьте водимые данные!");
                    listBox1.Text += "Ошибка!\n";
                }
            }
        }
        private void SelectingPerformingOperation(Operator operat)
        {
            if (textBoxInputString.Text[0] == 'O')
            {
                int h = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                int w = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                int y = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                int x = Convert.ToInt32(Convert.ToString(operands.Pop().value));

                string name = Convert.ToString(operands.Pop().value);
                if (x + w < Init.pictureBox1.Width && y + w < Init.pictureBox1.Height)
                {

                    my_figure = new My_Figure(name,x,y,w,h);
                    operat = new Operator(my_figure.Draw, 'O');
                    ShapeContainer.AddFigure(my_figure);
                    listBox1.Items.Add  ("Моя фигура" + my_figure.name + " Создалась\n");
                    operat.operatorMethod();

                }

                else
                {

                    MessageBox.Show("Выход за границы!");
                    listBox1.Text += "Выход за границы!\n";
                }

            }
            if (textBoxInputString.Text[0] == 'M')
            {
                try
                {
                    int y = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int x = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    name = Convert.ToString(operands.Pop().value);
                    string movename = "Моя фигура" + name + " Переместилась\n";
                    if (ShapeContainer.FindFigure(name) == null)
                    {
                        MessageBox.Show("Проверьте ввводимые данные!");
                        listBox1.Text += "Проверьте ввводимые данные!\n";

                    }
                    else
                    {
                        ShapeContainer.FindFigure(name).MoveTo(x, y);

                        listBox1.Text += movename + "\n";
                    }
                }
                catch
                {
                    MessageBox.Show("Должнобыть ровно 3 параметра!");
                    listBox1.Text += "Ошибка!\n";
                }
            }
            if (textBoxInputString.Text[0] == 'D')
            {
                try
                {
                 name = Convert.ToString(operands.Pop().value);
                string deletename = "Моя фигурала" + name + "Удалилась";
                if (ShapeContainer.FindFigure(name) == null)
                {
                    MessageBox.Show("Проверьте вводимые данные!");
                    listBox1.Text += " Ошибка\n";
                }
                else
                {
                                      ShapeContainer.FindFigure(name).DeleteF(ShapeContainer.FindFigure(name), true);
                    listBox1.Text += ShapeContainer.FindFigure(name) + deletename;
                }
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка,проверьте вводимые символы!");
                    listBox1.Text += "Ошибка!\n";
                }





            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

                








               











               
            
        
    
   


















