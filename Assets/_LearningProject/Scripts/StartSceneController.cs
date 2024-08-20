using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] PageContainer _startPageContainer;
    [SerializeField] ModalContainer _startModalContainer;

    EventBus.EventBinding<ScreenTransitionEvent> _onScreenTransitionEvent;

    // Start is called before the first frame update
    void Start()
    {
        _onScreenTransitionEvent = new EventBinding<ScreenTransitionEvent>(OnTransitionEventReceived);
        _startPageContainer.Push("Screens/LoadingScreen", false,
            onLoad: x =>
            {
                var page = x.page;
                Debug.Log("LoadingScreen Loaded");
            });
    }

    private void OnTransitionEventReceived(ScreenTransitionEvent raisedEvent)
    {
        switch (raisedEvent.MyScreenType)
        {
            case ScreenType.StartupMainScreen:
                _startPageContainer.Push("Screens/StartupMainScreen", false,
                    onLoad: x =>
                    {
                        var page = x.page;
                        Debug.Log("StartupMainScreen Loaded");
                    });
                break;
            case ScreenType.LoadingScreen:
                _startPageContainer.Push("Screens/LoadingScreen", false,
                    onLoad: x =>
                    {
                        var page = x.page;
                        Debug.Log("LoadingScreen Loaded");
                    });
                break;
            case ScreenType.StartupNextScreen:
                _startPageContainer.Push("Screens/StartupNextScreen", false,
                    onLoad: x =>
                    {
                        var page = x.page;
                        Debug.Log("名前入力スクリーン Loaded");
                    });
                break;
            case ScreenType.Back:
                _startPageContainer.Pop(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}