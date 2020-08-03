using NoteApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.BusinessLogics.Services.Repository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Notes>> ReadAsync();
        Task<Notes> CreateAsync(Notes notes);
        Task<Notes> UpdateAsync(Notes note);
        Task<Notes> DeleteAsync(Notes notes);
    }
}
