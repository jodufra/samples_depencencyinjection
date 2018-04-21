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
        [InlineData(-1, false)]
        [InlineData(int.MinValue, false)]
        [InlineData(int.MaxValue, false)]
        public void IsNewTest(int id, bool isNew)
        {
            var dummy = new DummyEntity(id);
            Assert.Equal(dummy.IsNew, isNew);
        }

        class DummyEntity : BaseEntity
        {
            public DummyEntity(int id)
            {
                Id = id;
            }
        }
    }
}
