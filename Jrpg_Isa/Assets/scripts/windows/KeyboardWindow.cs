using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    public Text inputField;
    public int maxCharacters = 7;

    //delay between each cursor blink
    private float delay = 0;
    private float cursertDelay = .5f;
    private bool blink;
    private string _text = "";

    void Update()
    {
        var text = _text;

        if(_text.Length < maxCharacters)
        {
            //add the _ to the end
            text += "_";

            if(blink)
            {
                text = text.Remove(text.Length - 1);
            }
        }
        inputField.text = text;

        delay += Time.deltaTime;
        if(delay > cursertDelay)
        {
            delay = 0;
            blink = !blink;
        }
    }

    public void OnKeyPress(string key)
    {
        if(_text.Length < maxCharacters)
        {
            //add the key to text
            _text += key;
        }
    }
    //backspace button
    public void OnDelete()
    {
        if(_text.Length > 0)
        {
            _text = _text.Remove(_text.Length - 1);
        }
    }
    //name filled in
    public void OnAccept()
    {
        Application.Quit();
    }
    //no name no play
    public void OnCancel()
    {
        OnPreviousWindow();
    }
}
