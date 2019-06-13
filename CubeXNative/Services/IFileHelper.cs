using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CubeXNative.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }   
}
