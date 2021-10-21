using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Function.IntegrationsTest
{
    [CollectionDefinition(nameof(TestCollection))]
    public class TestCollection : ICollectionFixture<TestFixture>
    {

    }
}
