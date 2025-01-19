using System;
using UnityEngine;
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

    public static event Action<CinemachineDollyCart, float> SwitchCart;

    public static void OnSwitchCart(CinemachineDollyCart newCart, float cartStartPoint) => SwitchCart?.Invoke(newCart, cartStartPoint);

    public static event Action<AudioClip> PlaySoundEffect;
    public static void OnPlaySoundEffect(AudioClip sfx) => PlaySoundEffect?.Invoke(sfx);

    public static event Action ScreenFlash;
    public static void OnScreenFlash() => ScreenFlash?.Invoke();
}
