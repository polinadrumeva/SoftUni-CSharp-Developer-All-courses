namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public string StealFieldInfo(string name, params string[] fieldsToInvestigate)
        { 
            Type objectToInvestigate = Type.GetType(name);
            FieldInfo[] fields = objectToInvestigate.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            var objectInv = Activator.CreateInstance(objectToInvestigate, new object[] { });
            sb.AppendLine($"Class under investigation: {objectToInvestigate.Name}");

            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(objectInv)}");
            }

            return sb.ToString();
        }
    }
}
