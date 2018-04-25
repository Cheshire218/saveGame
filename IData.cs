namespace Assets._scripts.GU_04_04_2018
{
    public interface IData<T>
    {
        void Save(T data);
        T Load();
        void SetOptions(string path = "");
    }
}