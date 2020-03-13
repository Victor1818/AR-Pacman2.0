using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    public bool alive;
    public float speed;
    public Vector3 spawn;
    public playerScript player;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.alive)
        {
            if (alive)
            {
                HandleInSpawn();
            }
            else
            {
                if (transform.position.x == 5 && transform.position.z == 0)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.left * speed;
                }
                else if (transform.position.x == -5 && transform.position.z == 0)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                }
                else if ((transform.position.x == -3 || transform.position.x == 3) && transform.position.z == -4)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
                }
                else if ((transform.position.x == -3 || transform.position.x == 3) && transform.position.z == 6)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.back * speed;
                }
                else if (transform.position.x == 0 && transform.position.z == 2)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.back * speed;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = spawn;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnoreGhostPhysicsCollision") || collision.gameObject.CompareTag("IgnorePhysicsCollision"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            float xDiff = player.transform.position.x - transform.position.x;
            float zDiff = player.transform.position.z - transform.position.z;
            if (alive)
            {
                HandleAliveMovement(xDiff, zDiff);
                if (transform.position.x < 2 && transform.position.x > -2 && transform.position.z < 1 && transform.position.z > -1) HandleInSpawn();
            }
            else
            {
                HandleNotAliveMovement();
            }
        }
        else if (collision.gameObject.CompareTag("StageWrap"))
        {
            transform.position = new Vector3((collision.gameObject.transform.position.x < 0 ? collision.gameObject.transform.position.x + 1 : collision.gameObject.transform.position.x - 1) * -1,
                0, transform.position.z);
        }
    }

    private void HandleAliveMovement(float xDiff, float zDiff)
    {
        if (xDiff > 0 && zDiff > 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
        else if (xDiff < 0 && zDiff > 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
        else if (xDiff > 0 && zDiff < 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
        else if (xDiff < 0 && zDiff < 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
        else
        {
            int rand = Random.Range(0, 100);
            if (rand < 25)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else if (rand >= 25 && rand < 50)
            {
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
            }
            else if (rand >= 50 && rand < 75)
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
    }

    private void HandleNotAliveMovement()
    {
        if (transform.position.x > 0 && transform.position.z > 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.down * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
        else if (transform.position.x > 0 && transform.position.z < 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
        else if (transform.position.x < 0 && transform.position.z > 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
        else if (transform.position.x < 0 && transform.position.z < 0)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
    }

    private void HandleInSpawn()
    {
        if (transform.position.x < 0.1 && transform.position.x > -0.1 && transform.position.z < 1.1 && transform.position.z > -0.1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        }
        else if (transform.position.x > -2 && transform.position.x < 0 && transform.position.z < 1 && transform.position.z > -1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.right * speed;
        }
        else if (transform.position.x < 2 && transform.position.x > 0 && transform.position.z < 1 && transform.position.z > -1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.left * speed;
        }
        else if (transform.position.x < 0.2 && transform.position.x > -0.2 && transform.position.z < 2.1 && transform.position.z > 1.9)
        {
            float xDiff = player.transform.position.x - transform.position.x;
            if (xDiff > 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
        else
        {
            if (Random.Range(0, 120) == 0)
            {
                HandleAliveMovement(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z);
            }
        }
    }
}
