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

        public int ID_INDICATOR { get; set; }

        public int EMPLOYEE_NO { get; set; }

        [Required]
        public DateTime DATE { get; set; }

        [Required]
        public int QUANTITY { get; set; }

        public DateTime INDICATOR_DATE { get; set; }
    }
}