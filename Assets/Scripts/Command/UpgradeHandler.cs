using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler
{
    private List<Command> commandHistory;
    public UpgradeHandler()
    {
        commandHistory = new List<Command>();
    }

    public void executeCommand(Command command)
    {
        commandHistory.Add(command);
        command.ExecuteUpgrade();
    }

    public void executeAllCommandsFromHistory()
    {
        foreach(Command command in commandHistory)
        {
            command.ExecuteUpgrade();
        }
    }

}
