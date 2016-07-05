namespace FTP_Client.Messages
{
    public class FtpDeleteFileRequest : FtpRequest
    {
        public FtpDeleteFileRequest(string path): base("DELE")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}
