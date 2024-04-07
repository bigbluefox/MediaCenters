using MediaCenters.Data;
using MediaCenters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCenters.Services
{

    public class VideoService
    {
        private readonly MediaCenterContext _context;

        public VideoService(MediaCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Videos
                    .AsNoTracking()
                    .ToList();
        }

        public Video? GetById(int id)
        {
            return _context.Videos
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Video Create(Video newVideo)
        {
            _context.Videos.Add(newVideo);
            _context.SaveChanges();

            return newVideo;
        }



        public void UpdateVideo(int VideoId, int sauceId)
        {
            var VideoToUpdate = _context.Videos.Find(VideoId);

            //if (VideoToUpdate is null || sauceToUpdate is null)
            //{
            //    throw new InvalidOperationException("Video does not exist");
            //}

            //VideoToUpdate.Sauce = sauceToUpdate;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var VideoToDelete = _context.Videos.Find(id);
            if (VideoToDelete is not null)
            {
                _context.Videos.Remove(VideoToDelete);
                _context.SaveChanges();
            }
        }
    }
}
