using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IBlockData
    {
        public string CreateBlockData(string blockName, out string msg);
    }
}
