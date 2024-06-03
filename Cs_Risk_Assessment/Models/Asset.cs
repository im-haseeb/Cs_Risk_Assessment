namespace Cs_Risk_Assessment.Models
{
	public class Asset : BaseModel
	{
		public string? Name { get; set; }
		public string? Type { get; set; }
		public string? Reference { get; set; }
		public string? Location { get; set; }
		public string? Owner { get; set; }
		public Guid? AssessmentId { get; set; }
		public Assessment? Assessment { get; set; }
		public ICollection<Threat>? Threats { get; set; }=  new List<Threat>();
	}
}
