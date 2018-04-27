using System.IO;
using UnityEngine;

namespace Assets._scripts.GU_04_04_2018
{
    public class PlayerPrefsData : IData<Player>
    {
        private string _path;
        public void Save(Player player)
        {
            PlayerPrefs.SetString("Name", Crypto.CryptoXOR(player.Name));
            PlayerPrefs.SetString("Hp", Crypto.CryptoXOR(player.Hp.ToString()));
            PlayerPrefs.SetString("IsVisible", Crypto.CryptoXOR(player.IsVisible.ToString()));
            PlayerPrefs.Save();
        }
        public Player Load()
        {
            Player result = new Player();
            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = Crypto.CryptoXOR(PlayerPrefs.GetString(key));
            }
            key = "Hp";
            if (PlayerPrefs.HasKey(key))
            {
                result.Hp = System.Convert.ToSingle(Crypto.CryptoXOR(PlayerPrefs.GetString(key)));
            }
            key = "IsVisible";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsVisible = Crypto.CryptoXOR(PlayerPrefs.GetString(key)).IsTryBool();
            }
            return result;
        }


        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "KirsanPlayerPrefsData.GeekBrains");
        }
        public void Clear()
        {
            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
            }
            PlayerPrefs.DeleteAll();
        }

    }

}
