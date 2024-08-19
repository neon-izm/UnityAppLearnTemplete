using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Button _nextButton;

    private bool _raisedNextEvent = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        _nextButton.onClick.AddListener(OnNextButtonClicked);
        yield return new WaitForSeconds(5);
        if (!_raisedNextEvent)
        {
            OnNextButtonClicked();
        }
    }

    private void OnEnable()
    {
        _raisedNextEvent = false;
    }

    private void OnNextButtonClicked()
    {
        EventBus.EventBus<ScreenTransitionEvent>.Raise(new ScreenTransitionEvent()
        {
            MyScreenType = ScreenType.StartupMainScreen
        });
        _raisedNextEvent = true;
    }

}