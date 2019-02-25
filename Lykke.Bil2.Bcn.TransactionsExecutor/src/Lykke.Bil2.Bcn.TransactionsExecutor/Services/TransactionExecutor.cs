using System;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.Contract.TransactionsExecutor;
using Lykke.Bil2.Contract.TransactionsExecutor.Requests;
using Lykke.Bil2.Contract.TransactionsExecutor.Responses;
using Lykke.Bil2.Sdk;
using Lykke.Bil2.Sdk.Exceptions;
using Lykke.Bil2.Sdk.TransactionsExecutor;
using Lykke.Bil2.Sdk.TransactionsExecutor.Services;
using Newtonsoft.Json;

namespace Lykke.Bil2.Bcn.TransactionsExecutor.Services
{
    public class TransactionExecutor : ITransactionExecutor
    {
        public TransactionExecutor(/* TODO: Provide specific settings, if necessary */)
        {
        }

        public async Task BroadcastAsync(BroadcastTransactionRequest request)
        {
            // TODO: broadcast transaction, throw TransactionBroadcastingException on error
            //
            // IMPORTANT: This method MUST NOT throw if transaction affects blockchain in any manner!
            //
            // For example
            //
            // dynamic signed;
            //
            // try
            // {
            //     signed = JsonConvert.DeserializeObject<dynamic>(request.SignedTransaction.DecodeToString());
            // }
            // catch (JsonException ex)
            // {
            //     throw new RequestValidationException("Failed to deserialize signed transaction", request.SignedTransaction, ex, nameof(request.SignedTransaction));
            // }
            //
            // var result = await BcnApi.Send(signed);
            //
            // switch (result)
            // {
            //     case 100:
            //         throw new TransactionBroadcastingException(TransactionBroadcastingError.RebuildRequired, "Transaction expired");
            //
            //     case 200:
            //         throw new TransactionBroadcastingException(TransactionBroadcastingError.RetryLater, "Node is busy");
            // }


            throw new System.NotImplementedException();
        }

        public async Task<BuildReceivingTransactionResponse> BuildReceivingAsync(BuildReceivingTransactionRequest request)
        {
            // Most of blockchains does not require receiving transactions, so it is not supported by default.
            // Replace next line with receiving transaction building code, if necessary.

            throw new OperationNotSupportedException("Receiving transactions are not supported");
        }

        public async Task<BuildSendingTransactionResponse> BuildSendingAsync(BuildSendingTransactionRequest request)
        {
            // TODO: prepare data required for signing, return as base58 encoded string


            throw new System.NotImplementedException();
        }
    }
}