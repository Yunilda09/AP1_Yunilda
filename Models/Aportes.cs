using System.ComponentModel.DataAnnotations;

public class Aportes
{
    [Key]
    public int AportesId { get; set; }
    [Required(ErrorMessage ="Es obligatorio")]
    public String? Persona { get; set; }
     [Range(1,1_000_000)]
    public double Salario { get; set; }
}