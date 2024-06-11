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
        public readonly IBlockData _repositoryBlockdata;
        public BlockWorker(IBlockData repositoryBlockdata)
        {
            this._repositoryBlockdata = repositoryBlockdata;
        }

        public string CreateBlock(string blockName)
        {

            DataTable dt = new DataTable();
            string message = _repositoryBlockdata.CreateBlockData(blockName);
            return message;

        }

        public DataSet GetBlock(BlockModel model)
        {
            DataSet ds = new DataSet();
            ds = _repositoryBlockdata.GetBlockData(model);
            return ds;
        }
    }
}
