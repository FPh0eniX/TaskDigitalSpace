using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    #region Fields
    public enum ButtonType
    {
		Start,
		Finish
    }
    [SerializeField] private ButtonType buttonType;

    public static UnityEvent OnPressStartButton = new UnityEvent();
    public static UnityEvent OnPressFinishButton = new UnityEvent();
    #endregion


    #region Main Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            switch (buttonType)
            {
                case ButtonType.Start:
                    OnPressStartButton?.Invoke();
                    break;
                case ButtonType.Finish:
                    OnPressFinishButton?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
    #endregion


    #region Helper Methods
    #endregion
}

