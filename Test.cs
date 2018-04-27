using UnityEngine;

namespace Assets._scripts.GU_04_04_2018
{
    public class Test : MonoBehaviour
    {
        //private IData<Player> _data = new StreamData();
        //private IData<Player> _data = new XMLData();
        //private IData<Player> _data = new PlayerPrefsData();
        private IData<Player> _data = new JsonData();

        void Start()
        {
            if (_data == null) return;
            var player = new Player
            {
                Name = "Kirsan",
                Hp = 100,
                IsVisible = true,
            };


            _data.SetOptions(Application.dataPath);
            _data.Save(player);

            var newPlayer = _data.Load();

            Debug.Log(newPlayer);
        }
    }
}