namespace Cs_Risk_Assessment.ViewModels
{
    public class ViewAssessmentDetailsDto
    {
        public bool HasValue { get; set; } = false;
        public int CriticalCount { get; set; }
        public int HighCount { get; set; }
        public int ThreatsCount { get; set; }
        public List<Top5Vul>? Top5Vuls { get; set; }
        public List<Top5Threat>? top5Threats { get; set; }
    }

    public class Top5Vul
    {
        public string name { get; set; }
        public int usage { get; set; }
        //public string name2 { get; set; }
        //public int usage2 { get; set; }
        //public string name3 { get; set; }
        //public int usage3 { get; set; }
        //public string name4 { get; set; }
        //public int usage4 { get; set; }
        //public string name5 { get; set; }
        //public int usage5 { get; set; }
    }

    public class Top5Threat
    {
        public string name { get; set; }
        public int usage { get; set; }
        //public string name2 { get; set; }
        //public int usage2 { get; set; }
        //public string name3 { get; set; }
        //public int usage3 { get; set; }
        //public string name4 { get; set; }
        //public int usage4 { get; set; }
        //public string name5 { get; set; }
        //public int usage5 { get; set; }
    }
}
