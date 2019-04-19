using System.Threading.Tasks;
using Lykke.Bil2.Contract.BlocksReader.Events;
using Lykke.Bil2.Sdk.BlocksReader.Services;

namespace Lykke.Bil2.Bcn.BlocksReader.Services
{
    public class IrreversibleBlockHandler
    {
        private readonly IIrreversibleBlockListener _listener;

        public IrreversibleBlockHandler(
            IIrreversibleBlockListener listener
        )
        {
            _listener = listener;

            // TODO: Subscribe on irreversible block changed event, and call OnIrreversibleBlockChangedAsync() method
        }

        public async Task OnIrreversibleBlockChangedAsync(long blockNumber, string blockHash)
        {
            await _listener.HandleNewLastIrreversibleBlockAsync
            (
                new LastIrreversibleBlockUpdatedEvent
                (
                    blockNumber,
                    blockHash
                )
            );
        }
    }
}