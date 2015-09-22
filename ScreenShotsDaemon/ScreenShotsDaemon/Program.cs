using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShotsDaemon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Rectangle r = Screen.PrimaryScreen.Bounds;
            while(true)
            {
                Thread.Sleep(300);
                Image img = new Bitmap(r.Width, r.Height);
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), r.Size);
                string path_time = string.Format("{0:yyyy-MM-dd-HH-mm-ss-ffff}", DateTime.Now);
                img.Save("E:\\screen_shot_daemon\\" + path_time + ".jpg");
                g.Dispose();
                img.Dispose();
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
