using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CreditaNelas.Models
{
    public class Postagens
    {
        [Key]
        public int Id_Postagem { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Escreva um título")]
        public string Titulo { get; set; }

        [Display(Name = "Url da imagem")]
        public string UrlImagem { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite aqui seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Deixa aqui uma descrição da ajuda que necessita")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe seu whatsapp, não se esqueça do DDD")]
        public string Whatsapp { get; set; }

        
        public int Id_Usuario { get; set; }

    
        public Usuarios Usuario { get; set; }
    }
}