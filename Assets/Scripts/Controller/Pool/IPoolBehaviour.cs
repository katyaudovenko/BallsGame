namespace Controller.Pool
{
    public interface IPoolBehaviour
    {
        void OnInitialize();
        void OnSetup();
        void OnReset();
    }
}