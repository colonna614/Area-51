using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMove : MonoBehaviour
{

    private bool dirRight = true;
    public float speed;

    void Update()
    {
        move();
    }
    void move()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= .5f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -7)
        {
            dirRight = true;
        }
    }
}
