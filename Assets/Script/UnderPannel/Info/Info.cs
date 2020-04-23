using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public Image nameImage;
    public Image[] levelImage;
    public Text battleText;
    public Text atkText;
    public Text hpText;
    public Text speedText;
    public Text criticalText;
    public Text sheildText;
    public Text atkSpeedText;

    [Header("숫자")]
    public Sprite[] number;

    Vector2 originNamePos;

    private void Start()
    {
        originNamePos = nameImage.transform.localPosition;
        SetInfoAll();
       
    }

    public void SetInfoAll()
    {
        LvSet();
        battleText.text = "전투력 " + GameManager.instance.GetBattle();
        atkText.text = "공격력 " + GameManager.instance.GetAtk(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.atkEnhance));
        hpText.text = "체력 " + GameManager.instance.GetHp(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.hpEnhance));
        speedText.text = "속력 " + GameManager.instance.GetSpeed();
        criticalText.text = "크리티컬 " + GameManager.instance.GetCritical();
        sheildText.text = "방어력 " + GameManager.instance.GetSheild();
        atkSpeedText.text = "공격속도 " + GameManager.instance.GetAtkSpeed();
    }

    void LvSet()
    {
        int tempLv = GameManager.instance.userInfo.GetLevel();
        if (tempLv > 999)
            tempLv = 999;
        string lvString = tempLv.ToString();
        char[] lvChar = lvString.ToCharArray();



        for (int i=0; i < levelImage.Length; i++)
        {
            levelImage[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < levelImage.Length - (levelImage.Length - lvString.Length); i++)
        {
            levelImage[i].gameObject.SetActive(true);
        }

      

        for(int i=  0; i < lvString.Length; i++)
        {
            int temp = int.Parse(lvChar[i].ToString());
            levelImage[i].sprite = number[temp];
        }

        nameImage.transform.localPosition = new Vector3(originNamePos.x - ((levelImage[0].GetComponent<RectTransform>().rect.width * 0.85f) * (levelImage.Length - lvString.Length)), originNamePos.y, 0);

    }
}
