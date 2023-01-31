using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToMainMenu : MonoBehaviour
{
    public GameObject CanvasStartUI;
    public GameObject CanvasGameOver;
    public Button ButtonToMainMenu;
    
    void Start()
    {
        CanvasGameOver.SetActive(false);
        ButtonToMainMenu.onClick.AddListener(TaskOnClick);
    } 

    void TaskOnClick()
    {
        CanvasGameOver.SetActive(false);
        CanvasStartUI.SetActive(true);
    }
}