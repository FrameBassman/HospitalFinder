namespace ConsoleApplication
{
    using System.Collections.Generic;

    public class Hospital
    {
        public string Name;

        public List<Address> Addresses;

        public Hospital(string name, string[] addressStrings)
        {
            this.Name = name;

            this.Addresses = new List<Address>();

            foreach (var address in addressStrings)
            {
                this.Addresses.Add(Address.Parse(address));
            }
        }
    }
}
