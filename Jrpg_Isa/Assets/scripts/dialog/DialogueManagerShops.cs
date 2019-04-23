using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerShops : MonoBehaviour
{

    public GameObject dBox;

    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;

    public int currentLine;

    private PlayerMovement thePlayer;

    public int dialoguetime;

    public GameObject button1, button2;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialoguetime >= 10)
        {
            dialoguetime = 10;
        }
        else
        {
            dialoguetime++;
        }

        if (dialogActive && Input.GetKeyUp(KeyCode.E) && dialoguetime >= 10)
        {
            currentLine++;
        }

        if (currentLine >= dialogLines.Length - 1 && dialogActive)
        {
            button1.SetActive(true);
            button2.SetActive(true);
        }
        if (currentLine >= dialogLines.Length && dialoguetime >= 10)
        {
            dBox.SetActive(false);
            dialogActive = false;
            button1.SetActive(false);
            button2.SetActive(false);
            thePlayer.canMove = true;
            currentLine = 0;
        }

        dText.text = dialogLines[currentLine];

    }

    public void ShowDialogue()
    {
        dialoguetime = 0;
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
