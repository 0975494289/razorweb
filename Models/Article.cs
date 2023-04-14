using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace entity.models
{
    public class Article
    {
        [Key]
        public int Id {set;get;}

        [StringLength(255)]
        [Required]
        [DataType(DataType.Text)]
        public string Title {set;get;}

        [DataType(DataType.Date)]
        [Required]
        public DateTime Created {set;get;}

        [DataType(DataType.Text)]
        [Required]
        public string Content {set;get;}
    }
}