using ConfigurationName;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

    JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    var user = new User()
    {
        FirstName = "Mo",
        Address = null
    };
    var jsonResult = JsonSerializer.Serialize(user, options);

//builder.Services.Configure<Settings>(builder.Configuration.GetSection(Settings.Section));
jsonResult.ToString();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
