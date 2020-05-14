using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Notes.Pages.NoteScaffold
{
    public class IndexModel : PageModel
    {
        
        private readonly Notes.Data.NotesScaffoldContext _context;

        
        public IndexModel(Notes.Data.NotesScaffoldContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList ColorList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ColorSelected { get; set; }

    
        public async Task OnGetAsync()
        {
            

            IQueryable<string> colorQuery = from n in _context.Note
                                            orderby n.Color
                                            select n.Color;

            var notes = from n in _context.Note
                        select n;

            if (!string.IsNullOrEmpty(SearchString)){
                notes = notes.Where(s => s.Title.Contains(SearchString) || s.TextNote.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ColorSelected))
            {
                notes = notes.Where(s => s.Color.Contains(ColorSelected));
            }

            ColorList = new SelectList(await colorQuery.Distinct().ToListAsync());

            Note = await notes.ToListAsync();
        }
    }
}
