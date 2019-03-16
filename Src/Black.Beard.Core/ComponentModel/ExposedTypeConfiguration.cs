using Bb.ComponentModel.Attributes;
using System.Collections.Generic;

namespace Bb.ComponentModel
{
    
    [ExposeClass(Context = ConstantsCore.Configuration, Name = "ExposedTypes")]
    public class ExposedTypeConfigurations
    {

        public ExposedTypeConfigurations()
        {
            Attributes = new List<ExposedAttributeTypeConfiguration>();
        }

        public string TypeName { get; set; }

        public List<ExposedAttributeTypeConfiguration> Attributes { get; set; }

    }

    public class ExposedAttributeTypeConfiguration
    {

        public ExposedAttributeTypeConfiguration()
        {

        }

        public string TypeName { get; set; }

        public string Context { get; set; }

        public string DisplayName { get; set; }

        public IocScopeEnum LifeCycle { get; set; }

    }

}
