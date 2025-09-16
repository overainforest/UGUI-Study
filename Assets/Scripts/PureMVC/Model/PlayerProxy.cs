using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class PlayerProxy : Proxy//引用命名空间继承Proxy
{
    public new const string NAME = "PlayerProxy";

    public PlayerProxy():base(PlayerProxy.NAME)
    {
        PlayerDataObj data = new PlayerDataObj();

        //初始化
        data.playerName = PlayerPrefs.GetString("PlayerName", "Hero");
        data.lev = PlayerPrefs.GetInt("PlayerLev", 1);
        data.money = PlayerPrefs.GetInt("PlayerMoney", 1000);
        data.gem = PlayerPrefs.GetInt("PlayerGem", 100);
        data.power = PlayerPrefs.GetInt("PlayerPower", 100);
        data.hp = PlayerPrefs.GetInt("PlayerHp", 100);
        data.atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        data.def = PlayerPrefs.GetInt("PlayerDef", 5);
        data.crite = PlayerPrefs.GetInt("PlayerCrite", 5);
        data.miss = PlayerPrefs.GetInt("PlayerMiss", 5);
        data.luck = PlayerPrefs.GetInt("PlayerLuck", 5);

        Data = data;
    }

    public void LevUp()
    {
        PlayerDataObj data=Data as PlayerDataObj;//类型转换
        
        data.lev += 1;
        data.hp += 20;
        data.atk += 5;
        data.def += 2;
        data.crite += 1;
        data.miss += 1;
        data.luck += 1;

    }

    public void SaveData()
    {
        PlayerDataObj data = Data as PlayerDataObj;//类型转换

        PlayerPrefs.SetString("PlayerName", data.playerName);
        PlayerPrefs.SetInt("PlayerLev", data.lev);
        PlayerPrefs.SetInt("PlayerMoney", data.money);
        PlayerPrefs.SetInt("PlayerGem", data.gem);
        PlayerPrefs.SetInt("PlayerPower", data.power);
        PlayerPrefs.SetInt("PlayerHp", data.hp);
        PlayerPrefs.SetInt("PlayerAtk", data.atk);
        PlayerPrefs.SetInt("PlayerDef", data.def);
        PlayerPrefs.SetInt("PlayerCrite", data.crite);
        PlayerPrefs.SetInt("PlayerMiss", data.miss);
        PlayerPrefs.SetInt("PlayerLuck", data.luck);
    }
}
