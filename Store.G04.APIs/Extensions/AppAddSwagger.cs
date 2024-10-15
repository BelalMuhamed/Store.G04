namespace Store.G04.APIs.Extensions
{
    public static  class AppAddSwagger
    {
        public static WebApplication AddSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
