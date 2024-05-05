using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class Person : IXmlSerializable
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Required for IXmlSerializable
    public XmlSchema GetSchema()
    {
        // Create an XML schema for the Person object
        XmlSchema schema = new XmlSchema();

        // Define elements for Name and Age
        XmlSchemaElement nameElement = new XmlSchemaElement
        {
            Name = "Name",
            SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        };
        schema.Items.Add(nameElement);

        XmlSchemaElement ageElement = new XmlSchemaElement
        {
            Name = "Age",
            SchemaTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema")
        };
        schema.Items.Add(ageElement);

        return schema;
    }

    // Called when serializing object to XML
    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("Person");

        writer.WriteStartElement("Name");
        writer.WriteString(Name);
        writer.WriteEndElement();

        writer.WriteStartElement("Age");
        writer.WriteValue(Age);
        writer.WriteEndElement();

        writer.WriteEndElement();
    }

    // Called when deserializing XML to object
    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("Person");

        reader.ReadStartElement("Name");
        Name = reader.ReadContentAsString();
        reader.ReadEndElement();

        reader.ReadStartElement("Age");
        Age = reader.ReadContentAsInt();
        reader.ReadEndElement();

        reader.ReadEndElement();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a person object
        Person person = new Person { Name = "John", Age = 30 };

        // Serialize the person object to XML
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (XmlWriter writer = XmlWriter.Create("person.xml"))
        {
            serializer.Serialize(writer, person);
        }
    }
}
