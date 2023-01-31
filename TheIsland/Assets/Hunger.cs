using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    private Image hunger_Stats;

    public float radius = 1f;
    public LayerMask layerMask;
    public float hunger_InNumbers = 50.0f;
    public GameObject CanvasGameOver;
    public GameObject MainGame;
    
    private Transform spawnPoint;
    private Transform playerPosition;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    void Update()
    {
        if (hunger_InNumbers <= 0)
        {
            // should move this to one function
            hunger_InNumbers = 50;
            playerPosition.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            CanvasGameOver.SetActive(true);
            MainGame.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            hunger_InNumbers -= Time.deltaTime * 2f;
        }
        Display_HungerStats(hunger_InNumbers);
        Gather_Food();
    }
    public void Display_HungerStats(float hungerValue)
    {
        hungerValue /= 100f;
        hunger_Stats.fillAmount = hungerValue;
    }

    public void Gather_Food()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (hits.Length > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                var hunger_per_click = 20;
                if ((hunger_InNumbers < (100 - hunger_per_click)))
                {
                    // show on screen:
                    // first time: "You feel the tree with your hand moving along the bark following the branches and feel something fruit like. You eat the fruit"
                    // everyother times: "You eat the unknow fruit."
                    hunger_InNumbers += hunger_per_click;
                }
                else
                {
                    hunger_InNumbers = 100;
                }
            }
        }
    }
}
