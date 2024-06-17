using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class BlockWorker : IBlock
    {
        public readonly IBlockRepository _repositoryBlockdata;
        public BlockWorker(IBlockRepository repositoryBlockdata)
        {
            this._repositoryBlockdata = repositoryBlockdata;
        }
        
        public bool InsertBlockDetails(string blockName)
        {

            return _repositoryBlockdata.InsertBlockDetails(blockName);

        }

        public bool DeleteBlock(int id)
        {

            return _repositoryBlockdata.DeleteBlockData(id);

        }

        public bool UpdateBlockStatus(int id,bool status)
        {

            return _repositoryBlockdata.UpdateBlockData(id, status);

        }
        public List<BlockModel> GetBlock()
        {            
            DataSet ds;
			List<BlockModel> blackModels = new List<BlockModel>();
            ds = _repositoryBlockdata.GetBlockData();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
					blackModels.Add(new BlockModel
                    {
                        Id = Convert.ToInt32(dr["BlockId"]),
                        BlockName = dr["BlockName"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"])
                    });
                }
            }
			return blackModels;
        }
	}
}
