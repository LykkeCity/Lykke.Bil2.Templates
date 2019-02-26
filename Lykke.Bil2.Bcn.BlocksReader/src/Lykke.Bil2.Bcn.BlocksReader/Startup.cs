using System.ComponentModel;
using System;
using JetBrains.Annotations;
using Lykke.Bil2.Bcn.BlocksReader.Services;
using Lykke.Bil2.Bcn.BlocksReader.Settings;
using Lykke.Bil2.Sdk.BlocksReader;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Lykke.Bil2.Sdk.BlocksReader.Services;

namespace Lykke.Bil2.Bcn.BlocksReader
{
    [UsedImplicitly]
    public class Startup
    {
        private const string IntegrationName = "Bcn";

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildBlockchainBlocksReaderServiceProvider<AppSettings>(options =>
            {
                options.IntegrationName = IntegrationName;

                // Register required service implementations:

                options.BlockReaderFactory = ctx =>
                    new BlockReader
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

#if pullIrreversibilityStrategy
                // Register irreversible block retrieving strategy

                options.AddIrreversibleBlockPulling(ctx =>
                    new IrreversibleBlockProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    ));
#endif

#if pushIrreversibilityStrategy
                // Register irreversible block retrieving strategy

                options.AddIrreversibleBlockPushing();

                // Register additional services

                options.UseSettings = settings =>
                {
                    services.AddSingleton(sp => new IrreversibleBlockHandler(sp.GetRequiredService<IIrreversibleBlockListener>()));
                };
#else
                // To access settings for any purpose,
                // usually, to register additional services like blockchain client,
                // uncomment code below:
                //
                // options.UseSettings = settings =>
                // {
                //     services.AddSingleton<IService>(new ServiceImpl(settings.CurrentValue.ServiceSettingValue));
                // };
#endif
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseBlockchainBlocksReader(options =>
            {
                options.IntegrationName = IntegrationName;
            });
        }
    }
}