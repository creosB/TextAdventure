using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string verb)
    {
        controller.currentText.text = "Type a Verb (\"go north\")";
        controller.currentText.text += "\nAllowed command:\nGo, Examine, Get, Give, Use, Inventory, TalkTo, Say, Help, Read";
    }
}
