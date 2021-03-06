﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int gameState = 0;
    // GAMESTATE is used to indicate what point our game is currently at
    // gameState == 0, Menus
    // gameState == 1, In-Game

    public static float gameStartTime = 0f;
    public GameObject powerUp;
    public float pwrUpTimer = 0f;
    public bool powerUpOut = false;
    public int powerUpCount = 0;
    public bool room1Taken = false;
    public bool room2Taken = false;
    public bool room3Taken = false;
    public bool room4Taken = false;
        

	// Use this for initialization
	void Start ()
    {
        pwrUpTimer = Time.time;
	}

    void Awake()
    {
        gameState = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (pwrUpTimer + 15 < Time.time && powerUpCount < 2)
        {
            spawnPowerup();
            pwrUpTimer = Time.time;
        }
        if (pwrUpTimer + 15 < Time.time && powerUp.Equals(null)){
            powerUpCount = 0;
            room1Taken = false;
            room2Taken = false;
            room3Taken = false;
            room4Taken = false;
        }
	}

    public static void Restart()
    {
        setStartTime();
        EnemyManager.Restart();
    }

    private static void setStartTime()
    {
        gameStartTime = Time.time;
    }

    public static float getGameTime()
    {
        return Time.time - gameStartTime;
    }

    private void spawnPowerup()
    {
        int randomNum;
        System.Random rand = new System.Random();
        randomNum = rand.Next(1, 8);
        Vector3 room1 = new Vector3(50, 50);
        Vector3 room2 = new Vector3(-50, 50);
        Vector3 room3 = new Vector3(50, -50);
        Vector3 room4 = new Vector3(-50, -50);

        switch (randomNum)
        {
            case 1:
                if (!room1Taken)
                {
                    GameObject powerUp1 = Instantiate(powerUp, room1, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room1Taken = true;

                }
                break;
            case 2:
                if (!room2Taken)
                {
                    GameObject powerup2 = Instantiate(powerUp, room2, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room2Taken = true;
                   

                }
                break;
            case 3:
                if (!room3Taken)
                {
                    GameObject powerup3 = Instantiate(powerUp, room3, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room3Taken = true;

                }
                break;
            case 4:
                if (!room4Taken)
                {
                    GameObject powerup4 = Instantiate(powerUp, room4, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room4Taken = true;

                }
                break;
            default:
                break;
        }
    }
}
