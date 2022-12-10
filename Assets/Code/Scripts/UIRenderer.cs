using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TextMode
{
    Timer,
    Record
}

public class UIRenderer : MonoBehaviour
{
    #region Fields
    [SerializeField] private TMP_Text textField;
    

    [SerializeField] private TextMode textmode;
    #endregion


    #region Main Methods
    private void Start()
    {
        TimerState.OnTimerStep.AddListener(UpdateUI);
        TimerState.OnFinish.AddListener(UpdateUI);
    }
    #endregion

    #region Helper Methods
    private void UpdateUI(float value, int key)
    {
        switch (textmode)
        {
            case TextMode.Timer:
                if(((int)TextMode.Timer) == key)
                    textField.text = value.ToString() + " " + "s";
                break;
            case TextMode.Record:
                if(((int)TextMode.Record) == key)
                    textField.text = "Record: " + value.ToString();
                break;
            default:
                break;
        }
    }
    #endregion
}

