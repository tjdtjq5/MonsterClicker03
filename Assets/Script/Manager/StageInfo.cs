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

    public void SetStageInfo(string stage)
    {
        string[] tempStageString = stage.Split('-');
        Stage = new Vector2(int.Parse(tempStageString[0]), int.Parse(tempStageString[1]));
    }

   
}
