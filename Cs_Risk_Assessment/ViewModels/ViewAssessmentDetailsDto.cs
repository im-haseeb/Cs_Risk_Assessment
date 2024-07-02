namespace Cs_Risk_Assessment.ViewModels
{
    public class ViewAssessmentDetailsDto
    {
        public int ThreatsCount { get; set; }
        public Top5Risks? Top5Risks { get; set; }
        public Top5Vul? Top5Vul { get; set; }
    }

    public class Top5Vul
    {
        public string name1 { get; set; }
        public int usage1 { get; set; }
        public string name2 { get; set; }
        public int usage2 { get; set; }
        public string name3 { get; set; }
        public int usage3 { get; set; }
        public string name4 { get; set; }
        public int usage4 { get; set; }
        public string name5 { get; set; }
        public int usage5 { get; set; }
    }

    public class Top5Risks
    {
        public string name1 { get; set; }
        public int usage1 { get; set; }
        public string name2 { get; set; }
        public int usage2 { get; set; }
        public string name3 { get; set; }
        public int usage3 { get; set; }
        public string name4 { get; set; }
        public int usage4 { get; set; }
        public string name5 { get; set; }
        public int usage5 { get; set; }
    }
}
