
public interface IGameContext
{
    public T GetService<T>();

    public void AddService(object sercvice);

    public void RemoveService(object sercvice);

    public void AddListener(object listener);

    public void RemoveListener(object listener);

    public void ConstructGame();

    public void InitGame();

    public void StartGame();

    public void FinishGame();
}