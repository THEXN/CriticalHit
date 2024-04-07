using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CriticalHit;

public class Config
{
    [JsonProperty("总开关")]
    public bool enable = false;
    [JsonProperty("仅暴击显示")]
    public bool noCritMessages = true;
    [JsonProperty("消息分类")]
    public Dictionary<WeaponType, CritMessage> CritMessages = new Dictionary<WeaponType, CritMessage>();

    public void Write(string path)
    {
        using FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
        Write(stream);
    }

    public void Write(Stream stream)
    {
        string value = JsonConvert.SerializeObject((object)this, (Formatting)1);
        using StreamWriter streamWriter = new StreamWriter(stream);
        streamWriter.Write(value);
    }

    public void Read(string path)
    {
        if (File.Exists(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Read(stream);
            }
        }
    }

    public void Read(Stream stream)
    {
        using StreamReader streamReader = new StreamReader(stream);
        Config deserializedConfig = JsonConvert.DeserializeObject<Config>(streamReader.ReadToEnd());
        // 更新所有属性
        enable = deserializedConfig.enable;
        noCritMessages = deserializedConfig.noCritMessages;
        CritMessages = deserializedConfig.CritMessages;
    }

}
