namespace FTP_Client.Messages
{
    public class FtpFeaturesRequest : FtpRequest
    {
        public FtpFeaturesRequest(): base("FEAT")
        {
        }
    }
}