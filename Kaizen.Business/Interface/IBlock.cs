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
        public string CreateBlock(string blockName);
        public DataSet GetBlock(BlockModel model);
    }
}
