using System.ComponentModel.DataAnnotations;

namespace WebApiCoreClinica.Models
{
    public class Medicos
    {

        [Required]
        public string? codmed { get; set; }
        [Required]
        public string? nommed { get; set; }
        [Required]
        public int anio_colegio { get; set; }
        [Required]
        public string?  codesp { get; set; }
        [Required]
        public string? coddis { get; set; }

        public string? eliminado { get; set; }
    }
}
