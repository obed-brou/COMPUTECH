using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using COMPUTECH.Data;
using COMPUTECH.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.ComponentModel.DataAnnotations;  // Agregar este using

namespace COMPUTECH.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must upload an image.")] // Validación para la imagen
        public IFormFile ImageUpload { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validar si la imagen se ha subido correctamente
            if (ImageUpload == null || ImageUpload.Length == 0)
            {
                ModelState.AddModelError("ImageUpload", "An image is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Manejo de la imagen
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageUpload.FileName);  // Genera un nombre único para evitar colisiones
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Verifica que la carpeta "uploads" exista
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);  // Crea la carpeta si no existe
            }

            // Guarda el archivo en el servidor
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await ImageUpload.CopyToAsync(fileStream);
            }

            // Guardar la URL relativa de la imagen
            BlogPost.ImageUrl = "/uploads/" + fileName;

            // Guardar los datos del blog post
            BlogPost.DatePosted = DateTime.Now;
            _context.BlogPosts.Add(BlogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
