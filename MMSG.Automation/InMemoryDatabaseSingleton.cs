using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System;
using MMSG.Automation.DataTransferObjects;

namespace MMSG.Automation
{
    internal class InMemoryDatabaseSingleton
    {
        /// <summary>
        /// This is the in memory database.
        /// </summary>
        private readonly InMemoryDatabase _inMemoryDatabase = null;

        /// <summary>
        /// This is the singleton instance class.
        /// </summary>
        private static InMemoryDatabaseSingleton _inMemoryDatabaseSingleton = null;

        // created xml serializer and initialize to null.
        XmlNodeList xmlNodeList = null;
        XmlSerializer xmlSerializer = null;

        /// <summary>
        /// This is the private constructor of the database and
        /// deserialize xml data in memory based on environment variable.
        /// </summary>
        private InMemoryDatabaseSingleton()
        {
            _inMemoryDatabase = new InMemoryDatabase();

            // based on environment deserialize xml data in memory
            switch (AutomationConfigurationManager.ApplicationTestEnvironment.ToUpper())
            {
                        case "COMETDEV":
                            this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
               (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                        case "COMETUAT":
                            this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
               (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                        case "ROLCERT":
                            this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                        case "MOLUAT":
                            this.DeserializeTheXmlDataInMemory(GetInMemoryTestDataFilePath
                 (AutomationConfigurationManager.ApplicationTestEnvironment)); break;
                        default: throw new ArgumentException("The suggested environment was not found");
            }
        }

        /// <summary>
        /// Deserialize The XML Data In Memory.
        /// </summary>
        /// <param name="xmlTestDataFilePath">This is the xml file path.</param>
        private void DeserializeTheXmlDataInMemory(String xmlTestDataFilePath)
        {
            // get xml data based on file path
            String getXmlData = File.ReadAllText(xmlTestDataFilePath);
            var xmlDocument = new XmlDocument();
            // load xml data
            xmlDocument.LoadXml(getXmlData);

            // desearlize dat
            DesearlizeUserTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
            //DesearlizePackageTestData(xmlDocument, ref xmlNodeList, ref xmlSerializer);
        }

        /// <summary>
        /// Get the In Memory Test Data XML File Path.
        /// </summary>
        /// <param name="applicationEnvironment">This is application nvironment name.</param>
        /// <returns>In memory TestData xml file path.</returns>
        private String GetInMemoryTestDataFilePath(string applicationEnvironment)
        {
            // get xml file path
            String xmlFilePath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
            + "\\..\\..\\..\\MMSG.Automation\\InMemoryTestData\\TestData"
            + applicationEnvironment + ".xml").Replace("file:\\", "");
            return xmlFilePath;
        }

        /// <summary>
        /// Desearlize User Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizeUserTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for courses
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfUser");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<User>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get users list
                var getUserList = (List<User>)
                 xmlSerializer.Deserialize(reader);
                foreach (User users in getUserList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(users);
                }
            }
        }

        /// <summary>
        /// Desearlize User Test Data In Memory.
        /// </summary>
        /// <param name="xmlDocument">Represents an XML document.</param>
        /// <param name="xmlNodeList">Represents an ordered collection of nodes.</param>
        /// <param name="xmlSerializer">Serializes and deserializes objects into and from XML documents. 
        /// The XmlSerializer enables you to control how objects are encoded into XML.</param>
        private void DesearlizePackageTestData(XmlDocument xmlDocument,
            ref XmlNodeList xmlNodeList, ref XmlSerializer xmlSerializer)
        {
            // get xml node list for Package
            xmlNodeList = xmlDocument.SelectNodes("Data/ArrayOfPackage");
            // created object xml serializer
            xmlSerializer = new XmlSerializer(typeof(List<Package>));
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                // created object xml node reader
                var reader = new XmlNodeReader(xmlNodeList.Item(0));
                // get users list
                var getUserList = (List<Package>)
                 xmlSerializer.Deserialize(reader);
                foreach (Package packages in getUserList)
                {
                    // push in memory
                    _inMemoryDatabase.Insert(packages);
                }
            }
        }

        /// <summary>
        /// This class returns the instance of the in memory database
        /// </summary>
        /// <returns></returns>
        private static InMemoryDatabaseSingleton GetInstance()
        {
            //if the instance doesnt exist then create a new one
            return _inMemoryDatabaseSingleton ?? (_inMemoryDatabaseSingleton = new InMemoryDatabaseSingleton());
        }

        /// <summary>
        /// This is the instance of the database
        /// </summary>
        public static InMemoryDatabase DatabaseInstance
        {
            get { return GetInstance()._inMemoryDatabase; }
        }
    }
}