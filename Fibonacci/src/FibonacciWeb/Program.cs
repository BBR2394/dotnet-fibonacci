using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FibonacciWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app => {
                    app.UseRouting(); app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/Fibonacci",
                            async context =>
                            {
                                await context.Response.WriteAsync(
                                    JsonSerializer.Serialize(Fibonacci.Fibonacci.Compute(new []{"44", "43"}))); });
                    }); });
            }); 
        }
}
