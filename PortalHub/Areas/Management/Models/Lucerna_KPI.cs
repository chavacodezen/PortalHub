using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalHub.Areas.Management.Models
{
    [Table("INDICATORS_LOG")]
    public class Lucerna_KPI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_LOG { get; set; }

        [ForeignKey("ID_INDICATOR")]
        public int ID_INDICATOR { get; set; }

        [Required]
        public DateTime DATE { get; set; }

        [Required]
        public int QUANTITY { get; set; }

        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese solo números.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de empleado debe ser mayor que cero.")]
        [ForeignKey("EMPLOYEE_NO")]
        public int EMPLOYEE_NO { get; set; }

        public DateTime INDICATOR_DATE { get; set; }
    }
}