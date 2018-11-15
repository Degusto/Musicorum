using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Migrations;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;

using Podemski.Musicorum.Dao.Entities;
using SQLite.CodeFirst;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal sealed class DatabaseContext : Context
    {
        private EntityContext _context;
        private readonly string _connectionString;

        internal DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal override void LoadContext()
        {
            LoadDll();

            _context = new EntityContext(_connectionString);

            Artists = _context.Artists.ToList();
            Albums = _context.Albums.ToList();
            Tracks = _context.Tracks.ToList();

            FixRelations();
        }

        private void FixRelations()
        {
            foreach (var artist in Artists)
            {
                artist.Albums = Albums.Where(album => album.ArtistId == artist.Id);

                foreach (var album in artist.Albums.Cast<Album>())
                {
                    album.Artist = artist;
                }
            }

            foreach (var album in Albums)
            {
                album.TrackList = Tracks.Where(track => track.AlbumId == album.Id);

                foreach (var track in album.TrackList.Cast<Track>())
                {
                    track.Album = album;
                }
            }
        }

        internal override void SaveChanges()
        {
            _context.Artists.AddOrUpdate(Artists.ToArray());
            _context.Albums.AddOrUpdate(Albums.ToArray());
            _context.Tracks.AddOrUpdate(Tracks.ToArray());

            RemoveEntities(_context.Artists, _context.Artists.AsEnumerable().Where(a => !Artists.Contains(a)));
            RemoveEntities(_context.Albums, _context.Albums.AsEnumerable().Where(a => !Albums.Contains(a)));
            RemoveEntities(_context.Tracks, _context.Tracks.AsEnumerable().Where(a => !Tracks.Contains(a)));

            _context.SaveChanges();
        }

        private void RemoveEntities<T>(DbSet<T> collection, IEnumerable<T> itemsToRemove)
            where T : class
        {
            if (itemsToRemove.Any())
            {
                collection.RemoveRange(itemsToRemove);
            }
        }

        private void LoadDll()
        {
            if (typeof(System.Data.Entity.SqlServer.SqlProviderServices) == null)
            {
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
            }
        }

        private class EntityContext : DbContext
        {
            public EntityContext(string databaseLocation) : base(new SQLiteConnection
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = databaseLocation }.ConnectionString
            }, true)
            { }

            public DbSet<Artist> Artists { get; set; }

            public DbSet<Album> Albums { get; set; }

            public DbSet<Track> Tracks { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<EntityContext>(modelBuilder);

                Database.SetInitializer(sqliteConnectionInitializer);
            }
        }

        public class SQLiteConfiguration : DbConfiguration
        {
            public SQLiteConfiguration()
            {
                SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
                SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
                SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
            }
        }
    }
}