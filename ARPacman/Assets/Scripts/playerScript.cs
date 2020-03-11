using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public enum Direction { FORWARD, LEFT, BACKWARD, RIGHT, NONE }

    public bool alive;
    public Vector3 spawn;
    public bool powered;
    public float speed;
    public int lives;

    private Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        powered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives != -1)
        {
            if (Input.gyro.enabled)
            {
                float angle = Input.gyro.attitude.eulerAngles.y;
                if (angle <= 45 || angle >= 315)
                {
                    direction = Direction.FORWARD;
                }
                else if (angle > 45 && angle < 135)
                {
                    direction = Direction.LEFT;
                }
                else if (angle >= 135 && angle <= 225)
                {
                    direction = Direction.BACKWARD;
                }
                else
                {
                    direction = Direction.RIGHT;
                }
            }
            if (direction == Direction.FORWARD)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
                Debug.Log("ARPACMAN: direction: FORWARD");
            }
            else if (direction == Direction.RIGHT)
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                Debug.Log("ARPACMAN: direction: RIGHT");
            }
            else if (direction == Direction.BACKWARD)
            {
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
                Debug.Log("ARPACMAN: direction: BACKWARD");
            }
            else if (direction == Direction.LEFT)
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
                Debug.Log("ARPACMAN: direction: LEFT");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnorePhysicsCollision"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
            if (collision.gameObject.GetComponent<NewBehaviourScript>())
            {
                NewBehaviourScript ghost = collision.gameObject.GetComponent<NewBehaviourScript>();
                if (ghost.isAlive)
                {
                    if (powered)
                    {
                        ghost.isAlive = false;
                        //Change to dead ghost material
                    }
                    else
                    {
                        lives--;
                        transform.position = spawn;
                    }
                }
            }
        }
    }
}
