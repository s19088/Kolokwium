using Kolokwium_2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Controllers
{
    [Route("api/music-labels")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicDbContext _context;


        public MusicController(MusicDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetLabel(int id)
        {
            if (_context.MusicLabels.Where(e => e.IdMusicLabel == id).Any())
            {
                List<Album> list = new List<Album>();//lista albumow
                foreach(var album in _context.Albums.OrderByDescending(e=>e.PublishDate))
                {
                    if(album.IdMusicLabel == id)
                    {
                        list.Add(album);
                    }
                }
                string json = JsonConvert.SerializeObject(list);

                return Ok(json);
            }
            return NotFound("nie ma takiego labelu");
        }
    }
}
