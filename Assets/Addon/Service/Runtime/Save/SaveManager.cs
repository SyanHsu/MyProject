using Services;
using UnityEngine;

public class SaveManager : SaveManagerBase
{
    protected string defaultSavePath;

    protected override void Awake()
    {
        base.Awake();
        defaultSavePath = FileTool.CombinePath(Application.persistentDataPath, "save.json");
        core = new SaveManagerCore();
        Read(defaultSavePath);
    }

    protected internal override void Init()
    {
        base.Init();
        eventSystem.AddListener<int>(EEvent.BeforeLoadScene, BeforeLoadScene);
    }

    private void BeforeLoadScene(int index)
    {
        if (index < SceneController.GameIndex)
            NeedLoad = false;
    }

    public void Save()
        => base.Save(defaultSavePath);
}
