using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderShop : MonoBehaviour {

    public string dialogue;

    private DialogueManagerShops dMan;

    public string[] dialogueLines;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManagerShops>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                // dMan.ShowBox(dialogue);

                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                }

            }
        }
    }
}
