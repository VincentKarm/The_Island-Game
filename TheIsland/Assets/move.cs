using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class move : MonoBehaviour
{
    private CharacterController Character_Controller;
    private Vector3 move_direction;
    public float speed = 5f;
    private float gravity = 20f;
    public float jump_Force = 7f;
    private float vertical_Velocity;

    void Awake() {
        Character_Controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        LockAndUnlockCursor();
    }

    void MoveThePlayer() {
        move_direction = new Vector3(Input.GetAxis("Horizontal"), 0f,
                                     Input.GetAxis("Vertical"));
        move_direction = transform.TransformDirection(move_direction);
        move_direction = move_direction * speed * Time.deltaTime;

        ApplyGravity();
        Character_Controller.Move(move_direction);
    }

    void ApplyGravity() {
        if (Character_Controller.isGrounded) {
            vertical_Velocity -= gravity * Time.deltaTime;
            PlayerJump();
        }
        else {
            vertical_Velocity -= gravity * Time.deltaTime;
        }
        move_direction.y = vertical_Velocity * Time.deltaTime;
    }

    void PlayerJump(){
        if (Character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            vertical_Velocity = jump_Force;
        }
    }

    void LockAndUnlockCursor() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}

