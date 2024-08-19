using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public struct ScreenTransitionEvent : IEvent
{
    public ScreenType MyScreenType;
}
