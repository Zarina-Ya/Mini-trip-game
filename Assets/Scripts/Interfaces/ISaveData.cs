
namespace ZarinkinProject
{

    public interface ISaveData<T>
    {
        void SaveData(T _player);

        T Load();
    }
}
