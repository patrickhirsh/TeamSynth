﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //rotate to look at the player
        //transform.LookAt(target.position);

        //rb.AddForce(transform.forward * speed);
        var direction = Vector3.zero;
        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > hitbox)
        {//move if distance from target is greater than 1
            direction = target.position - transform.position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);

            Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
        }
    }
}
