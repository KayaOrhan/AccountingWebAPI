
using System.Reflection;

namespace Muhasebe.Persistance
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
