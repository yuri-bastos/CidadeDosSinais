using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BaseMechanic : MonoBehaviour
{
    private int score;
    private int currentFigure;
    private List<int> remainingFigures;
    private List<Figure> figures;
        public Figure figure0 = null;
        public Figure figure1 = null;
        public Figure figure2 = null;
        public Figure figure3 = null;
        public Figure figure4 = null;
        public Figure figure5 = null;
        public Figure figure6 = null;
        public Figure figure7 = null;
        public Figure figure8 = null;
        public Figure figure9 = null;
    [Space]
    [SerializeField] public Text correctText = null;
    [SerializeField] public Text currentFigureText = null;
    [SerializeField] public Text scoreText = null;
    [SerializeField] public Instruction instructionSet = null;

    [SerializeField] public UnityEvent callZoomOut = null;
    [SerializeField] public UnityEvent resetObjects = null;

    [SerializeField] public UnityEvent onVictory = null;
    [SerializeField] public UnityEvent onDefeat = null;
    [SerializeField] public UnityEvent onVictoryAfterAnimation = null;
    [SerializeField] public UnityEvent onDefeatAfterAnimation = null;

    public void Start()
    {
        correctText.text = "";
        score = 0000;
        scoreText.text = score.ToString();
        figures = new List<Figure> { figure0, figure1, figure2, figure3, figure4, figure5, figure6, figure7, figure8, figure9 };
        remainingFigures = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        reactivateAllButtons();
        instructionSet.showInstructionSet.Invoke();
        getNewFigure();
    }

    void Update()
    {

    }

    void getNewFigure()
    {
        int index = Random.Range(0, remainingFigures.Count);
        currentFigure = remainingFigures[index];
        Debug.Log(currentFigure);
        instructionSet.enableVideo(currentFigure);
        currentFigureText.text = figures[currentFigure].figureName;

    }

    public void checkCorrect(int number)
    {
        if(currentFigure == number)
        {
            Debug.Log("Acertou");

            figures[number].correct();
            remainingFigures.Remove(currentFigure);
            score += 0050;
            scoreText.text = score.ToString();

            if (remainingFigures.Count > 0)
            {
                getNewFigure();
            }

            else
            {

                if(score > 0)
                {
                    Debug.Log("Vitória");
                    callZoomOut.Invoke();
                    instructionSet.hideInstructionSet.Invoke();
                    onVictory.Invoke();
                }
                else
                {
                    Debug.Log("Derrota");
                    callZoomOut.Invoke();
                    instructionSet.hideInstructionSet.Invoke();
                    onDefeat.Invoke();
                }


            }

        }

        else
        {
            figures[number].incorrect();
            score -= 0010;
            scoreText.text = score.ToString();
        }

    }

    public void OnVictoryAfter()
    {
        onVictoryAfterAnimation.Invoke();
    }

    public void OnDefeatAfter()
    {
        onDefeatAfterAnimation.Invoke();
    }


    void reactivateAllButtons()
    {
        for(int i = 0; i < figures.Count; i++)
        {
            figures[i].restart();
        }
        resetObjects.Invoke();
    }
}
