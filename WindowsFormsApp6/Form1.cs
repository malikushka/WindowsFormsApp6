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
        public Form1()
        {
            InitializeComponent();



     public partial class Form1 : Form
        {
            Bitmap bitmap;
            Pen pen;
            int schet = 0;
            Ellipse ellipse;
            ShapeContainer shapeContainer;
            PointF[] pointFs;
            int count;

            bool schetTriangle = true;


            public Form1()
            {
                InitializeComponent();
                this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                this.pen = new Pen(Color.Black, 1);
                Init.bitmap = this.bitmap;
                Init.pen = this.pen;
                Init.pictureBox1 = pictureBox1;
                shapeContainer = new ShapeContainer();


            }
            private void button2_Click(object sender, EventArgs e)//рисуем элипс
            {

                if ((textBox1.Text != String.Empty) && (textBox2.Text != String.Empty) && (textBox3.Text != String.Empty) && (textBox4.Text != String.Empty))
                {
                    this.ellipse = new Ellipse(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                    if ((int.Parse(textBox3.Text) + int.Parse(textBox2.Text)) < 400 && (int.Parse(textBox4.Text) + int.Parse(textBox1.Text)) < 400 && int.Parse(textBox2.Text) < 400 && int.Parse(textBox1.Text) < 400)
                    {
                        ShapeContainer.AddFigure(this.ellipse);
                        this.ellipse.Draw();
                        listBox1.Items.Add(this.ellipse);
                    }
                    else
                    {
                        MessageBox.Show("Выход за пределы полотна! Пожалуйста измените значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            private void button11_Click(object sender, EventArgs e)//рисуем круг
            {

                if ((textBox18.Text != String.Empty) && (textBox21.Text != String.Empty) && (textBox26.Text != String.Empty))
                {
                    Circle circle = new Circle(int.Parse(textBox18.Text), int.Parse(textBox21.Text), int.Parse(textBox26.Text));
                    if ((int.Parse(textBox18.Text) + int.Parse(textBox26.Text) * 2) < 400 && (int.Parse(textBox21.Text) + int.Parse(textBox26.Text) * 2) < 400 && int.Parse(textBox26.Text) * 2 < 400)
                    {
                        ShapeContainer.AddFigure(circle);
                        circle.Draw();
                        listBox1.Items.Add(circle);
                    }
                    else
                    {
                        MessageBox.Show("Выход за пределы полотна! Пожалуйста измените значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void button3_Click(object sender, EventArgs e)//рисуем прямоугольник
            {
                if ((textBox7.Text != String.Empty) && (textBox8.Text != String.Empty) && (textBox6.Text != String.Empty) && (textBox8.Text != String.Empty))
                {
                    Rectangle rectangle = new Rectangle(int.Parse(textBox7.Text), int.Parse(textBox8.Text), int.Parse(textBox6.Text), int.Parse(textBox5.Text));
                    if ((int.Parse(textBox7.Text) + int.Parse(textBox7.Text)) < 400 && (int.Parse(textBox8.Text) + int.Parse(textBox5.Text)) < 400 && int.Parse(textBox6.Text) < 400
                    && int.Parse(textBox5.Text) < 370)
                    {
                        ShapeContainer.AddFigure(rectangle);
                        rectangle.Draw();
                        listBox1.Items.Add(rectangle);




                    }
                    else
                    {
                        MessageBox.Show("Выход за пределы полотна! Пожалуйста измените значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            private void button17_Click(object sender, EventArgs e)//Создаем квадрат
            {
                if ((textBox20.Text != String.Empty) && (textBox33.Text != String.Empty) && (textBox34.Text != String.Empty))
                {
                    Square square = new Square(int.Parse(textBox20.Text), int.Parse(textBox33.Text), int.Parse(textBox34.Text));
                    if ((int.Parse(textBox20.Text) + int.Parse(textBox34.Text)) < 400 && (int.Parse(textBox33.Text) + int.Parse(textBox34.Text)) < 400 && int.Parse(textBox34.Text) < 400)
                    {
                        ShapeContainer.AddFigure(square);
                        square.Draw();
                        listBox1.Items.Add(square);
                    }
                    else
                    {
                        MessageBox.Show("Выход за пределы полотна! Пожалуйста измените значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



            private void button14_Click(object sender, EventArgs e)//число точек
            {
                if ((textBox25.Text != String.Empty))
                {
                    count = Convert.ToInt32(textBox25.Text);
                    pointFs = new PointF[count];
                    textBox25.Enabled = false;
                    button14.Enabled = false;

                }






            }

            private void button15_Click(object sender, EventArgs e)//создаем полигон
            {
                if ((textBox23.Text != String.Empty) && (textBox24.Text != String.Empty))
                {
                    Polygon polygon = new Polygon(pointFs);
                    schet = 0;
                    textBox25.Enabled = true;
                    button14.Enabled = true;
                    if ((int.Parse(textBox23.Text) + int.Parse(textBox24.Text)) < 400 && int.Parse(textBox23.Text) < 400 && int.Parse(textBox24.Text) < 370)
                    {
                        ShapeContainer.AddFigure(polygon);
                        polygon.Draw();
                        listBox1.Items.Add(polygon);
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }



            }

            private void button23_Click(object sender, EventArgs e)//фиксация точек
            {
                if (schet < count)
                {
                    Polygon poligon = new Polygon(int.Parse(textBox23.Text), int.Parse(textBox24.Text));
                    if ((int.Parse(textBox23.Text) + int.Parse(textBox24.Text)) < 400 && int.Parse(textBox23.Text) < 400 && int.Parse(textBox24.Text) < 370)
                    {
                        pointFs[schet].X = int.Parse(textBox23.Text);
                        pointFs[schet].Y = int.Parse(textBox24.Text);
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    schet++;

                }
                else
                {
                    //textBox23.Enabled = false;
                    // textBox24.Enabled = false;



                }

            }



            private void button4_Click(object sender, EventArgs e)//создаем треугольник
            {
                if (schetTriangle == true)
                {
                    textBox25.Text = "3";
                    textBox25.Enabled = false;
                    count = 3;
                    pointFs = new PointF[count];
                    if ((textBox23.Text != String.Empty) && (textBox24.Text != String.Empty))
                    {
                        Triangle triangle = new Triangle(int.Parse(textBox23.Text), int.Parse(textBox24.Text));
                        if ((int.Parse(textBox23.Text) + int.Parse(textBox24.Text)) < 400 && int.Parse(textBox23.Text) < 400 && int.Parse(textBox24.Text) < 370)
                        {
                            pointFs[schet].X = int.Parse(textBox23.Text);
                            pointFs[schet].Y = int.Parse(textBox24.Text);


                        }
                        else
                        {
                            MessageBox.Show("Проверьте введенные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        schet++;
                        textBox23.Clear();
                        textBox24.Clear();

                    }
                    else
                    {
                        //textBox23.Enabled = false;
                        //textBox24.Enabled = false;
                        //button23.Enabled = false;



                    }
                }



            }
            My_Figure n;
            private void button1_Click(object sender, EventArgs e)
            {
                n = new My_Figure(int.Parse(textBox37.Text), int.Parse(textBox38.Text), int.Parse(textBox39.Text), int.Parse(textBox40.Text));
                ShapeContainer.AddFigure(n);
                n.Draw();
                listBox1.Items.Add(n);
            }
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
            }
            private void button7_Click(object sender, EventArgs e)//перемещение элипса
            {


                if (true)
                {
                    if (textBox12.Text != String.Empty && textBox15.Text != String.Empty)
                    {
                        //if (int.Parse(textBox12.Text) < 500 && int.Parse(textBox15.Text) > 500)
                        //{
                        Figure fig = (Figure)listBox1.SelectedItem;
                        fig.MoveTo(int.Parse(textBox12.Text), int.Parse(textBox15.Text));

                        //}


                    }
                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }




                }

            }

            private void button6_Click(object sender, EventArgs e)//удаление фигуры
            {

                if (true)
                {

                    Figure fig = (Figure)listBox1.SelectedItem;
                    fig.DeleteF(fig);
                    listBox1.Items.Remove(listBox1.SelectedItem);





                }

            }





            private void button13_Click(object sender, EventArgs e)//перемещение круга
            {



                if (true)
                {
                    if (textBox19.Text != String.Empty && textBox22.Text != String.Empty)
                    {

                        Figure fig = (Figure)listBox1.SelectedItem;
                        fig.MoveTo(int.Parse(textBox19.Text), int.Parse(textBox22.Text));
                    }

                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }







            }

            private void button12_Click(object sender, EventArgs e)//удаление фигуры
            {
                Figure fig = (Figure)listBox1.SelectedItem;
                fig.DeleteF(fig);
                listBox1.Items.Remove(listBox1.SelectedItem);

            }







            private void button8_Click(object sender, EventArgs e)//перемещение треугольника
            {

                if (true)
                {
                    if (textBox14.Text != String.Empty && textBox13.Text != String.Empty)
                    {

                        Figure fig = (Figure)listBox1.SelectedItem;
                        fig.MoveTo(int.Parse(textBox14.Text), int.Parse(textBox13.Text));


                    }
                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }




            private void button9_Click(object sender, EventArgs e)//удалить фигуру
            {

                Figure fig = (Figure)listBox1.SelectedItem;
                fig.DeleteF(fig);
                listBox1.Items.Remove(listBox1.SelectedItem);


            }

            private void button16_Click(object sender, EventArgs e)//перемещение квадрата
            {
                if (true)
                {
                    if (textBox35.Text != String.Empty && textBox36.Text != String.Empty)
                    {

                        Figure fig = (Figure)listBox1.SelectedItem;
                        fig.MoveTo(int.Parse(textBox35.Text), int.Parse(textBox36.Text));


                    }
                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            private void button18_Click(object sender, EventArgs e)//удалить фигуру
            {
                Figure fig = (Figure)listBox1.SelectedItem;
                fig.DeleteF(fig);
                listBox1.Items.Remove(listBox1.SelectedItem);


            }

            private void button19_Click(object sender, EventArgs e)//удалить мою фигуру
            {
                Figure fig = (Figure)listBox1.SelectedItem;
                fig.DeleteF(fig);
                listBox1.Items.Remove(listBox1.SelectedItem);

            }

            private void button20_Click(object sender, EventArgs e)//перемещение моей фигуры
            {
                if (true)
                {
                    if (textBox41.Text != String.Empty && textBox42.Text != String.Empty)
                    {

                        My_Figure n = (My_Figure)listBox1.SelectedItem;
                        n.MoveTo(int.Parse(textBox41.Text), int.Parse(textBox42.Text));


                    }
                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }

            private void button21_Click(object sender, EventArgs e)//перемещение полигона
            {
                if (true)
                {
                    if (textBox43.Text != String.Empty && textBox45.Text != String.Empty)
                    {
                        Figure fig = (Figure)listBox1.SelectedItem;
                        fig.MoveTo(int.Parse(textBox43.Text), int.Parse(textBox45.Text));




                    }
                    else
                    {
                        MessageBox.Show("Передвижение невозможно! Пожалуйста, измените коориднаты передвижения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }


            }

            private void button22_Click(object sender, EventArgs e)//удалить фигуру
            {
                Figure fig = (Figure)listBox1.SelectedItem;
                fig.DeleteF(fig);
                listBox1.Items.Remove(listBox1.SelectedItem);


            }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }
        }
    }


















}
    }
}
