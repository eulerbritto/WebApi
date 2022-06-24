namespace WebApi.Helpers;

public class AppSettings
{
    public string Secret { get; set; }
    public int TokenExpireInHours { get; set; }
}