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
        public InternmentChartViewModel InternmentChart { get; set; }
        public AppointmentChartViewModel AppointmentChart { get; set; }
        public ProductChartViewModel ProductChart { get; set; }
        public ProductExpiredChartModel ProductExpiredChart { get; set; }
        public ProductInStockChartModel ProductInStockChart { get; set; }
    }

    public class InternmentChartViewModel
    {
        public List<string> Labels { get; set; }
        public List<int> Values { get; set; }
    }

    public class AppointmentChartViewModel
    {
        public List<string> Labels { get; set; }
        public List<int> Values { get; set; }
    }

    public class ProductChartViewModel
    {
        public List<string> Labels { get; set; }
        public List<int> Values { get; set; }
    }
}
