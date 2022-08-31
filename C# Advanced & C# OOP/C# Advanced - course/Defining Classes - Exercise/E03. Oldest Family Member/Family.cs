using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMember;
        public Family()
        {
            this.familyMember = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.familyMember.Add(person);
        }

        public Person GetOldestMember()
        {
            int maxAge = this.familyMember.Max(person => person.Age);
            return this.familyMember.First(person => person.Age == maxAge);
        }

    }
}
