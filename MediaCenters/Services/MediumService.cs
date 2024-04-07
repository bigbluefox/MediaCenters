using MediaCenters.Data;
using MediaCenters.Models;
using MediaCenters.Utility;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using TagLib.Mpeg;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MediaCenters.Services
{
    public class Mediaervice
    {
        private readonly MediaCenterContext _context;

        public Mediaervice(MediaCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Medium> GetAll()
        {
            return _context.Media
                    .AsNoTracking()
                    .ToList();
        }

        public Medium? GetById(int id)
        {
            return _context.Media
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Medium Create(Medium newMedium)
        {
            _context.Media.Add(newMedium);
            _context.SaveChanges();

            return newMedium;
        }


        public void UpdateSauce(int MediumId, int sauceId)
        {
            var MediumToUpdate = _context.Media.Find(MediumId);
            //var sauceToUpdate = _context.Sauces.Find(sauceId);

            //if (MediumToUpdate is null || sauceToUpdate is null)
            //{
            //    throw new InvalidOperationException("Medium or sauce does not exist");
            //}

            //MediumToUpdate.Sauce = sauceToUpdate;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var MediumToDelete = _context.Media.Find(id);
            if (MediumToDelete is not null)
            {
                _context.Media.Remove(MediumToDelete);
                _context.SaveChanges();
            }
        }



        #region 媒体文件批量添加

        /// <summary>
        ///     媒体文件批量添加
        /// </summary>
        /// <param name="list">媒体文件列表</param>
        /// <returns></returns>
        public void AddMedias(List<Medium> list)
        {
            _context.Media.AddRange(list);
            _context.SaveChanges();
        }

        #endregion


        /// <summary>
        ///   媒体总数量
        /// </summary>
        internal static int Total;

        /// <summary>
        ///   媒体输出数量
        /// </summary>
        internal static int SubTotal;

        /// <summary>
        ///   递归媒体文件查找
        /// </summary>
        /// <param name="di">目录</param>
        /// <param name="list">媒体列表</param>
        /// <param name="type">媒体类型</param>
        /// <param name="value">哈希选择结果值</param>
        public void FindMediaFile(DirectoryInfo di, ref List<Medium> list, string type, int value)
        {
            try
            {
                var fileType = 0;

                foreach (var file in di.GetFiles())
                {
                    if (file.Extension.Length < 2 || file.Extension.Length > 8) continue;
                    if (!FileHelper.IsMediaFile(type, file.Extension)) continue;

                    fileType = FileHelper.FileType(file.Extension, file.Length);

                    var model = new Medium();

                    #region 检查文件大小

                    int width = 0, height = 0;

                    //类型：0-其他；1-图片；2-音频；3-视频；4-图书；5-大文件

                    #region 图片处理

                    if (fileType == 1)
                    {
                        try
                        {
                            //var image = Image.FromFile(file.FullName);
                            //width = image.Width;
                            //height = image.Height;

                            //using (Image image = Image.FromFile(file.FullName))
                            //{
                            //    Console.WriteLine("图像格式: " + image.RawFormat);
                            //    Console.WriteLine("宽度: " + image.Width);
                            //    Console.WriteLine("高度: " + image.Height);

                            //    width = image.Width;
                            //    height = image.Height;
                            //}

                            //Console.WriteLine(file.FullName);

                            //using (Image image = Image.Load(file.FullName))
                            //{
                            //    //image.Mutate(x => x.Resize(width, height));
                            //    //image.Save(outputPath);

                            //    Console.WriteLine($"宽度:{image.Width}，高度:{image.Height}" );

                            //    width = image.Width;
                            //    height = image.Height;
                            //}

                            if (height < 128 || width < 128) continue;

                            //bytes = ImageToBytes(image);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            //Dispose(); // 防止内存溢出
                        }
                    }

                    #endregion

                    #region 音频处理

                    if (fileType == 2)
                    {
                        try
                        {
                            using (var audio = TagLib.File.Create(file.FullName))
                            {
                                Console.WriteLine("Title: " + audio.Tag.Title);
                                Console.WriteLine("Artist: " + audio.Tag.FirstPerformer);
                                Console.WriteLine("Album: " + audio.Tag.Album);
                                Console.WriteLine("Track: " + audio.Tag.Track);
                                Console.WriteLine("Year: " + audio.Tag.Year);
                                Console.WriteLine("Genre: " + (audio.Tag.Genres.Length > 0 ? audio.Tag.Genres[0] : ""));
                                Console.WriteLine("Duration: " + audio.Properties.Duration);

                                //Console.WriteLine($"{JsonConvert.SerializeObject(audio.Tag)}" );

                                Console.WriteLine("");

                                model.Album = audio.Tag.Album;
                                model.Artist = audio.Tag.FirstPerformer;
                                model.Duration = audio.Properties.Duration.ToString(@"hh\:mm\:ss");
                            }

                            #region 获取音乐文件信息

                            string mp3Info = "";

                            if (file.Extension.ToLower() == ".mp3")
                            {
                                //ShellClass sh = new ShellClass();
                                //Folder dir = sh.NameSpace(Path.GetDirectoryName(file.FullName));
                                //FolderItem item = dir.ParseName(Path.GetFileName(file.FullName));

                                //var artist = dir.GetDetailsOf(item, 13);
                                //var album = dir.GetDetailsOf(item, 14);
                                //var duration = dir.GetDetailsOf(item, 27);

                                //mp3Info += "文件名：" + dir.GetDetailsOf(item, 0) + " * ";
                                //mp3Info += "文件大小：" + dir.GetDetailsOf(item, 1) + " * ";
                                //mp3Info += "歌曲名：" + dir.GetDetailsOf(item, 21) + " * ";
                                //mp3Info += "歌手：" + dir.GetDetailsOf(item, 13) + " * ";
                                //mp3Info += "专辑：" + dir.GetDetailsOf(item, 14) + " * ";
                                //mp3Info += "时长：" + dir.GetDetailsOf(item, 27);

                                //model.Album = artist;
                                //model.Artist = album;
                                //model.SHA1 = duration;
                                //model.Artist = mp3Info.Length > 255 ? mp3Info.Substring(0, 254) : mp3Info;


                            }

                            #endregion

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            //Dispose(); // 防止内存溢出
                        }
                    }

                    #endregion

                    #region 视频处理

                    if (fileType == 3)
                    {
                        try
                        {
                            if (file.Length < 1048576 * 2) continue; // 2M以下小视频文件不予统计


                            string videoPath = file.FullName; // 指定要获取信息的视频文件路径

                            Process process = new Process();
                            process.StartInfo.FileName = @"D:\Codes\ffmpeg\ffmpeg-2024-01-17-git-8e23ebe6f9-essentials_build\bin\ffprobe.exe"; // FFmpeg 提供的命令行工具 ffprobe
                            process.StartInfo.Arguments = $"-v error -select_streams v:0 -show_entries stream=width,height,duration -of default=noprint_wrappers=1:nokey=1 \"{videoPath}\"";
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.CreateNoWindow = true;

                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            process.WaitForExit();

                            var videoinfo = output.Split(Environment.NewLine);
                            var b = videoinfo;



                            if (videoinfo.Length > 0)
                            {
                                int.TryParse(videoinfo[0], out width);
                            }
                            if (videoinfo.Length > 1)
                            {
                                int.TryParse(videoinfo[1], out height);
                            }
                            if (videoinfo.Length > 2)
                            {
                                double.TryParse(videoinfo[2], out double seconds);
                                TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

                                Console.WriteLine($"seconds:{timeSpan}");

                                model.Duration = timeSpan.ToString(@"hh\:mm\:ss");
                            }

                            Console.WriteLine("Video information:\n");
                            Console.WriteLine($"Resolution: {output}");
                            Console.WriteLine($"Duration: {GetVideoDurationFromFFProbeOutput(output)} seconds\n");

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            //Dispose(); // 防止内存溢出
                        }
                    }

                    #endregion

                    #region 图书处理

                    if (fileType == 4)
                    {

                    }

                    #endregion

                    #region 大文件处理

                    if (fileType == 5)
                    {

                    }

                    #endregion

                    #endregion

                    model.Type = fileType;
                    model.Name = DateTime.Now.ToFileTime().ToString();
                    model.Title = file.Name.Replace(file.Extension, "").Replace("'", "''");
                    model.Size = file.Length;
                    model.Extension = file.Extension.ToLower();
                    model.ContentType = MimeMapping.GetMimeMapping(file.FullName);
                    model.FullName = file.FullName.Replace("'", "''");
                    if (file.DirectoryName != null) model.DirectoryName = file.DirectoryName.Replace("'", "''");
                    model.CreationTime = file.CreationTime;

                    //SELECT Id, Type, Name, Title, Album, Artist, Duration, Width, Height, Size, Extension
                    //    , ContentType, FullName, DirectoryName, CreationTime, MD5, SHA1
                    //FROM Medias

                    model.Width = width;
                    model.Height = height;

                    model.Md5 = value == 1 || value == 3 ? HashAlgorithmHelper.ComputeFileHash<MD5>(file.FullName) : "";

                    //model.Md5 = value == 1 || value == 3 ? HashHelper.ComputeMD5(file.FullName) : "";
                    //model.SHA1 = value == 2 || value == 3 ? HashHelper.ComputeSHA1(file.FullName) : "";

                    list.Add(model);
                    Total++;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //Dispose();
            }

            if (list.Count > 99)
            {
                AddMedias(list);
                list = new List<Medium>();
            }

            try
            {
                var dir = di.GetDirectories();
                foreach (var d in dir)
                {
                    FindMediaFile(d, ref list, type, value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //Dispose();
            }
        }

        private static double GetVideoDurationFromFFProbeOutput(string output)
        {
            try
            {
                Console.WriteLine(output);
                int startIndex = output.LastIndexOf(' ') + 1;
                return Convert.ToDouble(output.Substring(startIndex));
            }
            catch (Exception ex)
            {
                Console.WriteLine(output);
                return 0;
            }

        }








    }

}
