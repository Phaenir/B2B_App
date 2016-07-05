namespace FTP_Client.Messages
{
    public class FtpQuitRequest : FtpRequest
    {
        public FtpQuitRequest(): base("QUIT")
        {
        }
    }
}