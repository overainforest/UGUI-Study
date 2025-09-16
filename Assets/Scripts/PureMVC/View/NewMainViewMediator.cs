using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainViewMediator : Mediator//�̳�Mediator
{
    public static new string NAME = "NewMainViewMeditor";//Mediator��ʶ��

    public NewMainViewMediator():base(NAME)
    {

    }

    public void SetView(NewMainView view)
    {
        ViewComponent = view;
        view.btnRole.onClick.AddListener( () => { SendNotification(PureNotification.SHOW_PANEL, "RolePanel"); } );
    }


    public override string[] ListNotificationInterests()//��д����
    {
        return new string[] {

            PureNotification.UPDATE_PLAYER_INFO,
            PureNotification.SHOW_PANEL
        };
    }

    public override void HandleNotification(INotification notification)
    {
        switch(notification.Name)
        {
            case PureNotification.UPDATE_PLAYER_INFO:

                if(ViewComponent != null) 
                    (ViewComponent as NewMainView).UpdateInfo(notification.Body as PlayerDataObj);

                break;
        }
    }

    //��ѡ��ע��ʱ��ʼ��ĳЩ����
    public override void OnRegister()
    {
        base.OnRegister();
        //��ʼ��

    }
}
