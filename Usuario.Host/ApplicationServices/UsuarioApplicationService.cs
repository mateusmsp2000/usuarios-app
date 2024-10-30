using System.Text.Json;
using Usuario.Domain.Services.DTOs;

namespace Usuario.Host.ApplicationServices;

public class UsuarioApplicationService : IUsuarioApplicationService
{
    private readonly HttpClient _httpClient;

    public UsuarioApplicationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UsuarioAleatorioDto.UsuarioDto?> ObterUsuarioAleatorio()
    {
        var response = await _httpClient.GetAsync("https://randomuser.me/api/");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse); // Verifique a resposta JSON

        var randomUserResponse = JsonSerializer.Deserialize<UsuarioAleatorioDto.RandomUserResponse>(jsonResponse,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Isso permite que a deserialização seja feita sem se preocupar com maiúsculas/minúsculas
            });

        return randomUserResponse?.Results.FirstOrDefault(); // Retorna o primeiro usuário ou null
    }


}