using Newtonsoft.Json;
using System.Collections.Generic;

namespace CriticalHit;

public class CritMessage
{
	[JsonProperty("��ϸ��Ϣ����")]
	public Dictionary<string, int[]> Messages = new Dictionary<string, int[]>();
}
