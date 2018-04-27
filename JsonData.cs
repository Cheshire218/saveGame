using System.IO;
using UnityEngine;

namespace Assets._scripts.GU_04_04_2018
{
    public class JsonData : IData<Player>
    {
        private string _path;
        public void Save(Player player)
        {
            var str = JsonUtility.ToJson(player);
            File.WriteAllText(_path, Crypto.CryptoXOR(str));
        }
        public Player Load()
        {
            var str = File.ReadAllText(_path);
            return JsonUtility.FromJson<Player>(Crypto.CryptoXOR(str));
        }
        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "KirsanJsonData.GeekBrains");
        }
    }
}
