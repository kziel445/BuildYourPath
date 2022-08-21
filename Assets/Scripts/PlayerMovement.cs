using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    private Rigidbody2D rb;
    public Transform cameraPosition;
    private float cameraYmin;
    public float speed = 40f;

    float horizontalMove;
    float verticalMove;

    bool ableToMove = true;
    bool jump = false;


    private void Awake()
    {
        PlayerState.GetInstance().OnDie += PlayerMovement_OnDie;
        PlayerState.GetInstance().OnRespawn += PlayerMovement_OnDie;
        cameraYmin = cameraPosition.position.y;
    }
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // camera
        float cameraYNew;
        if(cameraYmin < transform.position.y ) cameraYNew = transform.position.y;
        else cameraYNew = cameraYmin;

        cameraPosition.position = new Vector3(
            transform.position.x,
            cameraYNew,
            cameraPosition.position.z
            );

        // movement controls
        if(ableToMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void PlayerMovement_OnDie(object sender, EventArgs e)
    {
        ableToMove = !ableToMove;
    }
}