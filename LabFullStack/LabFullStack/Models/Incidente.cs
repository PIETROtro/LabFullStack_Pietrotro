using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public class Incidente
{
    public int Codigo { get; set; }

    [Required(ErrorMessage = "A descrição do problema é obrigatória.")]
    [StringLength(250)]
    [Display(Name = "Descrição do Problema")]
    public string DescricaoProblema { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data do Incidente")]
    public DateTime DataIncidente { get; set; }

    [StringLength(250)]
    [Display(Name = "Solução")]
    public string? Solucao { get; set; }

    [Required(ErrorMessage = "Informe se o incidente foi resolvido (sim/nao).")]
    [StringLength(3)]
    [Display(Name = "Resolvido")]
    public string Resolvido { get; set; } = null!;
}
