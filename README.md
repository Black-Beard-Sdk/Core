# Core      [![Build status](https://ci.appveyor.com/api/projects/status/3e4q6rqm8jaeb8x2?svg=true)](https://ci.appveyor.com/project/gaelgael5/core)

methods helpfull

## Bb.ComponentModel.TypeDiscovery

helper for discovers types

### Sample
``` CSharp
   
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

      // create a very fast factory to create instances of types
      Bb.ComponentModel.Factories.IFactory<Type1> factory = Bb.ComponentModel.TypeDiscovery.Instance.Create<Type1>("arg1", "arg2" );

```


## Bb.ComponentModel.MethodDiscovery

helper for discovers methods

Install

``` 
    Install-Package Black.Beard.Core
```

### Sample
``` CSharp

      // looking for all method
      System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> methods = 
          Bb.ComponentModel.MethodDiscovery.GetMethods(
              typeof(object), 
              System.Reflection.BindingFlags.Instance, 
              typeof(bool), new System.Collections.Generic.List<System.Type>() { typeof(object), typeof(object) }
      );

```

## Bb.ComponentModel.Accessors.PropertyAccessor

helper for discovers properties and provide very fast property value accessor

### Sample
``` CSharp

    // return a dictionary of properties declared in the type
    var properties = Bb.ComponentModel.Accessors.PropertyAccessor.GetProperties(typeof(object), true);

    // resolve the property by name
    var property = properties["propertyName"];

    // read value
    var value =  property.GetValue(instance);

    // set value
    var value =  property.SetValue(instance, "new value");

```

## Bb.ComponentModel.Attributes.IocRegisterAttribute

If you want implement a automatique register ioc process you can use this attribute for provide ioc configuration

```CSharp

    [Bb.ComponentModel.Attributes.IocRegisterAttribute(typeof(IContractToResolveService, IocScopeEnum.Transient))]
    public class Test : IContractToResolveService
    {


    }

``` 


## Find exposed types

If you expose types for autodetecting. You can easy find with method 'GetTypesWithAttributeExposeClass'

The sample demonstrate how find all types with 'ExposeClassAttribute' of context = 'Cast' and return a list keyvaluepair display name, Type
```CSharp

    KeyValuePair<string, Type>[] _types = instance.GetTypesWithAttributeExposeClass<object>(Bb.ConstantsCore.Cast);

``` 

Or
```CSharp

    var types = new ExposedTypes();

    // add a new attribute in referential
    types.Add(new ExposedTypeConfigurations()
    {
        TypeName = typeof(Test1).AssemblyQualifiedName,

        Attributes = new List<ExposedAttributeTypeConfiguration>()
        {
            new ExposedAttributeTypeConfiguration()
            {
                Context = "Test33",
            }
        }
    });

    // Push missing attributes in the TypeDescriptor layer
    types.AddAttributesInTypeDescriptors();

```