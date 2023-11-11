namespace SysPet.Models
{
    public class DoughnutChartModel
    {
        public List<DoughnutDataset> Datasets { get; set; }
    }

    public class DoughnutDataset
    {
        public List<int> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> HoverBackgroundColor { get; set; }
    }

}
