using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Common {

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData> {

        internal TestRepository Db; 
        internal class TestClass : CommonPage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData> {

            protected internal TestClass(IBeauticiansRepository r) : base(r) {
                PageTitle = "Beauticians";
            }

            public override string ItemId => Item?.Id ?? string.Empty;

            protected internal override string GetPageUrl() => "/Salon/Beauticians";

            protected internal override Beautician ToObject(BeauticianView view) => BeauticianViewFactory.Create(view);

            protected internal override BeauticianView ToView(Beautician obj) => BeauticianViewFactory.Create(obj);

        }

        internal class TestRepository : BaseTestRepositoryForId<Beautician, BeauticianData>, IBeauticiansRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Db = new TestRepository();
        }

    }

}
