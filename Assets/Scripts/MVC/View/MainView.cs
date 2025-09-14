using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Text playerName;
    public Text playerLev;
    public Text playerMoney;
    public Text playerGem;
    public Text playerPower;

    public Button btnRole;


    //提供一个接口供Controller更新界面
    public void UpdateInfo(PlayerModel data)
    {
        playerName.text = data.playerName;
        playerLev.text = "Lv." + data.lev;
        playerMoney.text = data.money.ToString();
        playerGem.text = data.gem.ToString();
        playerPower.text = data.power.ToString();
    }
}
