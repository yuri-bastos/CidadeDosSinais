using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrayScale : MonoBehaviour
{
    private Image image;
    private float duration = 1f;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void StartGrayscaleRoutine()
    {
        Debug.Log("Cinza\n");
        GrayScaleRoutine(duration, true);
    }

    public void Reset()
    {
        Debug.Log("Claro\n");
        resetGrayscale();
    }

    private void GrayScaleRoutine(float duration, bool isGrayScale)
    {
        /*float time = 0f;
        while(duration > time)
        {
            float durationFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = isGrayScale ? ratio : 1 - ratio;
            setGrayscale(grayAmount);
            time += durationFrame;
            yield return null;
        }*/
        setGrayscale(1);
    }

    private void setGrayscale(float amount = 1)
    {
        image.material.SetFloat("_GrayscaleAmount", amount);
    }

    private void resetGrayscale()
    {
        image.material.SetFloat("_GrayscaleAmount", 0);
    }
}
