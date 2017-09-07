using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Data.Entities {
    public class usuario {
        public int id {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        
        [Column("usuario")]
        public string usuario1 {get;set;}
        public bool activo {get;set;}
    }
}