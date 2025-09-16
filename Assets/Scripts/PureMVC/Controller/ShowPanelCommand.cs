using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class ShowPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        string panelName = notification.Body.ToString();

        switch (panelName)
        {
            case "MainPanel":
                if(!Facade.HasMediator(NewMainViewMediator.NAME))
                {
                    Facade.RegisterMediator(new NewMainViewMediator());
                }

                NewMainViewMediator mm = Facade.RetrieveMediator(NewMainViewMediator.NAME) as NewMainViewMediator;



                if(mm.ViewComponent == null)
                {
                    GameObject res = Resources.Load<GameObject>("UI/PureMVC/MainPanel");
                    GameObject obj = GameObject.Instantiate(res);
                    obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

                    mm.SetView(obj.GetComponent<NewMainView>());
                    //mm.ViewComponent = obj.GetComponent<NewMainView>();
                }
                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);

                break;

            case "RolePanel":
                
                if (!Facade.HasMediator(NewRoleViewMediator.NAME))
                {
                    Facade.RegisterMediator(new NewRoleViewMediator());
                }

                NewRoleViewMediator rm = Facade.RetrieveMediator(NewRoleViewMediator.NAME) as NewRoleViewMediator;

                if (rm.ViewComponent == null)
                {
                    GameObject res = Resources.Load<GameObject>("UI/PureMVC/RolePanel");
                    GameObject obj = GameObject.Instantiate(res);
                    obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

                    rm.SetView(obj.GetComponent<NewRoleView>());
                }

                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);

                break;

        }
    }
}
