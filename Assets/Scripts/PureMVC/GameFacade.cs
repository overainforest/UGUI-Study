using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : Facade
{
    public static string NAME = "GameFacade";//Mediator±êÊ¶·û

    public GameFacade() : base(NAME)
    {

    }

    private static GameFacade instance = null;

    public static GameFacade Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameFacade();
            }
            return instance;
        }
    }

    protected override void InitializeController()
    {
        base.InitializeController();

        RegisterCommand(PureNotification.START_UP, () => { return new StartUpCommand(); });
        RegisterCommand(PureNotification.SHOW_PANEL, () => { return new ShowPanelCommand(); });
        RegisterCommand(PureNotification.HIDE_PANEL, () => { return new HidePanelCommand(); });
        RegisterCommand(PureNotification.LEV_UP, () => { return new LevUpCommand(); });
    }

    public void StartUp()
    {
        SendNotification(PureNotification.START_UP);
    }
}
