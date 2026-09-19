using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public class Departamento
{
    public int Codigo { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(250)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = null!;

    [Display(Name = "Ativo")]
    public bool? Ativo { get; set; }
}
