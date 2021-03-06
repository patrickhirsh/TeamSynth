﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour {


    public float timer = 10f;
    public float radius = 5.0f;
    public float power = 10.0f;
    public Camera c;

	// Use this for initialization
	void Start () {
        if (Camera.main != null)
        {
            c = Camera.main;
        }
	}
	
    void FixedUpdate()
    {
        //decrement the timer on the bomb
        timer -= .1f;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
	

	// Update is called once per frame
	void Update () {
        if (Camera.main != null)
        {
            c = Camera.main;
        }
	}

    void OnDestroy()
    {
        explode();
    }

    void explode()
    {
        if (c != null)
        {
            ScreenShake ss = c.GetComponent<ScreenShake>();
            ss.shakeDuration += .3f;
        }
        //do the exploding
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            var direction = Vector3.zero;
            if (rb != null)
            {
                direction = rb.transform.position - transform.position;

                rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
                rb.gameObject.SendMessage("hit");
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Should Destroy Here");
            Destroy(this.gameObject);
        }
    }

    void hit(){
        
    }



}
