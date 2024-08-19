using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupMainScreen : MonoBehaviour
{
    [SerializeField] Button _nextButton;
    [SerializeField] Button _prevButton;

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
        EventBus.EventBus<ModalEvent>.Raise(new ModalEvent()
        {
            MyModalType = ModalType.ModalTest
        });
    }
}