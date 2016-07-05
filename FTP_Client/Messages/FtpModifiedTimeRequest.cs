namespace FTP_Client.Messages
{
    public class FtpModifiedTimeRequest : FtpRequest
    {
        public FtpModifiedTimeRequest(string filePath) : base("MDTM")
        {
            Arguments = new string[1];
            Arguments[0] = filePath.GetFtpPath();
        }
    }
}