using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> collection;
        private string name;
        private int neededRenovators;
        private string project;

        public List<Renovator> Collection { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        // Getter Count - returns the count of the renovators in the catalog.
        public int Count { get { return this.Collection.Count; } }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Collection = new List<Renovator>();
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }


        //•	string AddRenovator(Renovator renovator) - adds a renovator to the catalog's collection, if renovators are still needed.
        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Name == string.Empty || renovator.Name == " " || renovator.Type == null || renovator.Type == string.Empty || renovator.Type == " ")
            {
                return "Invalid renovator's information.";
            }
            else if (Collection.Count + 1 > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
           

             Collection.Add(renovator);
             return $"Successfully added {renovator.Name} to the catalog.";
            
        }

        //•	bool RemoveRenovator(string name) - removes a renovator by given name.
        public bool RemoveRenovator(string name)
        {
            Renovator renovatroToRemove = Collection.FirstOrDefault(x => x.Name == name);
            if (renovatroToRemove != null)
            {
                Collection.Remove(renovatroToRemove);
                return true;
            }
            return false;
        }

        //•	int RemoveRenovatorBySpecialty(string type) - removes all renovators by the given specialty.
        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> renovatorsToRemove = Collection.Where(x => x.Type == type).ToList();
            if (renovatorsToRemove.Count > 0)
            {
                Collection.RemoveAll(x => x.Type == type);
                return renovatorsToRemove.Count;
            }

            return 0;
        }

        //•	Renovator HireRenovator(string name) method – hire(set their available property to true without removing them from the collection) the renovator with the given name, if they exist.As a result, return the renovator, or null, if they don't exist.

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = Collection.FirstOrDefault(x => x.Name == name);
            if (renovatorToHire != null)
            {
               renovatorToHire.Hired = true;   
                return renovatorToHire;
            }

            return null;
        }

        //•	List<Renovator> PayRenovators (int days) method – return a list with all renovators that have been working for days days or more.
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsWorking = Collection.Where(x => x.Days >= days).ToList();
            return renovatorsWorking;
        }

        //•	Report() – returns a string with information about the catalog and renovators who are not hired in the following format:
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var renovator in Collection.Where(x => x.Hired == false))
            {
                report.AppendLine(renovator.ToString().TrimEnd());
            }

            return report.ToString();
        }

    }
}
