using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApp
{
    public interface IAlgo
    {
        List<int> Sort(List<int> numList);
        char Id { get; }
        string Name { get; }
    }
}
