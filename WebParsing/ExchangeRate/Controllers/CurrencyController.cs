using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var url = "https://uzmanpara.milliyet.com.tr/doviz-kurlari/";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[position()>1]");
            var data = nodes.Select((node) =>
            {
                return new
                {
                    Type =node.SelectSingleNode("td[2]").InnerText.ToUTF8(),
                    Purchase= decimal.Parse(node.SelectSingleNode("td[3]").InnerText),
                    Sale= decimal.Parse(node.SelectSingleNode("td[4]").InnerText),
                    Time = node.SelectSingleNode("td[6]").InnerText,
                    Status=true
                };
            });
            return Ok(data);
        }

    }
    public static class StringExtensions
    {
        public static string ToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Latin1.GetBytes(text));
        }
    }
}
