namespace BackendTask.Security
{
    public class JwtToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }

}
