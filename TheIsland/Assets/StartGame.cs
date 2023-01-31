using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject CanvasStartUI;
    public GameObject MainGame;
    public Button ButtonToStartGame;
    
    void Start()
    {
        MainGame.SetActive(false);
        ButtonToStartGame.onClick.AddListener(TaskOnClick);
    } 

    void TaskOnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CanvasStartUI.SetActive(false);
        MainGame.SetActive(true);
    }
}