using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenuManager : MonoBehaviour
{
    public GameObject player;
    public GameObject savemenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            savemenu.SetActive(true);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player.GetComponent<PlayerFlags>());
        savemenu.SetActive(false);
    }

    public void Loadlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
        savemenu.SetActive(false);
    }

    public void TurnOffMenu()
    {
        savemenu.SetActive(false);
    }
}
