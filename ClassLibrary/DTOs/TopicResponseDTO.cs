using ClassLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary.DTOs
{
    public partial class TopicResponseDTO
    {
        public int Id { get; set; }

        public required int TopicParentId { get; set; }

        [Required(ErrorMessage = "Var god och skriv ett svar")]
        [MinLength(2, ErrorMessage ="Ett svar måste vara minst 2 karaktärer")]
        public string CommentBody { get; set; }

        [Required(ErrorMessage = "Var god och skriv ett alias på respondenten")]
        [MinLength(5, ErrorMessage ="Alias måste vara minst 5 karaktärer")]
        [MaxLength(50, ErrorMessage = "Alias får inte vara mer än 50 karaktärer")]
        public string ResponderAlias { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
