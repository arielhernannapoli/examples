using System.ComponentModel.DataAnnotations;

namespace SAAPU.Data.EF.Entities
{
    public class Empresa 
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}