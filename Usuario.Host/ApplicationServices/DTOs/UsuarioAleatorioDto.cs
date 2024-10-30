namespace Usuario.Host.ApplicationServices.DTOs;

public class UsuarioAleatorioDto
{
    // Classes para deserializar a resposta da API
    public class RandomUserResponse
    {
        public UsuarioDto[] Results { get; set; } // Aqui você pode manter como array
        public InfoDto Info { get; set; } // Adicionando a classe Info para deserialização
    }

    public class UsuarioDto
    {
        public string Gender { get; set; }
        public NameDto Name { get; set; }
        public LocationDto Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public PictureDto Picture { get; set; }
    }

    public class NameDto
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class LocationDto
    {
        public StreetDto Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; } // Alterado para string
        public CoordinatesDto Coordinates { get; set; }
        public TimezoneDto Timezone { get; set; }
    }

    public class StreetDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class CoordinatesDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class TimezoneDto
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }

    public class PictureDto
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }

    // Classe para deserializar a seção 'info'
    public class InfoDto
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }
}
