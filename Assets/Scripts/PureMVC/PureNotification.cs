using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//用于声明各个通知的名字，方便管理通知
public class PureNotification : MonoBehaviour
{
    public const string SHOW_PANEL = "showPanel"; //显示面板

    public const string HIDE_PANEL = "hidePanel";//隐藏面板

    public const string UPDATE_PLAYER_INFO = "upDatePlayerInfo";

    public const string START_UP = "startUp"; //启动游戏

    public const string LEV_UP= "LevUp";//升级

}
