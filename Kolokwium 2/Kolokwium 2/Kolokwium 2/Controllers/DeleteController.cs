using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_2.Models;
using Kolokwium2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class DeleteMusicianController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public DeleteMusicianController(MusicDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMusician(int id)
        {
            
            int idMusicianTrack = 0;
            
            if (_context.Musicians.Where(e => e.IdMusician == id).Any())
            {
                foreach (var mus_track in _context.Musician_Tracks)
                {
                    if (mus_track.IdMusician == id)
                    {
                        idMusicianTrack = mus_track.IdMusician;
                        var track = _context.Tracks.Where(e => e.IdTrack == mus_track.IdTrack).First();

                       
                        if (track.IdMusicAlbum != null)
                        {
                            var album = _context.Albums.Where(e => e.IdAlbum == track.IdMusicAlbum).First();

                            
                            if (album.PublishDate.Date != null)
                            {
                                return Forbid("Nie można usunąć tego muzyka");//muzyk tworzy 
                            }
                        }
                    }
                }
                
                if (idMusicianTrack == 0)
                {
                    var musician = _context.Musicians.Where(e => e.IdMusician == id).SingleOrDefault();
                    _context.Musicians.Remove(musician);
                    _context.SaveChanges();
                    return NotFound("Podany muzyk nie jest w trakcie tworzenia zadnego tracka, usunieto pomyslnie.");
                }
            }
            
            return NotFound("Nie znaleziono muzyka ");
        }
    }
}