using Microsoft.EntityFrameworkCore;
using NoteApplication.Entities;
using System;

namespace NoteApplication.Database
{
    public class InMemoryDb : DbContext
    {
        //Create InmemoryDb Context
        public InMemoryDb(DbContextOptions<InMemoryDb> options) : base(options)
        {

        }

        //Create Notes Property
        public DbSet<Notes> notes { get; set; }
    }
}
