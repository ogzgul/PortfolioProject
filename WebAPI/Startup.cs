using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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

            services.AddControllers();
            services.AddSingleton<IAboutService, AboutManager>();
            services.AddSingleton<IAboutDal, EfAboutDal>();
            services.AddSingleton<IAnnouncementService, AnnouncementManager>();
            services.AddSingleton<IAnnouncementDal, EfAnnouncementDal>();
            services.AddSingleton<IContactService, ContactManager>();
            services.AddSingleton<IContactDal, EfContactDal>();
            services.AddSingleton<IExperienceService, ExperienceManager>();
            services.AddSingleton<IExperienceDal, EfExperienceDal>();
            services.AddSingleton<IFeatureService, FeatureManager>();
            services.AddSingleton<IFeatureDal, EfFeatureDal>();
            services.AddSingleton<IMessageService, MessageManager>();
            services.AddSingleton<IMessageDal, EfMessageDal>();
            services.AddSingleton<IPortfolioService, PortfolioManager>();
            services.AddSingleton<IPortfolioDal, EfPortfolioDal>();
            services.AddSingleton<IServiceService, ServiceManager>();
            services.AddSingleton<IServiceDal, EfServiceDal>();
            services.AddSingleton<ISkillService, SkillManager>();
            services.AddSingleton<ISkillDal, EfSkillDal>();
            services.AddSingleton<ISocialMediaService, SocialMediaManager>();
            services.AddSingleton<ISocialMediaDal, EfSocialMediaDal>();
            services.AddSingleton<ITestimonialService, TestimonialManager>();
            services.AddSingleton<ITestimonialDal, EfTestimonialDal>();
            services.AddSingleton<ITodoListService, TodoListManager>();
            services.AddSingleton<ITodoListDal, EfTodoListDal>();
            services.AddSingleton<IWriterMessageService, WriterMessageManager>();
            services.AddSingleton<IWriterMessageDal, EfWriterMessageDal>();
            services.AddSingleton<IWriterUserService, WriterUserManager>();
            services.AddSingleton<IWriterUserDal, EfWriterUserDal>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}