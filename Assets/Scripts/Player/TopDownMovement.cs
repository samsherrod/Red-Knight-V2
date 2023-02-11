﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public GameObject playerGun;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3 dir;

    [SerializeField]
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fetch the direction keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        // Look towards the mouse
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Clamp(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, -45, 45);
        playerGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}