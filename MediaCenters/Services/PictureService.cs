using MediaCenters.Data;
using MediaCenters.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCenters.Services
{

    public class PictureService
    {
        private readonly MediaCenterContext _context;

        public PictureService(MediaCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Picture> GetAll()
        {
            return _context.Pictures
                    .AsNoTracking()
                    .ToList();
        }

        public Picture? GetById(int id)
        {
            return _context.Pictures
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Picture Create(Picture newImage)
        {
            _context.Pictures.Add(newImage);
            _context.SaveChanges();

            return newImage;
        }

        public void UpdateSauce(int ImageId, int sauceId)
        {
            var ImageToUpdate = _context.Pictures.Find(ImageId);
            //var sauceToUpdate = _context.Sauces.Find(sauceId);

            //if (ImageToUpdate is null || sauceToUpdate is null)
            //{
            //    throw new InvalidOperationException("Image does not exist");
            //}

            //ImageToUpdate.Sauce = sauceToUpdate;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var ImageToDelete = _context.Pictures.Find(id);
            if (ImageToDelete is not null)
            {
                _context.Pictures.Remove(ImageToDelete);
                _context.SaveChanges();
            }
        }
    }
}
