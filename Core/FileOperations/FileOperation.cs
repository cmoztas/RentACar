using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.FileOperations
{
    public static class FileOperation
    {
        public static string FilePath { get; set; }

        public static string WriteFile(IFormFile file)
        {
            string newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(FilePath, newFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newFileName;
        }

        public static bool DeleteImageFile(string fileName)
        {
            string path = Path.Combine(FilePath, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }
    }
}