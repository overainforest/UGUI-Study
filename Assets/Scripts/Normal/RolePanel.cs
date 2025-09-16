using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrite;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;

    //�������Ӱ
    private static RolePanel panel;

    public static void ShowMe()
    {
        if(panel==null)
        {
            GameObject res = Resources.Load<GameObject>("UI/Normal/RolePanel");
            GameObject obj = Instantiate(res);
            panel = obj.GetComponent<RolePanel>();
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }

    public static void HideMe()
    {
        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        btnClose.onClick.AddListener(OnClickClose);
        btnLevUp.onClick.AddListener(OnClickLevUp);
    }


    public void OnClickClose()
    {
        //�رս�ɫ���
        RolePanel.HideMe();
    }

    public void OnClickLevUp()
    {
        //����
        int lev = PlayerPrefs.GetInt("PlayerLev", 1);
        int hp = PlayerPrefs.GetInt("PlayerHp", 100);
        int atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        int def = PlayerPrefs.GetInt("PlayerDef", 5);
        int crite = PlayerPrefs.GetInt("PlayerCrite", 10);
        int miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        int luck = PlayerPrefs.GetInt("PlayerLuck", 0);
        //��һ���Ĺ���ı���
        lev += 1;
        hp += 100;
        atk += 10;
        def += 5;
        crite += 2;
        miss += 2;
        luck += 1;
        //������
        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrite", crite);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);
        //ͬ������
        UpdateInfo();
        MainPanel.panel.UpdateInfo();
    }

    public void UpdateInfo()
    {
        txtLev.text = "Lv." + PlayerPrefs.GetInt("PlayerLev", 1).ToString();
        txtHp.text=PlayerPrefs.GetInt("PlayerHp", 100).ToString();
        txtAtk.text = PlayerPrefs.GetInt("PlayerAtk", 10).ToString();
        txtDef.text = PlayerPrefs.GetInt("PlayerDef", 5).ToString();
        txtCrite.text = PlayerPrefs.GetInt("PlayerCrite", 0).ToString();
        txtMiss.text = PlayerPrefs.GetInt("PlayerMiss",10).ToString();
        txtLuck.text = PlayerPrefs.GetInt("PlayerLuck", 0).ToString();
    }
}
