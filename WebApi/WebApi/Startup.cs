using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using WebApi.Coding;
using WebApi.Coding.Assemblers;
using WebApi.Coding.Assemblers.Actions;
using WebApi.Coding.Assemblers.Conditionals;
using WebApi.Coding.Assemblers.Data;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Data;
using WebApi.Speech;

namespace WebApi
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
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.TypeNameHandling = TypeNameHandling.All);

            services.AddSingleton<IPhraseQueue, PhraseQueue>();
            services.AddSingleton<IProgramQueue, ProgramQueue>();

            // Action assemblers
            services.AddSingleton<IActionAssembler, ActionAssembler>();
            services.AddSingleton<ISayPhraseActionAssembler, SayPhraseActionAssembler>();
            services.AddSingleton<IIfThenActionAssembler, IfThenActionAssembler>();
            services.AddSingleton<IIfThenElseActionAssembler, IfThenElseActionAssembler>();

            // Conditional assemblers
            services.AddSingleton<IEqualsAssembler, EqualsAssembler>();

            // Data assemblers
            services.AddSingleton<IConstantIntAssembler, ConstantIntAssembler>();
            services.AddSingleton<IConstantStringAssembler, ConstantStringAssembler>();
            services.AddSingleton<IDataAssembler, DataAssembler>();
            services.AddSingleton<IVariableIntAssembler, VariableIntAssembler>();
            services.AddSingleton<IVariableStringAssembler, VariableStringAssembler>();

            services.AddSingleton<IProgramAssembler, ProgramAssembler>();
            services.AddSingleton(provider => new Func<IData, SayPhraseAction>(data => new SayPhraseAction(data, provider.GetService<IPhraseQueue>())));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
