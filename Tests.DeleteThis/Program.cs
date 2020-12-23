using Tests.Bll.Template;

namespace Tests.DeleteThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string question = "<adjective id=\"1\" gender=\"Neuther\" amount=\"many\" declension=\"Nominative\"></adjective> <noun id=\"2\" amount=\"many\" declension=\"Nominative\"></noun> — это <noun id=\"3\" amount=\"many\" declension=\"Nominative\"></noun>. Не все <adjective id=\"1\" gender=\"Neuther\" amount=\"many\" declension=\"Nominative\"></adjective> <noun id=\"2\" amount=\"many\" declension=\"Nominative\"></noun> <verb id=\"4\" time=\"Present\" amount=\"many\" person=\"3\"></verb> в темноте.";
            var words = new WordParser(question);
        }
    }
}
