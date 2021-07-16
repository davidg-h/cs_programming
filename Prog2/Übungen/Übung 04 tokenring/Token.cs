
namespace Übung_4
{
    class Token
    {
        string data;
        int sender;
        int empfänger;

        public string Data
        {
            get { return data; }
        }
        public int Transmitter
        {
            get { return sender; }
        }
        public int Receiver
        {
            get { return empfänger; }
        }

        public Token(string Data, int transmitter, int receiver)
        {
            data = Data;
            sender = transmitter;
            empfänger = receiver;
        }
    }
}
