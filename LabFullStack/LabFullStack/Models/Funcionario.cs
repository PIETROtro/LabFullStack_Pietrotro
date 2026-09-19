using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public class Funcionario
{
    public int Codigo { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100)]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "O cargo é obrigatório.")]
    [StringLength(50)]
    [Display(Name = "Cargo")]
    public string Cargo { get; set; } = null!;

    public ICollection<Tarefa>? Tarefas { get; set; }
}
