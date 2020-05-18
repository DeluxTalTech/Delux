using Delux.Aids;
using Delux.Data.Client;

namespace Delux.Facade.Client
{
    public static class ClientViewFactory
    {
        public static Domain.Client.Client Create(ClientView v)
        {
            var d = new ClientData();
            Copy.Members(v, d);

            return new Domain.Client.Client(d);
        }

        public static ClientView Create(Domain.Client.Client o)
        {
            var v = new ClientView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        }
    }
}
