using System;
using Delux.Data.Client;
using Delux.Infra;
using Delux.Infra.Client;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Client
{
    [TestClass]
    public class ClientsRepositoryTests:RepositoryTests<ClientsRepository, global::Delux.Domain.Client.Client, ClientData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).Clients;
            Obj = new ClientsRepository((SalonDbContext)Db);
            base.TestInitialize();

        }

        protected override string GetId(ClientData d) => d.Id;

        protected override global::Delux.Domain.Client.Client GetObject(ClientData d) => new global::Delux.Domain.Client.Client(d);

        protected override void SetId(ClientData d, string id) => d.Id = id;

        protected override Type GetBaseType()
        {
            return typeof(IdRepository<global::Delux.Domain.Client.Client, ClientData>);
        }
    }
}
