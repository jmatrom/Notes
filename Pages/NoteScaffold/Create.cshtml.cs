using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using Notes.Data;
using Notes.Models;

namespace Notes.Pages.NoteScaffold
{
    public class CreateModel : PageModel
    {
        private readonly Notes.Data.NotesScaffoldContext _context;

        public CreateModel(Notes.Data.NotesScaffoldContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Note.CreatedDate = DateTime.Today;
            
            if(Note.Color is null)
            {
                Note.Color = "f5ed5d";
            }

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
