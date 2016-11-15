namespace ConsoleApplication
{
    using System;
    using System.Configuration;

    using Yandex.Api.Services;

    public class Address
    {
        public string Value;

        public double DistanseFromHome;

        private Address(string value, double distanse)
        {
            this.Value = value;
            this.DistanseFromHome = distanse;
        }

        public static Address Parse(string value)
        {
            GeocodeService service = new GeocodeService();

            var addressPoint = service.GetPoint(value);
            var homePoint = service.GetPoint(ConfigurationManager.AppSettings["home"]);

            double distanse =
                Math.Sqrt(
                    (addressPoint.Latitude - homePoint.Latitude) * (addressPoint.Latitude - homePoint.Latitude)
                    + (addressPoint.Longitude - homePoint.Longitude) * (addressPoint.Longitude - homePoint.Longitude));

            service = null;

            return new Address(value, distanse);
        }
    }
}
