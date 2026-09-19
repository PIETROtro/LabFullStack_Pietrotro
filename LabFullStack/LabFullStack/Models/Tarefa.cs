using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public class Tarefa
{
    public int Codigo { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(200)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data Planejada")]
    public DateTime DataPlanejada { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data Iniciada")]
    public DateTime? DataIniciada { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data Finalizada")]
    public DateTime? DataFinalizada { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data Cancelada")]
    public DateTime? DataCancelada { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    [StringLength(30)]
    [Display(Name = "Status")]
    public string StatusTarefa { get; set; } = null!;

    [Required(ErrorMessage = "O prazo é obrigatório.")]
    [StringLength(20)]
    [Display(Name = "Prazo")]
    public string Prazo { get; set; } = null!;

    [Display(Name = "Funcionário")]
    public int FuncionarioId { get; set; }

    public Funcionario? Funcionario { get; set; }
}
