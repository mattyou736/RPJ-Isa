using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;

    public QuestManager theQm;

    public string startText, endText;

    public bool isItemQuest;

    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    public int enemyKillCount;

    public GameObject playerFlag;

    public int gold;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(isItemQuest)
        {
            if(theQm.itemCollected == targetItem)
            {
                theQm.itemCollected = null;
                EndQuest();
            }
        }

        if (isEnemyQuest)
        {
            if (theQm.enemyKilled == targetEnemy)
            {
                theQm.enemyKilled = null;
                enemyKillCount++;
            }

            if(enemyKillCount >= enemiesToKill)
            {
                EndQuest();
            }
        }
    }

    public void StartQuest()
    {
        theQm.showQuestText(startText);
    }

    public void EndQuest()
    {
        theQm.showQuestText(endText);
        theQm.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
        playerFlag.GetComponent<PlayerFlags>().money += gold;
        playerFlag.GetComponent<PlayerFlags>().playerActor.IncreaseGold(gold);

    }
}
