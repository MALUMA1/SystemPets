namespace SysPet.Models
{
    public class StackedBarChartModel
    {
        public List<string> Labels { get; set; }
        public List<StackedBarDataset> Datasets { get; set; }
    }

    public class StackedBarDataset
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
    }

}
