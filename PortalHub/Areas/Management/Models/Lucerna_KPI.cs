using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalHub.Areas.Management.Models
{
    [Table("IND_LOG")]
    public class Lucerna_KPI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_LOG { get; set; }

        [ForeignKey("ID_IND1")]
        public int ID_IND1 { get; set; }

        [Required]
        public DateTime FECHA { get; set; }

        [Required]
        public int CANT { get; set; }

        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese solo números.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de empleado debe ser mayor que cero.")]
        [ForeignKey("NO_EMPLEADO")]
        public int NO_EMPLEADO { get; set; }

        public DateTime FECHA_IND { get; set; }
    }
}