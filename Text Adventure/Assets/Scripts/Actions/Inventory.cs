using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "Empty";
            return;
        }

        string result = "You have ";

        bool first = true;
        foreach(Item item in controller.player.inventory)
        {
            if (first)
                result += " a "+item.itemName; 
            else
                result += " and a "+item.itemName;
            first = false;
        }
        controller.currentText.text = result;
    }
}
