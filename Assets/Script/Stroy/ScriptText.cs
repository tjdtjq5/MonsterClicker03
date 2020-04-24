using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScriptText : MonoBehaviour
{
    public GameObject scriptObj;

    public Text script;
    List<string> tempStringList;
    string[] scripts;
    string[] names;
    int iCount;
    bool flag;
    IEnumerator ScriptControllCoroutine;

    public NextScene nextScene;
    public GameObject nextIcon;

    private void Start()
    {
        ScriptManager scriptManager = new ScriptManager(StageInfo.Stage);
        tempStringList = scriptManager.scripts;
        Script(tempStringList);
    }

    public void Script(List<string> scripts)
    {
        nextIcon.SetActive(false);

        this.scripts = new string[scripts.Count];
        this.names = new string[scripts.Count];
        for (int i = 0; i < tempStringList.Count; i++)
        {
            string[] tempString = tempStringList[i].Split('/');
            this.names[i] = tempString[0];
            this.scripts[i] = tempString[1];
        }

        this.script.text = "";
        ScriptControllCoroutine = ScriptCoroutine();
        StartCoroutine(ScriptControllCoroutine);
    }

    IEnumerator ScriptCoroutine()
    {

        yield return new WaitForSeconds(0.1f);
        if (iCount == 0)
            yield return new WaitForSeconds(0.5f);

        flag = true;
        char[] tempChar = scripts[iCount].ToCharArray();
        for (int i=0; i< scripts[iCount].Length; i++)
        {
            script.text += tempChar[i].ToString();
            yield return new WaitForSeconds(0.06f);
        }
        flag = false;
        nextIcon.SetActive(true);

        GetComponent<StroyCameraShaking>().Shaking();
        GetComponent<StroyCaracterSetting>().SetCaracter();
    }

    bool nextSceneFlag;
    public void TouchScreen()
    {
        if (!nextSceneFlag)
        {
            if (scripts.Length != 0)
            {
                if (flag)
                {
                    StopCoroutine(ScriptControllCoroutine);
                    script.text = scripts[iCount];
                    nextIcon.SetActive(true);
                    flag = false;

                    GetComponent<StroyCameraShaking>().Shaking();
                    GetComponent<StroyCaracterSetting>().SetCaracter();
                }
                else
                {
                    if (scripts.Length <= iCount + 1)
                    {
                        Debug.Log("다음씬");
                        nextSceneFlag = true;
                        nextScene.OnNextScene();
                    }
                    else
                    {
                        scriptObj.GetComponent<AudioSource>().Play();

                        StopCoroutine(ScriptControllCoroutine);
                        iCount++;
                        Script(tempStringList);
                    }
                }
            }
        }
    
    }
}
