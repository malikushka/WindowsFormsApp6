using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    
    
        public class Polygon : Figure
        {
            public PointF[] pointFs;
            public int count;
            private int v1;
            private int v2;
            private int y1;



            public Polygon(PointF[] pointFs)
            {
                this.pointFs = pointFs;


            }
            public Polygon(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
            public Polygon(int v1, int v2, int y1) : this(v1, v2)
            {
                this.y1 = y1;
            }

            public Polygon(int count)
            {
                this.count = count;
            }

            public override void MoveTo(int x, int y)
            {
                bool flag = true;
                for (int i = 0; i < pointFs.Length; i++)
                {
                    if (((this.pointFs[i].X + x < 0 && this.pointFs[i].Y + y < 0) ||
                            (this.pointFs[i].Y + y < 0) ||
                            (this.pointFs[i].X + x > Init.pictureBox1.Width - 1 && this.pointFs[i].Y + y < 0) ||
                            (this.pointFs[i].X + this.width + x > Init.pictureBox1.Width - 1) ||
                            (this.pointFs[i].X + x > Init.pictureBox1.Width - 1 && this.pointFs[i].Y + y > Init.pictureBox1.Height - 1) ||
                            (this.pointFs[i].Y + this.height + y > Init.pictureBox1.Height - 1) ||
                            (this.pointFs[i].X + x < 0 && this.pointFs[i].Y + y > Init.pictureBox1.Height - 1) ||
                            (this.pointFs[i].X + x < 0)))
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    for (int i = 0; i < pointFs.Length; i++)
                    {
                        pointFs[i].X += x;
                        pointFs[i].Y += y;
                    }
                }
                this.DeleteF(this, false);
                this.Draw();

            }


            public override void Draw()
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawPolygon(Init.pen, this.pointFs);
                Init.pictureBox1.Image = Init.bitmap;
            }

        }



    }


