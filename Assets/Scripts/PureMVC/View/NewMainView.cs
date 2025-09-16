using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMainView : MonoBehaviour
{
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    public Button btnRole;
    public Button btnSkill;


    //MVC思想，提供一个接口供Controller更新界面
    public void UpdateInfo(PlayerDataObj data)
    {
        txtName.text = data.playerName;
        txtLev.text = "Lv." + data.lev;
        txtMoney.text = data.money.ToString();
        txtGem.text = data.gem.ToString();
        txtPower.text = data.power.ToString();
    }
}
