using Bb.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            KeyValuePair<string, Type>[] _types = instance.GetTypesWithAttributeExposeClass<object>(Bb.ConstantsCore.Cast);

            Assert.AreEqual(_types.Count() == 1, true);


        }

    }

}
