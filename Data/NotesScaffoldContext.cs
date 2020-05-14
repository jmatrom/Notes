using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data
{
    public class NotesScaffoldContext : DbContext
    {
        public NotesScaffoldContext (DbContextOptions<NotesScaffoldContext> options)
            : base(options)
        {
        }

        public DbSet<Notes.Models.Note> Note { get; set; }
    }
}
