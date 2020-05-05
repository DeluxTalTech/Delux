using System;
using Delux.Aids;
using Delux.Data.Common;
using Delux.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra
{
    [TestClass]
    public abstract class RepositoryTests<TRepository, TObject, TData>
        : BaseTests
    where TRepository : IRepository<TObject>
    where TObject : Entity<TData>
    where TData : NameData, new()
    {

        protected TData Data;
        protected TRepository Obj;
        protected DbContext Db;
        protected int Count;
        protected DbSet<TData> DbSet;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(TRepository);
            Data = GetRandom.Object<TData>();
            Count = GetRandom.UInt8(20, 40);
            CleanDbSet();
            AddItems();
        }
        protected void TestGetList()
        {
            Obj.PageIndex = GetRandom.Int32(2, Obj.TotalPages - 1);
            var l = Obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(Obj.PageSize, l.Count);
        }

        [TestCleanup] public void TestCleanup() => CleanDbSet();

        protected void CleanDbSet()
        {
            foreach (var p in DbSet)
                Db.Entry(p).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        protected void AddItems()
        {
            for (var i = 0; i < Count; i++)
                Obj.Add(GetObject(GetRandom.Object<TData>())).GetAwaiter();
        }

        [TestMethod] public void IsSealed() => Assert.IsTrue(Type.IsSealed);

        [TestMethod] public void IsInherited() => Assert.AreEqual(GetBaseType().Name, Type?.BaseType?.Name);

        protected abstract Type GetBaseType();

        [TestMethod] public void GetTest() => TestGetList();

        [TestMethod] public void GetByIdTest() => AddTest();


        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var id = GetId(Data);
            var expected = Obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(Data, expected.Data);
            Obj.Delete(id).GetAwaiter();
            expected = Obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        protected abstract string GetId(TData d);

        [TestMethod]
        public void AddTest()
        {
            var id = GetId(Data);
            var expected = Obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            Obj.Add(GetObject(Data)).GetAwaiter();
            expected = Obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(Data, expected.Data);
        }

        protected abstract TObject GetObject(TData d);

        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var id = GetId(Data);
            var newData = GetRandom.Object<TData>();
            SetId(newData, id);
            Obj.Update(GetObject(newData)).GetAwaiter();
            var expected = Obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData, expected.Data);
        }
        protected abstract void SetId(TData d, string id);
    }
}