using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SaveImageFile
{
    static class Program
    {
        public const string DefaultFilenameFormat = "dd.MM.yyyy HH.mm.ss";
        public static string CurrentLocation = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        /// <summary>
        /// Главный метод для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string location = CurrentLocation.EndsWith("\\") ? CurrentLocation : CurrentLocation + "\\";
            string filename = DateTime.Now.ToString(DefaultFilenameFormat);

            if (Clipboard.ContainsText())
                File.WriteAllText(location + filename + $".txt", Clipboard.GetText(), Encoding.UTF8);
            else
                Clipboard.GetImage().Save(location + filename + $".png", ImageFormat.Png);
        }
    }
}