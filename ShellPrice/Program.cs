using Newtonsoft.Json;
using System;
using RestSharp;

namespace ShellPrice
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("http://localhost:7381");
            //client.Timeout = -1;
            var request = new RestRequest("IQRetailRestAPI/v1/IQ_API_Request_Stock_Attributes?callformat=JSON", Method.Post);
            request.AddHeader("Authorization", "Basic OTk6QVBJVGVzdA==");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
                @" ""IQ_API"": {" + "\n" +
                @" ""IQ_API_Request_Stock"": {" + "\n" +
                @" ""IQ_Company_Number"": ""002""," + "\n" +
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
            Console.WriteLine(response.Content);

            dynamic res = JsonConvert.DeserializeObject(response.Content);

            request = new RestRequest("IQRetailRestAPI/v1/IQ_API_Request_Stock_Attributes?callformat=JSON", Method.Post);
            request.AddHeader("Authorization", "Basic OTk6QVBJVGVzdA==");
            request.AddHeader("Content-Type", "application/json");
            body = @"{" + "\n" +
                @" ""IQ_API"": {" + "\n" +
                @" ""IQ_API_Submit_Stock"": {" + "\n" +
                @" ""IQ_Company_Number"": ""002""," + "\n" +
                @" ""IQ_Terminal_Number"": 205," + "\n" +
                @" ""IQ_User_Number"": 205," + "\n" +
                @" ""IQ_User_Password"": ""8CB2237D0679CA88DB6464EAC60DA96345513964""," + "\n" +
                @" ""IQ_Partner_Passphrase"": ""743B25C6C57BA9A4D02EBBAD9D11B9ADC47A1BCA""," + "\n" +
                @" ""IQ_Submit_Data"": {" + "\n" +
                @" ""iq_root_json"": {" + "\n" +
                @" ""iq_identification_info"": {" + "\n" +
                @" ""company_store_id"": ""DEMO1""," + "\n" +
                // Here update company_code as "TRN"
                @" ""company_code"": ""002""," + "\n" +
                // Here update company code
                @" ""company_name"": ""Demo Trading 1""," + "\n" +
                @" ""company_address1"": ""15 STREET ADRES""," + "\n" +
                @" ""company_address2"": ""ROSSLYN NORTH WEST""," + "\n" +
                @" ""company_address3"": ""AKASIA""," + "\n" +
                @" ""company_address4"": ""PRETORIA""," + "\n" +
                @" ""company_telephone1"": ""+27 12 541 3112""," + "\n" +
                @" ""company_telephone2"": ""+27 12 542 3112""," + "\n" +
                @" ""company_fax"": ""+27 12 543 3112""," + "\n" +
                @" ""company_email"": ""demo2@afriwt.co.za""," + "\n" +
                @" ""company_tax"": ""4770233719""," + "\n" +
                @" ""company_registration_Number"": ""2007/1664442/24""," + "\n" +
                @" ""company_customs_Code"": """"" + "\n" +
                @" }," + "\n" +
                @" ""stock_master"": [{" + "\n" +
                @" ""export_class"": ""Stock""," + "\n" +
                @" ""stock_code"": ""A01DEMO0001""," + "\n" +
                @" ""barcode"": ""A01DEMO0001""," + "\n" +
                @" ""multiple_barcodes"": []," + "\n" +
                @" ""general_code"": """"," + "\n" +
                @" ""description"": ""STOCK 01""," + "\n" +
                @" ""alternative_description"": ""~Alt Description""," + "\n" +
                @" ""major_department"": ""001""," + "\n" +
                @" ""minor_department"": """"," + "\n" +
                @" ""category"": """"," + "\n" +
                @" ""range"": """"," + "\n" +
                @" ""item_category"": ""Stock Item""," + "\n" +
                @" ""use_fixed_cost"": false," + "\n" +
                @" ""cost_as_percentage_of_sell_price"": 0," + "\n" +
                @" ""pack_size"": 1," + "\n" +
                @" ""pack_description"": ""EACH""," + "\n" +
                @" ""bin_location"": """"," + "\n" +
                @" ""is_sell_price_inclusive"": false," + "\n" +
                @" ""sell_prices"": [" + "\n" +
                @" {" + "\n" +
                @" ""index"": 1," + "\n" +
                // Here Update index 1
                //@" ""inclusive"": 529," + "\n" +
                //@" ""exclusive"": 460" + "\n" +
                @" ""inclusive"": " + res.sell_prices[5].inclusive + "," + "\n" +
                @" ""exclusive"": " + res.sell_prices[5].exclusive + "\n" +
                // Here  Update index 1
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 2," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 3," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 4," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 5," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 6," + "\n" +
                // Here  Update index 6
                //@" ""inclusive"": 161," + "\n" +
                //@" ""exclusive"": 140" + "\n" +
                @" ""inclusive"": 0," + "\n" +
                @" ""exclusive"": 0" + "\n" +
                // Here  Update index 6
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 7," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 8," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 9," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }," + "\n" +
                @" {" + "\n" +
                @" ""index"": 10," + "\n" +
                @" ""inclusive"": 161," + "\n" +
                @" ""exclusive"": 140" + "\n" +
                @" }" + "\n" +
                @" ]," + "\n" +
                // Here update the average_cost 
                @" ""average_cost"": " + res.sell_prices[0].exclusive + "," + "\n" +
                // Here update the average_cost 
                @" ""minimum_level"": 2," + "\n" +
                @" ""maximum_level"": 5," + "\n" +
                @" ""reorder_level"": 2," + "\n" +
                @" ""reorder_quantity"": 5," + "\n" +
                @" ""store_serial_numbers"": false," + "\n" +
                @" ""vat_rate"": ""Normal Vat""," + "\n" +
                @" ""auto_calculation_on"": ""Never""," + "\n" +
                @" ""markup_cost_to_use"": ""Average Cost""," + "\n" +
                @" ""reporting_item"": """"," + "\n" +
                @" ""reporting_factor"": 0," + "\n" +
                @" ""modules_onhold"": []," + "\n" +
                @" ""web_item"": false," + "\n" +
                @" ""regular_supplier"": """"," + "\n" +
                @" ""mdr_supplier_id"": """"," + "\n" +
                @" ""suppliers"": []," + "\n" +
                @" ""supplier_item_code"": """"," + "\n" +
                @" ""style"": """"," + "\n" +
                @" ""colour_number"": 0," + "\n" +
                @" ""size_number"": 0," + "\n" +
                @" ""new_prices"": [" + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0," + "\n" +
                @" 0" + "\n" +
                @" ]," + "\n" +
                @" ""extended_description"": """"," + "\n" +
                @" ""notes"": """"," + "\n" +
                @" ""picture"": """"," + "\n" +
                @" ""picture_name"": """"," + "\n" +
                @" ""cashier"": 205," + "\n" +
                @" ""boxes"": 0," + "\n" +
                @" ""maximum_discount"": 0," + "\n" +
                @" ""is_section7_exempt"": false," + "\n" +
                @" ""disallow_decimals"": false," + "\n" +
                @" ""unit_of_measure"": ""Units""," + "\n" +
                @" ""line_colour_type"": 0," + "\n" +
                @" ""is_scale_item"": false," + "\n" +
                @" ""status"": """"," + "\n" +
                @" ""ordering_method"": ""Replenishment""," + "\n" +
                @" ""order_formula_number"": 0," + "\n" +
                @" ""override_grv_labels"": false," + "\n" +
                @" ""override_grv_label_quantity"": 0," + "\n" +
                @" ""abc_classification"": """"," + "\n" +
                @" ""abc_classification_gp_percentage"": 0," + "\n" +
                @" ""discount_in_modules"": []," + "\n" +
                @" ""shelf_life"": 0," + "\n" +
                @" ""document_source"": 5," + "\n" +
                @" ""enable_associated_items"": 0," + "\n" +
                @" ""exclude_grv_extra"": false," + "\n" +
                @" ""exclude_selling_value"": 0," + "\n" +
                @" ""is_batch_control"": false," + "\n" +
                @" ""default_line_sales_representative"": 0" + "\n" +
                @" }]" + "\n" +
                @" }" + "\n" +
                @" }," + "\n" +
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
