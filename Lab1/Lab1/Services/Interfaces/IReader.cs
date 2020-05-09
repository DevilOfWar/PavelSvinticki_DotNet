using System.Collections.Generic;

namespace Lab1.Services.Interfaces
{
    public interface IReader<T>
    {
        IEnumerable<T> Read(string path, out List<string> fieldNames);
    }
}
