﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gameCon;
    

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        gameCon = gameCon.GetComponent<GameController>();
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if(gameCon.score >= 100)
        {

            scrollSpeed = -25;
        }
    }

    
}
