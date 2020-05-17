using Delux.Aids;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Technician;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Common {

    [TestClass]
    public class CrudPageTests : AbstractPageTests<CrudPage<ITreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentView, TreatmentData>,
        BasePage<ITreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentView, TreatmentData>> {

        private string _fixedFilter;
        private string _fixedValue;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Obj = new TestClass(Db);
            _fixedFilter = GetRandom.String();
            _fixedValue = GetRandom.String();
            Assert.AreEqual(null, Obj.FixedValue);
            Assert.AreEqual(null, Obj.FixedFilter);
        }

        [TestMethod] public void ItemTest() {
            IsProperty(() => Obj.Item, x => Obj.Item = x);
        }

        [TestMethod] public void AddObjectTest() {
            var idx = Db.List.Count;
            Obj.Item = GetRandom.Object<TreatmentView>();
            Obj.AddObject(_fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(_fixedFilter, Obj.FixedFilter);
            Assert.AreEqual(_fixedValue, Obj.FixedValue);
            TestArePropertyValuesEqual(Obj.Item, Db.List[idx].Data);
        }

        [TestMethod] public void UpdateObjectTest() {
            GetObjectTest();
            var idx = GetRandom.Int32(0, Db.List.Count);
            var itemId = Db.List[idx].Data.Id;
            Obj.Item = GetRandom.Object<TreatmentView>();
            Obj.Item.Id = itemId;
            Obj.UpdateObject(_fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(Db.List[^1].Data, Obj.Item);
        }

        [TestMethod] public void GetObjectTest() {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);
            for (var i = 0; i < count; i++) AddObjectTest();
            var item = Db.List[idx];
            Obj.GetObject(item.Data.Id, _fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(count, Db.List.Count);
            TestArePropertyValuesEqual(item.Data, Obj.Item);
        }

        [TestMethod] public void DeleteObjectTest() {
            AddObjectTest();
            Obj.DeleteObject(Obj.Item.Id, _fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(_fixedFilter, Obj.FixedFilter);
            Assert.AreEqual(_fixedValue, Obj.FixedValue);
            Assert.AreEqual(0, Db.List.Count);
        }

        [TestMethod] public void ToViewTest() {
            var d = GetRandom.Object<TreatmentData>();
            var v = Obj.ToView(new global::Delux.Domain.Treatment.Treatment(d));
            TestArePropertyValuesEqual(d, v);
        }

        [TestMethod] public void ToObjectTest() {
            var v = GetRandom.Object<TreatmentView>();
            var o = Obj.ToObject(v);
            TestArePropertyValuesEqual(v, o.Data);
        }

    }

}
