namespace FTP_Client.Messages
{
    public class FtpUserRequest : FtpRequest
    {
        public FtpUserRequest(string userName) : base("USER", userName)
        {
        }
    }
}