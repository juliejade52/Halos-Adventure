﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public int JumpForce;
    public Transform groundPoint;
    public LayerMask groundLayer;
    public bool grounded;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       grounded = Physics2D.OverlapPoint(groundPoint.position,groundLayer); 
    }
    // Update is called once per frame
    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * JumpForce);
        }

        anim.SetFloat("yVelocity",rb.velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    public void GameOver()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
