
namespace MedicionHumedad.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using MedicionHumedad.Models;
    using MedicionHumedad.Data.Models;
    using MedicionHumedad.Data.UnitofWork;
    using MedicionHumedad.Business.Service;
    using Microsoft.EntityFrameworkCore;
    using MedicionHumedad.Data.Entity;

    public class Startup
    {
        private readonly IHostingEnvironment _currentEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _currentEnvironment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DB service
            services.AddDbContext<MedicionHumedadDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:MedicionHumedadDB"]));
            var options = services.BuildServiceProvider()
                    .GetRequiredService<DbContextOptions<MedicionHumedadDBContext>>();

            


            //using (var dbContext = new MedicionHumedadDBContext(options))
            //{
            //    var model = dbContext.Model; //force the model creation
            //}

            //Task.Run(() =>
            //{
            //    using (var dbContext = new SamplitDBContext(options))
            //    {
            //        var model = dbContext.Model; //force the model creation
            //    }
            //});


            #region Configuration


            //services.Configure<JwtSamplitAuthentication>(Configuration.GetSection("JwtSamplitAuthentication"));

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #endregion


            // include support for CORS
            // More often than not, we will want to specify that our API accepts requests coming from other origins (other domains). When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests (to improve security).
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy-public",
                    builder => builder.WithOrigins(
                        "https://MedicionHumedad.azurewebsites.net", "http://localhost:4200",
                        "http://localhost:20000", "http://localhost:21000",
                        "http://localhost:22000", "http://localhost:23000",
                        "http://localhost:24000", "http://localhost:25000",
                        "http://localhost:50000", "http://localhost:51000",
                        "http://localhost:52000", "http://localhost:53000",
                        "http://localhost:54000", "http://localhost:55000",
                        "http://localhost:33087", "https://samplitapi.azurewebsites.net")   // WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build()
                    );
            });


            // MVC service
            services.AddMvc();
            services.AddSignalR();

            #region "DI code"


            // General UnitOfWork injections
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddTransient<DbContext>(sp => sp.GetService<MedicionHumedadDBContext>());


            // Services injections

            services.AddScoped(typeof(ISensorServiceAsync), typeof(SensorServiceAsync));
            services.AddScoped(typeof(IFrutoServiceAsync), typeof(FrutoAsync));
            services.AddScoped(typeof(IMedicionServiceAsync), typeof(MedicionServiceAsync));
            services.AddScoped(typeof(IRolServiceAsync), typeof(RolServiceAsync));
            services.AddScoped(typeof(IUsuarioServiceAsync), typeof(UsuarioServiceAsync));
            services.AddScoped(typeof(IPlantacionServiceAsync), typeof(PlantacionServiceAsync));


            //...add other services

            //services.AddScoped(typeof(IService<,>), typeof(GenericService<,>));
            //services.AddScoped(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));

            #endregion

            #region AutoMapper configuration
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                CreateMap(mc);
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            //data mapper profiler setting
            //Mapper.Initialize((config) => config.AddProfile<MappingProfile>());
            #endregion

            // Swagger API documentation
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Samplit API", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT Bearer into field", Name = "Authorization", Type = "apiKey" });
            //    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>{
            //        { "Bearer", Enumerable.Empty<string>() },
            //    });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My Api API", Version = "v1" });

            });
        }


        private static void CreateMap(IMapperConfigurationExpression mc)
        {
            var vms = typeof(BaseViewModel).Assembly.GetTypes()?.ToList()
                .Where(vm => typeof(BaseViewModel).IsAssignableFrom(vm)).ToList();

            var entities = typeof(BaseModel).Assembly.GetTypes()?.ToList()
                .Where(vm => typeof(BaseModel).IsAssignableFrom(vm)).ToList();

            entities.Where(e => vms.Select(v => v.Name).Any(n => n == e.Name + "ViewModel")).ToList().ForEach(e =>
            {
                var vm = vms.First(v => v.Name == e.Name + "ViewModel");
                mc.CreateMap(e, vm);
                mc.CreateMap(vm, e);
            });
            //mc.CreateMap<UserRole, UserRoleViewModel>();
            //mc.CreateMap<UserRoleViewModel, UserRole>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            app.UseMiddleware<ExceptionHandler>();
            //}

            app.UseAuthentication(); // needs to be up in the pipeline, before MVC


            app.UseCors("CorsPolicy-public");  // apply to every request
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            app.UseStaticFiles();
            // Swagger API documentation
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicionHumedad API V1");
            });
        }
    }
}