using UnityEngine;

namespace Geekbrains.Editor
{
    public class CreateMinesFromRes : MonoBehaviour
    {

        [SerializeField] private int _count = 1;
        [SerializeField] private int _height = 1;
 
        private Transform _myTransform;

        private void Start()
        {
            CreateObj();
        }

        public void CreateObj()
        {
            GameObject obj = Resources.Load("Mine") as GameObject;
            _myTransform = transform;
            float halfX = _myTransform.localScale.x * 5;
            float halfZ = _myTransform.localScale.z * 5;
            for (int i = 0; i < _count; i++)
            {
                Instantiate(obj, new Vector3(_myTransform.position.x + Random.Range(-halfX, halfX), _myTransform.position.y + _height, _myTransform.position.z + Random.Range(-halfZ, halfZ)), Quaternion.identity);
            }
        }


    }
}