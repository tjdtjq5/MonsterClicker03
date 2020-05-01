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
                            scripts.Add("연희/예빈아, 안녕?");
                            scripts.Add("예빈/... ...");
                            scripts.Add("연희/예빈아?");
                            scripts.Add("예빈/... ...");
                            scripts.Add("연희/예! 빈! 아!");
                            scripts.Add("예빈/어? 어어! 연희야 무슨 일이야?");
                            scripts.Add("연희/혹시 나랑 대결한번 하지 않을래?");
                            scripts.Add("예빈/지, 지금?");
                            scripts.Add("연희/응! 근데 왜 호진이를 그렇게 쳐다보고 있어?");
                            scripts.Add("예빈/야아! 쉿! 조용히 해!");
                            scripts.Add("연희/뭐야 뭐야~ 둘이 무슨 사이야!");
                            scripts.Add("예빈/아무 사이도 아니야!");
                            scripts.Add("예빈/그냥 전해 줄게 있는데… 못 하구 있어…");
                            scripts.Add("연희/그게 뭐야?");
                            scripts.Add("예빈/이거… 귤!");
                            scripts.Add("연희/귤?");
                            scripts.Add("예빈/응… 그냥 맛있어 보여서! 좋아하지 않을까 해서…");
                            scripts.Add("예빈/대결해 줄 테니, 이 귤을 호진이에게 전해주지 않을래?");
                            scripts.Add("연희/좋아! 자, 그럼 시작해 볼까?");
                            break;
                        case 3:
                            scripts.Add("연희/호진아!");
                            scripts.Add("호진/어? 무슨 일이야?");
                            scripts.Add("연희/자! 이거!");
                            scripts.Add("호진/귤? 갑자기 왠 귤이야?");
                            scripts.Add("연희/아 이거! 저기 예…");
                            scripts.Add("예빈/(찌릿)");
                            scripts.Add("연희/어 그… 그런게 있어!");
                            scripts.Add("호진/뭐야! 말해줘! 누가 준거야!");
                            scripts.Add("연희/나랑 펫 대결을 해서 이긴다면 알려 줄게!");
                            scripts.Add("호진/대결…? 뭐야 약해 보이는데?");
                            scripts.Add("연희/우리 토리는 벌써 2승이라구!");
                            scripts.Add("연희/자! 시작이다!");
                            break;
                        case 4:
                            scripts.Add("데니스 킴/Hello, my student!");
                            scripts.Add("연희/선생님 안녕하세요!");
                            scripts.Add("데니스 킴/Oh~! 이 펫은?");
                            scripts.Add("데니스 킴/연희의 new 펫인가요?");
                            scripts.Add("연희/네 선생님! 토리라고 해요!");
                            scripts.Add("데니스 킴/So Cute~!");
                            scripts.Add("데니스 킴/우리 CoBongEe와 친하게 지내 보렴, ToRi~");
                            scripts.Add("데니스 킴/한번 쓰다듬어 볼까요?");
                            scripts.Add("토리/(앙!)");
                            scripts.Add("데니스 킴/Ouch! 지금 저를 문거에요?");
                            scripts.Add("데니스 킴/안 되겠어요, 버릇을 고쳐야 겠어요!");
                            scripts.Add("연희/네???");
                            scripts.Add("데니스 킴/대결입니다! 자 Ready~!");
                            scripts.Add("데니스 킴/Start!");
                            break;
                        case 5:
                            scripts.Add("데니스 킴/Hello, my student!");
                            scripts.Add("연희/선생님 안녕하세요!");
                            scripts.Add("데니스 킴/Oh~! 이 펫은?");
                            scripts.Add("데니스 킴/연희의 new 펫인가요?");
                            scripts.Add("연희/네 선생님! 토리라고 해요!");
                            scripts.Add("데니스 킴/So Cute~!");
                            scripts.Add("데니스 킴/우리 CoBongEe와 친하게 지내 보렴, ToRi~");
                            scripts.Add("데니스 킴/한번 쓰다듬어 볼까요?");
                            scripts.Add("토리/(앙!)");
                            scripts.Add("데니스 킴/Ouch! 지금 저를 문거에요?");
                            scripts.Add("데니스 킴/안 되겠어요, 버릇을 고쳐야 겠어요!");
                            scripts.Add("연희/네???");
                            scripts.Add("데니스 킴/대결입니다! 자 Ready~!");
                            scripts.Add("데니스 킴/Start!");
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
                            if (isWin)
                            {
                                scripts.Add("연희/와! 내가 이겼어!");
                                scripts.Add("예빈/내가 집중을 못해서 그래…");
                                scripts.Add("예빈/... ...");
                                scripts.Add("예빈/약속은 꼭 지켜줘…");
                            }
                            else
                            {
                                scripts.Add("예빈/... ...");
                                scripts.Add("예빈/그래도 이 귤은…");
                                scripts.Add("연희/... ...");
                            }
                            break;
                        case 3:
                            if (isWin)
                            {
                                scripts.Add("연희/이것 봐! 우리 토리 강하지?");
                                scripts.Add("연희/약해 보인다고 깔보지 마시라~!");
                                scripts.Add("호진/그나저나 이 귤은 누가… 왜 준 거지?");
                                scripts.Add("예빈/(찌릿)");
                                scripts.Add("연희/다... 다음에 봐!");
                            }
                            else
                            {
                                scripts.Add("호진/이것 봐! 약하구만!");
                                scripts.Add("호진/자, 이제 말해줘!");
                                scripts.Add("예빈/(찌릿)");
                                scripts.Add("연희/아… 안돼…!");
                            }
                            break;
                        case 4:
                            if (isWin)
                            {
                                scripts.Add("데니스 킴/Oh no~!");
                                scripts.Add("데니스 킴/토리가 생각보다 Strong 하군요!");
                                scripts.Add("데니스 킴/좋아요! Forgive 해주겠어요.");
                                scripts.Add("연희/죄송합니다 선생님~");
                                scripts.Add("연희/이리와 토리!");
                            }
                            else
                            {
                                scripts.Add("데니스 킴/Wonderful 코봉이~ Wonderful!");
                                scripts.Add("연희/... ...");
                            }
                            break;
                        case 5:
                            if (isWin)
                            {
                                scripts.Add("데니스 킴/Oh no~!");
                                scripts.Add("데니스 킴/토리가 생각보다 Strong 하군요!");
                                scripts.Add("데니스 킴/좋아요! Forgive 해주겠어요.");
                                scripts.Add("연희/죄송합니다 선생님~");
                                scripts.Add("연희/이리와 토리!");
                            }
                            else
                            {
                                scripts.Add("데니스 킴/Wonderful 코봉이~ Wonderful!");
                                scripts.Add("연희/... ...");
                            }
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
