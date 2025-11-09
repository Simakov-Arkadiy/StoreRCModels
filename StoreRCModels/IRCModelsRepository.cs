using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public interface IRCModelsRepository
    {
        RCModel[] GetAllByType(string color);
        RCModel[] GetAllByTitel(string titel);
        RCModel GetById(int numberRCModel);
        RCModel[] GetAllById(IEnumerable<int> rcmodelIds);
    }
}
