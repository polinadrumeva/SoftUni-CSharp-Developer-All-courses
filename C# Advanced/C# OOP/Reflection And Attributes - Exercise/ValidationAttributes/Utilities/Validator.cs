namespace ValidationAttributes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Text;


    public static class Validator
    {
        public static bool IsValid(object obj)
        {
           Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().Where(p => p.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);
                foreach (CustomAttributeData customAttribute in property.CustomAttributes)
                {
                    Type customAttrType = customAttribute.AttributeType;
                    object attribInstance = property.GetCustomAttribute(customAttrType);

                    MethodInfo vaidateMethod = customAttrType.GetMethods().First(m => m.Name == "IsValid");
                    bool result = (bool)vaidateMethod.Invoke(attribInstance, new object[] { propValue });

                    if (!result)
                    { 
                        return false;
                    }

                }
            }

            return true;
        }
    }
}
