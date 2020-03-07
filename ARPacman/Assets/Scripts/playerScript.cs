using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public bool isAlive = true;
    public double player_X = 0;
    public double player_Y = 0;
    public bool powered = false;
    public int speed = 4;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        player_X = 5;
        player_Y = 5;
        powered = false;
        speed = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsAlive();
        if (!isAlive)
        {
            lives--;
            if (lives == 0)
            {
                print("Game Over!");
            }
            else
            {
                Start();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }

    //Checks if the Player overlaps with Ghost wlile it's not powered
    public bool CheckIsAlive()
    {
        if(!powered && ((player_X < ghost_X+0.5 && player_X > ghost_X-0.5) && (player_Y < ghost_Y + 0.5 && player_Y > ghost_Y - 0.5)))
        {
            isAlive = false;
        }

        return isAlive;
    }

}
