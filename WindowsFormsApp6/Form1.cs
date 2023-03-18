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
        Rectangle rectangle;
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        bool flag = true;
        string name;

        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.Black, 1);
            Init.bitmap = bitmap;
            Init.pen = pen;
            Init.pictureBox1 = pictureBox1;
            pictureBox1.BackColor = Color.LightSteelBlue;

        }
        private bool IsNotOperation(char item)
        {
            if (!(item == 'R' || item == 'M' || item == 'D' || item == ',' || item == '(' || item == ')'))
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

                    else if (textBoxInputString.Text[i] == 'R')
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
                    }
                }



            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

                








               











               
            
        
    
   


















