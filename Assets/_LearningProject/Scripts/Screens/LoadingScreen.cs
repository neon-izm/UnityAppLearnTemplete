using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Button _skipNextButton;

    [SerializeField] TMPro.TextMeshProUGUI _loadingCountDownText;
    private bool _raisedNextEvent = false;

    Coroutine _countDownCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _skipNextButton.onClick.AddListener(OnSkipButtonClicked);
    }

    private void OnEnable()
    {
        _raisedNextEvent = false;
        _countDownCoroutine = StartCoroutine(CheckForNextEvent());
    }

    IEnumerator CheckForNextEvent()
    {
        for (int i = 5; i > 0; i--)
        {
            _loadingCountDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        if (!_raisedNextEvent)
        {
            EventBus.EventBus<ScreenTransitionEvent>.Raise(new ScreenTransitionEvent()
            {
                MyScreenType = ScreenType.StartupMainScreen
            });
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_countDownCoroutine);
    }

    private void OnSkipButtonClicked()
    {
        EventBus.EventBus<ScreenTransitionEvent>.Raise(new ScreenTransitionEvent()
        {
            MyScreenType = ScreenType.StartupNextScreen
        });
        _raisedNextEvent = true;
    }
}