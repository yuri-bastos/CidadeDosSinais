using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CEGI
{
    public class ButtonUtility : MonoBehaviour
    {
        public void GoToMenu()
        {
            Debug.Log("Voltar");
            SceneController.Instance.LoadScene("MainMenu");
        }

        public void LoadScene(string sceneName)
        {
            SceneController.Instance.LoadScene(sceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}