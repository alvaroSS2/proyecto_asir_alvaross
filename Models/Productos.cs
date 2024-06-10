using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Productos
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public required string Nombre { get; set; }

    [Required]
    [StringLength(100)]
    public required string Marca { get; set; }

    [Required]
    [StringLength(100)]
    public required string Modelo { get; set; }

    [Required]
    [StringLength(50)]
    public required string Categoria { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Required]
    [Range(0, int.MaxValue)] 
    public int Stock { get; set; }

    public required string Descripcion { get; set; }
}
