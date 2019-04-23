using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shops : MonoBehaviour
{
    public GameObject player;
    public GameObject dlogManShop;
    public int gold = 10;
    public GameObject thief, Ebutton;

    public void ThiefYes()
    {
        player.GetComponent<PlayerFlags>().playerActor.DecreaseGold(gold);
        dlogManShop.GetComponent<DialogueManagerShops>().dBox.SetActive(false);
        dlogManShop.GetComponent<DialogueManagerShops>().dialogActive = false;
        dlogManShop.GetComponent<DialogueManagerShops>().button1.SetActive(false);
        dlogManShop.GetComponent<DialogueManagerShops>().button2.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true;
        dlogManShop.GetComponent<DialogueManagerShops>().currentLine = 0;
        thief.SetActive(false);
        Ebutton.SetActive(false);
    }
    public void ThiefNo()
    {
        dlogManShop.GetComponent<DialogueManagerShops>().dBox.SetActive(false);
        dlogManShop.GetComponent<DialogueManagerShops>().dialogActive = false;
        dlogManShop.GetComponent<DialogueManagerShops>().button1.SetActive(false);
        dlogManShop.GetComponent<DialogueManagerShops>().button2.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true;
        dlogManShop.GetComponent<DialogueManagerShops>().currentLine = 0;
    }
}
