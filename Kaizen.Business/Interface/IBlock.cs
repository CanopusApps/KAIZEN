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
        public bool InsertBlockDetails(BlockModel blockmodel);
        public List<BlockModel> GetBlock();
        public bool DeleteBlock(int id);

        public bool UpdateBlockStatus(int id, bool status);
        public bool UpdateBlockDetails(BlockModel blockmodel);
        
    }
}
