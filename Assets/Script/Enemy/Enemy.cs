using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Vector3 originPos;

    int originHp;
    int hp;

    [Header("경험치")]
    public ExpUp expUp;
    public int getExp;

    [Header("체력바")]
    public GameObject hp_bar_pannel;
    public Text hp_text;
    public Image[] lv_image;
    public Sprite[] number;

    private void Start()
    {
        originHp = GameManager.instance.GetScarowHp();
        hp = originHp;
        originPos = this.transform.position;
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetHp_barPannel()
    {
        hp_bar_pannel.SetActive(true);
        hp_text.text = GameManager.instance.GetScarowHp().ToString();

        int tempLv = GameManager.instance.GetScarowLv();
        if (tempLv > 999)
            tempLv = 999;
        string lvString = tempLv.ToString();
        char[] lvChar = lvString.ToCharArray();



        for (int i = 0; i < lv_image.Length; i++)
        {
            lv_image[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < lv_image.Length - (lv_image.Length - lvString.Length); i++)
        {
            lv_image[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < lvString.Length; i++)
        {
            int temp = int.Parse(lvChar[i].ToString());
            lv_image[i].sprite = number[temp];
        }

    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp_text.text = hp.ToString();
        if (hp <= 0)
        {
            hp_bar_pannel.SetActive(false);
            SparowCrowDeadSpwone();
        }
    }

    // 죽었을 때
    public void SparowCrowDeadSpwone()
    {
        expUp.EUp(getExp);
        StartCoroutine(SparowCrowDeadSpwoneCoroutine());
    }

    IEnumerator SparowCrowDeadSpwoneCoroutine()
    {
        this.transform.position = new Vector3(1000, 1000, 1000);
        yield return new WaitForSeconds(10F);
        this.transform.position = originPos;
        hp = originHp;
    }
}
