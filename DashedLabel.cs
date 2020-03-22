using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Ace_Stream_File_Launcher
{
    class DashedLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen p = new Pen(ColorTranslator.FromHtml("#9aaeb2"));
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            p.Width = 3;
            Rectangle rect = new Rectangle(e.ClipRectangle.X+15, e.ClipRectangle.Y+15, e.ClipRectangle.Width - 30,
                                           e.ClipRectangle.Height - 30);

            e.Graphics.DrawRectangle(p, rect);
        }
    }
}
