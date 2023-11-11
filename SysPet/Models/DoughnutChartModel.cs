namespace SysPet.Models
{
    public class DoughnutChartModel
    {
        public List<DoughnutDataset> Datasets { get; set; }
        public List<string> Labels { get; set; }
    }

    public class ProductExpiredChartModel
    {
        public List<DoughnutDataset> Datasets { get; set; }
        public List<string> Labels { get; set; }
    }

    public class ProductInStockChartModel
    {
        public List<DoughnutDataset> Datasets { get; set; }
        public List<string> Labels { get; set; }
    }

    public class DoughnutDataset
    {
        public List<int> Data { get; set; }
        
        public List<string> BackgroundColor { get; set; }
        public List<string> HoverBackgroundColor { get; set; }
    }

}
