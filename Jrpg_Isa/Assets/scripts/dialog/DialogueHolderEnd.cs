using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueHolderEnd : MonoBehaviour
{

    public string dialogue;

    private DialogueManagerEnd dMan;

    public string[] dialogueLines;
    public string[] dialogueLinesfinished;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManagerEnd>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E) && player.GetComponent<PlayerFlags>().money >= 30)
            {
                // dMan.ShowBox(dialogue);

                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLinesfinished;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                }
            }
            else if (Input.GetKeyUp(KeyCode.E) && player.GetComponent<PlayerFlags>().money <= 30)
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
