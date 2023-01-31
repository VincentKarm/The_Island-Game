using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Drowning : MonoBehaviour
{
    public float radius = 2f;
    public LayerMask layerMask;
    public float air_InNumbers = 50.0f;
    public GameObject CanvasGameOver;
    public GameObject MainGame;
    public TMP_Text TheTextBox;
    float tempTime = 0f;

    List<string> possibleText = new List<string>();

    private Transform spawnPoint;
    private Transform playerPosition;


    void Start()
    {
        possibleText.Add("Guess what... YOU ARE DROWNING");
        possibleText.Add("You are gasping for air because you have forgotten how to swim, and breath underwater");
        possibleText.Add("You have forgotten how to swim and breath underwater, so you might drown soon.");
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (hits.Length > 0)
        {
            Display_YouAreDrowning();
        }
    }
    public void Display_YouAreDrowning()
    {
        if (air_InNumbers <= 0)
        {
            playerPosition.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            air_InNumbers = 50;
            CanvasGameOver.SetActive(true);
            MainGame.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            tempTime = tempTime+Time.deltaTime;
            if (tempTime >= 2)
            {
                TheTextBox.text = possibleText[Random.Range(0, possibleText.Count)]; 
                tempTime = 0;
            }
            air_InNumbers -= Time.deltaTime * 5f;
            // TheTextBox.text
            // Something
            // somehow give textbox text "YOU'RE DROWNING"
            // or "You are gasping for air because you have forgotten how to swim, and breath underwater."
            // maybe even "You have forgotten how to swim and breath underwater, so you might drown soon."
        }
    }
}
