using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace COMPUTECH.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        // Campo para almacenar la URL de la imagen
        public string ImageUrl { get; set; }

        // Reacciones (likes)
        public int Likes { get; set; } = 0;

        // Relación con los comentarios
        // Los comentarios no son obligatorios en el momento de crear la publicación
        public ICollection<Comment>? Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Comment content is required.")]
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public string Author { get; set; }

        // Relación con el BlogPost
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}

