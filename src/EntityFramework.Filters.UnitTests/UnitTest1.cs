using System;
using System.Linq;
using EntityFramework.Filters.Example;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFramework.Filters.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_filter_based_on_global_value()
        {
            using (var context = new ExampleContext())
            {
                var tenant = context.Tenants.Find(1);
                context.CurrentTenant = tenant;
                context.EnableFilter("Tenant")
                    .SetParameter("tenantId", tenant.TenantId);

                Assert.IsTrue(context.BlogEntries.Count() == 1);
            }
        }
    }
}
