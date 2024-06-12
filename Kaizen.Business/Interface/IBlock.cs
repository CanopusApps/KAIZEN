using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IBlock
    {
        public string CreateBlock(BlockModel model);
        public DataSet GetBlock(BlockModel model);
        public string DeleteBlock(BlockModel model);
    }
}
