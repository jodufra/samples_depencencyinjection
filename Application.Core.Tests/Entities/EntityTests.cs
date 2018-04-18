using Application.Core.Entities;
using System;
using Xunit;

namespace Tests.Application.Core.Entities
{
    public class EntityTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(int.MaxValue, false)]
        [InlineData(-1, false)]
        [InlineData(int.MinValue, false)]
        public void IsNewTest(int id, bool isNew)
        {
            var dummy = new DummyEntity() { Id = id };
            Assert.Equal(dummy.IsNew, isNew);
        }

        class DummyEntity : BaseEntity { }

    }
}
