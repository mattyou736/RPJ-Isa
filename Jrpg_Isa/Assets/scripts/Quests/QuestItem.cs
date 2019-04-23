using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;

    private QuestManager theQm;
    private DialogueManager theDM;

    public string itemName ,text;
    public GameObject player;
    public int gold;


    // Use this for initialization
    void Start ()
    {
        theQm = FindObjectOfType<QuestManager>();
        theDM = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (!theQm.questCompleted[questNumber] && theQm.quest[questNumber].gameObject.activeSelf)
            {
                player.GetComponent<PlayerFlags>().playerActor.IncreaseGold(gold);
                player.GetComponent<PlayerFlags>().money += gold;
                theQm.itemCollected = itemName;
                gameObject.SetActive(false);

                theDM.dialogLines = new string[1];
                theDM.dialogLines[0] = text;

                theDM.currentLine = 0;

                theDM.ShowDialogue();
            }
        }
    }
}
