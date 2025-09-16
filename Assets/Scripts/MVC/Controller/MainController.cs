using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    
    public MainView mainView;//����������

    //ʹ�õ���ģʽ
    private static MainController controller = null;

    //�ⲿʹ��controller��ʹ��Controller��ȡ�����޷��޸�controller
    public static MainController Controller
    {
        get
        {
            return controller;
        }
    }

    //��ʾ������
    public static void ShowMe()
    {
        //��������������
        if(controller == null)
        {
            //��λ��UI�ļ��е�Mainpanel��Ϊ��Ϸ���帳ֵ��res
            GameObject res = Resources.Load<GameObject>("UI/MVC/MainPanel");
            //������Ϸʵ��������Ϸʵ��ָ��Ϊres
            GameObject obj = Instantiate(res);
            //Ϊobjָ�������壬�������ǲ��ҵ�����ΪCanvas����Ϸ���壬�Ҳ��游�������š�
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            //����Ϸ����obj��MainController�����ֵ��controller����ʱcontorller��Ϊ��
            controller = obj.GetComponent<MainController>();
        }
        //��ʾ������
        controller.gameObject.SetActive(true);
    }
    
    //����������
    public static void HideMe()
    {
        //�����ֿ��������ڣ���MainPanel����
        if (controller != null)
        {
            //����������
            controller.gameObject.SetActive(false);
        }
    }

    //���½���
    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            mainView.UpdateInfo(data);
        }
    }

    private void Start()
    {
        //�������MainView�����ֵ��mainView
        mainView = GetComponent<MainView>();

        //����mainView���вκ�����ʹ�����ݿ�������Ϊ�������½��棬��������������
        mainView.UpdateInfo(PlayerModel.Data);//���ⲿ������PlayerModel

        //�԰�ť�����������������仯��ִ��ClickRoleBtn
        mainView.btnRole.onClick.AddListener(ClickRoleBtn);

        //��Data����������ı䣬ִ��UpdateInfo������������
        PlayerModel.Data.AddListener(UpdateInfo);

    }

    //����������ʱ��ɾ����Data�ļ���
    private void OnDestroy()
    {
        PlayerModel.Data.RemoveListener(UpdateInfo);
    }

    //�����ɫ��ť
    private void ClickRoleBtn()
    {
        RoleController.ShowMe();//���ⲿ������RoleController
    }
}
