namespace Cs_Risk_Assessment.ViewModels
{
	public class AssetsViewModel
	{
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string Reference { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
    }

	public class AssetsViewModelWithThreats
	{
		public string AssetName { get; set; }
		public string AssetType { get; set; }
		public string Reference { get; set; }
		public string Location { get; set; }
		public string Owner { get; set; }
        public List<string> Threats { get; set; }
    }

    public class AssetsViewModelWithThreatsAndVulnerabilities
    {
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string Reference { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        public List<ThreatsWithVulnerabilities> Threats { get; set; }


    }

    public class ThreatsWithVulnerabilities
    {
        public string Threat { get; set; }
        public List<string> Vulnerabilities { get; set; }
    }




	public class FinalDataModel
	{
		public string AssetName { get; set; }
		public string AssetType { get; set; }
		public string Reference { get; set; }
		public string Location { get; set; }
		public string Owner { get; set; }
		public List<FinalThreatsWithVulnerabilities> Threats { get; set; }


	}

	public class FinalThreatsWithVulnerabilities
	{
		public string Threat { get; set; }
		public List<FinalVulnerabilitiesWithMetaData> Vulnerabilities { get; set; }
	}

	public class FinalVulnerabilitiesWithMetaData
	{
		public string Vulnerability { get; set; }
		public string LikeliHood { get; set; }
		public string Impact { get; set; }
	}

}
