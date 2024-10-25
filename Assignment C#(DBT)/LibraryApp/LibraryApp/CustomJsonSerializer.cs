using System;
using System.Collections.Generic;
using System.Text;

public class CustomJsonSerializer
{
	public string Serialize(object obj)
	{
		var properties = obj.GetType().GetProperties();
		var sb = new StringBuilder("{");

		foreach (var prop in properties)
		{
			sb.AppendFormat("\"{0}\":", prop.Name);
			var value = prop.GetValue(obj);

			if (value is string || value is int || value is bool)
			{
				sb.AppendFormat("\"{0}\"", value);
			}
			else if (value is IEnumerable<object> list)
			{
				sb.Append("[");
				foreach (var item in list)
				{
					sb.Append(Serialize(item) + ",");
				}
				sb.Length--; 
				sb.Append("]");
			}
			sb.Append(",");
		}

		sb.Length--;
		sb.Append("}");
		return sb.ToString();
	}

	public T Deserialize<T>(string json) where T : new()
	{
	
		return new T();
	}
}
