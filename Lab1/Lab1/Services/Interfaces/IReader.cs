using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Services.Interfaces
{
    public interface IReader<T>
    {
        IEnumerable<T> Read(string path, out List<string> fieldNames);
    }
}
