using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        // The OnGet method is called when the page is requested and initializes any state needed for the page.
        // Currently, no state is being initialized.
        public IActionResult OnGet()
        {
            // The Page method creates a PageResult object that renders the Create.cshtml page.
            return Page();
        }

        // The Movie property uses the [BindProperty] attribute to opt-in to model binding. When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the Movie model.
        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // When the return type is IActionResult or Task<IActionResult>, a return statement must be provided.
        // The OnPostAsync method is run when the page posts form data.
        public async Task<IActionResult> OnPostAsync()
        {
            // If there are any model errors, the form is redisplayed, along with any form data posted (Client-side validation).
          if (!ModelState.IsValid || _context.Movie == null || Movie == null)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
