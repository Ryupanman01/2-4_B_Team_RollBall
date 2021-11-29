﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : Trap
{

    [SerializeField]
    float moveX;
    [SerializeField]
    float moveY;
    [SerializeField]
    float moveZ;
    [SerializeField]
    float speed;

    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;

    protected override void Start()
    {
        origin = transform.position;
        destination = new Vector3(origin.x - moveX, origin.y, origin.z - moveZ);
    }

    protected override void Update()
    {
        if (stop)
        {
            return;
        }

        step = speed * Time.deltaTime;

        if (!goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (transform.position == destination)
            {
                goBack = true;

                StartCoroutine(Wait());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);

            if (transform.position == origin)
            {
                goBack = false;

                StartCoroutine(Wait());
            }
        }
    }
}