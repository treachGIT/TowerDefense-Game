using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSUpgradeCommand : Command
{
    public BSUpgradeCommand(GameController gameController) : base(gameController) { }

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
                    tower.AddComponent<BulletSpeedDecorator>().SetTower(tw);
                    break;
                }
            }
        }
    }
}
