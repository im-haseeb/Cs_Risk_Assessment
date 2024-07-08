namespace Cs_Risk_Assessment.ViewModels
{
	public class DetailRiskAssessmentDto
	{
		public string Asset { get; set; }
		public string AssetType { get; set; }
		public string ReferenceDetails { get; set; }
		public string Threats { get; set; }
		public string Vulnerabilities { get; set; }
		public string Likelihood { get; set; }
		public string Impact { get; set; }
		public string OverallRiskScore { get; set; }
	}
}
