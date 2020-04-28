using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float sprintspeed;
    [SerializeField] private float JumpRaycastDist;

    private Rigidbody player;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                player.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private void Move()
    {
        float HorAxis = Input.GetAxisRaw("Horizontal");
        float VerAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 movement = new Vector3(HorAxis, 0, VerAxis) * sprintspeed * Time.fixedDeltaTime;
            Vector3 newPos = player.position + player.transform.TransformDirection(movement);

            player.MovePosition(newPos);
        }
        else
        {
            Vector3 movement = new Vector3(HorAxis, 0, VerAxis) * speed * Time.fixedDeltaTime;
            Vector3 newPos = player.position + player.transform.TransformDirection(movement);

            player.MovePosition(newPos);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, JumpRaycastDist);
    }
}
