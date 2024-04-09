using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcClienteApiCrudDoctores.Models
{
    public class Doctor
    {
    

    public int IdDoctor { get; set; }
    public string Apellido { get; set; }
    public string Especialidad { get; set; }
    public int Salario { get; set; }
    public int IdHospital { get; set; }
}
}
