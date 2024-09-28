﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
         
           // var folderPath = @"C:\Users\IT\Desktop\Company.Web\wwwroot\Images\";
   //1-Get Folder Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files" ,folderName);

            //2- Get File Name
            var FileName = $"{Guid.NewGuid()}-{file.FileName}";

            //3- Combine Folder Path with File Name
            var FilePath =Path.Combine(FolderPath,FileName);

            using var FileStream = new FileStream(FilePath , FileMode.Create);

            file.CopyTo(FileStream);

            return FileName;

        }

    }
}
