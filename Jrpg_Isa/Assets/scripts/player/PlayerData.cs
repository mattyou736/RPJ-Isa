using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//means it can be saved in file
[System.Serializable]
public class PlayerData
{
    //cant save vector 3 so we use float array
    public float[] position;

    public PlayerData (PlayerFlags player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
