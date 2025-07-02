using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

class ApiManager
{
    private static readonly HttpClient client = new HttpClient();

    public static string Post(string endpoint, object body)
    {
        var url = $"{EnviromentData.EnvVar("HOST")}{endpoint}";
        var json = JsonConvert.SerializeObject(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = client.PostAsync(url, content).Result;
        return response.Content.ReadAsStringAsync().Result;
    }
}