using System;
using System.Collections.Generic;
using System.Text;

public class CustomXmlSerializer
{
	public string Serialize(object obj)
	{
		var properties = obj.GetType().GetProperties();
		var sb = new StringBuilder();
		sb.AppendFormat("<{0}>", obj.GetType().Name);

		foreach (var prop in properties)
		{
			var value = prop.GetValue(obj);
			sb.AppendFormat("<{0}>", prop.Name);

			if (value is IEnumerable<object> list)
			{
				foreach (var item in list)
				{
					sb.Append(Serialize(item));
				}
			}
			else
			{
				sb.Append(value);
			}

			sb.AppendFormat("</{0}>", prop.Name);
		}

		sb.AppendFormat("</{0}>", obj.GetType().Name);
		return sb.ToString();
	}

	public T Deserialize<T>(string xml) where T : new()
	{
		return new T();
	}
}

