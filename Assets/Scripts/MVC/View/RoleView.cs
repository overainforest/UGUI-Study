using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleView : MonoBehaviour
{
    public Text lev;
    public Text hp;
    public Text atk;
    public Text def;
    public Text cri;
    public Text miss;
    public Text luck;

    public Button btnClose;
    public Button btnLevUp;

    //面板要控制界面
    public void UpdateInfo(PlayerModel data)
    {
        lev.text = "Lv." + data.lev;
        hp.text = data.hp.ToString();
        atk.text = data.atk.ToString();
        def.text = data.def.ToString();
        cri.text = data.crite.ToString() + "%";
        miss.text = data.miss.ToString() + "%";
        luck.text = data.luck.ToString() + "%";
    }

}
