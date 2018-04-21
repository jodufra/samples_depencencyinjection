using Application.Core.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tests.Application.Core.Factories
{
    public class FactoryTests
    {
        public static IEnumerable<object[]> GetDictionaries()
        {
            var dictionaries = new List<object[]>
            {
                new object[]{ new Dictionary<string, object>(), true },
                new object[]{ null, false }
            };
            return dictionaries;
        }

        [Theory]
        [MemberData(nameof(GetDictionaries))]
        public void CanGetPerRequestTheory(IDictionary dictionary, bool shouldBeEqual)
        {
            using (var factory = new DummyFactory())
            {
                var dummyFirst = factory.GetPerRequest(dictionary);
                Assert.NotNull(dummyFirst);

                var dummySecond = factory.GetPerRequest(dictionary);
                Assert.NotNull(dummySecond);

                if (shouldBeEqual)
                {
                    Assert.Equal(dummyFirst, dummySecond);
                }
                else
                {
                    Assert.NotEqual(dummyFirst, dummySecond);
                }
            }
        }

        [Theory]
        [InlineData(@"Test")]
        [InlineData(@"!#$%&/()=?")]
        [InlineData(nameof(DummyObject))]
        public void CanStoreObjectByKeyTheory(string key)
        {
            using (var factory = new DummyFactory(key))
            {
                var dictionary = new Dictionary<string, object>();
                var dummyObject = factory.GetPerRequest(dictionary);

                Assert.NotNull(dummyObject);
                Assert.True(dictionary.ContainsKey(key));
                Assert.Equal(dummyObject, dictionary[key]);
            }
        }

        [Fact]
        public void CanDisposeMultipleTimesFact()
        {
            var factory = new DummyFactory();

            // Factories should not throw exception when disposed more than once
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
