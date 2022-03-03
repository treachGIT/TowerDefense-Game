using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASUpgradeCommand : Command
{
    public ASUpgradeCommand(GameController gameController) : base(gameController) { }

    public override void ExecuteUpgrade()
    {
        foreach (GameObject tower in gameController.towersToUpgrade)
        {
            Tower[] towers = tower.GetComponents<Tower>();
            foreach (Tower tw in towers)
            {
                if (tw.enabled == true)
                {
                    tw.enabled = false;
                    tower.AddComponent<AttackSpeedDecorator>().SetTower(tw);
                    break;
                }
            }
        }
    }
}
