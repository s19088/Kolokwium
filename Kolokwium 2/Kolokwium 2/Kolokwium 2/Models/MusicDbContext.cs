using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }

        public MusicDbContext() { }
        public MusicDbContext
            (DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var listMusician = new List<Musician>();
            listMusician.Add(new Musician { IdMusician = 1, FirstName = "buko", LastName = "San", Nickname = "" });
            listMusician.Add(new Musician { IdMusician = 2, FirstName = "ostrr", LastName = "aaaa", Nickname = "raper" });
            listMusician.Add(new Musician { IdMusician = 3, FirstName = "tony ", LastName = "stark", Nickname = "ironman" });
            modelBuilder.Entity<Musician>().HasData(listMusician);

            var listMusicLabel = new List<MusicLabel>();
            listMusicLabel.Add(new MusicLabel { IdMusicLabel = 11, Name = "avenger" });
            listMusicLabel.Add(new MusicLabel { IdMusicLabel = 22, Name = "prosto" });
            listMusicLabel.Add(new MusicLabel { IdMusicLabel = 22, Name = "kayax" });
            modelBuilder.Entity<MusicLabel>().HasData(listMusicLabel);

            var listAlbum = new List<Album>();
            listAlbum.Add(new Album { IdAlbum = 111, AlbumName = "blackalbum", PublishDate = DateTime.Now, IdMusicLabel = 11 });
            listAlbum.Add(new Album { IdAlbum = 222, AlbumName = "jazz", PublishDate = DateTime.Now, IdMusicLabel = 22 });
            listAlbum.Add(new Album { IdAlbum = 333, AlbumName = "pomocy", PublishDate = DateTime.Now, IdMusicLabel = 33 });
            modelBuilder.Entity<Album>().HasData(listAlbum);

            var listTrack = new List<Track>();
            listTrack.Add(new Track { IdTrack = 1111, TrackName = "cokolwiek", Duration = 1, IdMusicAlbum = 111 });
            listTrack.Add(new Track { IdTrack = 2222, TrackName = "hot16challenge", Duration = 1, IdMusicAlbum = 222 });
            listTrack.Add(new Track { IdTrack = 3333, TrackName = "cokolwiek", Duration = 1, IdMusicAlbum = 333 });
            modelBuilder.Entity<Track>().HasData(listTrack);

            var listMusician_Track = new List<Musician_Track>();
            listMusician_Track.Add(new Musician_Track { IdMusicianTrack = 11111, IdMusician = 1, IdTrack = 1111 });
            listMusician_Track.Add(new Musician_Track { IdMusicianTrack = 22222, IdMusician = 2, IdTrack = 2222 });
            listMusician_Track.Add(new Musician_Track { IdMusicianTrack = 33333, IdMusician = 3, IdTrack = 3333 });
            modelBuilder.Entity<Musician_Track>().HasData(listMusician_Track);
        }
    }
}