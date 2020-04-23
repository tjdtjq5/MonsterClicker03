using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public List<string> scripts;
    public ScriptManager(Vector2 stage, bool isEnd = false, bool isWin = false)
    {
        scripts = new List<string>();
        if (!isEnd)
        {
            switch ((int)stage.x)
            {
                case 1:
                    switch ((int)stage.y)
                    {
                        case 1:
                            scripts.Add("미소/야! 뭔데! 니 언제 펫 생겼는데?!");
                            scripts.Add("연희/토리라고 해. 귀엽지?");
                            scripts.Add("미소/야 그래도 우리 다람이가 최고지! \n아, 맞다! 니 그 얘기 들었나?");
                            scripts.Add("연희/무슨 이야기?");
                            scripts.Add("미소/어린이 대공원에서 강한 펫을 선발하는 대회가 열린다꼬 하네?");
                            scripts.Add("연희/와 진짜? 우리도 참가해 보자!");
                            scripts.Add("미소/아이고야 연희야, 내가 말 안했나! ‘강한’ 펫을 선발한다고!");
                            scripts.Add("연희/그러니까! 그냥 참가에 의미를 두는 거지!");
                            scripts.Add("미소/음... 그라믄 내랑 대결 함 해 볼래?");
                            scripts.Add("연희/지금? 우리 토리는 대결과는 거리가 먼데…");
                            scripts.Add("미소/자! 책상 붙이라!");
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;

                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        if (isEnd)
        {
            switch ((int)stage.x)
            {
                case 1:
                    switch ((int)stage.y)
                    {
                        case 1:
                            if (isWin)
                            {
                                scripts.Add("미소/니 쫌 하네?");
                                scripts.Add("연희/와 나 처음 해본거야! 우리 토리 대단한데?! \n다람이도 수고했어!");
                                scripts.Add("미소/야! 사실 다람이도 대결 몇 번 안 해봤다!\n니 그럼 쟤는 이길 수 있겠나 ?");
                                scripts.Add("연희/누구?");
                                scripts.Add("미소/쟤가 펫 대회도 여러 번 나간 경험자다 아이가! 함 해봐라!");
                            }
                            else
                            {
                                scripts.Add("미소/아이고 연희야!\n닌 진짜 공부나 열심히 해라!");
                                scripts.Add("연희/... ...");
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;

                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
     
    }
}
