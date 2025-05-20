using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] Parameters parameters)
        {
            // Construye la query string
            var queryParams = new List<string> { $"results={parameters.Results}" };
            if (!string.IsNullOrWhiteSpace(parameters.Gender))
                queryParams.Add($"gender={parameters.Gender}");
            if (!string.IsNullOrWhiteSpace(parameters.Nat))
                queryParams.Add($"nat={parameters.Nat}");
            if (!string.IsNullOrWhiteSpace(parameters.Seed))
                queryParams.Add($"seed={parameters.Seed}");

            var fullUrl = $"https://randomuser.me/api/?{string.Join("&", queryParams)}";

            var response = await _httpClient.GetFromJsonAsync<ApiResponse>(fullUrl);
            if (response == null || response.Results == null)
                return NotFound();

            var users = response.Results.Select(u => new UserDto
            {
                NombreCompleto = $"{u.Name.First} {u.Name.Last}",
                Genero = u.Gender,
                Ubicacion = $"{u.Location.City}, {u.Location.Country}",
                Correo = u.Email,
                FechaNacimiento = DateTime.Parse(u.Dob.Date),
                Foto = u.Picture.Large
            }).ToList();

            return Ok(users);
        }


    }
}
