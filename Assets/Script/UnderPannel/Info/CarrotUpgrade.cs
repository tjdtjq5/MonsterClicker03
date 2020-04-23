using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotUpgrade : MonoBehaviour
{
    [Header("토끠")]
    public GameObject rabbit;
    [Header("당근이미지")]
    public Image carrotImage;
    public Sprite carrotSpriteLevel01;
    public Sprite carrotSpriteLevel02;
    public Sprite carrotSpriteLevel03;
    public Sprite carrotSpriteLevel04;
    [Header("당근업그레이드 패널")]
    public GameObject background;
    public GameObject carrotPannel;
    public Image carrotPannelImage;
    public Text carrotAtk;
    public Text carrotExplanation;
    [Header("돈")]
    public Money money;

    private void Start()
    {
        SetCarrot();
    }

    void SetCarrot()
    {
        int atk = GameManager.instance.userInfo.GetCarrotLevel();

        switch (GameManager.instance.userInfo.GetCarrotLevel())
        {
            case 1:
                carrotImage.sprite = carrotSpriteLevel01;
                carrotAtk.text = "공격력 "+ atk + "증가";
                carrotExplanation.text = "깊은 곳에서 막 뽑은 당근이다.";
                break;
            case 2:
                carrotImage.sprite = carrotSpriteLevel02;
                carrotAtk.text = "공격력 " + atk + "증가";
                carrotExplanation.text = "토끠가 좋아하는 싱싱한 당근이다.";
                break;
            case 3:
                carrotImage.sprite = carrotSpriteLevel03;
                carrotAtk.text = "공격력 " + atk + "증가";
                carrotExplanation.text = "무기로 개조 되어버린 당근이다.";
                break;
            case 4:
                carrotImage.sprite = carrotSpriteLevel04;
                carrotAtk.text = "공격력 " + atk + "증가";
                carrotExplanation.text = "토끠가 리본을 달아 주었다.";
                break;
        }
 
    }
    void SetPannel()
    {
        switch (GameManager.instance.userInfo.GetCarrotLevel())
        {
            case 1:
                carrotPannelImage.sprite = carrotSpriteLevel01;
                break;
            case 2:
                carrotPannelImage.sprite = carrotSpriteLevel02;
                break;
            case 3:
                carrotPannelImage.sprite = carrotSpriteLevel03;
                break;
            case 4:
                carrotPannelImage.sprite = carrotSpriteLevel04;
                break;
        }
    }

    public void OnClickEnter()
    {
        StartCoroutine(OnClickEnterCoroutine());
    }

    public void OnClickExit()
    {
        StartCoroutine(OnClickExitCoroutine());
    }

    public void OnClickCarrotUpgrade()
    {
        StartCoroutine(OnClickCarrotUpgradeCoroutine());
    }

    bool flag;
    IEnumerator OnClickEnterCoroutine()
    {
        flag = true;
        background.SetActive(true);
        carrotPannel.SetActive(true);
        carrotPannel.GetComponent<Animator>().SetTrigger("True");
        SetPannel(); 
        yield return new WaitForSeconds(0.6f);
        flag = false;
    }

    IEnumerator OnClickExitCoroutine()
    {
        if (!flag)
        {
            carrotPannel.GetComponent<Animator>().SetTrigger("False");
            yield return new WaitForSeconds(0.6f);
            carrotPannel.SetActive(false);
            background.SetActive(false);
        }
    }

    IEnumerator OnClickCarrotUpgradeCoroutine()
    {
        yield return null;
        if(GameManager.instance.userInfo.GetCarrotLevel() < 4)
        {
            if (GameManager.instance.userInfo.GetMoney() >= 5000000)
            {
                rabbit.transform.Find("당근").Find("1단계당근").gameObject.SetActive(false);
                rabbit.transform.Find("당근").Find("2단계당근").gameObject.SetActive(false);
                rabbit.transform.Find("당근").Find("3단계당근").gameObject.SetActive(false);
                rabbit.transform.Find("당근").Find("4단계당근").gameObject.SetActive(false);

                rabbit.transform.Find("당근").Find(GameManager.instance.userInfo.GetCarrotLevel() + 1 + "단계당근").gameObject.SetActive(true);
                GameManager.instance.userInfo.SetCarrotLevel(GameManager.instance.userInfo.GetCarrotLevel() + 1);

                money.PlusMoney(-5000000);
                SetCarrot();
                SetPannel();
            }
        }
    }
}
