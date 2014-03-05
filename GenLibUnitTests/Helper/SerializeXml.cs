using System;
using System.Collections.Generic;
using System.IO;
using GenLib.BitByte;
using GenLibUnitTests.Extension;
using Xunit;

namespace GenLibUnitTests.Helper
{
    public class SerializeXml
    {
        // serializeXmlTestObjects.xml contents:
        //<?xml version="1.0" encoding="utf-8"?>
        //<ArrayOfSerializeXmlTestObject xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        //  <SerializeXmlTestObject>
        //    <Name>testName</Name>
        //    <CanDo>true</CanDo>
        //  </SerializeXmlTestObject>
        //  <SerializeXmlTestObject>
        //    <Name>testName2</Name>
        //    <CanDo>false</CanDo>
        //  </SerializeXmlTestObject>
        //</ArrayOfSerializeXmlTestObject>

        [Fact]
        public void SerializeDeserialize()
        {
            var testObject = new SerializeXmlTestObject
                                 {
                                     Name = "testName",
                                     CanDo = true
                                 };

            var serializedString = new GenLib.Helper.SerializeXml().Serialize<SerializeXmlTestObject>(testObject);
            Console.WriteLine(serializedString);

            var newTestObject = new GenLib.Helper.SerializeXml().Deserialize<SerializeXmlTestObject>(serializedString);
            Assert.Equal(testObject.Name, newTestObject.Name);

            Assert.True(true);
        }

        [Fact]
        public void SerializeDeserializeToFromBytes()
        {
            var testObject = new SerializeXmlTestObject
                                 {
                                     Name = "testName",
                                     CanDo = true
                                 };

            var enc = new Encoder();
            var sxu = new GenLib.Helper.SerializeXml();
            var serializedBytes = enc.StringToBytes(sxu.Serialize<SerializeXmlTestObject>(testObject));

            var result = enc.ConvertToHex(enc.BytesToString(serializedBytes), true);
            Console.WriteLine(result);

            var newTestObject = sxu.Deserialize<SerializeXmlTestObject>(enc.BytesToString(serializedBytes));
            Assert.Equal(testObject.Name, newTestObject.Name);

            Assert.True(true);
        }

        [Fact]
        public void SerializeDeserializeList()
        {
            var testObjects = new List<SerializeXmlTestObject>
                                  {
                                      new SerializeXmlTestObject
                                          {
                                              Name = "testName",
                                              CanDo = true
                                          },
                                      new SerializeXmlTestObject
                                          {
                                              Name = "testName2",
                                              CanDo = false
                                          }
                                  };

            var sxu = new GenLib.Helper.SerializeXml();
            var serializedString = sxu.Serialize<List<SerializeXmlTestObject>>(testObjects);
            Console.WriteLine(serializedString);

            var testObjects2 = sxu.Deserialize<List<SerializeXmlTestObject>>(serializedString);
            Assert.Equal("testName", testObjects2[0].Name);
            Assert.True(testObjects2[0].CanDo);
            Assert.Equal("testName2", testObjects2[1].Name);
            Assert.False(testObjects2[1].CanDo);

            Assert.True(true);
        }

        [Fact]
        public void SerializeFromTestFile()
        {
            const string filename = @"TestFiles\serializeXmlTestObjects.xml";
            var serializedString = File.ReadAllText(filename);
            Console.WriteLine(serializedString);

            var testObjects =
                new GenLib.Helper.SerializeXml().DeserializeXmlFromFile<List<SerializeXmlTestObject>>(filename);
            testObjects.Count.ShouldBeGreaterThanOrEqualTo(1);
            Assert.Equal("testName", testObjects[0].Name);

            Assert.True(true);
        }

        #region Nested type: SerializeXmlTestObject

        public class SerializeXmlTestObject
        {
            public string Name { get; set; }
            public bool CanDo { get; set; }
        }

        #endregion
    }
}