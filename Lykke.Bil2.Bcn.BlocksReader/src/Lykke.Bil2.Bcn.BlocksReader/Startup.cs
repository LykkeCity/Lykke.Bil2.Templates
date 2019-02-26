using System;
using JetBrains.Annotations;
using Lykke.Bil2.Bcn.BlocksReader.Services;
using Lykke.Bil2.Bcn.BlocksReader.Settings;
using Lykke.Bil2.Sdk.BlocksReader;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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



                // If blockchain does not support blocks irreversibility then delete this block of comments.
                //
                // If blockchain does not support blocks irreversibility, or "push" strategy is used, then delete ./Services/IrreversibleBlockProvider.cs.
                //
                // If blockchain supports blocks irreversibility then choose either "push" or "pull"
                // strategy for retrieving last irreversible block and uncomment corresponding line below:
                //
                // options.AddIrreversibleBlockPushing();
                //
                // options.AddIrreversibleBlockPulling(ctx =>
                //     new IrreversibleBlockProvider
                //     (
                //         /* TODO: Provide specific settings and dependencies, if necessary */
                //     ));



                // To access settings for any purpose,
                // usually, to register additional services like blockchain client,
                // uncomment code below:
                //
                // options.UseSettings = settings =>
                // {
                //     services.AddSingleton<IService>(new ServiceImpl(settings.CurrentValue.ServiceSettingValue));
                // };
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