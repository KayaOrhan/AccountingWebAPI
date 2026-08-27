using System;
using System.Collections.Generic;
using System.Text;

namespace Muhasebe.Domain.Abstraction
{
    public abstract class Entity
    {
        public string  Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
