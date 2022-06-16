using System.ComponentModel.DataAnnotations;

public class Aporte
{
    [Key]
    public int AporteId { get; set; }
    [Required(ErrorMessage ="Obligatorio")]
    public String? Persona { get; set; }
    [Range(1,1_000_000)]
    public double Monto { get; set; }
}