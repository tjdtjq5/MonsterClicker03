using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MyTime : MonoBehaviour
{
    public string url = "";
    string hour;
    string minute;
    string second;

    public Text time;
    public SpeechBubble speechBubble;

    void Start()
    {
        RealTimeUpdate();
    }

    public void Stopwatch()
    {
        StartCoroutine(StopwatchCoroutine());
    }

    public void RealTimeUpdate()
    {
        StartCoroutine(RealTimeCoroutine());
        Invoke("RealTimeUpdate", 10);
    }

    IEnumerator StopwatchCoroutine()
    {
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");

                DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
                TimeSpan timestamp = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

                int stopwatch = (int)timestamp.TotalSeconds - PlayerPrefs.GetInt("net", (int)timestamp.TotalSeconds);

                PlayerPrefs.SetInt("net", (int)timestamp.TotalSeconds);
            }
        }
    }

    bool clockFlag;
    IEnumerator RealTimeCoroutine()
    {
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");
                DateTime dateTime = DateTime.Parse(date);
                hour = dateTime.Hour.ToString();
                minute = dateTime.Minute.ToString();
                second = dateTime.Second.ToString();

                string AP = "AM";
                if(dateTime.Hour > 12)
                {
                    hour = (dateTime.Hour - 12).ToString();
                    AP = "PM";
                }

                if (minute.Length > 1)
                {
                    time.text = hour + ":" + minute + " " + AP;
                }
                else
                {
                    time.text = hour + ":0" + minute + " " + AP;
                }

                if (minute == "0" && !clockFlag)
                {
                    clockFlag = true;
                    speechBubble.SpeechInput(hour + "시 입니다.");
                }
                if(minute != "0")
                {
                    clockFlag = false;
                }
            }
        }
    }
}
