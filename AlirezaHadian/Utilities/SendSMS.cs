namespace AlirezaHadian.Utilities
{
    public class SendSMS
    {
        public static void SendWithPattern(string date, string project, string name)
        {
            var client = new SMS.WebService2SoapClient(SMS.WebService2SoapClient.EndpointConfiguration.WebService2Soap12,
"https://portal.amootsms.com/webservice2.asmx");

            string UserName = "09397673794";
            string Password = "1274255325";
            string Mobile = "09397673794";
            int PatternCodeID = 1942;
            string[] PatternValues = new string[] { date, project, name };

            //SMS.WebService2Soap webService = new webService.WebService2SoapClient();
            //SMS.SendResult result = webService.SendWithPattern(UserName, Password, Mobile, PatternCodeID, PatternValues);

            SMS.WebService2SoapClient webService = client;

            Task<SMS.SendResult> result = client.SendWithPatternAsync(UserName, Password, Mobile, PatternCodeID, PatternValues);
        }
    }
}
