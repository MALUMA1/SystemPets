namespace SysPet.Models
{
    public class MultiLineChartModel
    {
        public List<string> Labels { get; set; }
        public List<LineDataset> Datasets { get; set; }
    }

    public class LineDataset
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BorderColor { get; set; }
        public int BorderWidth { get; set; }
    }

}
