using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Utils
{
    public interface ISave<T>
    {
        public void Retain(T entitiy);

        public T Restore(string fileName);
    }
}
