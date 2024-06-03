namespace Cs_Risk_Assessment.Models
{
	public class Assessment : BaseModel
	{
        public string Name { get; set; }
        public ICollection<Asset>? Assets { get; set; }
		public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        
	}
}
