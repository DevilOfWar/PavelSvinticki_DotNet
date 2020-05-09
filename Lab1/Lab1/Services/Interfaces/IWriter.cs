using System.Collections.Generic;

namespace Lab1.Services.Interfaces
{
    public interface IWriter<T>
    {
        void Write(IEnumerable<T> collection, IEnumerable<string> fieldNames, string path);
    }
}
