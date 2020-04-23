using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Money : MonoBehaviour
{
    public Text moneyText;
    IEnumerator tempCount;

    private void Start()
    {
        SetMoney();
    }

    public void SetMoney()
    {
        if(tempCount != null)
            StopCoroutine(tempCount);

        tempCount = Count(GameManager.instance.userInfo.GetMoney(), 0);
        StartCoroutine(tempCount);
    }


    IEnumerator Count(long target, long current)
    {
        double duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
        double offset = (target - current) / duration;
        double currentDouble = current;

        while (currentDouble < target)
        {
            currentDouble += (offset * Time.deltaTime);
            string tempMoney = string.Format("{0:#,###}", (long)currentDouble);
            moneyText.text = tempMoney;
            yield return null;
        }

        current = target;
        string tempcurrent = string.Format("{0:#,###}", (long)current);
        if (target == 0)
            tempcurrent = "0";
        moneyText.text = tempcurrent;
    }

    public void PlusMoney(int money)
    {
        GameManager.instance.userInfo.SetMoney(GameManager.instance.userInfo.GetMoney() + money);
        SetMoney();
    }

  
}
