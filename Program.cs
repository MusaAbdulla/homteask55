namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();
            app.MapControllerRoute(
         name: "default",
         pattern: "{controller=Taskcontroller}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
//Vallah Billah Erroru Hell ede bilmedim yoxsa axira cixacagdim((((((
