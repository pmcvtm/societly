using System;
using System.Linq;
using Fixie;
using Ploeh.AutoFixture.Kernel;
using Fixture = Ploeh.AutoFixture.Fixture;

namespace Societly.Tests.Infrastructure
{
    public class TestcaseClassPerFixtureConvention : Convention
    {
        public TestcaseClassPerFixtureConvention()
        {
            Classes
                .NameEndsWith("Tests")
                .Where(t =>
                    t.GetConstructors().Count() == 1
                    && t.GetConstructors().Count(ci => ci.GetParameters().Length > 0) == 1
                );

            Methods.Where(mi => mi.IsPublic && mi.IsVoid());

            ClassExecution
                .CreateInstancePerClass()
                .UsingFactory(CreateFromFixture);
        }

        private object CreateFromFixture(Type type)
        {
            var fixture = new Fixture();

            new IntegratedTestCustomization().Customize(fixture);

            return new SpecimenContext(fixture).Resolve(type);
        }
    }
}
