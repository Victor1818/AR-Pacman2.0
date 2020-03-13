using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{
    public enum Direction { FORWARD, LEFT, BACKWARD, RIGHT, NONE }

    public bool alive;
    public Vector3 spawn;
    public bool powered;
    public float speed;
    public int lives;
    public int score;

    private webCamScript wCScript;
    private Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        powered = false;
        wCScript = GetComponentInChildren<webCamScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity.ToString());
        if (lives != -1)
        {
            if (wCScript.gyro.enabled)
            {
                float angle = wCScript.gyro.attitude.eulerAngles.y;
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
                else if (angle > 225 && angle < 315)
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
        else
        {
            alive = false;
        }
        Debug.Log(GetComponent<Rigidbody>().velocity.ToString());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnorePhysicsCollision"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
            if (collision.gameObject.GetComponent<ghostScript>())
            {
                ghostScript g = collision.gameObject.GetComponent<ghostScript>();
                if (g.alive)
                {
                    if (powered)
                    {
                        score += 200;
                        g.alive = false;
                        //Change to dead ghost material
                    }
                    else
                    {
                        lives--;
                        transform.position = spawn;
                    }
                }
            }
            else if (collision.gameObject.GetComponent<pelletScript>())
            {
                pelletScript p = collision.gameObject.GetComponent<pelletScript>();
                if (p.powerPellet)
                {
                    score += 50;
                }
                else
                {
                    score += 10;
                }
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("StageWrap"))
        {
            transform.position = new Vector3((collision.gameObject.transform.position.x < 0 ? collision.gameObject.transform.position.x + 1 : collision.gameObject.transform.position.x - 1) * -1,
                0, transform.position.z);
        }
    }
}
