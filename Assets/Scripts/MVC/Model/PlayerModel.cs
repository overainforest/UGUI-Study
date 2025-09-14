using UnityEngine;
using UnityEngine.Events;

public class PlayerModel
{
    public string playerName { get; private set; }
    public int lev { get; private set; }
    public int money { get; private set; }
    public int gem { get; private set; }
    public int power { get; private set; }


    public int hp { get; private set; }
    public int atk { get; private set; }
    public int def { get; private set; }
    public int crite { get; private set; }
    public int miss { get; private set; }
    public int luck { get; private set; }

    //�����¼�
    public event UnityAction<PlayerModel> dataUpdate;

    //����ģʽ�����ݳ�ʼ����
    private static PlayerModel data = null;
    //����ģʽ���ⲿʹ��data����ͨ��Data���Ի�ȡ
    public static PlayerModel Data
    {
        get
        {
            if (data == null)
            {
                data = new PlayerModel();
                data.Init();
            }
            return data;
        }
    }

    //��ʼ������
    public void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Hero");
        lev = PlayerPrefs.GetInt("PlayerLev", 1);
        money = PlayerPrefs.GetInt("PlayerMoney", 1000);
        gem = PlayerPrefs.GetInt("PlayerGem", 100);
        power = PlayerPrefs.GetInt("PlayerPower", 100);
        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        def = PlayerPrefs.GetInt("PlayerDef", 5);
        crite = PlayerPrefs.GetInt("PlayerCrite", 5);
        miss = PlayerPrefs.GetInt("PlayerMiss", 5);
        luck = PlayerPrefs.GetInt("PlayerLuck", 5);
    }

    //�����߼������ݱ仯��
    public void LveUp()
    {
        lev += 1;
        hp += 20;
        atk += 5;
        def += 2;
        crite += 1;
        miss += 1;
        luck += 1;

        SaveData();
    }

    //��������
    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.SetInt("PlayerGem", gem);
        PlayerPrefs.SetInt("PlayerPower", power);
        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrite", crite);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLuck", luck);

        UpdateInfo();
    }

    //�������ݱ仯
    public void AddListener(UnityAction<PlayerModel> funtion)
    {
        dataUpdate += funtion;
    }

    //�����Ƴ�
    public void RemoveListener(UnityAction<PlayerModel> funtion)
    {
        dataUpdate -= funtion;
    }

    //�����������¼���֪ͨ���
    private void UpdateInfo()
    {
        //���κ���ʹ��PalyerModel.Data.AddListener��XXX��ע�����¼���dataUpdate != null
        if (dataUpdate != null)
        {
            //���ⲿ�����Լ���this������ĵ�������PlayerModel.Data
            dataUpdate(this);
        }
    }
}