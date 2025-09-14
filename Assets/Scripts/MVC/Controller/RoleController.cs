using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    public RoleView roleView;

    //����ģʽ
    private static RoleController controller = null;
    public static RoleController Controller { get { return controller; } }

    //��ʾ��ɫ���
    public static void ShowMe()
    {
        if(controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            controller = obj.GetComponent<RoleController>();
        }
        controller.gameObject.SetActive(true);
    }

    //���ؽ�ɫ���
    public static void HideMe()
    {
        if(controller != null)
        {
            controller.gameObject.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //��ȡView�������ʼ������
        roleView = this.GetComponent<RoleView>();
        roleView.UpdateInfo(PlayerModel.Data);

        //��ť����¼��ļ���
        roleView.btnClose.onClick.AddListener(ClickCloseButton);
        roleView.btnLevUp.onClick.AddListener(ClickLevUpButton);

        //���ݸ��µļ���
        PlayerModel.Data.AddListener(UpdateInfo);
    }

    //����رհ�ť
    private void ClickCloseButton()
    {
        HideMe();
    }

    //���������ť
    private void ClickLevUpButton()
    {
        PlayerModel.Data.LveUp();
    }

    //���ݸ���ʱ����
    private void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
        {
            roleView.UpdateInfo(data);
        }
    }

    private void OnDestroy()
    {
        //�Ƴ����ݼ���
        PlayerModel.Data.RemoveListener(UpdateInfo);
    }
}
