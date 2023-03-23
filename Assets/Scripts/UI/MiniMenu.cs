using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMenu : MonoBehaviour
{
    [SerializeField] private GameObject miniMenuScreen = null;

    public void toggleMiniMenuScreen(bool openOrClosed)
    {
        miniMenuScreen.SetActive(openOrClosed);
    }
}
