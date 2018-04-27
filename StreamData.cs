using UnityEngine;
using System.IO;

namespace Assets._scripts.GU_04_04_2018
{
    public class StreamData : IData<Player>
    {
        private string _path;

        public Player Load()
        {
            var result = new Player();

            if (!File.Exists(_path)) return result;

            using (var sr = new StreamReader(_path))
            {
                while(!sr.EndOfStream)
                {
                    result.Name = Crypto.CryptoXOR(sr.ReadLine());
                    result.Hp = System.Convert.ToSingle(Crypto.CryptoXOR(sr.ReadLine()));
                    result.IsVisible = Crypto.CryptoXOR(sr.ReadLine()).IsTryBool();
                }
            }

                return result;
        }

        public void Save(Player data)
        {
            using (var sw = new StreamWriter(_path))
            {
                sw.WriteLine(Crypto.CryptoXOR(data.Name));
                sw.WriteLine(Crypto.CryptoXOR(data.Hp.ToString()));
                sw.WriteLine(Crypto.CryptoXOR(data.IsVisible.ToString()));
            }
        }

        public void SetOptions(string path = "")
        {
            _path = Path.Combine(path, "Kirsan.Geekbrains");
        }
    }
}
