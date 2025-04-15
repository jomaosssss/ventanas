using nuevo.Models;


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. agregas el servidor y nombre de tu base de datos
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CfepruebadosContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
                app.UseRouting();
app.UseAuthorization();
app.UseDeveloperExceptionPage();


app.MapStaticAssets();

                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Inicio}/{id?}")
                .WithStaticAssets();



            app.Run();

        