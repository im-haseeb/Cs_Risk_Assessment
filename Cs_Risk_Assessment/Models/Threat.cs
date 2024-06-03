namespace Cs_Risk_Assessment.Models
{
	public class Threat : BaseModel
	{
        public string Name { get; set; }
		public List<string> Vulnerabilities { get; set; }

		public Guid? AssetId { get; set; }
		public Asset? Asset { get; set; }
    }
}
