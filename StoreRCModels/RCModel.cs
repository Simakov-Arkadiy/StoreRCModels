using System;

namespace StoreRCModels
{
    public class RCModel
    {
        public int numberRCModel { get; }
        public string nameRCModel { get; }
        public string typeRCModel { get; }
        public string color {  get; }
        public string description { get; }
        public decimal price { get; }

        public RCModel(int numberRCModel, string nameRCmodel, string typeRCModel, string color, string descriptoin, decimal price) 
        {
            this.numberRCModel = numberRCModel;
            this.nameRCModel = nameRCmodel;
            this.typeRCModel = typeRCModel;
            this.color = color;
            this.description = descriptoin;
            this.price = price;
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
