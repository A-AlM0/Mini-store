using System.ComponentModel.DataAnnotations;

namespace mini_store.Models
{
    public class Products
    {
        [Key]
        public int Id {get; set;}
        
        public string Name {get; set;}

        public float Price { get; set; }
        
        public string Image {get; set;}
    }
}
