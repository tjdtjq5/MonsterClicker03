using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpeechBubble : MonoBehaviour
{
    public GameObject speechBubble;
    public AudioClip messageSound;
    public Image character;
    public Sprite nomalImage;
    public Sprite smailImage;
    Text speech;
    Animator ui_ani;

    string[] tempSpeechs;
    bool flag;
    bool touchFlag;
    int iCount;
    int tempCount;

    private void Start()
    {
        speech = speechBubble.transform.GetChild(0).GetComponent<Text>();
        ui_ani = speechBubble.GetComponent<Animator>();
        speechBubble.SetActive(false);

    }

    Sequence mySequence;
    public void SpeechInput(string text, bool smile = false)
    {
        if (!touchFlag)
        {
            if (smile)
                character.sprite = smailImage;

            this.GetComponent<AudioSource>().clip = messageSound;
            this.GetComponent<AudioSource>().Play();
            speech.text = "";
            tempSpeechs = text.Split('/');
            flag = true;
            touchFlag = true;
            speechBubble.SetActive(true);
            ui_ani.SetTrigger("True");
            mySequence.Append(speech.DOText(tempSpeechs[iCount], 1.5f).OnComplete(() => flag = false));
            iCount++;
            tempCount = iCount;
            Invoke("NextCount", 4f);
        }
        else
        {
            StartCoroutine(SpeechInputCoroutine(text, 10f));
        }
    }

    private void Update()
    {
        if(touchFlag == true && flag == false && Input.GetMouseButtonDown(0))
        {
            Next();
          
        }
    }

   
    void Next()
    {
        if (tempSpeechs.Length == iCount)
        {
            character.sprite = nomalImage;
            ui_ani.SetTrigger("False");
            iCount = 0;
            touchFlag = false;
            mySequence.Kill();
            StartCoroutine(FalseCoroutine());
        }

        if (iCount != 0)
        {
            this.GetComponent<AudioSource>().clip = messageSound;
            this.GetComponent<AudioSource>().Play();
            speech.text = "";
            flag = true;
            speechBubble.SetActive(true);
            ui_ani.SetTrigger("True");
            mySequence.Append(speech.DOText(tempSpeechs[iCount], 1.5f).OnComplete(() => flag = false));
            iCount++;
            tempCount = iCount;
            Invoke("NextCount", 4f);
        }
    }

    void NextCount()
    {
        if(iCount == tempCount && touchFlag == true && flag == false)
        {
            Next();
        }
    }

    

    IEnumerator SpeechInputCoroutine(string text, float time)
    {
        yield return new WaitForSeconds(time);
        SpeechInput(text);
    }

    IEnumerator FalseCoroutine()
    {
        yield return new WaitForSeconds(.6f);
        speechBubble.SetActive(false);
    }
}
