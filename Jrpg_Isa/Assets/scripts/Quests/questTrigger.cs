using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questTrigger : MonoBehaviour
{
    private QuestManager theQm;

    public int questNumber;

    public bool startQuest, endQuest;

    public GameObject player, icon;
    public int gold;

    // Use this for initialization
    void Start ()
    {
        theQm = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            if(!theQm.questCompleted[questNumber])
            {
                if(startQuest && !theQm.quest[questNumber].gameObject.activeSelf)
                {
                    theQm.quest[questNumber].gameObject.SetActive(true);
                    icon.SetActive(false);
                    theQm.quest[questNumber].StartQuest();
                }

                if(endQuest && theQm.quest[questNumber].gameObject.activeSelf)
                {
                    player.GetComponent<PlayerFlags>().playerActor.IncreaseGold(gold);
                    theQm.quest[questNumber].EndQuest();
                }
            }
        }
    }
}
