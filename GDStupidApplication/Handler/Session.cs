using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GDStupidApplication.Handler
{
    public class Session
    {

        public static String DefaultPassword = (15+2).ToString() + (0+0+0-1+1).ToString() + "" + "4" + (1998-1).ToString(); //unch
        public static String SavedPassword = "default";
        public static String WallpaperImage = Directory.GetCurrentDirectory() + "\\assets\\wallpaper.png";
        public static String PrankImage = Directory.GetCurrentDirectory() + "\\assets\\prank.jpg";
        public Session() { 

        }

    }
}
