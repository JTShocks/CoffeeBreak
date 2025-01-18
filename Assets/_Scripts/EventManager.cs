using System;
using Cinemachine;
using UnityEngine.Events;

public static class EventManager
{
    public static event Action TimerStart;
    public static event Action TimerStop;
    public static event Action<float> TimerUpdate;
    public static event Action<bool> TimerPause;

    public static void OnTimerStart() => TimerStart?.Invoke();
    public static void OnTimerStop() => TimerStop?.Invoke();
    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);
    public static void OnTimerPause(bool isPaused) => TimerPause?.Invoke(isPaused);

    public static event Action GameWin;

    public static void OnGameWin() => GameWin?.Invoke();

    public static event Action<CinemachineVirtualCamera> SwitchCamera;

    public static void OnSwitchCamera(CinemachineVirtualCamera newCamera) => SwitchCamera?.Invoke(newCamera);
}
