using System.Text.Json;
using Microsoft.Extensions.Options;
using Usuario.Host.ApplicationServices.DTOs;
using Usuario.Host.DTOs;

namespace Usuario.Host.ApplicationServices;

public class UsuarioApplicationService : IUsuarioApplicationService
{
    private readonly HttpClient _httpClient;
    private readonly string? _randomUserApiUrl;

    public UsuarioApplicationService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _randomUserApiUrl = configuration["RandomUserApiUrl"];
    }

    public async Task<UsuarioAleatorioDto.UsuarioDto?> ObterUsuarioAleatorio()
    {
        var response = await _httpClient.GetAsync(_randomUserApiUrl);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var randomUserResponse = JsonSerializer.Deserialize<UsuarioAleatorioDto.RandomUserResponse>(jsonResponse,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });

        return randomUserResponse?.Results.FirstOrDefault(); 
    }


}