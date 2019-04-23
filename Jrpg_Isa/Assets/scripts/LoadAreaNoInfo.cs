using UnityEngine;
using System.Collections;

public class LoadAreaNoInfo : MonoBehaviour
{

    public string levelToLoad;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
