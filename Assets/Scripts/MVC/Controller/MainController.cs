using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    
    public MainView mainView;//声明主界面

    //使用单例模式
    private static MainController controller = null;

    //外部使用controller，使用Controller获取，且无法修改controller
    public static MainController Controller
    {
        get
        {
            return controller;
        }
    }

    //显示主界面
    public static void ShowMe()
    {
        //当控制器不存在
        if(controller == null)
        {
            //将位于UI文件夹的Mainpanel作为游戏物体赋值给res
            GameObject res = Resources.Load<GameObject>("UI/MVC/MainPanel");
            //创键游戏实例，将游戏实例指定为res
            GameObject obj = Instantiate(res);
            //为obj指定父物体，父物体是查找到的名为Canvas的游戏物体，且不随父物体缩放。
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            //将游戏物体obj的MainController组件赋值给controller，此时contorller不为空
            controller = obj.GetComponent<MainController>();
        }
        //显示主界面
        controller.gameObject.SetActive(true);
    }
    
    //隐藏主界面
    public static void HideMe()
    {
        //当发现控制器存在，即MainPanel存在
        if (controller != null)
        {
            //隐藏主界面
            controller.gameObject.SetActive(false);
        }
    }

    //更新界面
    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            mainView.UpdateInfo(data);
        }
    }

    private void Start()
    {
        //将物体的MainView组件赋值给mainView
        mainView = GetComponent<MainView>();

        //利用mainView的有参函数，使用数据库数据作为参数更新界面，即加载已有数据
        mainView.UpdateInfo(PlayerModel.Data);//从外部调用了PlayerModel

        //对按钮点击监听，如果发生变化，执行ClickRoleBtn
        mainView.btnRole.onClick.AddListener(ClickRoleBtn);

        //对Data监听，如果改变，执行UpdateInfo，即更新数据
        PlayerModel.Data.AddListener(UpdateInfo);

    }

    //当物体销毁时，删除对Data的监听
    private void OnDestroy()
    {
        PlayerModel.Data.RemoveListener(UpdateInfo);
    }

    //点击角色按钮
    private void ClickRoleBtn()
    {
        RoleController.ShowMe();//从外部调用了RoleController
    }
}
