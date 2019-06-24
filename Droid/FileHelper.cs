using CubeXNative.Services;
using System;
using System.IO;

//[assembly: Dependency(typeof(FileHelper))]
namespace CubeXNative.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (!Directory.Exists(docFolder))
            {
                Directory.CreateDirectory(docFolder);
            }

            return Path.Combine(docFolder, filename);
        }
    }
}