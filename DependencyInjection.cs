using System.Text.Json.Serialization;
using BasicDBWebApp.MyDbContext;
using BasicDBWebApp.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp
{
    public class DependencyInjection
    {
        public static void ConfigureServices(
            IServiceCollection services,
            string connectionString)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //own additions
            services.AddControllers();
                //.AddJsonOptions(options =>
                //{
                //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                //});
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IStudentCourseService, StudentCourseService>();
        }
    }
}
