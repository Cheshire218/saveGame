using UnityEngine;

namespace Assets._scripts.GU_04_04_2018
{
    public class Test : MonoBehaviour
    {
        private IData<Player> _data;
        
        void Start()
        {
            if (_data == null) return;
        }
    }
}