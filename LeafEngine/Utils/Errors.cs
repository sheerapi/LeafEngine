using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{

    [Serializable]
    public class ShaderException : Exception
    {
        public ShaderException() { }
        public ShaderException(string message) : base(message) { }
        public ShaderException(string message, Exception inner) : base(message, inner) { }
        protected ShaderException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
