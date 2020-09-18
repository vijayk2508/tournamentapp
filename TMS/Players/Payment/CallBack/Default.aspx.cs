using paytm;
using System;
using System.Collections.Generic;
using System.Web;

public partial class Players_Payment_CallBack_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string merchantKey = "vTwHs82Uc0dADYXa";
            Dictionary<String, String> paytmParams = new Dictionary<String, String>();
            string paytmChecksum = "";
            foreach (string key in Request.Form.Keys)
            {
                paytmParams.Add(key.Trim(), Request.Form[key].Trim());
            }
            if (paytmParams.ContainsKey("CHECKSUMHASH"))
            {
                paytmChecksum = paytmParams["CHECKSUMHASH"];
                paytmParams.Remove("CHECKSUMHASH");
            }

            bool isValidChecksum = CheckSum.verifyCheckSum(merchantKey, paytmParams, paytmChecksum);

            if (isValidChecksum)
            {
                string paytmStatus = paytmParams["STATUS"];
                string txnId = paytmParams["TXNID"];
                pTxnId.InnerText = "Transaction Id : " + txnId;
                if (paytmStatus == "TXN_SUCCESS")
                {
                    h1Message.InnerText = "Your payment is success";
                }
                else if (paytmStatus == "PENDING")
                {
                    h1Message.InnerText = "Payment is pending !";
                }
                else if (paytmStatus == "TXN_FAILURE")
                {
                    h1Message.InnerText = "Payment Failure !";
                }
                Response.Write("Checksum Match");
            }
            else
            {
                Response.Write("Checksum MisMatch");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception message: " + ex.Message.ToString());
        }

    }
}