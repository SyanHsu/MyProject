using Services;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-999)]
public class GameLauncher : MonoBehaviour
{
    public bool needConfirm;

    public Slider progressSlider;
    public Text reminderText;

    private SceneController sceneController;

    private int count_incomplete;
    /// <summary>
    /// 剩余的初始化任务数
    /// </summary>
    public int Count_Incomplete
    {
        get => count_incomplete;
        set
        {
            if (value < 0 || value == count_incomplete)
                return;
            if (value == 0)
                StartGame();
            count_incomplete = value;
        }
    }

    private void Awake()
    {
        Count_Incomplete = 1;
    }

    private void Start()
    {
        sceneController = ServiceLocator.Get<SceneController>();
        Invoke(nameof(Initialize), 1f);
    }

    private void Initialize()
    {
        Random.InitState(System.DateTime.Now.Second);
        Count_Incomplete--;
    }

    private void StartGame()
    {
        GameInitSettings settings = Resources.Load<GameInitSettings>("GameInitSettings");
        if (needConfirm)
        {
            sceneController.AsyncLoadScene += OnLoadingScene;
        }
        sceneController.LoadScene(settings == null ? 1 : settings.index_startGame, needConfirm);
    }

    private void OnLoadingScene(AsyncOperation asyncOperation)
    {
        StartCoroutine(WaitingLoadingScene(asyncOperation));
    }

    private IEnumerator WaitingLoadingScene(AsyncOperation asyncOperation)
    {
        do
        {
            progressSlider.value = asyncOperation.progress;
            yield return null;
        } while (asyncOperation.progress < 0.9f);
        progressSlider.value = 1f;
        reminderText.enabled = true;
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
        sceneController.AsyncLoadScene -= OnLoadingScene;
    }
}