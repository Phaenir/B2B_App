namespace FTP_Client.Messages
{
    public class FtpListRequest : FtpRequest
    {
        public FtpListRequest(string path) : base("LIST")
        {
            Arguments = new string[1];
            Arguments[0] = path.GetFtpPath();
        }
    }
}