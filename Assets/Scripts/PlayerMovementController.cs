using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Variables
    public CharacterController controller;
    public float speed = 100.0f;
    public float jump_value = 1.8f;
    public float gravity = 9.0f;

    Vector3 jump_velocity = new Vector3(0.0f, 0.0f, 0.0f);

    public Transform ground_check;
    public float collision_radius = 3.0f;
    public LayerMask ground_mask;

    bool playerGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = Physics.CheckSphere(ground_check.position, collision_radius, ground_mask);
        //Debug.Log(playerGrounded);
        if (playerGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        jump_velocity.y -= gravity * Time.deltaTime;

        if (playerGrounded && jump_velocity.y < 0)
        {
            jump_velocity.y = 0;
        }

        //Debug.Log(jump_velocity.y);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = Camera.main.transform.right * x + Camera.main.transform.forward * z;
        Vector3 actual_velocity = move * speed * Time.deltaTime + jump_velocity;
        controller.Move(actual_velocity); //pos = pos + move
    }

    void Jump()
    {
        jump_velocity.y = jump_value;
    }
}


