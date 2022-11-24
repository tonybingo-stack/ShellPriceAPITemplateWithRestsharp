using Newtonsoft.Json;
using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ShellPrice
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("http://dexprod.draas.co.za:65001");
            //client.Timeout = -1;
            var request = new RestRequest("IQRetailRestAPI/v1/IQ_API_Request_Stock_Attributes?callformat=JSON", Method.Post);
            request.AddHeader("Authorization", "Basic OTk6QVBJVGVzdA==");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
                @" ""IQ_API"": {" + "\n" +
                @" ""IQ_API_Request_Stock"": {" + "\n" +
                // Here update IQ_Company_Number as DXS
                @" ""IQ_Company_Number"": ""DXS""," + "\n" +
                // Here update IQ_Company_Number
                @" ""IQ_Terminal_Number"": 205," + "\n" +
                @" ""IQ_User_Number"": 205," + "\n" +
                @" ""IQ_User_Password"": ""8CB2237D0679CA88DB6464EAC60DA96345513964"", " + "\n" +
                @" ""IQ_Partner_Passphrase"": ""743B25C6C57BA9A4D02EBBAD9D11B9ADC47A1BCA"" " + "\n" +
                @" }" + "\n" +
                @" }" + "\n" +
                @"}" + "\n" +
                @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            //Console.WriteLine(body);

            // Here pare the response as Json so that we can use response data for second submit API.
            dynamic res = JsonConvert.DeserializeObject(response.Content);
            res = res.iq_api_result_data;
            for (int i=0;i<res.iq_root_json.stock_master.Count; i++)
            {
                // remove unneccessary fields
                res.iq_root_json.stock_master[i].Property("date_lastmoved").Remove();
                res.iq_root_json.stock_master[i].Property("date_lastpurchased").Remove();
                res.iq_root_json.stock_master[i].Property("date_lastsold").Remove();
                res.iq_root_json.stock_master[i].Property("date_lasttransferred").Remove();
                res.iq_root_json.stock_master[i].Property("previous_sellingprice").Remove();
                res.iq_root_json.stock_master[i].Property("previous_sellingprice_date").Remove();
                res.iq_root_json.stock_master[i].Property("laybye_onhand").Remove();
                res.iq_root_json.stock_master[i].Property("latest_cost").Remove();
                res.iq_root_json.stock_master[i].Property("base_cost").Remove();
                res.iq_root_json.stock_master[i].Property("previous_cost").Remove();
                res.iq_root_json.stock_master[i].Property("highest_cost").Remove();
                res.iq_root_json.stock_master[i].Property("sales_order").Remove();
                res.iq_root_json.stock_master[i].Property("purchase_order").Remove();
                res.iq_root_json.stock_master[i].Property("transfer_requests").Remove();
                res.iq_root_json.stock_master[i].Property("transfer_requests_out").Remove();
                res.iq_root_json.stock_master[i].Property("label_quantity").Remove();
                res.iq_root_json.stock_master[i].Property("work_in_progress_quantity").Remove();
                res.iq_root_json.stock_master[i].Property("created").Remove();
                res.iq_root_json.stock_master[i].Property("modified").Remove();
                res.iq_root_json.stock_master[i].Property("onhand").Remove();
                res.iq_root_json.stock_master[i].Property("onhand_available").Remove();
                res.iq_root_json.stock_master[i].Property("last_stock_take").Remove();

                // Update average_cost, index 1, index 6, 
                res.iq_root_json.stock_master[i].average_cost = res.iq_root_json.stock_master[i].sell_prices[0].exclusive;

                res.iq_root_json.stock_master[i].sell_prices[0].inclusive = res.iq_root_json.stock_master[i].sell_prices[5].inclusive;
                res.iq_root_json.stock_master[i].sell_prices[0].exclusive = res.iq_root_json.stock_master[i].sell_prices[5].exclusive;

                res.iq_root_json.stock_master[i].sell_prices[5].inclusive = 0;
                res.iq_root_json.stock_master[i].sell_prices[5].exclusive = 0;
            }

            request = new RestRequest("IQRetailRestAPI/v1/IQ_API_Request_Stock_Attributes?callformat=JSON", Method.Post);
            request.AddHeader("Authorization", "Basic OTk6QVBJVGVzdA==");
            request.AddHeader("Content-Type", "application/json");
            body = @"{" + "\n" +
                @" ""IQ_API"": {" + "\n" +
                @" ""IQ_API_Submit_Stock"": {" + "\n" +
                // Here update IQ_Company_Number as TRN
                @" ""IQ_Company_Number"": ""TRN""," + "\n" +
                // Here update IQ_Company_Number
                @" ""IQ_Terminal_Number"": 205," + "\n" +
                @" ""IQ_User_Number"": 205," + "\n" +
                @" ""IQ_User_Password"": ""8CB2237D0679CA88DB6464EAC60DA96345513964""," + "\n" +
                @" ""IQ_Partner_Passphrase"": ""743B25C6C57BA9A4D02EBBAD9D11B9ADC47A1BCA""," + "\n" +
                @" ""IQ_Submit_Data"": " +
                res.ToString() +
                @"," + "\n" +
                @" ""IQ_Overrides"": [""imeDuplicateCode""]" + "\n" +
                @" }" + "\n" +
                @" }" + "\n" +
                @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);

            Console.WriteLine(response.Content);
        }
    }
}
