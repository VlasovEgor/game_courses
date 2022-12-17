
public interface IWarehouseComponent
{
    public Ingredients Type { get; }

    bool CanLoad();

    void Load(int resources);

    bool CanUnload();

    int Unload(int amount);

    int UnloadAll();
}
