using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp8.task1.enums;
using LabApp8.task1.interfaces;

namespace LabApp8.task1.models
{
    internal class Transport : IFileContainer<Detail>, IEnumerable
    {
        private string transportName;
        private TransportType transportType;
        private DateTime registrationDate;
        private double price;

        private List<Detail> details;
        private bool isDataSaved;

        public Transport()
        {
            details = new List<Detail>();
        }
        public Transport(string transportName,
            TransportType transportType,
            DateTime registrationDate,
            double price,
            Detail[] details)
        {
            TransportName = transportName;
            TransportType = transportType;
            RegistrationDate = registrationDate;
            Price = price;
            this.details = details.ToList();
        }
        public string TransportName
        {
            get => transportName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                transportName = value;
            }
        }
        public TransportType TransportType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                price = value;
            }
        }
        public int Count => details.Count;
        public bool IsDataSaved => isDataSaved;
        public Detail this[int index]
        {
            get
            {
                if (index < 0 || index >= details.Count)
                    throw new IndexOutOfRangeException();
                return details[index];
            }
            set
            {
                if (index < 0 || index >= details.Count)
                    throw new IndexOutOfRangeException();
                details[index] = value;
            }
        }
        public void Add(Detail element)
        {
            details.Add(element);
            isDataSaved = false;
        }
        public void Delete(Detail element)
        {
            details.Remove(element);
            isDataSaved = false;
        }
        public void Sort()
        {
            details.Sort();
        }
        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Detail detail in details)
                {
                    writer.WriteLine(detail.ToString());
                }
            }
            isDataSaved = true;
        }
        public void Load(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            isDataSaved = true;
        }
        public IEnumerator GetEnumerator()
        {
            return details.GetEnumerator();
        }
        public override string ToString()
        {
            return string.Join("\n", details);
        }
    }
}
