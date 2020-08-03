using NoteApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.BusinessLogics.Interface
{
    public interface INoteService
    {
        Task<IEnumerable<Notes>> ReadAsync();
        Task<Notes> CreateAsync(Notes notes);
        Task<Notes> UpdateAsync(Notes notes);
        Task<Notes> DeleteAsync(Notes notes);
    }
}
