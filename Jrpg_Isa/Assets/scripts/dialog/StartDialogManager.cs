using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDialogManager : MonoBehaviour
{

    public GameObject dBox;

    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;

    public int currentLine;
    public string newGameScene;

    public bool thisIsTheEnd;
    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.E))
        {
            currentLine++;
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;

            if(thisIsTheEnd)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(newGameScene);
            }
            

        }

        dText.text = dialogLines[currentLine];

    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        
    }
}
