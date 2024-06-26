using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices
{
    public interface IBlockRepository
    {
        public bool InsertBlockDetails(string blockName);
        public bool DeleteBlockData(int id);
        public DataSet GetBlockData();
        public bool UpdateBlockData(int id, bool status);
        public bool UpdateBlockDetails(string blockName,int id);
    }
}
