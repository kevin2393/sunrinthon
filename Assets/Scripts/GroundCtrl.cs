using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundCtrl : MonoBehaviour
{

    public int Randomnum;

    public float speed = 5f;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -337)
        {
            transform.position = new Vector3(21, -4, 0);
            if (speed <= 15)
            {
                speed += 5f;
            }

        }
    }
}