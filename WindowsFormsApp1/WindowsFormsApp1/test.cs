
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    class test
    {
        static string url = "https://m.esteelauder.com/rpc/jsonrpc.tmpl?JSONRPC=[{%22method%22:%22offers.query%22,%22params%22:[{%22format_for%22:%22mustache%22,%22view%22:%22loyalty_gwp_offers%22}],%22id%22:4}]";
        public static void main()
        {
            string result = HttpUtils.HttpGet(url, "");
            Console.WriteLine(result);
            dynamic json = JsonConvert.DeserializeObject<dynamic>(result);

            Console.WriteLine(json[0].result.value.offers[0].benefit_fields.ChoiceOfSkus.choicesPcatData.Count);


        }
    }
}