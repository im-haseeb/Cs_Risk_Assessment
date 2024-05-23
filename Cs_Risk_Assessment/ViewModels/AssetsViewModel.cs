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
}
