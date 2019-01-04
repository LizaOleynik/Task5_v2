using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Race_v4
{
    public class Drawing
    {
        public static void Draw(Graphics g, RaceProcess process, int count_cars)
        {
            g.FillRectangle(Brushes.LightGray, new Rectangle(30, 30, 590, 340));
            g.FillRectangle(Brushes.WhiteSmoke, new Rectangle(count_cars * 20 + 30, count_cars * 20 + 30, 590 - count_cars * 40, 340 - count_cars * 40));

            for (int i = 1; i < count_cars; i++)
                g.DrawRectangle(Pens.White, new Rectangle(30 + i * 20, 30 + i * 20, 590 - i * 40, 340 - i * 40));

            g.DrawRectangle(Pens.Red, new Rectangle(550 - count_cars * 20, 370 - count_cars * 20, 20, count_cars * 20));
            for (int i = 0; i < process.cars.Count; i++)
            {
                g.FillEllipse(Brushes.Crimson, new Rectangle(process.cars[i].X, process.cars[i].Y, 10, 10));
                g.DrawString((i + 1).ToString(), new Font("Times New Roman", 12, FontStyle.Regular), new SolidBrush(Color.Black), process.cars[i].X + 10, process.cars[i].Y - 7);
                if (process.cars[i].X == 495 && process.cars[i].Y == 295 + i * 20)
                    process.cars[i].IncCount();

                if (process.cars[i].count_cycle == process.count_cycle)
                {
                    process.state = false;
                    process.cars.Clear();
                    break;
                }

            }
            if (process.state)
            {
                if (process.l1.Crash)
                    g.FillEllipse(Brushes.Red, process.l1.X, process.l1.Y, 10, 10);
                if (process.l2.Crash)
                    g.FillEllipse(Brushes.Red, process.l2.X, process.l2.Y, 10, 10);
            }
        }
    }
}
