using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace WebShop.Web.Helpers
{
    public class FileUploadHelpers
    {
        public static async Task SaveImagesFile(Stream fileContent, string filePath)
        {
            try
            {
                byte[] data = new byte[fileContent.Length];
                fileContent.Read(data, 0, (int)fileContent.Length);

                using (Stream stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    await stream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public static string FileNameBuilder(string name, string originUploadName)
        {
            string fileName = FileNameRemoveSpecialChars(name);
            string extension = GetFileExtension(originUploadName);
            return string.Format("{0}.{1}", fileName, extension);
        }

        public static string FileNameRemoveSpecialChars(string fileName)
        {
            string regPattern = "W+/g";
            return Regex.Replace(fileName, regPattern, "_");
        }

        public static string GetFileExtension(string fileName)
        {
            string[] fileNameParts = fileName.Split('.');
            return fileNameParts[fileNameParts.Length - 1];
        }
    }
}