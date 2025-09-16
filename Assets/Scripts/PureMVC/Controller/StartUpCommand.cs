using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        if(!Facade.HasProxy(PlayerProxy.NAME))
        {
            Facade.RegisterProxy(new PlayerProxy());
        }
    }
}
