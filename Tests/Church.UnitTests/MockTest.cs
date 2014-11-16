using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Church.UnitTests
{
    public abstract class MockTest
    {
        private MockRepository repo;

        [TestInitialize]
        public virtual void SetUp()
        {
            repo = new MockRepository(MockBehavior.Strict);
        }

        [TestCleanup]
        public virtual void TearDown()
        {
            repo.VerifyAll();
        }

        protected Mock<T> CreateMock<T>()
            where T : class
        {
            return repo.Create<T>();
        }
    }
}
