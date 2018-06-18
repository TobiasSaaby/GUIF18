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
        static public bool ReadFile(string fileName, out Tuple<List<Bistad>, List<MideTal>> bimider)
        {

            bimider = Tuple.Create(new List<Bistad>(), new List<MideTal>());

            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(TupleIsh<List<Bistad>, List<MideTal>>));

            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            bimider = (TupleIsh<List<Bistad>, List<MideTal>>)serializer.Deserialize(reader);
            reader.Close();

            return true;
        }

        internal static void SaveFile(string fileName, TupleIsh<List<Bistad>, List<MideTal>> bimider)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(
    typeof(TupleIsh<List<Bistad>, List<MideTal>>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, bimider);

            writer.Close();
        }
    }
}
