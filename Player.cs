using System;

namespace Assets._scripts.GU_04_04_2018
{
    public struct Player
    {
        public string Name;
        public float Hp;
        public bool IsVisible;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Name, Hp, IsVisible);
        }
    }
}