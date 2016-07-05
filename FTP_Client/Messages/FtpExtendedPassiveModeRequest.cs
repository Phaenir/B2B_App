namespace FTP_Client.Messages
{
    public class FtpExtendedPassiveModeRequest : FtpRequest
    {
        public FtpExtendedPassiveModeRequest() : base("EPSV")
        {
        }
    }
}