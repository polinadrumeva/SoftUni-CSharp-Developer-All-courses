namespace Cadastre.Utilities
{
    using System.Text;
    using System.Xml.Serialization;
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
	        var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var reader = new StringReader(inputXml);
            var deserializedDto = (T)serializer.Deserialize(reader);

            return deserializedDto;
        }
        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
	        var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var deserializedDtos = (T[])serializer.Deserialize(reader);

            return deserializedDtos;
        }

        public string Serialize<T>(T obj, string rootName)
        {
	        var sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute(rootName);
			var serializer = new XmlSerializer (typeof(T), xmlRoot);
			var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using var writer = new StringWriter();
            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().Trim();
        }

        public string Serialize<T>(T[] obj, string rootName)
        {
	        var sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute (rootName);
            var serializer = new XmlSerializer(typeof(T[]), xmlRoot);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add (string.Empty, string.Empty);

            using var writer = new StringWriter();
            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().Trim();
        }
    }    
}
