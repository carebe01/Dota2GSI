using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Dota2GSI.Nodes
{
    public class Node
    {
        protected JObject _ParsedData;

        internal Node(string json_data)
        {
            if (json_data.Equals(""))
            {
                json_data = "{}";
            }
            _ParsedData = JObject.Parse(json_data);
        }

        internal string GetString(string Name)
        {
            JToken value;
            
            if(_ParsedData.TryGetValue(Name, out value))
                return value.ToString();
            else
                return "";
        }

        internal int GetInt(string Name)
        {
            JToken value;
            
            if(_ParsedData.TryGetValue(Name, out value))
                return Convert.ToInt32(value.ToString());
            else
                return -1;
        }

        internal long GetLong(string Name)
        {
            JToken value;

            if (_ParsedData.TryGetValue(Name, out value))
                return Convert.ToInt64(value.ToString());
            else
                return -1;
        }

        internal T GetEnum<T>(string Name)
        {
			JToken value;

			if (_ParsedData.TryGetValue(Name, out value) && !string.IsNullOrWhiteSpace(value.ToString()))
			{
				try
				{
					return (T)Enum.Parse(typeof(T), value.ToString(), true);
				}
				catch
				{
					return (T)Enum.Parse(typeof(T), "Undefined", true);
				}
			}
			else
			{
				return (T)Enum.Parse(typeof(T), "Undefined", true);
			}
		}

        internal bool GetBool(string Name)
        {
            JToken value;
            
            if(_ParsedData.TryGetValue(Name, out value) && value.ToObject<bool>())
                return value.ToObject<bool>();
            else
                return false;
        }

        internal IJEnumerable<JToken> GetArray(string Name)
        {
	        Newtonsoft.Json.Linq.JToken value;

	        if (_ParsedData.TryGetValue(Name, out value) && value.HasValues)
		        return value.Values();
	        else
		        return new JEnumerable<JToken>();
        }
    }
}
