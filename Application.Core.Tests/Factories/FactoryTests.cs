using Application.Core.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tests.Application.Core.Factories
{
    public class FactoryTests
    {
        [Fact]
        public void GetPerRequestTest()
        {
            var factory = new DummyFactory();
            var dictionary = new Dictionary<string, object>();

            var dummyFirst = factory.GetPerRequest(dictionary);
            Assert.NotNull(dummyFirst);

            var dummySecond = factory.GetPerRequest(dictionary);
            Assert.NotNull(dummySecond);

            Assert.Equal(dummyFirst, dummySecond);
        }

        [Fact]
        public void GetPerRequestWithoutDictionaryTest()
        {
            var factory = new DummyFactory();

            var dummyFirst = factory.GetPerRequest(null);
            Assert.NotNull(dummyFirst);

            var dummySecond = factory.GetPerRequest(null);
            Assert.NotNull(dummySecond);

            Assert.NotEqual(dummyFirst, dummySecond);
        }

        [Theory]
        [InlineData(@"Test")]
        [InlineData(@"!#$%&/()=?")]
        [InlineData(nameof(DummyObject))]
        public void ObjectIsStoredByKeyTest(string key)
        {
            var factory = new DummyFactory(key);
            var dictionary = new Dictionary<string, object>();
            var dummyObject = factory.GetPerRequest(dictionary);

            Assert.NotNull(dummyObject);
            Assert.True(dictionary.ContainsKey(key));
            Assert.Equal(dummyObject, dictionary[key]);
        }

        [Fact]
        public void MultipleDisposeTest()
        {
            var factory = new DummyFactory();

            // Factories should not throw exception when disposed more then once
            factory.Dispose();
            factory.Dispose();
            factory.Dispose();
            factory.Dispose();
            factory.Dispose();
        }

        class DummyFactory : BaseFactory<DummyObject>
        {
            public DummyFactory() : base(nameof(DummyObject)) { }
            public DummyFactory(string key) : base(key) { }

            protected override IDictionary GetContextDictionary() => null;
        }

        class DummyObject : IDisposable
        {
            public void Dispose() { }
        }
    }

}
