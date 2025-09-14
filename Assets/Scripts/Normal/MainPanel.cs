using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //1.获取控件
    public Text textName;
    public Text textLev;
    public Text textMoney;
    public Text textGem;
    public Text textPower;

    //2.获取按钮
    public Button btnRole;

    //private static MainPanel panel;

    public static MainPanel panel { get; private set; }

    //4.动态显影
    public static void ShowMe()
    {
        //显示主面板
        if(panel == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            panel = obj.GetComponent<MainPanel>();
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }

    public static void HideMe()
    {
        //if (panel!=null)
        //{
        //    Destroy(panel);
        //    panel = null;
        //}

        //隐藏主面板:1.直接删 2.显影

        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }

    }

    void Start()
    {
        //3.添加按钮事件
        btnRole.onClick.AddListener(OnClickRole);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //5.更新角色信息
    public void OnClickRole()
    {
        //打开角色面板
        Debug.Log("打开角色面板");
        RolePanel.ShowMe();
    }

    public void UpdateInfo()
    {
        //获取玩家数据的方式：1.网络请求 2.json 3.xml 4.二进制 5. PlayerPrefs
        textName.text = PlayerPrefs.GetString("PlayerName", "Player");
        textLev.text="LV."+ PlayerPrefs.GetInt("PlayerLev", 1).ToString();
        textMoney.text = PlayerPrefs.GetInt("PlayerMoney", 0).ToString();
        textGem.text = PlayerPrefs.GetInt("PlayerGem", 0).ToString();
        textPower.text = PlayerPrefs.GetInt("PlayerPower", 0).ToString();
    }
}
