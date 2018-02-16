﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_03_Controller : MonoBehaviour {

    // Use this for initialization
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    private Rigidbody2D rb;
    public float dragVal = .5f;
    public float hp;
    private float periodz = 5.0f;
    public float periodzint;
    bool charge1 = false;
    float charge2 = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = dragVal;
        periodz = 10f;
    }

    void FixedUpdate()
    {
        Debug.Log(Time.time);
        //rotate to look at the player
        //transform.LookAt(target.position);
        if(periodz < Time.time)
        {
            periodz += periodzint;
            charge1 = true;
        }
        //rb.AddForce(transform.forward * speed);
        var direction = Vector3.zero;
        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > hitbox)
        {//move if distance from target is greater than 1
            if (charge1)
            {
                Debug.Log("Inside Charge one if");
                if (charge2 > 10.0f)
                {
                    Debug.LogError("Should shoot now");
                    charge1 = false;
                    charge2 = 0;
                    direction = target.position - transform.position;

                    rb.AddForce(direction.normalized * (speed * 7), ForceMode2D.Impulse);

                }
                else
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = 0;
                    charge2 += .1f;
                }
            }
            else
            {
                direction = target.position - transform.position;
                rb.AddForce(direction.normalized * speed, ForceMode2D.Force);

                //Mathf.Clamp(rb.velocity.magnitude, -3f, 3f);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}