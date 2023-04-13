using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CanvasApi.Client.Test {
    public abstract class TestSetup {
        protected ServiceCollection ServiceCollection { get; private set; }

        [SetUp]
        public void Setup() {
            var builder = new ConfigurationBuilder();

            builder
                .AddUserSecrets<TestSetup>()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();

            var config = builder.Build();
            var canvasOptions = config.GetSection("Canvas").Get<CanvasOptions>();
            var canvasDomain = canvasOptions.CanvasDomain;
            var apiKey = canvasOptions.ApiKey;

            this.ServiceCollection = new ServiceCollection();

            this.ServiceCollection.AddHttpClient<ICanvasApiClient, CanvasApiClient>(client =>
                client.ConfigureCanvasApi(canvasDomain, apiKey)
            );
        }
    }
}