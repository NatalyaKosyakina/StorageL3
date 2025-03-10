
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StorageL3.Abstractions;
using StorageL3.db;
using StorageL3.GraphQLServices.Mutations;
using StorageL3.GraphQLServices.Queries;
using StorageL3.Repo;

namespace StorageL3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddGraphQLServer().AddQueryType<StorageQuery>().AddMutationType<Mutation>();

            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var cfg = config.Build();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.RegisterType<StorageRepo>().As<IStorageRepo>();
                cb.Register(c => new StorageContext(cfg.GetConnectionString("db"))).InstancePerDependency();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            //app.MapGraphQL();

            app.Run();
        }
    }
}
