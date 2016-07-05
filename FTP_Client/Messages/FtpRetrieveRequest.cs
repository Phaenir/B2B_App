namespace FTP_Client.Messages
{
    public class FtpRetrieveRequest : FtpRequest
    {
        public FtpRetrieveRequest(string path) : base("RETR")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}