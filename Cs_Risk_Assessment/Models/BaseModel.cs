using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Cs_Risk_Assessment.Models
{
	public class BaseModel
	{
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
