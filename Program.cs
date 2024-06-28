using Onboarding.Api.MockService;
using Onboarding.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
var openAiApiKey = "";
var openAiService = new OpenAIService1(openAiApiKey);
var webInfoService = new WebsiteInfoService(openAiService);
//builder.Services.AddSingleton(new OpenAIService(openAiApiKey));
builder.Services.AddSingleton(webInfoService);
builder.Services.AddSingleton(new OnboardingService(openAiService, new BusinessRevenueService(), new MccMockService(), new CompanyHouseMockService(), webInfoService));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
