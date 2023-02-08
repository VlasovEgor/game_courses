interface IUnloadZoneComponent
{
    int MaxValue { get; set; }

    int Value { get; set; }

    bool CanUnload();

    int UnloadAll();
}