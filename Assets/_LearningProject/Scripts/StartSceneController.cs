using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    PageContainer _startPageContainer;
    [SerializeField]
    ModalContainer _startModalContainer;
    EventBus.EventBinding<ModalEvent> _onScreenModalEvent;
    
    EventBus.EventBinding<ScreenTransitionEvent> _onScreenTransitionEvent;
    // Start is called before the first frame update
    void Start()
    {
        _onScreenModalEvent = new EventBinding<ModalEvent>(OnModalEventReceived);
        _onScreenTransitionEvent = new EventBinding<ScreenTransitionEvent>(OnTransitionEventReceived);
        _startPageContainer.Push("Screens/LoadingScreen", false,
            onLoad: x =>
            {
                var page = x.page;
                Debug.Log("LoadingScreen Loaded");
            });

    }

    private void OnModalEventReceived(ModalEvent obj)
    {
        switch (obj)
        {
            case ModalEvent modalEvent:
                switch (modalEvent.MyModalType)
                {
                    case ModalType.ModalTest:
                        _startModalContainer.Push("Modals/BasicModal", false,
                            onLoad: x =>
                            {
                                var modal = x.modal;
                                var modalBody=modal.GetComponent<BasicModal>();
                                modalBody.SetModal(new ModalComponent()
                                {
                                    Title = "ここは未実装です",
                                    Message = "ここは未実装です。ごめんね！実装してね\nがんばってね",
                                    OkButtonText = "OK",
                                    CancelButtonText = "Cancel",
                                    OnOk = () =>
                                    {
                                        _startModalContainer.Pop(false);
                                    },
                                    OnCancel = () =>
                                    {
                                        _startModalContainer.Pop(false);
                                    }

                                });
                                Debug.Log("ModalTest Loaded");
                            });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
            
        }
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
            case ScreenType.Back:
                _startPageContainer.Pop(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
