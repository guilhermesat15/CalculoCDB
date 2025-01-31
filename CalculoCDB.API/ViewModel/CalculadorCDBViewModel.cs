using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.API.ViewModel
{
    public class CalculadorCDBViewModel
    {
        [Required(ErrorMessage = "O campo quantidade meses não pode ser vazio.")]
        [Range(2, int.MaxValue, ErrorMessage = "A quantidade meses, deve ser maior que 1.")]
        public int quantidadeMeses { get; set; }

        [Required(ErrorMessage = "o campo valor inicial não pode ser vazio.")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor inicial deve ser um valor monetário positivo.")]
        public double valorInicial { get; set; }
    }
}