using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Black.Beard.Core.UnitTests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestCast()
        {

            // initialize type discovery with path to search for resolve type
            var instance = Bb.ComponentModel.TypeDiscovery.Initialize();
            KeyValuePair<string, Type>[] _types = instance.GetTypesWithAttributeExposeClass(Bb.ConstantsCore.Cast);

            Assert.AreEqual(_types.Count() == 1, true);

        }


        [TestMethod]
        public void TestReferential()
        {

            var items = ExposedTypeReferential.Instance.Types;

            Assert.AreEqual(items.Count() == 2, true);

        }


        [TestMethod]
        public void TestExposedTypes()
        {

            ExposedTypes types = new ExposedTypes();

            var ctx = types.GetContexts();
            Assert.AreEqual(ctx.Count() == 2, true);

            var types2 = types.GetTypes();
            Assert.AreEqual(types2.Count() == 2, true);

            types.Add(new ExposedTypeConfigurations()
            {

                new ExposedTypeConfiguration()
                {

                    TypeName = typeof(Test1).AssemblyQualifiedName,

                    Attributes = new List<ExposedAttributeTypeConfiguration>()
                    {
                        new ExposedAttributeTypeConfiguration()
                        {
                            Context = "Test33",
                        }
                    }
                }

            });

            ctx = types.GetContexts();
            Assert.AreEqual(ctx.Count() == 3, true);

            types2 = types.GetTypes();
            Assert.AreEqual(types2.Count() == 3, true);

        }


        [TestMethod]
        public void TestExposedTypes2()
        {

            ExposedTypes types = new ExposedTypes();

            types.Add(new ExposedTypeConfigurations()
            {
                new ExposedTypeConfiguration()
                {
                    TypeName = typeof(Test1).AssemblyQualifiedName,

                    Attributes = new List<ExposedAttributeTypeConfiguration>()
                    {
                        new ExposedAttributeTypeConfiguration()
                        {
                            Context = "Test33",
                        }
                    }
                }
            });

            types.AddAttributesInTypeDescriptors();

            var l = TypeDescriptor.GetAttributes(typeof(Test1)).OfType<ExposeClassAttribute>().ToList();

            Assert.AreEqual(l.Count() == 1, true);

        }

    }

    public class Test1
    {

    }

    public class ExposedTypeReferential : TypeWithAttributeReferential<ExposeClassAttribute>
    {

        public override void Refresh()
        {
            base.Refresh();
        }

    }

}
