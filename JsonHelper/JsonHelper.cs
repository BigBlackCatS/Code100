using Newtonsoft.Json;

namespace Code100.JsonFuctionality
{
    public class JsonHelper
    {
        public static DataSet? LoadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<DataSet>(json);
            }
        }
    }
}
