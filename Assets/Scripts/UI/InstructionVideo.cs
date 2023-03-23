using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InstructionVideo : MonoBehaviour
{
    [SerializeField] public VideoPlayer videoPlayer = null;

    public void convertName(string category, string fileName)
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, category + "/", fileName + ".mp4");
    }

    public void reset()
    {
        videoPlayer.url = "";
    }
}
