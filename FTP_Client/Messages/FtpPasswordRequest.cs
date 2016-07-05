namespace FTP_Client.Messages
{
    public class FtpPasswordRequest : FtpRequest
    {
        public FtpPasswordRequest(string password): base("PASS", password)
        {
        }
    }
}