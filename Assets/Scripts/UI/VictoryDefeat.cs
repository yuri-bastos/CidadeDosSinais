using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDefeat : MonoBehaviour
{
    [SerializeField] public Text scoreGame = null;
    [SerializeField] public Text scoreVictory = null;

    public void updateScore()
    {
        scoreVictory.text = scoreGame.text;
    }
}
