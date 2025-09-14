using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    public RoleView roleView;

    //单例模式
    private static RoleController controller = null;
    public static RoleController Controller { get { return controller; } }

    //显示角色面板
    public static void ShowMe()
    {
        if(controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            controller = obj.GetComponent<RoleController>();
        }
        controller.gameObject.SetActive(true);
    }

    //隐藏角色面板
    public static void HideMe()
    {
        if(controller != null)
        {
            controller.gameObject.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //获取View组件，初始化界面
        roleView = this.GetComponent<RoleView>();
        roleView.UpdateInfo(PlayerModel.Data);

        //按钮点击事件的监听
        roleView.btnClose.onClick.AddListener(ClickCloseButton);
        roleView.btnLevUp.onClick.AddListener(ClickLevUpButton);

        //数据更新的监听
        PlayerModel.Data.AddListener(UpdateInfo);
    }

    //点击关闭按钮
    private void ClickCloseButton()
    {
        HideMe();
    }

    //点击升级按钮
    private void ClickLevUpButton()
    {
        PlayerModel.Data.LveUp();
    }

    //数据更新时调用
    private void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
        {
            roleView.UpdateInfo(data);
        }
    }

    private void OnDestroy()
    {
        //移除数据监听
        PlayerModel.Data.RemoveListener(UpdateInfo);
    }
}
