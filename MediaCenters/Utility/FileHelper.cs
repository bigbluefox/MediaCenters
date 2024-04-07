using MediaCenters.Models;
using MediaCenters.Services;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;
using System.Security.Cryptography;

namespace MediaCenters.Utility
{
    public static class FileHelper
    {
        /// <summary>
        /// 文件大小转换
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static string FileSize(long fileSize)
        {
            var size = "";

            if (fileSize < 102.4)
            {
                size = "0.10K";
            }
            else if (fileSize < 1024 * 1024)
            {
                var rst = Math.Round(fileSize / 1024.0, 2, MidpointRounding.AwayFromZero);
                size = rst.ToString("##.00") + "K";
            }
            else if (fileSize < 1024 * 1024 * 1024)
            {
                var rst = Math.Round(fileSize / 1024.0 / 1024.0, 2, MidpointRounding.AwayFromZero);
                size = rst.ToString("##.00") + "M";
            }
            else
            {
                var rst = Math.Round(fileSize / 1024.0 / 1024.0 / 1024.0, 2, MidpointRounding.AwayFromZero);
                size = rst.ToString("##.00") + "G";
            }

            return size;
        }



        #region Convert Image to Byte

        ///// <summary>
        /////   Convert Image to Byte[]
        ///// </summary>
        ///// <param name="image"></param>
        ///// <returns></returns>
        //public static byte[] ImageToBytes(Image image)
        //{
        //    var format = image.;
        //    using var ms = new MemoryStream();

        //    if (format.Equals(ImageFormat.Jpeg))
        //    {
        //        image.Save(ms, ImageFormat.Jpeg);
        //    }
        //    else if (format.Equals(ImageFormat.Png))
        //    {
        //        image.Save(ms, ImageFormat.Png);
        //    }
        //    else if (format.Equals(ImageFormat.Bmp))
        //    {
        //        image.Save(ms, ImageFormat.Bmp);
        //    }
        //    else if (format.Equals(ImageFormat.Gif))
        //    {
        //        image.Save(ms, ImageFormat.Gif);
        //    }
        //    else if (format.Equals(ImageFormat.Icon))
        //    {
        //        image.Save(ms, ImageFormat.Icon);
        //    }
        //    var buffer = new byte[ms.Length];
        //    //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
        //    ms.Seek(0, SeekOrigin.Begin);
        //    ms.Read(buffer, 0, buffer.Length);
        //    return buffer;
        //}

        #endregion

        #region 是否媒体文件

        /// <summary>
        ///   是否媒体文件
        /// </summary>
        /// <param name="type">媒体类型</param>
        /// <param name="ext">扩展名</param>
        /// <returns></returns>
        public static bool IsMediaFile(string type, string ext)
        {
            ext = ext.Trim('.').ToLower();
            var strExt = "*";
            var isMediaFile = false;
            // 类型：0-其他；1-图片；2-音频；3-视频;4-阅读；5-大文件
            switch (type)
            {
                // 图片
                case "1":
                    strExt = "jpg,png,jpeg,gif,icon,bmp,tiff,tga,exif,svg,psd,eps,ai.raw,wmf";
                    isMediaFile = strExt.IndexOf(ext, StringComparison.Ordinal) > -1;
                    break;


                // 音频
                case "2":
                    strExt = "mp3,flac,ape,mid,wav,aac,wma,ogg,cda,asf,rm,vof,m4a";
                    isMediaFile = strExt.IndexOf(ext, StringComparison.Ordinal) > -1;
                    break;

                // 视频
                case "3":
                    strExt = "mp4,mkv,avi,wmv,mpg,mpeg,mov,rm,rmvb,flv,f4v,m4v,3gp,dat,ts,mts,vob";
                    isMediaFile = strExt.IndexOf(ext, StringComparison.Ordinal) > -1;
                    break;

                // 阅读
                case "4":
                    strExt = "pdf,doc,docx,ppt,pptx,epub,chm,txt";
                    isMediaFile = strExt.IndexOf(ext, StringComparison.Ordinal) > -1;
                    break;

                default:
                    // 其他
                    isMediaFile = true;
                    break;
            }

            return isMediaFile;
        }

        private static string _imageFileType = "jpg,jpeg,png,gif,icon,bmp,tiff,tga,exif,svg,psd,eps,ai.raw,wmf";
        private static string _audioFileType = "mp3,flac,ape,wav,aac,wma,ogg,cda,asf,vof,m4a";
        private static string _videoFileType = "mp4,mkv,avi,wmv,mpg,mpeg,mov,rm,rmvb,flv,f4v,m4v,3gp,dat,ts,mts,vob";
        private static string _bookFileType = "pdf,doc,docx,ppt,pptx,epub,chm,txt";

        /// <summary>
        /// 根据扩展名，确定文件类型
        /// </summary>
        /// <param name="ext">文件扩展名</param>
        /// <returns>类型：0-其他；1-图片；2-音频；3-视频；4-图书；5-大文件</returns>
        public static int FileType(string ext, long? size)
        {
            var type = 0;
            ext = ext.Trim('.').ToLower();

            if (_imageFileType.Contains(ext))
            {
                type = 1;
            }
            else if (_audioFileType.Contains(ext))
            {
                type = 2;
            }
            else if (_videoFileType.Contains(ext))
            {
                type = 3;
            }
            else if (_bookFileType.Contains(ext))
            {
                type = 4;
            }
            else
            {
                if (size > 1024000000)
                {
                    type = 5;
                }
            }

            return type;
        }





        #endregion

        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }


    }
}
