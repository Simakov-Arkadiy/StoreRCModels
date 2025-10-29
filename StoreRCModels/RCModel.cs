using System;

namespace StoreRCModels
{
    public class RCModel
    {
        public int numberRCModdel { get; }
        public string nameRCModel { get; }
        public string typeRCModel { get; }
        public string color {  get; }

        public RCModel(int numberRCModel, string nameRCmodel, string typeRCModel, string color) 
        {
            this.numberRCModdel = numberRCModel;
            this.nameRCModel = nameRCmodel;
            this.typeRCModel = typeRCModel;
            this.color = color;
        }
        internal static bool IsTypeRCModel(string s)
        {
            if (s == null) 
                return false;
            s = s.ToLower();
            switch (s)
            {
                
                case "tank"
                    : return true;
                case "fly"
                    : return true;
                case "car"
                    :return true;
                default
                    : return false;
            }
        }
        
    }
}
