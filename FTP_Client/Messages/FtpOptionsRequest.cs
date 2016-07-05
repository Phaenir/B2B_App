namespace FTP_Client.Messages
{
    public class FtpOptionsRequest : FtpRequest
    {
        public FtpOptionsRequest(string option) : base("OPTS", option)
        {
            
        }
    }
}