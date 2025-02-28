using MagicVIllaApp.Utility;

namespace MagicVIllaApp.Models;

public class ApiRequest
{
    public StaticFilesApiType.ApiType ApiType { get; set; }
    public string Url { get; set; }
    public object Data { get; set; }
}