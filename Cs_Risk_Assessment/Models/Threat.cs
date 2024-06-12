namespace Cs_Risk_Assessment.Models
{
	public class Threat : BaseModel
	{
        public string Name { get; set; }
		public ICollection<Vulnerability> Vulnerabilities { get; set; } = new List<Vulnerability>();

		public Guid? AssetId { get; set; }
		public Asset? Asset { get; set; }
    }
}
