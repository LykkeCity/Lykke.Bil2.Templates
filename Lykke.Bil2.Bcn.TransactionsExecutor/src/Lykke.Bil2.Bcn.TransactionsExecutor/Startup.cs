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

                options.IntegrationInfoServiceFactory = ctx =>
                    new IntegrationInfoService
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransactionEstimatorFactory = ctx =>
                    new TransactionEstimator
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );

                options.TransactionExecutorFactory = ctx =>
                    new TransactionExecutor
                    (
                        /* TODO: Provide specific settings and dependencies, if necessary */
                    );


                // To access settigns for any purpose,
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
