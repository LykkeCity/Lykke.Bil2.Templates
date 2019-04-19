using System;
using JetBrains.Annotations;
using Lykke.Bil2.Bcn.TransactionsExecutor.Services;
using Lykke.Bil2.Bcn.TransactionsExecutor.Settings;
using Lykke.Bil2.Sdk.TransactionsExecutor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Bil2.Bcn.TransactionsExecutor
{
    [UsedImplicitly]
    public class Startup
    {
        private const string IntegrationName = "Bcn";

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildBlockchainTransactionsExecutorServiceProvider<AppSettings>(options =>
            {
                options.IntegrationName = IntegrationName;

                // Register required service implementations:

#if formatAddress
                options.AddressFormatsProviderFactory = ctx =>
                    new AddressFormatsProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );
#endif

                options.AddressValidatorFactory = ctx =>
                    new AddressValidator
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.HealthProviderFactory = ctx =>
                    new HealthProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.DependenciesInfoProvider = ctx =>
                    new DependencyInfoProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.BlockchainInfoServiceFactory = ctx =>
                    new BlockchainInfoProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransactionBroadcasterFactory = ctx =>
                    new TransactionBroadcaster
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransactionsStateProviderFactory = ctx =>
                    new TransactionsStateProvider
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

#if transferAmountModel
                options.TransferAmountTransactionsBuilderFactory = ctx =>
                    new TransferAmountTransactionsBuilder
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransferAmountTransactionsEstimatorFactory = ctx =>
                    new TransferAmountTransactionsEstimator
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );
#endif

#if transferCoinsModel
                options.TransferCoinsTransactionsBuilderFactory = ctx =>
                    new TransferCoinsTransactionsBuilder
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransferCoinsTransactionsEstimatorFactory = ctx =>
                    new TransferCoinsTransactionsEstimator
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );
#endif

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
            app.UseBlockchainTransactionsExecutor(options =>
            {
                options.IntegrationName = IntegrationName;
            });
        }
    }
}
