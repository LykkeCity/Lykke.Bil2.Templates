using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.Contract.TransactionsExecutor.Requests;
using Lykke.Bil2.Contract.TransactionsExecutor.Responses;
using Lykke.Bil2.Sdk.TransactionsExecutor.Services;

namespace Lykke.Bil2.Bcn.TransactionsExecutor.Services
{
    public class TransactionEstimator : ITransactionEstimator
    {
        public TransactionEstimator(/* TODO: Provide specific settings, if necessary */)
        {
        }

        public async Task<EstimateSendingTransactionResponse> EstimateSendingAsync(EstimateSendingTransactionRequest request)
        {
            // TODO: estimate transaction fees.
            //
            // Throw:
            // - Lykke.Bil2.Contract.Common.RequestValidationException:
            //     if a transaction can’t be estimated with the given parameters
            //     and it will be never possible to estimate the transaction with exactly the same
            //     parameters.
            //
            // - System.Exception:
            //     if there are any other errors.
            //     Likely a temporary issue with infrastructure or configuration,
            //     request should be repeated later.
            //
            // Result usually consists of single fee element,
            // but for some blockchains fees may be charged in multiple currencies/tokens.
            //
            // For example:
            //
            // var fee = ...;
            //
            // return new EstimateSendingTransactionResponse
            // (
            //     new Dictionary<AssetId, CoinsAmount>
            //     {
            //         { request.Inputs.Single().AssetId, CoinsAmount.FromDecimal(fee, accuracy: 6) }
            //     }
            // );

            throw new System.NotImplementedException();
        }
    }
}