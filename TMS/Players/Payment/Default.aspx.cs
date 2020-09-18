using paytm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

public partial class Players_Payment_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Payment();
    }


    private void Payment()
    {
        try
        {
            String merchantMid = "gTLiAh52801463280885";
            String merchantKey = "vTwHs82Uc0dADYXa";
            string orderId = "order12345678900000";
            string channelId = "WEB";
            string custId = "cust123";
            string mobileNo = "7983868472";
            string email = "vickyk25021997@gmail.com";
            string txnAmount = "100";
            string website = "DEFAULT";
            // This is the staging value. Production value is available in your dashboard
            string industryTypeId = "Retail";
            string callbackURL = "http://dev.pubgtournament.com/Players/Payment/CallBack/Default.aspx";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "MID", merchantMid },
                { "CHANNEL_ID", channelId },
                { "INDUSTRY_TYPE_ID", industryTypeId },
                { "WEBSITE", website },
                { "EMAIL", email },
                { "MOBILE_NO", mobileNo },
                { "CUST_ID", custId },
                { "ORDER_ID", orderId },
                { "TXN_AMOUNT", txnAmount },
                { "REQUEST_TYPE", "DEFAULT"},
                { "PAYMENT_MODE_ONLY", "Yes"},
                { "CALLBACK_URL", callbackURL } //This parameter is not mandatory. Use this to pass the callback url dynamically.
            };

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);
            parameters.Add("CHECKSUMHASH", checksum);
            string paytmURL= "https://securegw.paytm.in/theia/processTransaction?orderid=" + orderId;

            // string transactionURL = "https://securegw-stage.paytm.in/theia/processTransaction";
            // for production 
            // string transactionURL = "https://securegw.paytm.in/theia/processTransaction"; 

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += " <meta http-equiv='Content-Type' content='text/html; charset =ISO-8859-1'>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
        }
        catch (Exception ex)
        {
            Response.Write("Exception message: " + ex.Message.ToString());
        }

        
        /*
        //String transactionURL = "https://securegw.paytm.in/merchant-status/getTxnStatus";
        String merchantMid = "gTLiAh52801463280885";
        String merchantKey = "vTwHs82Uc0dADYXa";
        String orderId = "order1";
        String transactionURL = "https://securegw.paytm.in/theia/processTransaction?orderid=" + orderId;
        String txnAmount = "100";
        Dictionary<String, String> paytmParams = new Dictionary<String, String>();
        paytmParams.Add("MID", merchantMid);
        paytmParams.Add("ORDERID", orderId);
        paytmParams.Add("TXN_AMOUNT", txnAmount);
        try
        {
            string paytmChecksum = paytm.CheckSum.generateCheckSum(merchantKey, paytmParams);
            paytmParams.Add("CHECKSUMHASH", paytmChecksum);
            String postData = "JsonData=" + new JavaScriptSerializer().Serialize(paytmParams);
            HttpWebRequest connection = (HttpWebRequest)WebRequest.Create(transactionURL);
            connection.Headers.Add("ContentType", "application/json");
            connection.Method = "POST";
            using (StreamWriter requestWriter = new StreamWriter(connection.GetRequestStream()))
            {
                requestWriter.Write(postData);
            }
            string responseData = string.Empty;
            using (StreamReader responseReader = new StreamReader(connection.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
                Response.Write(responseData);
                Response.Write("Requested Json= " + postData);
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception message: " + ex.Message.ToString());
        }*/
    }

}