using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateTime = System.DateTime;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class SafeTests : BaseTests
    {
        private LogTests.TestLogBook _logBook;

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Safe);
            _logBook = new LogTests.TestLogBook();
            Log.LogBook = _logBook;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Log.LogBook = null;
        }

        [TestMethod] public void RunTest() { }

        [TestMethod]
        public void RunFunctionTest()
        {
            var actual = Safe.Run(() => "Result", "Error");
            Assert.AreEqual("Result", actual);
            Assert.IsNull(_logBook.LoggedException);
        }

        [TestMethod]
        public void RunFailingFunctionTest()
        {
            var actual = Safe.Run(() => throw new NotImplementedException(), "Error");
            Assert.AreEqual("Error", actual);
            var exception = _logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(NotImplementedException));
        }

        [TestMethod]
        public void RunMethodTest()
        {
            var newLogBook = new LogTests.TestLogBook();
            Safe.Run(() => Log.LogBook = newLogBook);
            Assert.IsNull(newLogBook.LoggedException);
        }

        [TestMethod]
        public void RunFailingMethodTest()
        {
            Safe.Run(() => throw new ArgumentOutOfRangeException());
            var exception = _logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentOutOfRangeException));
        }

        [TestMethod]
        public void RunInsideRunTest()
        {
            Safe.Run(() => {
                Safe.Run(() => throw new ArgumentException());

                throw new AggregateException();
            });
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(AggregateException));
        }

        [TestMethod]
        public void RunInsideRunLockedTest()
        {
            Safe.Run(() => {
                Safe.Run(() => throw new ArgumentException(), true);

                throw new AggregateException();
            }, true);
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(AggregateException));
        }

        [TestMethod]
        public void RunInSeparateThreadsTest()
        {
            var list = new List<string>();
            StartThreads(list);
            ValidateList(list);
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentNullException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(ArithmeticException));
        }

        private static void StartThreads(ICollection<string> l)
        {
            var t1 = new Thread(() =>
                Method(l, "method1: ", () => throw new ArgumentNullException()));
            var t2 = new Thread(() =>
                Method(l, "method2: ", () => throw new ArithmeticException()));
            t1.Start();
            Thread.Sleep(1);
            t2.Start();
            Thread.Sleep(50);
        }

        private static void Method(ICollection<string> list, string message, Action exception)
        {
            Safe.Run(() => {
                Safe.Run(() => {
                    for (var i = 0; i < 10; i++)
                    {
                        list.Add(message + DateTime.Now);
                        Thread.Sleep(1);
                    }

                    exception();
                }, true);
                list.Add(message + DateTime.Now);
            }, true);
        }

        private static void ValidateList(IReadOnlyList<string> l)
        {
            Assert.AreEqual(22, l.Count);

            for (var i = 0; i < 22; i++)
            {
                Assert.IsTrue(
                    i < 11
                        ? l[i].StartsWith("method1:")
                        : l[i].StartsWith("method2:"),
                    $"list[{i}] = {l[i]}");
            }
        }

    }
}
