using NoteApplication.Database;
using NoteApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace NoteApplication.BusinessLogics.Services.Repository
{
    public class NoteRepository : INoteRepository
    {
        //create local instance for InmemoryDb
        private InMemoryDb DbContext;
        public NoteRepository(InMemoryDb DbContext)
        {
            this.DbContext = DbContext;
        }
          //Get notes from Inmemory db   
        public async Task<IEnumerable<Notes>> ReadAsync()
        {
            var notes = this.DbContext.notes.ToList();
            return notes;
        }
        //Add notes into Inmemory Db and return notes
        public async Task<Notes> CreateAsync(Notes notes)
        {
            this.DbContext.Add(notes);
            this.DbContext.SaveChanges();
            return notes;
        }
        //Update Notes into Inmemory Db and return notes 
        public async Task<Notes> UpdateAsync(Notes note)
        {
            var notes = this.DbContext.notes.FirstOrDefault(e => e.Id == note.Id);
            if (notes != null)
            {
                notes.Id = note.Id;
                notes.Title = note.Title;
                notes.Author = note.Author;
                notes.Description = note.Description;
                notes.Status = note.Status;
                this.DbContext.SaveChanges();
            }
            else
            {
                note = null;
            }
            return note;
        }
        //Delete Notes from INmemory Db and return Notes
        public async Task<Notes> DeleteAsync(Notes notes)
        {
            var note = this.DbContext.notes.FirstOrDefault(e => e.Id == notes.Id);
            if (notes != null)
            {
                this.DbContext.Remove(notes.Id);
                this.DbContext.SaveChanges();
                return notes;
            }
            else
            {
                return null;
            }
        }
    }
}
