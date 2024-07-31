using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class FlightLogService
{
    private readonly HttpClient _httpClient;

    public FlightLogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<FlightLog>> GetFlightLogs()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<FlightLog>>("api/FlightLog");
    }

    public async Task<FlightLog> GetFlightLog(int id)
    {
        return await _httpClient.GetFromJsonAsync<FlightLog>($"api/FlightLog/{id}");
    }

    public async Task CreateFlightLog(FlightLog flightLog)
    {
        await _httpClient.PostAsJsonAsync("api/FlightLog", flightLog);
    }

    public async Task UpdateFlightLog(FlightLog flightLog)
    {
        await _httpClient.PutAsJsonAsync($"api/FlightLog/{flightLog.Id}", flightLog);
    }

    public async Task DeleteFlightLog(int id)
    {
        await _httpClient.DeleteAsync($"api/FlightLog/{id}");
    }
}

public class FlightLog
{
    public int Id { get; set; }
    public string TailNumber { get; set; }
    public string FlightID { get; set; }
    public DateTime Takeoff { get; set; }
    public DateTime Landing { get; set; }
    public TimeSpan Duration { get; set; }
}
