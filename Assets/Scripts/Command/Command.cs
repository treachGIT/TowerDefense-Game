using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public GameController gameController;

    public Command(GameController gameController)
    {
        this.gameController = gameController;

    }

    public abstract void ExecuteUpgrade();

}
