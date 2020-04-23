using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkEffectManager : MonoBehaviour
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
        effectObj.GetComponent<DamageEffect>().SetDamageTarget(damage);
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
    void Pure02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure02", 0, 1.1f));
    }
    void Pure03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure03", 0, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Pure03_02", .4f, 1.1f));
    }
    void Pure04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure04", 0, 1.6f));
    }
    void Pure05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure05", .25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Pure05_02", 0, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Pure05_03", .75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Pure05_04", .5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure05", 1.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Pure05_02", 1f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Pure05_03", 1.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Pure05_04", 1.5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Pure05", 2.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Pure05_02", 2, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Pure05_03", 2.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Pure05_04", 2.5f, 0.7f));
    }
    void Poison01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison01", 0, 1.1f));
    }
    void Poison02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison02", 0, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Poison02_02", .3f, 1.1f));
    }
    void Poison03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison03", .25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Poison03_02", 0, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Poison03_03", .75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Poison03_04", .5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison03", 1.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Poison03_02", 1f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Poison03_03", 1.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Poison03_04", 1.5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison03", 2.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Poison03_02", 2, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Poison03_03", 2.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Poison03_04", 2.5f, 0.7f));
    }
    void Poison04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison04", 0, 1.1f));
    }
    void Poison05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Poison05", 0, 1.6f));
    }
    void Fight01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fight01", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fight01_02", .25f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fight01_03", .15f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Fight01_04", .35f, 1.1f));
    }
    void Fight02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fight02", 0f, .3f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fight02_02", .25f, .3f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fight02_03", .15f, .3f));
    }
    void Fight03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fight03", 0, .4f));
    }
    void Fight04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fight04", 0, .4f));
    }
    void Fight05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fight05", 0.65f, .4f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fight05_02", 0f, .4f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Black", 0f, 1.05f));
    }
    void Fire01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire01", 0f, .6f));
    }
    void Fire02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire02", 0f, 1.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Black", 0f, 1.7f));
    }
    void Fire03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire03", 0f, 1.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fire03_02", 0f, 1.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fire03_03", 0f, 1.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Black", 0f, 1.7f));
    }
    void Fire04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire04", 0f, 1f));
    }
    void Fire05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire05", 0f, 1f));
    }
    void Fire06()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire06", 0f, 1.3f));
    }
    void Fire07()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire07", 0f, 1.3f));
    }
    void Fire08()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire08", .25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fire08_02", 0, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fire08_03", .75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Fire08_04", .5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire08", 1.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fire08_02", 1f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fire08_03", 1.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Fire08_04", 1.5f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire08", 2.25f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fire08_02", 2, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Fire08_03", 2.75f, 0.7f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Fire08_04", 2.5f, 0.7f));
    }
    void Fire09()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire09", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire09_02", 1.1f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Fire09_03", 0f, 2.2f));
    }

    void Fire10()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Fire10", 0f, 1.1f));
    }
    void Water01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water01", 0f, 1.1f));
    }
    void Water02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water02", 0f, 0.8f));
    }
    void Water03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water03", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Water03_02", 0.3f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Water03_03", 0.5f, 1.1f));
    }
    void Water04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water04", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Water04_02", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Water04_03", 0f, 1.1f));
    }
    void Water05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water05", 0f, 1.1f));
    }
    void Water06()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water06", 0f, 1.6f));
    }
    void Water07()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water07", 0f, 1.1f));
    }
    void Water08()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water08", .25f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Water08_02", 0, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Water08_03", .75f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Water08_04", .5f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Water08", 1.25f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Water08_02", 1f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Water08_03", 1.75f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Water08_04", 1.5f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Water08", 2.25f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Water08_02", 2, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Water08_03", 2.75f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Water08_04", 2.5f, 0.5f));
    }
    void Water09()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water09", 0f, 2f));
    }
    void Water10()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Water10", 0f, 1.6f));
    }
    void Electricity01()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric01", 0f, 0.7f));
    }
    void Electricity02()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric02", 0.2f, 1.6f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Black", 0f, 1.8f));
    }
    void Electricity03()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric03", 0f, 0.6f));
    }
    void Electricity04()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric04", 0f, 1.1f));
    }
    void Electricity05()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric05", 0f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Electric05_02", 0.2f, 1.1f));
    }
    void Electricity06()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric06", 0f, 0.5f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Electric06_02", 0.2f, 0.5f));
    }
    void Electricity07()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric07", .25f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Electric07_02", 0, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Electric07_03", .75f, 1.1f));
        StartCoroutine(SkillCoroutine(EffectObj04, "Electric07_04", .5f, 1.1f));
    }
    void Electricity08()
    {
        StartCoroutine(SkillCoroutine(EffectObj01, "Electric08", 0, 1.6f));
    }
    void Electricity10()
    {
        StartCoroutine(SkillCoroutine(EffectObj04, "Electricity10_02", 0, 2f));
        StartCoroutine(SkillCoroutine(EffectObj02, "Electricity10", 1f, .5f));
        StartCoroutine(SkillCoroutine(EffectObj03, "Electricity10_03", 1.3f, .5f));
        StartCoroutine(SkillCoroutine(EffectObj01, "Electricity10_04", 1.5f, .5f));
    }

}
