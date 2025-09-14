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

    //声明事件
    public event UnityAction<PlayerModel> dataUpdate;

    //单例模式让数据初始化。
    private static PlayerModel data = null;
    //单例模式，外部使用data可以通过Data属性获取
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

    //初始化数据
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

    //升级逻辑（数据变化）
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

    //保存数据
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

    //监听数据变化
    public void AddListener(UnityAction<PlayerModel> funtion)
    {
        dataUpdate += funtion;
    }

    //监听移除
    public void RemoveListener(UnityAction<PlayerModel> funtion)
    {
        dataUpdate -= funtion;
    }

    //监听到升级事件，通知外界
    private void UpdateInfo()
    {
        //当任何类使用PalyerModel.Data.AddListener（XXX）注册了事件，dataUpdate != null
        if (dataUpdate != null)
        {
            //向外部传递自己，this即此类的单例，即PlayerModel.Data
            dataUpdate(this);
        }
    }
}