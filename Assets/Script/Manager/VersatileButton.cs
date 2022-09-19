using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    public void Purchase(int price)
    {
        // ������ ����(price)�� GamaManager�� �ִ� score���� ũ�ٸ�
        if(price > GameManager.instance.score)
        {
            // �������� ���ŵ��� �ʰ� �Լ��� ����˴ϴ�.
            return;
        }
        else if(price <= GameManager.instance.score)
        {
            GameManager.instance.score -= price;
            GameManager.instance.dragon++;
        }
    }

    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }

}
