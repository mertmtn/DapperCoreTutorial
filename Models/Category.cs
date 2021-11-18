using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("Categories")]
    public class Category: IEntity
    {   
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; } 
    }
}
