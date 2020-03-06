using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    Vector3 vector = new Vector3(2, 0, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = vector;
    }

    public void MoveLeft()
    {
        vector = new Vector3(-speed, 0, 0);
    }

    public void MoveRight()
    {
        vector = new Vector3(speed, 0, 0);
    }

    public void MoveUp()
    {
        vector = new Vector3(0, speed, 0);
    }

    public void MoveDown()
    {
        vector = new Vector3(0, -speed, 0);
    }
}
