using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Alba : MonoBehaviour
{
    [Header ("알바패널과 알바와 수가 같아야 함")]
    public Transform[] albaPannel;

    [Serializable]
    public struct alba
    {
        public Sprite companySprite;
        public string loborExplanation;
        public int second;
        public int money;
        public int moneyPercent;
        public int cost;
    }
    [Header("면접비용이 업글마다 오르는 퍼센트")]
    [Range (0,100)] public int costPercent;
    public alba[] albas;

    [Header("머니")]
    public Money money;


    public void Start()
    {
        SetAlba();
    }

    // money = 복리로 moneyPercent만큼 증가 
    // cost = 복리로 costPercent만큼 증가
    void SetAlba()
    {
        for(int i=0; i<albaPannel.Length; i++)
        {
            if(albas[i].companySprite != null)
            {
                albaPannel[i].Find("회사이미지").GetComponent<Image>().sprite = albas[i].companySprite;
                albaPannel[i].Find("작업내용").GetComponent<Text>().text = albas[i].loborExplanation;
                string temp = "초";
                int tempSecond = albas[i].second;
               
                if (albas[i].second >= 60)
                {
                    temp = "분";
                    tempSecond = tempSecond / 60;
                }
                if (albas[i].second >= 3600)
                {
                    temp = "시간";
                    tempSecond = tempSecond / 60;
                }

                int tempMoney = Money(i);
                string tempMoneyString = string.Format("{0:#,###}", tempMoney);
                int tempCost = Cost(i);
                string tempCostString = string.Format("{0:#,###}", tempCost);

                albaPannel[i].Find("급여").GetComponent<Text>().text = "급여 : " + tempSecond + temp + " " + tempMoneyString + "원";
                albaPannel[i].Find("면접비용").GetComponent<Text>().text = "면접비용 : " + tempCostString + "원";
                albaPannel[i].Find("지원버튼").gameObject.SetActive(true);

                StartCoroutine(Alba01Coroutine());
                StartCoroutine(Alba02Coroutine());
                StartCoroutine(Alba03Coroutine());
                StartCoroutine(Alba04Coroutine());
                StartCoroutine(Alba05Coroutine());
                StartCoroutine(Alba06Coroutine());
                StartCoroutine(Alba07Coroutine());
                StartCoroutine(Alba08Coroutine());
                StartCoroutine(Alba09Coroutine());
                StartCoroutine(Alba10Coroutine());
            }
            else
            {
                albaPannel[i].Find("지원버튼").gameObject.SetActive(false);
            }

        }
    }

    public void OnClickAlba01()
    {
        if(GameManager.instance.userInfo.GetMoney() >= Cost(0))
        {
            money.PlusMoney(-Cost(0));
            GameManager.instance.userInfo.SetAlba(0, GameManager.instance.userInfo.GetAlba(0) + 1);
            SetAlba();
        }
    }

    bool alba01Flag;
    IEnumerator Alba01Coroutine()
    {
        if(GameManager.instance.userInfo.GetAlba(0) > 0 && !alba01Flag)
        {
            alba01Flag = true;
            while (true)
            {
                albaPannel[0].Find("스크롤바").GetComponent<Scrollbar>().size += Time.fixedDeltaTime / albas[0].second;

                if (albaPannel[0].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[0].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(0));
                }
                yield return null;
            }
        }
    }

    public void OnClickAlba02()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(1))
        {
            money.PlusMoney(-Cost(1));
            GameManager.instance.userInfo.SetAlba(1, GameManager.instance.userInfo.GetAlba(1) + 1);
            SetAlba();
        }
    }

    bool alba02Flag;
    IEnumerator Alba02Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(1) > 0 && !alba02Flag)
        {
            alba02Flag = true;
            while (true)
            {
              
                albaPannel[1].Find("스크롤바").GetComponent<Scrollbar>().size += Time.fixedDeltaTime / albas[1].second;

                if (albaPannel[1].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[1].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(1));
                }
                yield return null;
            }
        }
    }

    public void OnClickAlba03()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(2))
        {
            money.PlusMoney(-Cost(2));
            GameManager.instance.userInfo.SetAlba(2, GameManager.instance.userInfo.GetAlba(2) + 1);
            SetAlba();
        }
    }

    bool alba03Flag;
    IEnumerator Alba03Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(2) > 0 && !alba03Flag)
        {
            alba03Flag = true;

            while (true)
            {
                albaPannel[2].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[2].second;

                if (albaPannel[2].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[2].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(2));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba04()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(3))
        {
            money.PlusMoney(-Cost(3));
            GameManager.instance.userInfo.SetAlba(3, GameManager.instance.userInfo.GetAlba(3) + 1);
            SetAlba();
        }
    }

    bool alba04Flag;
    IEnumerator Alba04Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(3) > 0 && !alba04Flag)
        {
            alba04Flag = true;

            while (true)
            {
                albaPannel[3].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[3].second;

                if (albaPannel[3].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[3].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(3));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba05()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(4))
        {
            money.PlusMoney(-Cost(4));
            GameManager.instance.userInfo.SetAlba(4, GameManager.instance.userInfo.GetAlba(4) + 1);
            SetAlba();
        }
    }

    bool alba05Flag;
    IEnumerator Alba05Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(4) > 0 && !alba05Flag)
        {
            alba05Flag = true;

            while (true)
            {
                albaPannel[4].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[4].second;

                if (albaPannel[4].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[4].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(4));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba06()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(5))
        {
            money.PlusMoney(-Cost(5));
            GameManager.instance.userInfo.SetAlba(5, GameManager.instance.userInfo.GetAlba(5) + 1);
            SetAlba();
        }
    }

    bool alba06Flag;
    IEnumerator Alba06Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(5) > 0 && !alba06Flag)
        {
            alba06Flag = true;

            while (true)
            {
                albaPannel[5].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[5].second;

                if (albaPannel[5].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[5].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(5));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba07()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(6))
        {
            money.PlusMoney(-Cost(6));
            GameManager.instance.userInfo.SetAlba(6, GameManager.instance.userInfo.GetAlba(6) + 1);
            SetAlba();
        }
    }

    bool alba07Flag;
    IEnumerator Alba07Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(6) > 0 && !alba07Flag)
        {
            alba07Flag = true;

            while (true)
            {
                albaPannel[6].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[6].second;

                if (albaPannel[6].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[6].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(6));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba08()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(7))
        {
            money.PlusMoney(-Cost(7));
            GameManager.instance.userInfo.SetAlba(7, GameManager.instance.userInfo.GetAlba(7) + 1);
            SetAlba();
        }
    }

    bool alba08Flag;
    IEnumerator Alba08Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(7) > 0 && !alba08Flag)
        {
            alba08Flag = true;

            while (true)
            {
                albaPannel[7].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[7].second;

                if (albaPannel[7].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[7].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(7));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba09()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(8))
        {
            money.PlusMoney(-Cost(8));
            GameManager.instance.userInfo.SetAlba(8, GameManager.instance.userInfo.GetAlba(8) + 1);
            SetAlba();
        }
    }

    bool alba09Flag;
    IEnumerator Alba09Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(8) > 0 && !alba09Flag)
        {
            alba09Flag = true;

            while (true)
            {
                albaPannel[8].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[8].second;

                if (albaPannel[8].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[8].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(8));
                }
                yield return null;

            }
        }
    }

    public void OnClickAlba10()
    {
        if (GameManager.instance.userInfo.GetMoney() >= Cost(9))
        {
            money.PlusMoney(-Cost(9));
            GameManager.instance.userInfo.SetAlba(9, GameManager.instance.userInfo.GetAlba(9) + 1);
            SetAlba();
        }
    }

    bool alba10Flag;
    IEnumerator Alba10Coroutine()
    {
        if (GameManager.instance.userInfo.GetAlba(9) > 0 && !alba10Flag)
        {
            alba10Flag = true;

            while (true)
            {
                albaPannel[9].Find("스크롤바").GetComponent<Scrollbar>().size += Time.deltaTime / albas[9].second;

                if (albaPannel[9].Find("스크롤바").GetComponent<Scrollbar>().size == 1)
                {
                    albaPannel[9].Find("스크롤바").GetComponent<Scrollbar>().size = 0;
                    money.PlusMoney(Money(9));
                }
                yield return null;

            }
        }
    }

    int Cost(int whatAlba)
    {
        int tempCost = albas[whatAlba].cost;
        for (int j = 0; j < GameManager.instance.userInfo.GetAlba(whatAlba); j++)
        {
            tempCost = tempCost + (costPercent * (tempCost / 100));
        }
        return tempCost;
    }

    int Money(int whatAlba)
    {
        int tempMoney = albas[whatAlba].money;
        for (int j = 0; j < GameManager.instance.userInfo.GetAlba(whatAlba); j++)
        {
            tempMoney = tempMoney + (albas[whatAlba].moneyPercent * (tempMoney / 100));
        }
        return tempMoney;
    }
}
