using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Instruction : MonoBehaviour
{

    private List<string> fileNames;
        public string fileName0 = "";
        public string fileName1 = "";
        public string fileName2 = "";
        public string fileName3 = "";
        public string fileName4 = "";
        public string fileName5 = "";
        public string fileName6 = "";
        public string fileName7 = "";
        public string fileName8 = "";
        public string fileName9 = "";

    [SerializeField] public string category = null;

    [Space]

    [SerializeField] public InstructionVideo instructionVideo = null;

    [Space]

    [SerializeField] public UnityEvent showInstructionSet = null;

    [SerializeField] public UnityEvent hideInstructionSet = null;

    public void Start()
    {
        fileNames = new List<string> { fileName0, fileName1, fileName2, fileName3, fileName4, fileName5, fileName6, fileName7, fileName8, fileName9 };
    }

    public void enableVideo(int n)
    {
        instructionVideo.convertName(category, fileNames[n]);
    }
}
