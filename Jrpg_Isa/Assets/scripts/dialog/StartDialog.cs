using UnityEngine;
using System.Collections;

public class StartDialog : MonoBehaviour
{
    public string dialogue;

    private StartDialogManager dMan;

    public string[] dialogueLines;

    // Use this for initialization
    void Start ()
    {
        dMan = FindObjectOfType<StartDialogManager>();

        if (!dMan.dialogActive)
        {
            dMan.dialogLines = dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialogue();

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
