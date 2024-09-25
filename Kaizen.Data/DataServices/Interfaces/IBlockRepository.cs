using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Data.DataServices
{
    public interface IBlockRepository
    {
        public bool InsertBlockDetails(BlockModel blockmodel);
        public bool DeleteBlockData(int id);
        public DataSet GetBlockData();
        public bool UpdateBlockData(int id, bool status);
        public bool UpdateBlockDetails(BlockModel blockmodel);
    }
}
