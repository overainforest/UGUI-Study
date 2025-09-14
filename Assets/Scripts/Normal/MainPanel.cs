using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //1.��ȡ�ؼ�
    public Text textName;
    public Text textLev;
    public Text textMoney;
    public Text textGem;
    public Text textPower;

    //2.��ȡ��ť
    public Button btnRole;

    //private static MainPanel panel;

    public static MainPanel panel { get; private set; }

    //4.��̬��Ӱ
    public static void ShowMe()
    {
        //��ʾ�����
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

        //���������:1.ֱ��ɾ 2.��Ӱ

        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }

    }

    void Start()
    {
        //3.��Ӱ�ť�¼�
        btnRole.onClick.AddListener(OnClickRole);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //5.���½�ɫ��Ϣ
    public void OnClickRole()
    {
        //�򿪽�ɫ���
        Debug.Log("�򿪽�ɫ���");
        RolePanel.ShowMe();
    }

    public void UpdateInfo()
    {
        //��ȡ������ݵķ�ʽ��1.�������� 2.json 3.xml 4.������ 5. PlayerPrefs
        textName.text = PlayerPrefs.GetString("PlayerName", "Player");
        textLev.text="LV."+ PlayerPrefs.GetInt("PlayerLev", 1).ToString();
        textMoney.text = PlayerPrefs.GetInt("PlayerMoney", 0).ToString();
        textGem.text = PlayerPrefs.GetInt("PlayerGem", 0).ToString();
        textPower.text = PlayerPrefs.GetInt("PlayerPower", 0).ToString();
    }
}
