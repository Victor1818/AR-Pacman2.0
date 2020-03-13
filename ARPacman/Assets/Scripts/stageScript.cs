using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageScript : MonoBehaviour
{
    public GameObject pelletPrefab;
    public GameObject powerPelletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<pelletScript>().Length == 0)
        {
            for (int x = -8; x < 9; x++)
            {
                for (int z = -10; z < 10; z++)
                {
                    if ((x < -5 || x > 5) && (z < -3 || z > 3))
                    {
                        if ((x == -8 || x == 8) && z != -7)
                        {
                            if (z != 8 && z != -6)
                            {
                                InstantiatePellet(new Vector3(x, 0, z), false);
                            }
                            else
                            {
                                InstantiatePellet(new Vector3(x, 0, z), true);
                            }
                        }
                        else if ((x == -7 || x == 7) && z != -9 && z != -5 && z != 5 && z != 7 && z != 8)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                        else if ((x == -6 || x == 6) && z != -9 && (z < -7 || z > -5) && z != -5 && z != 5 && z != 7 && z != 8)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                    }
                    else if ((x == -5 || x == 5) && z != -9)
                    {
                        InstantiatePellet(new Vector3(x, 0, z), false);
                    }
                    else if ((x > -5 && x < 5) && (z > 3 || z < -3))
                    {
                        if ((x == -4 || x == 4) && z == -10 && z == -6 && z == 6 && z == 9)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                        else if ((x == -3 || x == 3) && z != -8 && z != 7 && z != 8)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                        else if ((x == -2 || x == 2) && z != -8 && z != 5 && z != 7 && z != 8)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                        else if ((x == -1 || x == 1) && z != -7 && z != 5)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                        else if (x == 0 && z != -6 && (z < -9 || z > -7) && z != 4 && z != 5 && z < 7)
                        {
                            InstantiatePellet(new Vector3(x, 0, z), false);
                        }
                    }
                }
            }
        }
    }

    private void InstantiatePellet(Vector3 position, bool powerPellet)
    {
        if (!powerPellet)
        {
            Instantiate(pelletPrefab, position, Quaternion.identity, transform);
        }
        else
        {
            Instantiate(powerPelletPrefab, position, Quaternion.identity, transform);
        }
    }
}
