using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Black.Beard.Core.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            // initialize type discovery with path to search for resolve type
            Bb.ComponentModel.TypeDiscovery.Initialize(@"c:\dir1", @"c:\dir2");

            // add directory if missed in begining
            Bb.ComponentModel.TypeDiscovery.Instance.AddDirectories(@"c:\dir3", @"c:\dir4");

            // looking for all loaded type inherits from object and with an attribute Attribute1 that Key property equal 'test'
            var types1 = Bb.ComponentModel.TypeDiscovery.Instance.GetTypesWithAttributes<Attribute1>(typeof(object), attr => attr.Key == "test").ToArray();

            // add specificly an assembly by file path
            Bb.ComponentModel.TypeDiscovery.Instance.AddAssemblyFile("path file", withPdb: true);

            // generic way to find a type in all loaded types
            var types2 = Bb.ComponentModel.TypeDiscovery.Instance.GetTypes(type => true);

            // resolve a type by this name. Do System.Type.GetType(""); but active a mecanic of auto resolution of assembly before
            var type1 = Bb.ComponentModel.TypeDiscovery.Instance.ResolveByName("");

            // create a very fast factory to create instances of types. constructor is resolved from types of arguments
            Bb.ComponentModel.Factories.IFactory<Type1> factory = Bb.ComponentModel.TypeDiscovery.Instance.Create<Type1>("arg1", "arg2");



        }

        public void TestMethodDiscovery()
        {

            // looking for all method
            System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> methods =
                Bb.ComponentModel.MethodDiscovery.GetMethods(
                    typeof(object),
                    System.Reflection.BindingFlags.Instance,
                    typeof(bool), new System.Collections.Generic.List<System.Type>() { typeof(object), typeof(object) }
            );

        }

        public void TestPropertyAccessor()
        {

            // return a dictionary of properties declared in the type
            var properties = Bb.ComponentModel.Accessors.PropertyAccessor.GetProperties(typeof(object), true);

            // resolve the property by name
            var property = properties["propertyName"];

        }

        // 
    }


    public class Type1
    {

    }

    public class Attribute1 : System.Attribute
    {

        public Attribute1()
        {

        }

        public string Key { get; set; }

    }

}
