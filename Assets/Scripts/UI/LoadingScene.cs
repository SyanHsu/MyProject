using DG.Tweening;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public EventSystem eventSystem;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        canvasGroup = GetComponent<CanvasGroup>();
        eventSystem = ServiceLocator.Get<EventSystem>();
        eventSystem.AddListener<int>(EEvent.BeforeLoadScene, (_) => canvasGroup.DOFade(1f, 0.5f));
        eventSystem.AddListener<int>(EEvent.AfterLoadScene, (_) => canvasGroup.DOFade(0f, 0.5f));
    }
}
