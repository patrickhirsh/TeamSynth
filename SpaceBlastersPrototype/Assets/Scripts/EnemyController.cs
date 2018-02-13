﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    private Rigidbody2D rb;
    public float dragVal = .5f;
    public float hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = dragVal;
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

    //This is the function we need to call from the bullet object when we hit the correct collider
    void Hit()
    {
        if(hp > 1)
        {
            hp--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //This SHOULD run when the destroy method is called on a game object
    void OnDestroy()
    {
        Debug.Log("OH no we was destroy");
        //Activate destroyed particle effect

    }
}
