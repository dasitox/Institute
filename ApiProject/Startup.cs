using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.EFModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiProject.Serivices;
using ApiProject.Models;

namespace ApiProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<IadesContext>(options =>
            {
                options.UseSqlServer(@"Server=.\sqlexpress;Database=Iades;Trusted_Connection=true");
            });

            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();         
            
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Student, StudentsDTO>();
                config.CreateMap<Teacher, TeachersDTO>();
                config.CreateMap<StudentsDTO, Student>();
                config.CreateMap<TeachersDTO, Teacher>();
                config.CreateMap<ViewStudentDTO, Student>();
                config.CreateMap<Student, ViewStudentDTO>();
                config.CreateMap<Teacher, ViewTeacherDTO>();
                config.CreateMap<ViewTeacherDTO, Teacher>();
                config.CreateMap<ViewTeacherDTO, TeachersDTO>();
                config.CreateMap<TeachersDTO, ViewTeacherDTO>();
            });

            app.UseMvc();
            
        }


    }
}
