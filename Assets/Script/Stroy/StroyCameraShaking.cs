using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StroyCameraShaking : MonoBehaviour
{
    [Header("오브젝트 쉐이킹")]
    public GameObject shaking_obj;
    [Header("스크립트 텍스트")]
    public Text text;

    public string[] shaking_texts;

    public void Shaking()
    {
        string tempText = text.text;
        for (int i = 0; i < shaking_texts.Length; i++)
        {
            if (shaking_texts[i] == tempText)
            {
                StartCoroutine(Shake(shaking_obj, 50, 0.5f));
            }
        }
    }

   

    public IEnumerator Shake(GameObject obj,float _amount, float _duration)
    {
        Vector3 originPos = obj.transform.position;
        float timer = 0;
        while (timer <= _duration)
        {
            obj.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        obj.transform.localPosition = originPos;

    }
}
