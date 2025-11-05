

using StoreRCModel.Web.Models;
using System.Text;

namespace StoreRCModel.Web
{
    public static class SessionExstantioncs
    {
        private const string key = "Clart";
        public static void Set(this ISession session, Clart value)
        {
            if (value == null)
                return;
            using(var stream = new MemoryStream())
            using(var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.items.Count);
                foreach (var item in value.items)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                }
                writer.Write(value.amount);
                session.Set(key, stream.ToArray());
            }
        }
        public static bool TryGetCart(this ISession session, out  Clart value)
        {
            if(session.TryGetValue(key,out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    value = new Clart();
                    var lenght = reader.ReadInt32();
                    for (int i = 0; i < lenght; i++) 
                    {
                        var bookId = reader.ReadInt32();
                        var count = reader.ReadInt32();

                        value.items.Add(bookId, count);
                    }
                    value.amount = reader.ReadDecimal();
                    return true;    
                }
            }
            value = null;
            return false;
        }
    }
}
