using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\uploads\";
        static string path = @"images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (path + newFileName).Replace("\\", "/");
            //var sourcepath = Path.GetTempFileName();
            //if (file.Length > 0)
            //{
            //    using (var stream = new FileStream(sourcepath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}
            //var result = newPath(file);
            //File.Move(sourcepath, result);
            //return result;
        }

        public static void Delete(string path)
        {
            if (File.Exists(directory + path.Replace("/", "\\")) && Path.GetFileName(path) != "defaultCar.png")
            {
                File.Delete(directory + path.Replace("/", "\\"));
            }
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            Delete(sourcePath);
            return Add(file);
        }

        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            string path = Environment.CurrentDirectory + @"\Images\carImages";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
