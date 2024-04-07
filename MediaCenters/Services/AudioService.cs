using MediaCenters.Data;
using MediaCenters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCenters.Services
{

    public class AudioService
    {
        private readonly MediaCenterContext _context;

        public AudioService(MediaCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Audio> GetAll()
        {
            return _context.Audios
                    .AsNoTracking()
                    .ToList();
        }

        public Audio? GetById(int id)
        {
            return _context.Audios
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Audio Create(Audio newAudio)
        {
            _context.Audios.Add(newAudio);
            _context.SaveChanges();

            return newAudio;
        }

        //public void AddTopping(int AudioId, int toppingId)
        //{
        //    var AudioToUpdate = _context.Audios.Find(AudioId);
        //    var toppingToAdd = _context.Toppings.Find(toppingId);

        //    if (AudioToUpdate is null || toppingToAdd is null)
        //    {
        //        throw new InvalidOperationException("Audio or topping does not exist");
        //    }

        //    if (AudioToUpdate.Toppings is null)
        //    {
        //        AudioToUpdate.Toppings = new List<Topping>();
        //    }

        //    AudioToUpdate.Toppings.Add(toppingToAdd);

        //    _context.SaveChanges();
        //}

        public void UpdateSauce(int AudioId, int sauceId)
        {
            var AudioToUpdate = _context.Audios.Find(AudioId);
            //var sauceToUpdate = _context.Sauces.Find(sauceId);

            //if (AudioToUpdate is null || sauceToUpdate is null)
            //{
            //    throw new InvalidOperationException("Audio does not exist");
            //}

            //AudioToUpdate.Sauce = sauceToUpdate;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var AudioToDelete = _context.Audios.Find(id);
            if (AudioToDelete is not null)
            {
                _context.Audios.Remove(AudioToDelete);
                _context.SaveChanges();
            }
        }
    }
}
