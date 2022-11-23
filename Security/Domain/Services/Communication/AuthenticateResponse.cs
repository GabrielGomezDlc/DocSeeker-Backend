﻿namespace DocSeeker.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Dni { get; set; }
    public string Genre { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public string cell1 { get; set; }
    public string photo { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}
