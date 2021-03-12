using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLesson.Models
{
   // [Table("products")]
    public class Product : Entity
    {
        //[Column("name")]
        //[Required]
        //[StringLength(25)]        
        public string Name { get; set; }
        public virtual ICollection<ProductDish> ProductDishes { get; set; }
        //[ForeignKey("Dish")]
        //[Column("dishId ")]
        //public Guid DishId { get; set; }
        //public Dish Dish { get; set; }
    }
}
