namespace SysPet.Models
{
    public class BubbleChartModel
    {
        public List<BubbleDataset> Datasets { get; set; }
    }

    public class BubbleDataset
    {
        public List<BubbleData> Data { get; set; }
        public string Label { get; set; }
        public string BackgroundColor { get; set; }
    }

    public class BubbleData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
    }

}
