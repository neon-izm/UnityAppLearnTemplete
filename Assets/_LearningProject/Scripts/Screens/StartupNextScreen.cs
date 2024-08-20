using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;

public class StartupNextScreen : MonoBehaviour
{
    [SerializeField] Button _nextButton;
    [SerializeField] Button _prevButton;
    [SerializeField] TMPro.TMP_InputField _nameInputField;

    [SerializeField] Sprite _noNameErrorImage;
    private ModalContainer SceneModalContainer => ModalContainer.Find("StartupModal");

    // Start is called before the first frame update
    void Start()
    {
        _nextButton.onClick.AddListener(OnNextButtonClicked);
        _prevButton.onClick.AddListener(OnPrevButtonClicked);
    }

    private void OnPrevButtonClicked()
    {
        EventBus.EventBus<ScreenTransitionEvent>.Raise(new ScreenTransitionEvent()
        {
            MyScreenType = ScreenType.Back
        });
    }

    private void OnNextButtonClicked()
    {
        if (string.IsNullOrEmpty(_nameInputField.text))
        {
            SceneModalContainer.Push("Modals/BasicModal", false,
                onLoad: x =>
                {
                    var modal = x.modal;
                    var modalBody = modal.GetComponent<BasicModal>();
                    modalBody.SetModal(new ModalComponent()
                    {
                        Title = "Error",
                        BodyImage = _noNameErrorImage,
                        Message = "名前を入れて下さい",
                        OkButtonText = "OK",
                        OnOk = () => { SceneModalContainer.Pop(false); }
                    });
                });
        }
        else
        {
            SceneModalContainer.Push("Modals/BasicModal", false,
                onLoad: x =>
                {
                    var modal = x.modal;
                    var modalBody = modal.GetComponent<BasicModal>();
                    modalBody.SetModal(new ModalComponent()
                    {
                        Title = "ここは未実装です",
                        Message = "せっかく名前入れたのに\nここは未実装です。ごめんね！実装してね\nがんばってね",
                        OkButtonText = "OK",
                        CancelButtonText = "Cancel",
                        OnOk = () => { SceneModalContainer.Pop(false); },
                        OnCancel = () => { SceneModalContainer.Pop(false); }
                    });
                    Debug.Log("ModalTest Loaded");
                });
        }
    }
}