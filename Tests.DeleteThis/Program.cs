using Tests.Bll.Template;

namespace Tests.DeleteThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string question = "<adjective wordnumber=\"1\" gender=\"Neuther\" amount=\"many\" declension=\"Nominative\"></adjective> <noun wordnumber=\"2\" amount=\"many\" declension=\"Nominative\"></noun> — это <noun wordnumber=\"3\" amount=\"many\" declension=\"Nominative\"></noun>. Не все <adjective wordnumber=\"1\" gender=\"Neuther\" amount=\"many\" declension=\"Nominative\"></adjective> <noun wordnumber=\"2\" amount=\"many\" declension=\"Nominative\"></noun> <verb wordnumber=\"4\" time=\"Present\" amount=\"many\" person=\"3\"></verb> в темноте.";
            WordParser words = new WordParser(question);

        }
    }
}
