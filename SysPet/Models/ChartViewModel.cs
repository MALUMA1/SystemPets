namespace SysPet.Models
{
    public class ChartViewModel
    {
        public List<string> Labels { get; set; }
        public List<int> Values { get; set; }
        public StackedBarChartModel StackedBarChart { get; set; }
        public PieChartViewModel PieChart { get; set; }
        public MultiLineChartModel MultiLineChart { get; set; }
        public RadarChartModel RadarChart { get; set; }
        public BubbleChartModel BubbleChart { get; set; }
        public DoughnutChartModel DoughnutChart { get; set; }
    }
}
