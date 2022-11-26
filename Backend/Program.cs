using System.Net.Http.Headers;
using System.Text;

#region ResharperComments

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

#endregion

#region InitialSetUp

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Initialise HttpClient Singleton
var httpClient = new HttpClient();

// Get Credentials from Env Variables
var clientId = Environment.GetEnvironmentVariable("minify_client_id");
var clientSecret = Environment.GetEnvironmentVariable("minify_client_secret");

// Warn user if Credentials are not found. Do not run the app.
if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
{
    Console.WriteLine("Unable to find credentials. Please add in the following environment variables:\n");
    Console.WriteLine("'minify_client_id' - with your Spotify Client Id");
    Console.WriteLine("'minify_client_secret' - with your Spotify Client Secret\n");
    return;
}

#endregion

#region Endpoints

app.MapGet("/callback", (string code) =>
{
    Console.WriteLine("GET: /callback");
    return $"Paste this in your Minify Client: {code}";
});


app.MapGet("/getToken", (string code, string redirect_url) =>
{
    Console.WriteLine("GET: /getToken");

    var urlPostContent = new Dictionary<string, string>
    {
        { "grant_type", "authorization_code" },
        { "code", code },
        { "redirect_uri", redirect_url }
    };

    using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
    requestMessage.Content = new FormUrlEncodedContent(urlPostContent);

    var encodedStr = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
    requestMessage.Headers.Authorization =
        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(encodedStr));

    var response = httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
    var responseContent = response.Content.ReadFromJsonAsync<AuthToken>().GetAwaiter().GetResult();

    return responseContent;
});


app.MapGet("/refreshtoken", (string refresh_token) =>
{
    Console.WriteLine("GET: /refreshtoken");

    var urlPostContent = new Dictionary<string, string>
    {
        { "grant_type", "refresh_token" },
        { "refresh_token", refresh_token }
    };

    using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
    requestMessage.Content = new FormUrlEncodedContent(urlPostContent);

    var encodedStr = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
    requestMessage.Headers.Authorization =
        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(encodedStr));

    var response = httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
    var responseContent = response.Content.ReadFromJsonAsync<AuthToken>().GetAwaiter().GetResult();
    return responseContent;
});

#endregion


#region RunApplication

Console.WriteLine("All Credentials found. Running server on port 7000");

app.Run();

#endregion


#region ResponseClass

internal class AuthToken
{
    public string? access_token { get; set; }
    public string? token_type { get; set; }
    public int? expires_in { get; set; }
    public string? scope { get; set; }
    public string? refresh_token { get; set; }
}

#endregion