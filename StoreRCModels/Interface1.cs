using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRCModels
{
    public interface IRCModelsRepository
    {
        RCModel[] GetAllByTitel(string titel);
    }
}
