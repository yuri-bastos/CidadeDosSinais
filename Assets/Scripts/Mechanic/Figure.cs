using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Figure : MonoBehaviour
{
    [SerializeField] public UnityEvent playCorrectAnimation;
    [Space]
    [SerializeField] public UnityEvent playIncorrectAnimation;
    [Space]
    [SerializeField] public Text textCorrect;
    [Space]
    [SerializeField] public Button button = null;
    [Space]
    [SerializeField] public string figureName;

    public void restart()
    {
        button.interactable = true;
    }

    public void correct()
    {
        button.interactable = false;
        playCorrectAnimation.Invoke();
        changeText();
    }

    public void incorrect()
    {
        playIncorrectAnimation.Invoke();
        changeText();
    }

    public void changeText()
    {
        textCorrect.text = figureName;
    }
}
