using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdrParser.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SlaSheet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<ReportItem> ReportItems { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var data = CsvFile.Read<MyData>(new CsvSource("/Users/chauhan/Desktop/Book11.csv")).ToList();

            this.ReportItems = data.GroupBy(P => P.City).Select(G =>
            {
                double totalCount = G.Count();
                var obj = new ReportItem()
                {
                    SNo = 1,
                    City = G.Key,
                    Total = totalCount,
                    Meet = G.Count(P => P.TuiRate == P.TboRate),
                    Beat = G.Count(P => P.TuiRate > P.TboRate),
                    Lose = G.Count(P => P.TuiRate < P.TboRate),
                    Lose_0_5 = G.Count(P =>
                    {
                        var t = (P.TboRate - P.TuiRate) / P.TuiRate;
                        return t > 0 && t <= 5;
                    }),
                    Lose_6_10 = G.Count(P =>
                    {
                        var t = (P.TboRate - P.TuiRate) / P.TuiRate;
                        return t > 5 && t <= 10;
                    }),
                    Lose_1O_N = G.Count(P =>
                    {
                        var t = (P.TboRate - P.TuiRate) / P.TuiRate;
                        return t > 10;
                    }),
                    Meet_Per = 0d,
                    Beat_Per = 0,
                    Lose_Per = 0,
                    Lose_0_5_Per = 0,
                    Lose_6_10_Per = 0,
                    Lose_1O_N_Per = 0,
                };

                obj.Meet_Per = Math.Ceiling(obj.Meet / totalCount * 100);
                obj.Beat_Per = Math.Ceiling(obj.Beat / totalCount * 100);
                obj.Lose_Per = Math.Ceiling(obj.Lose / totalCount * 100);
                obj.Lose_0_5_Per = Math.Ceiling(obj.Lose_0_5 / obj.Lose * 100);
                obj.Lose_6_10_Per = Math.Ceiling(obj.Lose_6_10 / obj.Lose * 100);
                obj.Lose_1O_N_Per = Math.Ceiling(obj.Lose_1O_N / obj.Lose * 100);

                return obj;

            }).ToList();
        }
    }
}
