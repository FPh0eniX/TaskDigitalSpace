using System;
using UnityEngine;
using UnityEngine.Events;

public class OnTimerStepEvent : UnityEvent<float, int>{}
public class OnFinishEvent : UnityEvent<float, int>{}

public class TimerState : MonoBehaviour
{

    #region Fields
    public static OnTimerStepEvent OnTimerStep = new OnTimerStepEvent();
    public static OnFinishEvent OnFinish = new OnFinishEvent();

    private bool _isTimerWork = false;
    private int _timerStep = 1;
    private float _timerCounter = 0;
    private float _timeRecord = 0;
    #endregion


    #region Main Methods
    private void Start()
    {
        Button.OnPressStartButton.AddListener(StartTimer);
        Button.OnPressFinishButton.AddListener(StopTimer);
    }

    private void Update()
    {
        Timer();
    }
    private void OnDisable()
    {
        Button.OnPressStartButton.RemoveAllListeners();
        Button.OnPressFinishButton.RemoveAllListeners();
    }
    #endregion


    #region Helper Methods
    private void Timer()
    {
        if (_isTimerWork)
        {
            _timerCounter += _timerStep * Time.deltaTime;
            OnTimerStep.Invoke(MathF.Round(_timerCounter, 2), (int)TextMode.Timer);
        }
    }
    private void StartTimer()
    {
        _timerCounter = 0;
        _isTimerWork = true;
    }

    private void StopTimer()
    {
        _isTimerWork= false;
        OnFinish?.Invoke(RecalculateRecord(_timerCounter), (int)TextMode.Record);
    }

    private float RecalculateRecord(float currentResult)
    {
        if(currentResult < _timeRecord || _timeRecord == 0)
        {
            _timeRecord = currentResult;
            return MathF.Round(_timeRecord, 2);
        }
        return MathF.Round(_timeRecord, 2);
    }
    #endregion
}