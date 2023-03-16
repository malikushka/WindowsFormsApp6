using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class My_Figure : Figure
    {
        public Ellipse c1;
        public Rectangle r1;
        public Polygon t1;



        public override void Draw()
        {
            this.c1.Draw();
            this.r1.Draw();
            this.t1.Draw();

            Init.pictureBox1.Image = Init.bitmap;
        }

        public My_Figure(int x, int y, int w, int h)
        {
            this.c1 = new Ellipse(x + w / 3, y, w / 3, h / 4);
            this.r1 = new Rectangle(x, y + h * 1 / 4, w, h / 6);
            int numPoints = 3;
            PointF[] pointFs = new PointF[numPoints];
            this.t1 = new Polygon(pointFs);
            t1.pointFs[0].X = x + w / 2;
            t1.pointFs[0].Y = y + h / 4;
            t1.pointFs[1].X = x + ((h / 3) + w / 3);
            t1.pointFs[1].Y = y + ((h / 2) + w / 2);
            t1.pointFs[2].X = x + w / 3;
            t1.pointFs[2].Y = y + h / 2 + w / 2;
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;

        }


        public override void MoveTo(int x, int y)
        {
            int numPoints = 3;
            PointF[] pointFs = new PointF[numPoints];
            bool flag = true;
            for (int i = 0; i < pointFs.Length; i++)
            {

                {

                    flag = false;
                }
            }
            if (flag == true)
            {
                for (int i = 0; i < pointFs.Length; i++)
                {
                    t1.pointFs[i].X += x;


                    t1.pointFs[i].Y += y;
                }
              


            }


            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox1.Width - 1 && this.y + y < 0) ||
               (this.x + this.width + x > Init.pictureBox1.Width - 1) || (this.x + x > Init.pictureBox1.Width - 1 && this.y + y > Init.pictureBox1.Height - 1) ||
               (this.y + this.height + y > Init.pictureBox1.Height - 1) || (this.x + x < 0 && this.y + y > Init.pictureBox1.Height - 1) || (this.x + x < 0)))


            {
                this.x += x;
                this.y += y;
                r1.MoveTo(x, y);
                c1.MoveTo(x, y);
                t1.MoveTo(x, y);


               

            }










        }


    }


}




    

