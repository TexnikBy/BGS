using BGS.Api;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(
        webBuilder =>
        {
            webBuilder
                .UseStartup<Startup>()
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "client_dist"));
        })
    .Build()
    .Run();