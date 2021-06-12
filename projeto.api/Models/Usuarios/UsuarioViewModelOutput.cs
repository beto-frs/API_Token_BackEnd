using System.ComponentModel.DataAnnotations;

namespace projeto.api.Models.Usuarios
{
    public class UsuarioViewModelOutput
    {
        [Required(ErrorMessage = "O código é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O login é obrigatória")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }
    }
}
