using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    [SerializeField]
    private Transform lookRoot;

    private move move;
    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;
    private bool is_Crouching;

    
    void Awake()
    {
        move = GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();   
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
                move.speed = sprint_Speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            move.speed = move_Speed;
        }
    }

    void Crouch() {
        // it is useless but will keep it
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (is_Crouching)
            {
                lookRoot.localPosition = new Vector3(0f, stand_Height, 0f);
                move.speed = move_Speed;

                is_Crouching = false;
            }
            else
            {
                lookRoot.localPosition = new Vector3(0f, crouch_Height, 0f);
                move.speed = crouch_Speed;

                is_Crouching = true;
            }
        }
    }

}
