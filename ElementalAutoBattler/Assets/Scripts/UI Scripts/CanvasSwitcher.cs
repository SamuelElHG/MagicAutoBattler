using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasSwitcher : MonoBehaviour
{


    public void SwitchCanvasState(GameObject canvasObject)
    {
        canvasObject.gameObject.SetActive(!canvasObject.gameObject.activeSelf);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
