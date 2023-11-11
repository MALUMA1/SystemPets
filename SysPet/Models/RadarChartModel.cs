namespace SysPet.Models
{
    public class RadarChartModel
    {
        public List<string> Labels { get; set; }
        public List<RadarDataset> Datasets { get; set; }
    }

    public class RadarDataset
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BorderColor { get; set; }
        public string BackgroundColor { get; set; }
        public int BorderWidth { get; set; }
    }

}
