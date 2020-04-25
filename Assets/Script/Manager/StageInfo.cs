using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    static public Vector2 Stage;
    static public bool isEnd;
    static public bool isWin;

    public static void SetStageInfo(string stage) // 1/1/false/false
    {
        if (stage == "")
            return;

        string[] tempStageString = stage.Split('/');
        Stage = new Vector2(int.Parse(tempStageString[0]), int.Parse(tempStageString[1]));
        isEnd = bool.Parse(tempStageString[2]);
        isWin = bool.Parse(tempStageString[3]);
    }

   
}
