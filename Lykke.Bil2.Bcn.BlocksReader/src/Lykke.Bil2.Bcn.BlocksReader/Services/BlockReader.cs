using System.Transactions;
using System.Threading.Tasks;
using Lykke.Bil2.Contract.BlocksReader.Events;
using Lykke.Bil2.Sdk.BlocksReader.Services;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.Contract.TransactionsExecutor;

namespace Lykke.Bil2.Bcn.BlocksReader.Services
{
    public class BlockReader : IBlockReader
    {
        public BlockReader(/* TODO: Provide specific settings and dependencies, if necessary */)
        {
        }

        public Task ReadBlockAsync(long blockNumber, IBlockListener listener)
        {
            // TODO: Process block with specified number, emit header and transaction(s) events
            //
            // For example
            //
            // var block = ...;
            //
            // listener.HandleHeaderAsync(new BlockHeaderReadEvent(
            //     block.Number,
            //     block.Hash,
            //     block.Time,
            //     block.Raw.Length,
            //     block.Transactions.Count,
            //     block.Previous.Hash
            // ));

            // for (int i = 0; i < block.Transactions.Length; i++)
            // {
            //     var tx = block.Transactions[i];

            //     if (tx.State == "SUCCESS")
            //     {
            //         listener.HandleExecutedTransactionAsync(
            //             tx.Raw.ToBase58(),
            //             new TransactionExecutedEvent(
            //                 block.Hash,
            //                 i,
            //                 tx.Hash,
            //                 tx.Actions.SelectMany(act =>
            //                 {
            //                     yield return new BalanceChange("0", act.ActionId, act.Token.Id, CoinsChange.FromDecimal((-1) * act.Amount, act.Token.Accuracy), act.From);
            //                     yield return new BalanceChange("1", act.ActionId, act.Token.Id, CoinsChange.FromDecimal(act.Amount, act.Token.Accuracy), act.To);
            //                 }),
            //                 isIrreversible: true
            //             )
            //         );
            //     }

            //     if (tx.State == "FAILURE")
            //     {
            //         listener.HandleFailedTransactionAsync(
            //             tx.Raw.ToBase58(),
            //             new TransactionFailedEvent(
            //                  block.Hash,
            //                 i,
            //                 tx.Hash,
            //                 TransactionBroadcastingError.RebuildRequired,
            //                 tx.Error
            //             )
            //         );
            //     }
            // }


            throw new System.NotImplementedException();
        }
    }
}