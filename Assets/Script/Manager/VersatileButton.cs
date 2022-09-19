using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    public void Purchase(int price)
    {
        // 아이템 가격(price)이 GamaManager에 있는 score보다 크다면
        if(price > GameManager.instance.score)
        {
            // 아이템이 구매되지 않고 함수가 종료됩니다.
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
