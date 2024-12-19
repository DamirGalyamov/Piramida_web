using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Piramida_web.Features.DtoModels.Client;
using Piramida_web.Features.DtoModels.Login;
using Piramida_web.Features.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;

    public AuthController(IConfiguration configuration, IClientManager clientManager, IMapper mapper)
    {
        _configuration = configuration;
        _clientManager = clientManager;
        _mapper = mapper;
    }

    [HttpPost(nameof(Login), Name = nameof(Login))]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {

        System.Console.WriteLine(loginDto.Login);
        System.Console.WriteLine(loginDto.Password);
        // Пример проверки данных клиента (здесь можно подключить базу данных)
        var client = GetClientFromDatabase(loginDto.Login, loginDto.Password);

        if (client == null)
        {
            return Unauthorized("Неверный логин или пароль");
        }

        // Создаем токен
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, client.Email),
            new Claim("name", client.Name),
            new Claim("telephone", client.Telephone)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
            signingCredentials: creds
        );

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        });
    }

    private ClientDto GetClientFromDatabase(string login, string password)
    {
        var list = _clientManager.GetListClient(null);
        foreach (var item in list)
        {
            if (login == item.Login && password == item.Password)
            {
                return item;
            }
        }
        return null;
    }
}

public class LoginRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}
