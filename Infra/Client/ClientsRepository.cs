using Delux.Data.Client;
using Delux.Domain.Client;
using Delux.Infra.Common;

namespace Delux.Infra.Client
{
    public sealed class ClientsRepository:IdRepository<Domain.Client.Client,ClientData>, IClientsRepository
    {
        public ClientsRepository(SalonDbContext c) : base(c, c.Clients) { }

        protected internal override Domain.Client.Client ToDomainObject(ClientData d) => new Domain.Client.Client(d);
    }
}
