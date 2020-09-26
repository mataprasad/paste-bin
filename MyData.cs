using System;
namespace SlaSheet
{
    public class MyData
    {
        public string City { get; set; }
        public string TboCode { get; set; }
        public string TuiCode { get; set; }
        public double? TboRate { get; set; }
        public double? TuiRate { get; set; }
    }

    public class ReportItem
    {
        public int SNo { get; set; }
        public string City { get; set; }
        public double Total { get; set; }
        public double Meet { get; set; }
        public double Beat { get; set; }
        public double Lose { get; set; }
        public double Lose_0_5 { get; set; }
        public double Lose_6_10 { get; set; }
        public double Lose_1O_N { get; set; }
        public double Meet_Per { get; set; }
        public double Beat_Per { get; set; }
        public double Lose_Per { get; set; }
        public double Lose_0_5_Per { get; set; }
        public double Lose_6_10_Per { get; set; }
        public double Lose_1O_N_Per { get; set; }
    }
}
