using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SaveImageFile
{
    static class Program
    {
        public const string CurrentLocation = "C:\\Users\\evgen\\Desktop";
        public const string DefaultFilenameFormat = "dd.MM.yyyy HH.mm";
        /// <summary>
        /// Главный метод для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Save();
        }
        /// <summary>
        /// Сохраняет текстовый файл или изображение из буфера обмена.
        /// </summary>
        private static void Save()
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