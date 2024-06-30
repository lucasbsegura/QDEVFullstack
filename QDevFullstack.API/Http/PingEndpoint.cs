namespace QDevFullstack.API.Http
{
    public static class PingEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/ping", () => "pong!");
        }
    }
}