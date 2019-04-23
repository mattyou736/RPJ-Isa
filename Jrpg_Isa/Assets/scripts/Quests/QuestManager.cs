using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quest;

    public bool[] questCompleted;

    public DialogueManager theDM;

    public string itemCollected , enemyKilled;

	// Use this for initialization
	void Start ()
    {
        questCompleted = new bool[quest.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showQuestText(string questText)
    {
        theDM.dialogLines = new string[1];
        theDM.dialogLines[0] = questText;

        theDM.currentLine = 0;

        theDM.ShowDialogue();
    }
}
