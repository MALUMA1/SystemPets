using Microsoft.AspNetCore.Mvc;
using SysPet.Exception;
using SysPet.Models;
using System.Diagnostics;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("User");
            ViewBag.User = user;

            var model = new ChartViewModel
            {
                Labels = new List<string> { "January", "February", "March", "April", "May", "June" },
                Values = new List<int> { 10, 20, 15, 25, 30, 22 }
            };

            var stackedBar = new StackedBarChartModel
            {
                Labels = new List<string> { "January", "February", "March", "April", "May", "June" },
                Datasets = new List<StackedBarDataset>
                {
            new StackedBarDataset
            {
                Label = "Dataset 1",
                Data = new List<int> { 10, 20, 15, 25, 30, 22 },
                BackgroundColor = "rgba(75, 192, 192, 0.5)"
            },
            new StackedBarDataset
            {
                Label = "Dataset 2",
                Data = new List<int> { 5, 15, 10, 20, 25, 18 },
                BackgroundColor = "rgba(255, 99, 132, 0.5)"
            }
        }
            };

            var pieChart = new PieChartViewModel
            {
                Labels = new List<string> { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" },
                Data = new List<int> { 10, 20, 15, 25, 30, 22 },
                BackgroundColors = new List<string>
        {
            "rgba(255, 99, 132, 0.5)",
            "rgba(54, 162, 235, 0.5)",
            "rgba(255, 206, 86, 0.5)",
            "rgba(75, 192, 192, 0.5)",
            "rgba(153, 102, 255, 0.5)",
            "rgba(255, 159, 64, 0.5)"
        }
            };



            var multiLineChartModel = new MultiLineChartModel
            {
                Labels = new List<string> { "January", "February", "March", "April", "May", "June" },
                Datasets = new List<LineDataset>
        {
            new LineDataset
            {
                Label = "Dataset 1",
                Data = new List<int> { 10, 20, 15, 25, 30, 22 },
                BorderColor = "rgba(75, 192, 192, 1)",
                BorderWidth = 2
            },
            new LineDataset
            {
                Label = "Dataset 2",
                Data = new List<int> { 5, 15, 10, 20, 25, 18 },
                BorderColor = "rgba(255, 99, 132, 1)",
                BorderWidth = 2
            }
        }
            };

            var radarChart = new RadarChartModel
            {
                Labels = new List<string> { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" },
                Datasets = new List<RadarDataset>
        {
            new RadarDataset
            {
                Label = "Dataset 1",
                Data = new List<int> { 65, 59, 90, 81, 56, 55, 40 },
                BorderColor = "rgba(75, 192, 192, 1)",
                BackgroundColor = "rgba(75, 192, 192, 0.2)",
                BorderWidth = 2
            },
            new RadarDataset
            {
                Label = "Dataset 2",
                Data = new List<int> { 28, 48, 40, 19, 96, 27, 100 },
                BorderColor = "rgba(255, 99, 132, 1)",
                BackgroundColor = "rgba(255, 99, 132, 0.2)",
                BorderWidth = 2
            }
        }
            };

            var bubbleChart = new BubbleChartModel
            {
                Datasets = new List<BubbleDataset>
            {
                new BubbleDataset
                {
                    Label = "Dataset 1",
                    Data = GenerateRandomData(10),
                    BackgroundColor = "rgba(255, 99, 132, 0.5)"
                },
                new BubbleDataset
                {
                    Label = "Dataset 2",
                    Data = GenerateRandomData(10),
                    BackgroundColor = "rgba(54, 162, 235, 0.5)"
                }
            }
            };

            var doughnutChart = new DoughnutChartModel
            {
                Datasets = new List<DoughnutDataset>
        {
            new DoughnutDataset
            {
                Data = new List<int> { 30, 40, 30 },
                BackgroundColor = new List<string> { "rgba(255, 99, 132, 0.5)", "rgba(54, 162, 235, 0.5)", "rgba(255, 206, 86, 0.5)" },
                HoverBackgroundColor = new List<string> { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)" }
            }
        }
            };

            model.StackedBarChart = stackedBar;
            model.PieChart = pieChart;
            model.MultiLineChart = multiLineChartModel;
            model.RadarChart = radarChart;
            model.BubbleChart = bubbleChart;
            model.DoughnutChart = doughnutChart;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View();
        }

        private List<BubbleData> GenerateRandomData(int count)
        {
            var random = new Random();
            var data = new List<BubbleData>();

            for (int i = 0; i < count; i++)
            {
                data.Add(new BubbleData
                {
                    X = random.Next(1, 100),
                    Y = random.Next(1, 100),
                    Radius = random.Next(5, 20)
                });
            }

            return data;
        }
    }
}