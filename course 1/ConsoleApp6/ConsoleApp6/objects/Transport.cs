using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp6.enums;

namespace LabApp6.objects
{
    internal class Transport
    {
        private string transportName;
        private TransportType transportType;
        private DateTime registrationDate;
        private double price;
        private Detail[] details;

        public Transport(string transportName, TransportType transportType, DateTime registrationDate, double price, Detail[] details)
        {
            this.transportName = transportName;
            this.transportType = transportType;
            this.registrationDate = registrationDate;
            this.price = price;
            this.details = details;
        }
        public Transport()
        {
            transportName = "Unknown";
            transportType = TransportType.Ground;
            registrationDate = DateTime.Now;
            price = 0;
            details = new Detail[0];
        }
        public string TransportName
        {
            get {return transportName;}
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value", "The name cannot be empty");
                transportName = value;
            }
        }
        public TransportType TransportType {get; set;}
        public DateTime RegistrationDate {get; set;}
        public double Price
        {
            get {return price;}
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "The price cannot be negative");

                price = value;
            }
        }
        public Detail[] Details
        {
            get {return details;}
            set {details = value;}
        }
        public double TotalWeight
        {
            get => details.Sum(d => d.Weight);
        }
        public bool this[TransportType type]
        {
            get {return transportType == type;}
        }
        public void AddDetails(params Detail[] newDetails)
        {
            details = details.Concat(newDetails).ToArray();
        }
        public override string ToString()
        {
            return $"Name: {transportName}\n" +
                   $"Type: {transportType}\n" +
                   $"Date of registration: {registrationDate.ToShortDateString()}\n" +
                   $"Price: {price}\n" +
                   $"Total weight details: {TotalWeight}\n" +
                   $"Details:\n" +
                   string.Join("\n", details.Select(d => d.ToString()));
        }
        public string ToShortString()
        {
            return $"Name: {transportName}, Type: {transportType}, Price: {price}, Total weight details: {TotalWeight}";
        }
    }
}