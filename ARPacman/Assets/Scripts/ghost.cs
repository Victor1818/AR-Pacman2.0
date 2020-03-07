using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isAlive = true;
    public double ghost_X = 10;
    public double ghost_Y = 10;
    public bool vulnerable = false;
    public int speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        ghost_X = 10;
        ghost_Y = 10;
        vulnerable = false;
        speed = 5;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(vulnerable && isAlive)
        {
            CheckIsAlive();
        }

        if (!isAlive)
        {
            returnHome();
        }

    }

    //Checks if the Ghost overlaps with player while it's vulnerable
    public bool CheckIsAlive()
    {
        if (vulnerable && ((ghost_X < player_X + 0.5 && ghost_X > player_X - 0.5) && (ghost_Y < player_Y + 0.5 && ghost_Y > player_Y - 0.5)))
        {
            isAlive = false;
        }

        return isAlive;
    }

    //Will find the shortest path to its home and reset itself
    public void returnHome()
    {
        /*
         Shortest path logic goes here
         */

        if(ghost_X == 7 && ghost_Y == 7){
            Start();
        }
    }
}
