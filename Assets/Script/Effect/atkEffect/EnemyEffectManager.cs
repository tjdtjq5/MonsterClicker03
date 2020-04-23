using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectManager : MonoBehaviour
{
    public GameObject EffectObj01;
    public GameObject EffectObj02;
    public GameObject EffectObj03;
    public GameObject EffectObj04;

    int damage;

    private void Start()
    {
    }

    public void SkillEffect(string skillCode, int damage)
    {
        this.damage = damage;
        Invoke(skillCode, 0);
    }
    IEnumerator SkillCoroutine(GameObject effectObj, string skillName, float startTime, float endTime)
    {
        effectObj.GetComponent<EnemyDamageEffect>().SetDamageTarget(damage);
        yield return new WaitForSeconds(startTime);
        effectObj.GetComponent<Animator>().SetBool(skillName, true);
        yield return new WaitForSeconds(endTime);
        effectObj.GetComponent<Animator>().SetBool(skillName, false);
    }

    void Pure00()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure00", 0, .6f));
    }
    void Pure01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure01", 0, 1.1f));
    }
    void Poison01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison01", 0, 1.1f));
    }
}
