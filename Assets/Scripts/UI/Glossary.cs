using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Glossary : MonoBehaviour
{
    [SerializeField] public UnityEvent onHide = null;
    [SerializeField] public UnityEvent onShow = null;

    public bool isOpen = false;

    public void Start()
    {
        isOpen = false;
    }

    public void toggleView()
    {
        isOpen = !isOpen;
        if(isOpen == true)
        {
            onShow.Invoke();
        }
        else
        {
            onHide.Invoke();
        }
    }
}
