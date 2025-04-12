using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AnomalyPredictor.Options;

namespace AnomalyPredictor.Controllers{

[ApiController]
[Route("[controller]")]
public class AnomalyController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ApiSettings _apiSettings;

    public AnomalyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiSettings = apiSettings.Value;
    }

    [HttpPost("predict")]
    public async Task<IActionResult> Predict([FromBody] float[] features)
    {
        var json = JsonSerializer.Serialize(new { features });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = _apiSettings.Anomaly.BaseUrl + "/predict";

        var response = await _httpClient.PostAsync(url, content);
        var result = await response.Content.ReadAsStringAsync();

        return Ok(result);
    }

    public IActionResult Index()
    {
        return Content("Hello!!");
    }
}
}
