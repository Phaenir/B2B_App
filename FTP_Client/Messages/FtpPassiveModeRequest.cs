namespace FTP_Client.Messages
{
    public class FtpPassiveModeRequest : FtpRequest
    {
        public FtpPassiveModeRequest(): base("PASV")
        {
        }
    }
}