using Delux.Data.Client;
using Delux.Domain.Common;

namespace Delux.Domain.Client
{
    public sealed class Client: Entity<ClientData>
    {
        public Client() : this(null) { }

        public Client(ClientData data) : base(data) { }
    }
}
