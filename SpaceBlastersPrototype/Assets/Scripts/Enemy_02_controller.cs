﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_controller : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    public float hp = 3.0f;
    public float DragVal = .5f;
    private Rigidbody2D rb;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = DragVal;

        //we need to assign the target here, otherwise enemies generated at runtime won't have a target
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (GameManager.gameState == 1)
        {
            //rotate to look at the player
            //transform.LookAt(target.position);
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += -90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            //rb.AddForce(transform.forward * speed);
            var direction2 = Vector3.zero;
            //move towards the player
            if (Vector3.Distance(transform.position, target.position) > hitbox)
            {//move if distance from target is greater than 1
                direction2 = target.position - transform.position;
                rb.AddForce(direction.normalized * speed, ForceMode2D.Force);

                Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
            }
        }
    }

    void hit(){
        //we got hit
        hp--;
        if(hp <= 0.0f){
            ParticleManager.generateEnemy2Explosion(this.gameObject);
            this.gameObject.SetActive(false);
            EnemyManager.enemyCaches[1].Push(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet"){
            if(col.otherCollider.GetType() == typeof(CircleCollider2D)){
                hit();
            }
            else{
                Destroy(col.gameObject);
            }
        }
        else if (col.gameObject.tag == "player"){
            //use 
            col.gameObject.SendMessage("hit");
        }
        else{
            //probs hit another enmey zzzzzz
        }
    }
}
