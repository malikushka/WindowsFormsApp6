using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class Ellipse : Figure
    {
        public Ellipse(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, this.x, this.y, this.width, this.height);
            Init.pictureBox1.Image = Init.bitmap;
        }
        public override void MoveTo( int x, int y)
        {
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox1.Width - 1 && this.y + y < 0) ||
               (this.x + this.width + x > Init.pictureBox1.Width - 1) || (this.x + x > Init.pictureBox1.Width - 1 && this.y + y > Init.pictureBox1.Height - 1) ||
               (this.y + this.height + y > Init.pictureBox1.Height - 1) || (this.x + x < 0 && this.y + y > Init.pictureBox1.Height - 1) || (this.x + x < 0)))
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                this.x += x;
                this.y += y;

                this.DeleteF(this, false);
                this.Draw();
            }


        }
    }
}

