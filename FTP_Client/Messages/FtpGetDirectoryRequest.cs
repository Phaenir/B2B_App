namespace FTP_Client.Messages
{
    public class FtpGetDirectoryRequest : FtpRequest
    {
        public FtpGetDirectoryRequest() : base("PWD")
        {
        }
    }
}