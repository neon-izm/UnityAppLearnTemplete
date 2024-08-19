using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public struct ModalEvent : IEvent
{
    public ModalType MyModalType;
}
