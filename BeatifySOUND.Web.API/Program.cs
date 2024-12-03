using BeautifySOUND.Web.API;



var host = CreateHostBuilder(args).Build();
host.Run();
static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
//var builder = WebApplication.CreateBuilder(args);

//// получаем строку подключения из файла конфигурации

//// добавляем контекст ApplicationContext в качестве сервиса в приложение


//builder.Services.AddControllers();


//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


