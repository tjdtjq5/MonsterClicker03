using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamageEffect : MonoBehaviour
{
    int originDamage;
    int damage;
    public GameObject target;
    Transform targetPos;
    GameObject[] damageText;

    public Transform enemyPos;
    public GameObject[] nomalDamageText;
    public GameObject[] criticalDamageText;

    public BattleManager battleManager;

    public void SetDamageTarget(int damage)
    {
        damageText = new GameObject[nomalDamageText.Length];
        this.targetPos = enemyPos;
        this.originDamage = damage;
        this.damage = damage;
    }

    [HideInInspector]
    public int realDamge;
    public void Damage(int count)
    {
        realDamge = 0;

        if (count == 0)
            count = 1;
        for (int i = 0; i < count; i++)
        {
            this.damage = this.originDamage;
            StartCoroutine(DamageCoroutine(i));
        }
    }

    IEnumerator DamageCoroutine(int count)
    {
        int critical = Random.RandomRange(0, 100);
        if (critical <= GameManager.instance.GetCritical())
        {
            damageText[count] = criticalDamageText[count];
            damage = (int)(damage * 1.25f);
        }
        else
        {
            damageText[count] = nomalDamageText[count];
        }

        yield return new WaitForSeconds(count * 0.2f);
        damageText[count].SetActive(true);
        damageText[count].transform.position = target.transform.position;

        //데미지 표기
        int ten = Random.RandomRange(-damage / 10, damage / 10);
        damageText[count].GetComponent<Text>().text = (damage + ten).ToString();
        realDamge += (damage + ten);

        float randX = ((float)Random.RandomRange(-50, 50) / 100);
        float randY = ((float)Random.RandomRange(50, 85) / 100);
        damageText[count].transform.DOMove(new Vector2(damageText[count].transform.position.x + randX, damageText[count].transform.position.y + randY), 0.5f).SetEase(Ease.Unset);
        StartCoroutine(CaracterEffectCoroutine(target, "hit", 0, 0.4f));
        yield return new WaitForSeconds(0.5f);
        damageText[count].SetActive(false);
    }

    IEnumerator CaracterEffectCoroutine(GameObject effectObj, string skillName, float startTime, float endTime)
    {
        yield return new WaitForSeconds(startTime);
        effectObj.GetComponent<Animator>().SetBool(skillName, true);
        yield return new WaitForSeconds(endTime);
        effectObj.GetComponent<Animator>().SetBool(skillName, false);
    }
}
