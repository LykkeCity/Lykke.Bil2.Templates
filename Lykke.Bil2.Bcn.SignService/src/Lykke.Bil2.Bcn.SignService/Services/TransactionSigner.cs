using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.Contract.SignService.Responses;
using Lykke.Bil2.Sdk.SignService.Services;

namespace Lykke.Bil2.Bcn.SignService.Services
{
    public class TransactionSigner : ITransactionSigner
    {
        public TransactionSigner(/* TODO: Provide specific settings and dependencies, if necessary */)
        {
        }

        public async Task<SignTransactionResponse> SignAsync(IReadOnlyCollection<string> privateKeys, Base58String requestTransactionContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
