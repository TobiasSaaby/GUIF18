using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GUI_eksamen___Opgave_1
{
    class Repository
    {
        static public bool ReadFile(string fileName, out List<Bistad> bistader)
        {
            bistader = new List<Bistad>();
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(List<Bistad>));

            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            bistader = (List<Bistad>)serializer.Deserialize(reader);
            reader.Close();

            return true;
        }

        internal static void SaveFile(string fileName, List<Bistad> bistader)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(List<Bistad>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, bistader);
            writer.Close();
        }
    }
}
