namespace Praktikumsaufgabe_4__Generics_
{
    /// <summary>
    /// Person with Infos
    /// </summary>
    class VaccPerson
    {
        public string name, adress, passNumber;

        public VaccPerson(string name, string adress, string number)
        {
            this.name = name;
            this.adress = adress;
            passNumber = number;
        }

        public override string ToString()
        {
            return "Name: " + name + " \n" + "Adress: " + adress + " \n" + "Passnum: " + passNumber + "\n";
        }
    }

}
