namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["home"]))
            {
                Console.WriteLine("Navigate to App.config and fill 'value' variable.");
                return;
            }

            var hospitalList = new List<Hospital>();

            using (var streamReader = new StreamReader("HospitalAddresses.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    var pair = ParseLine(line);
                    hospitalList.Add(new Hospital(pair.Key, pair.Value));
                }
            }

            double maxDistanse = double.MaxValue;
            string result = string.Empty;

            foreach (Hospital hospital in hospitalList)
            {
                foreach (Address address in hospital.Addresses)
                {
                    if (maxDistanse > address.DistanseFromHome)
                    {
                        maxDistanse = address.DistanseFromHome;
                        result = address.Value + ";" + hospital.Name;
                    }
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static KeyValuePair<string, string[]> ParseLine(string hospital)
        {
            string[] strings = hospital.Split('\t');
            string hospitalName = strings[0];
            string[] hospitalAddresses = strings[1].Split(';');

            return new KeyValuePair<string, string[]>(hospitalName, hospitalAddresses);
        }
    }
}
