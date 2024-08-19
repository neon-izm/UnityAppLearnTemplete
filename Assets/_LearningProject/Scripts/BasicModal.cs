using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalComponent
{
    public string Title;
    public string Message;
    public string OkButtonText;
    public string CancelButtonText;
    public System.Action OnOk;
    public System.Action OnCancel;
}

public class BasicModal : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _title;
    [SerializeField] TMPro.TextMeshProUGUI _message;
    [SerializeField] Button _okButton;
    [SerializeField] Button _cancelButton;

    public void SetModal(ModalComponent modalComponent)
    {
        _title.text = modalComponent.Title;
        _message.text = modalComponent.Message;
        _okButton.onClick.RemoveAllListeners();
        _cancelButton.onClick.RemoveAllListeners();
        _okButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = modalComponent.OkButtonText;

        if (string.IsNullOrEmpty(modalComponent.CancelButtonText))
        {
            _cancelButton.gameObject.SetActive(false);
        }
        else
        {
            _cancelButton.gameObject.SetActive(true);
            _cancelButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = modalComponent.CancelButtonText;

            _cancelButton.onClick.AddListener(() => { modalComponent.OnCancel?.Invoke(); });
        }

        _okButton.onClick.AddListener(() => { modalComponent.OnOk?.Invoke(); });
    }

}