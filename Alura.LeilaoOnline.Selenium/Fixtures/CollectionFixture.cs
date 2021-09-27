using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
