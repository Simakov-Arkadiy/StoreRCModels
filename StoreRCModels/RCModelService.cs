using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public class RCModelService
    {
        private IRCModelsRepository repository;

        public RCModelService(IRCModelsRepository repository)
        {
            this.repository = repository;
        }
        public RCModel[] GetAllByQuery(string query)
        {
            if (RCModel.IsTypeRCModel(query))
            {
                return repository.GetAllByType(query);
            }
            else
            {
                return repository.GetAllByTitel(query);
            }
        }
    }
}
