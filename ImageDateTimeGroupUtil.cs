/******************************************************
* author :  xianhongdong
* description: 
* history:  created by xianhongdong 3/2/2015 1:15:27 PM 
******************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ImageGroupUtil
{
    class RelocateFailFile
    {
        public string SourceFile { get; set; }
        public string ConflitFile { get; set; }
    }
    class ImageDateTimeGroupUtil
    {
        public static bool RelocateDiretoryFile(DirectoryInfo dirInfo,string dstDir,List<RelocateFailFile> result)
        {
            var flag = true;
            foreach(var dir in dirInfo.GetDirectories())
            {
                if (!RelocateDiretoryFile(dir, dstDir, result))
                {
                    flag = false;
                }
            }
            foreach(var fileInfo in dirInfo.GetFiles())
            {
                if(fileInfo.Extension.ToLower() == ".jpg")
                {
                    if(!RelocateFile(fileInfo.FullName, dstDir, result))
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }
        static public bool RelocateFile(string sourceFile, string dstDir, List<RelocateFailFile> result)
        {
            var val = ImagePropertyUtil.GetProperty(sourceFile, "拍摄日期");
            //删除Unicode控制字符
            val = Regex.Replace(val, @"[^\u0020-\u007E]", string.Empty);
            var dstPath = GetRelocatePath(dstDir, val);
            var fileName = Path.GetFileName(sourceFile);
            var dstFilePath = string.Format("{0}\\{1}", dstPath, fileName);
            if (File.Exists(dstFilePath))
            {
                var srcMd5 = GetFileMd5(sourceFile);
                var dstMd5 = GetFileMd5(dstFilePath);
                if (srcMd5 == dstMd5)
                    return true;

                var failInfo = new RelocateFailFile() { SourceFile = sourceFile, ConflitFile = dstFilePath };
                result.Add(failInfo);
                return false;
            }
            File.Copy(sourceFile, dstFilePath);
            return true;
        }

        private static string GetFileMd5(string filePath)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                using(var fileStream = new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.None))
                {
                    var data = md5Hash.ComputeHash(fileStream);
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    return sBuilder.ToString();
                }
            }
        }

        static private string GetRelocatePath(string dstDir, string fileDatetime)
        {
            var time = DateTime.Parse(fileDatetime);
            var yearPath = string.Format("{0}\\{1}", dstDir, time.Year);
            if(!Directory.Exists(yearPath))
            {
                Directory.CreateDirectory(yearPath);
            }
            var monthPath = string.Format("{0}\\{1}月", yearPath, time.Month);
            if(!Directory.Exists(monthPath))
            {
                Directory.CreateDirectory(monthPath);
            }
            return monthPath;
        }
    }
}
