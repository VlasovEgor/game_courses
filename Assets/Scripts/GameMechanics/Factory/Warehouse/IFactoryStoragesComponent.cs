using System.Collections.Generic;

public interface IFactoryStoragesComponent
{
    public List<SerializedStorageData> StoragesList { get; }

    bool CanLoad(Ingredients storageType);

    void Load(Ingredients storageType, int resources);

    bool CanUnload(Ingredients storageType);

    int Unload(Ingredients storageType, int amount);

    int UnloadAll(Ingredients storageType);

    void SetupMaxValueAllStorages(int value);
}
