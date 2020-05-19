using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Common {

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<ITreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentView, TreatmentData> {

        internal TestRepository Db; 
        internal class TestClass : CommonPage<ITreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentView, TreatmentData> {

            protected internal TestClass(ITreatmentsRepository r) : base(r) {
                PageTitle = "Treatments";
            }

            public override string ItemId => Item?.Id ?? string.Empty;

            protected internal override string GetPageUrl() => "/Salon/Treatments";

            protected internal override global::Delux.Domain.Treatment.Treatment ToObject(TreatmentView view) => TreatmentViewFactory.Create(view);

            protected internal override TreatmentView ToView(global::Delux.Domain.Treatment.Treatment obj) => TreatmentViewFactory.Create(obj);

        }

        internal class TestRepository : BaseTestRepositoryForId<global::Delux.Domain.Treatment.Treatment, TreatmentData>, ITreatmentsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Db = new TestRepository();
        }

    }

}
