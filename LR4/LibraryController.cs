using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

[Route("[controller]")]
public class LibraryController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public LibraryController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Welcome to the Library!");
    }

    [HttpGet("Books")]
    public IActionResult GetBooks()
    {
        var books = _configuration.GetSection("Books").Get<List<string>>();
        return Ok(books);
    }

    [HttpGet("Profile/{id?}")]
    public IActionResult GetProfile(int? id)
    {
        if (id.HasValue && id >= 0 && id <= 5)
        {
         
            var userInfo = _configuration.GetSection($"Profiles:{id}").Get<string>();
            return Ok(userInfo);
        }

        var currentUserInfo = _configuration.GetSection("CurrentUser").Get<string>();
        return Ok(currentUserInfo);
    }
}
