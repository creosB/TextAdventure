using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

	// Use this for initialization
	void Start ()
    {		
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
	}
	
	// Update is called once per frame
	void Update ()
    {		
	}

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description+"\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();

    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>"+textEntryField.text+"</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = {' '};
        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length>1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens ! (are you forget command ? type Help)";
    }


}











