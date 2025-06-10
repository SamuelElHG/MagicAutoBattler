using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{


    public void SwitchCanvasState(GameObject canvasObject)
    {
        canvasObject.gameObject.SetActive(!canvasObject.gameObject.activeSelf);
    }
}
