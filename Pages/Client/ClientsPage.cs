using Delux.Data.Client;
using Delux.Domain.Client;
using Delux.Facade.Client;
using Delux.Pages.Common;

namespace Delux.Pages.Client
{
    public class ClientsPage : CommonPage<IClientsRepository, Domain.Client.Client, ClientView, ClientData>
    {
        protected internal ClientsPage(IClientsRepository r) : base(r)
        {
            PageTitle = "Kliendid";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/Kliendid";

        protected internal override Domain.Client.Client ToObject(ClientView view) => ClientViewFactory.Create(view);

        protected internal override ClientView ToView(Domain.Client.Client obj) => ClientViewFactory.Create(obj);
    }
}