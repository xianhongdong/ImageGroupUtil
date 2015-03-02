/******************************************************
* author :  xianhongdong
* description: 
* history:  created by xianhongdong 3/2/2015 9:26:41 AM 
******************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shell32;
using System.Drawing;

namespace ImageGroupUtil
{
    class ImagePropertyUtil
    {
        /*http://exif.cn/
         十六进制值  说明
      0x0100      图象宽度              0x0101      图象高度
      0x010E      图象描述
      0x010F      设备制造商            0x0110      设备型号
      0x0131      所用软件              0x0132      拍摄时间
      0x013B      作者
      0x0320      图像标题
      0x5090      亮度表                0x5091      色度表
      0x8298      版权声明              0x829A      Exif 曝光时间
      0x9000      EXIF版本              0x9003      原始拍摄时间ExifDTOriginal
      0x927C      厂家备注              0x9286      用户备注 
        */
        public static string GetImageCaptureTime(string filePath)
        {
            var img = Image.FromFile(filePath);
            var itemArray = img.PropertyItems;
            //
            foreach (var item in itemArray)
            {
                if (item.Id == 0x0132)
                {
                    return Encoding.ASCII.GetString(item.Value);
                }
            }
            return "";
        }
        /// <summary>

        /// 获取文件属性字典

        /// </summary>

        /// <param name="filePath">文件路径</param>

        /// <returns>属性字典</returns>

        public static Dictionary<string, string> GetProperties(string filePath)
        {

            if (!File.Exists(filePath))
            {

                throw new FileNotFoundException("指定的文件不存在。", filePath);

            }

            //初始化Shell接口 

            Shell32.Shell shell = new Shell32.Shell();

            //获取文件所在父目录对象 

            Folder folder = shell.NameSpace(Path.GetDirectoryName(filePath));

            //获取文件对应的FolderItem对象 

            FolderItem item = folder.ParseName(Path.GetFileName(filePath));

            //字典存放属性名和属性值的键值关系对 

            Dictionary<string, string> Properties = new Dictionary<string, string>();

            int i = 0;

            while (true)
            {

                //获取属性名称 

                string key = folder.GetDetailsOf(null, i);

                if (string.IsNullOrEmpty(key))
                {

                    //当无属性可取时，退出循环 

                    break;

                }

                //获取属性值 

                string value = folder.GetDetailsOf(item, i);

                //保存属性 

                Properties.Add(key, value);

                i++;

            }

            return Properties;

        }
        /// <summary>

        /// 获取指定文件指定下标的属性值

        /// </summary>

        /// <param name="filePath">文件路径</param>

        /// <param name="index">属性下标</param>

        /// <returns>属性值</returns>

        public static string GetPropertyByIndex(string filePath, int index)
        {

            if (!File.Exists(filePath))
            {

                throw new FileNotFoundException("指定的文件不存在。", filePath);

            }

            //初始化Shell接口 

            Shell32.Shell shell = new Shell32.Shell();

            //获取文件所在父目录对象 

            Folder folder = shell.NameSpace(Path.GetDirectoryName(filePath));

            //获取文件对应的FolderItem对象 

            FolderItem item = folder.ParseName(Path.GetFileName(filePath));

            string value = null;



            //获取属性名称 

            string key = folder.GetDetailsOf(null, index);

            if (false == string.IsNullOrEmpty(key))
            {

                //获取属性值 

                value = folder.GetDetailsOf(item, index);

            }

            return value;

        }
        /// <summary>

        /// 获取指定文件指定属性名的值

        /// </summary>

        /// <param name="filePath">文件路径</param>

        /// <param name="propertyName">属性名</param>

        /// <returns>属性值</returns>

        public static string GetProperty(string filePath, string propertyName)
        {

            if (!File.Exists(filePath))
            {

                throw new FileNotFoundException("指定的文件不存在。", filePath);

            }

            //初始化Shell接口 

            Shell32.Shell shell = new Shell32.Shell();

            //获取文件所在父目录对象 

            Folder folder = shell.NameSpace(Path.GetDirectoryName(filePath));

            //获取文件对应的FolderItem对象 

            FolderItem item = folder.ParseName(Path.GetFileName(filePath));

            string value = null;

            int i = 0;

            while (true)
            {

                //获取属性名称 

                string key = folder.GetDetailsOf(null, i);

                if (string.IsNullOrEmpty(key))
                {

                    //当无属性可取时，退出循环 

                    break;

                }

                if (true == string.Equals(key, propertyName, StringComparison.CurrentCultureIgnoreCase))
                {

                    //获取属性值 

                    value = folder.GetDetailsOf(item, i);

                    break;

                }



                i++;

            }

            return value;

        }
        /// <summary>

        /// 存储属性名与其下标（key值均为小写）

        /// </summary>

        private static Dictionary<string, int> _propertyIndex = null;



        /// <summary>

        /// 获取指定文件指定属性名的值

        /// </summary>

        /// <param name="filePath">文件路径</param>

        /// <param name="propertyName">属性名</param>

        /// <returns>属性值</returns>

        public static string GetPropertyEx(string filePath, string propertyName)
        {

            if (_propertyIndex == null)
            {

                InitPropertyIndex();

            }

            //转换为小写

            string propertyNameLow = propertyName.ToLower();

            if (_propertyIndex.ContainsKey(propertyNameLow))
            {

                int index = _propertyIndex[propertyNameLow];

                return GetPropertyByIndex(filePath, index);

            }

            return null;

        }



        /// <summary>

        /// 初始化属性名的下标

        /// </summary>

        private static void InitPropertyIndex()
        {

            Dictionary<string, int> propertyIndex = new Dictionary<string, int>();

            //获取本代码所在的文件作为临时文件，用于获取属性列表

            string tempFile = System.Reflection.Assembly.GetExecutingAssembly().FullName;

            Dictionary<string, string> allProperty = GetProperties(tempFile);

            if (allProperty != null)
            {

                int index = 0;

                foreach (var item in allProperty.Keys)
                {

                    //属性名统一转换为小写，用于忽略大小写

                    _propertyIndex.Add(item.ToLower(), index);

                    index++;

                }

            }

            _propertyIndex = propertyIndex;

        }
    }
}
