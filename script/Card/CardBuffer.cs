using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuffer : MonoBehaviour
{

    public static List<CardProperty> Card = new List<CardProperty>();

    /*
    * 아이디, 이름, 설명, 코스트, 
    * 트루데미지,최대체력, 최대마나, 마나회복, 이동속도, 아머
    * 공격력, 넉백, 에어리얼정도
    * 체력회복,마나회복
    * 스킬이미지, 프레임이미지
    */

    void Awake()
    {
        Card.Add(new CardProperty(0, "DMG UP", "고정데미지 증가", 0, 
            1, 0, 0, 0, 0, 0,
            0,0,0,
            false, false,
            Resources.Load<Sprite>("1001"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(1, "MAXHP UP", "최대체력 증가", 0, 
            0, 10, 0, 0, 0, 0,
            0,0,0, 
            false, false,
            Resources.Load<Sprite>("1002"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(2, "MAXMP UP", "최대마나 증가", 0, 
            0, 0, 5, 0, 0, 0,
            0,0,0, 
            false, false,
            Resources.Load<Sprite>("1003"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(3, "MP REGEN UP", "마나회복 증가", 0,
            0, 0, 0, 1, 0, 0,
            0,0,0, 
            false, false,
            Resources.Load<Sprite>("1004"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(4, "MOVE SPEED UP", "이동속도 증가", 0, 
            0, 0, 0, 0, 1, 0,
            0,0,0, 
            false, false,
            Resources.Load<Sprite>("1005"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(5, "ARMOR UP", "방어력 증가", 0, 
            0, 0, 0, 0, 0, 1,
            0,0,0, 
            false, false,
            Resources.Load<Sprite>("1006"), Resources.Load<Sprite>("10")));

        Card.Add(new CardProperty(6, "slash", "전방 배기", 0,
            0, 0, 0, 10, 0, 0, 
            0, 1, 0,
            false, false,
            Resources.Load<Sprite>("2001"), Resources.Load<Sprite>("11")));

        Card.Add(new CardProperty(7, "upper", "띄우기", 0,
            0, 0, 0, 10, 0, 0, 
            0, 1, 0,
            false, false,
            Resources.Load<Sprite>("2002"), Resources.Load<Sprite>("11")));

        Card.Add(new CardProperty(8, "fire", "파이어볼",0,
            0,0,0,10,0,0,
            0, 1, 0, 
            false, false,
            Resources.Load<Sprite>("2003"), Resources.Load<Sprite>("11")));

        Card.Add(new CardProperty(9, "HP potion", "체력회복 포션", 0,
            0,0,0,0,0,0,
            0,0,0, 
            true, false,
            Resources.Load<Sprite>("3001"), Resources.Load<Sprite>("12")));

        Card.Add(new CardProperty(10, "MP potion", "마나회복 포션", 0,
            0,0,0,0,0,0, 
            0,0,0, 
            false, true,
            Resources.Load<Sprite>("3002"), Resources.Load<Sprite>("12")));
    }
}
