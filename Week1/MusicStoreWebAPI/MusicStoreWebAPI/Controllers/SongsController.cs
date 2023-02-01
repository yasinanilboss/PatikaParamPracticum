using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> SongList = new List<Song>
        {
            new Song
            {
                Id = 1,
                Title = "One",
                GenreId = 1, // Metal
                Duration = "6",
                ReleaseDate = new System.DateTime(1992,11,20)
            },
            new Song
            {
                Id = 2,
                Title = "Enter Sandman",
                GenreId = 1, // Metal
                Duration = "7",
                ReleaseDate = new System.DateTime(1982,11,20)
            },
            new Song
            {
                Id = 3,
                Title = "Fade to Black",
                GenreId = 1, // Metal
                Duration = "8",
                ReleaseDate = new System.DateTime(1985, 7, 10)
            }
        };

        [HttpGet]
        public List<Song> GetSongs()
        {
            var songList = SongList.OrderBy(x => x.Id).ToList<Song>();
            return songList;
        }

        [HttpGet("{id}")]
        public Song GetById(int id)
        {
            var song = SongList.Where(x => x.Id == id).SingleOrDefault();
            return song;
        }

        [HttpGet]
        public Song GetByTitle(string title)
        {
            var song = SongList.Where(x => x.Title == title).SingleOrDefault();
            return song;
        } 


        //[HttpGet]
        //public Song Get([FromQuery] string id)
        //{
        //    var song = SongList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return song;
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Song newSong)
        {
            var song = SongList.SingleOrDefault(x => x.Title == newSong.Title);

            if(song != null)
            {
                return BadRequest();
            }

            SongList.Add(newSong);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song updateSong)
        {
            var song = SongList.SingleOrDefault(x => x.Id == id);

            if (song == null)
            {
                return BadRequest();
            }

            song.GenreId = updateSong.GenreId != default ? updateSong.GenreId : song.GenreId;
            song.Duration = updateSong.Duration != default ? updateSong.Duration : song.Duration;
            song.Title = updateSong.Title != default ? updateSong.Title : song.Title;
            song.ReleaseDate = updateSong.ReleaseDate != default ? updateSong.ReleaseDate : song.ReleaseDate;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = SongList.SingleOrDefault(x => x.Id == id);

            if (song == null)
            {
                return BadRequest();
            }

            SongList.Remove(song);
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch(int id, [FromBody] Song patchSong)
        {
            var song = SongList.FirstOrDefault(x => x.Id == id);

            if(song != null)
            {
                SongList.Add(patchSong);
            }
            return Ok();
        }

    }
}
