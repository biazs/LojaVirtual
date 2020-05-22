using System.Net;
using System.Net.Mail;
using LojaVirtual.Database;
using LojaVirtual.Libraries.CarrinhoCompra;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Libraries.Session;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();

            /*
             * SMTP
             */
            services.AddScoped<SmtpClient>(options =>
            {
                SmtpClient smtp = new SmtpClient()
                {
                    Host = Configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = Configuration.GetValue<int>("Email:ServerPort"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Configuration.GetValue<string>("Email:UserName"), Configuration.GetValue<string>("Email:Password")),
                    EnableSsl = true
                };
                return smtp;
            });

            services.AddScoped<GerenciarEmail>();
            services.AddScoped<LojaVirtual.Libraries.Cookie.Cookie>();
            services.AddScoped<CarrinhoCompra>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Session configuração
            services.AddMemoryCache();
            services.AddSession(options =>
            {

            });

            services.AddScoped<Session>();
            services.AddScoped<LojaVirtual.Libraries.Cookie.Cookie>();
            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaborador>();

            services.AddMvc(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "O campo deve ser preenchido");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LojaVirtual; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            //app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
