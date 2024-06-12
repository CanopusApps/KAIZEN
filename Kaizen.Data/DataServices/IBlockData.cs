using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IBlockData
    {
        public string CreateBlockData(BlockModel model);
        public string DeleteBlockData(BlockModel model);
        public DataSet GetBlockData(BlockModel model);
    }
}
