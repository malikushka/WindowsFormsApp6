using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox1;
        public static Pen pen;
    }
    class ShapeContainer
    {
        public static List<Figure> figureList;
        public ShapeContainer()

        {
            figureList = new List<Figure>();
        }
        public static void AddFigure(Figure figure)
        {
            figureList.Add(figure);
        }
        public static Figure FindFigure(string name)
        {
            foreach (Figure f in figureList)
            {
                if (f.name == name)
                {
                    return f;
                }

            }
            return null;

        }
    }

    public abstract class Figure
    {
        public int x;
        public int y;
        public int width;
        public int height;
        internal string name;


        abstract public void Draw();

        abstract public void MoveTo(int x, int y);
        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);

        }
        public void DeleteF(Figure figure, bool flag = true)
        {
            if (flag == true)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                this.Clear();
                Init.pictureBox1.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
            }
            else
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                this.Clear();
                Init.pictureBox1.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
                ShapeContainer.figureList.Add(figure);
            }


        }

    }
}


