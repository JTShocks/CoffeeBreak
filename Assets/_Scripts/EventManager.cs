using System;
using UnityEngine.Events;

public static class EventManager
{
    public static event Action TimerStart;
    public static event Action TimerStop;
    public static event Action<float> TimerUpdate;

    public static void OnTimerStart() => TimerStart?.Invoke();
    public static void OnTimerStop() => TimerStop?.Invoke();
    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);
}
