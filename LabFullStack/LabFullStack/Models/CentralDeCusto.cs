using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTask.Models;

public class CentralDeCusto
{
    public int Codigo { get; set; }

    [Required(ErrorMessage = "O nome da central é obrigatório.")]
    [StringLength(250)]
    [Display(Name = "Nome da Central")]
    public string NomeCentral { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor Meta Anual")]
    public decimal ValorMetaAnual { get; set; }
}
