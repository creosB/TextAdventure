using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "Nothing responds";
    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    if (item.InteractWith(controller,"say", noun))
                        return true;
                }
            }
        }
        return false;
    }

}
