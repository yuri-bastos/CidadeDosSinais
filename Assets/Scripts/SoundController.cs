using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoundController : MonoBehaviour
{
    public Image soundOnImage = null;
    public Image soundOffImage = null;

    // Start is called before the first frame update
    void Start()
    {
        toggleVolume();
        toggleVolume();
    }

    public void Mute()
    {
        AudioListener.volume = 0;
    }

    public void Unmute()
    {
        AudioListener.volume = 1;
    }

    public void toggleVolume()
    {
        if (AudioListener.volume == 0)
        {
            Unmute();
        }
        else if (AudioListener.volume == 1)
        {
            Mute();
        }
        else
        {
            Unmute();
        }
        updateVolumeImage();
    }

    public void updateVolumeImage()
    {
        soundOffImage.enabled = AudioListener.volume == 0;
        soundOnImage.enabled = AudioListener.volume == 1;
    }
}
