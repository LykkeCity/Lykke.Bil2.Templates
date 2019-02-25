# Blockchain integration transaction executor

This component of blockchain integration is intended for building and executing transactions.

To implement transaction executor component:
1. Implement `IAddressValidator` interface for validating deposit and withdraw addresses;
2. Implement `IHealthProvider` interface for checking services state;
3. Implement `IIntegrationInfoService` interface for checking blockchain state;
4. Implement `ITransactionEstimator` interface for estimating transaction cost;
5. Implement `ITransactionExecutor` interface for building and sending transactions;
6. Provide implementations to SDK code in `ConfigureServices()` method on startup;
4. Provide integration name and other options in `Configure()` method on startup.