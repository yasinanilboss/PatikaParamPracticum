using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreWebAPI
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }




    }
}
