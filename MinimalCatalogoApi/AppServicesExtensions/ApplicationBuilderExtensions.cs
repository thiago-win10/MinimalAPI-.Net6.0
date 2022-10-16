namespace MinimalCatalogoApi.AppServicesExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app,
            IWebHostEnvironment enviroment)
        {
            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            return app;
        }
        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.WithMethods();
                p.AllowAnyHeader();

            });
            return app;
        }
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {});
            return app;
        }


    }
}
