using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;


public class Program
{

     public static void Main(string[] args)
     {

              new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build()
                .Run();


      }



}