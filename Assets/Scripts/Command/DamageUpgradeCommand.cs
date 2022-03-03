using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgradeCommand : Command
{    
    public DamageUpgradeCommand(GameController gameController) : base (gameController) { }

    public override void ExecuteUpgrade()
    {
        foreach (GameObject tower in gameController.towersToUpgrade)
        {
            //wyszukiwanie ostatniego dodanego obiektu klasy tower
            Tower[] towers = tower.GetComponents<Tower>();
            foreach (Tower tw in towers)
            {
                if (tw.enabled == true)
                {
                    tw.enabled = false;
                    //opakowanie znalezionego obiektu
                    tower.AddComponent<DamageDecorator>().SetTower(tw);
                    break;
                }
            }
        }
    }
  
}
