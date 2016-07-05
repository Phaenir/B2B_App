namespace FTP_Client.Messages
{
    public class FtpSetDirectoryRequest : FtpRequest
    {
        public FtpSetDirectoryRequest(string directory) : base("CWD")
        {
            Arguments = new string[1];
            Arguments[0] = directory.GetFtpPath();
        }
    }
}