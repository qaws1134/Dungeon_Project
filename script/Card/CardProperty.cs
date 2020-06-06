using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CardProperty
{
    public Sprite CardSprite;
    public Sprite BackSprite;
    // itemID 1001 ~ 2000 스텟 카드 (이동속도, 마나 리젠, 공격력, 최대체력, 최대마나, 방어력)   
    // itemID 2001 ~ 3000 스킬 카드 (데미지, 넉백정도, 에어리얼 정도, )
    // itemID 3001 ~ 4000 소모품 카드 (hp회복, mp회복까지만 )

    public int cardID = 0;
    public string cardName = "";
    public string cardDescription = "";

    public int cost = 0;

    // 스텟
    public float TrueDmg = 0; // 고정 공격력
    public float maxHpUp = 0;  // 최대 체력
    public float maxMpUp = 0;  // 최대 마나
    public float regenMp = 0;  // 마나 회복
    public float Armor = 0;  // 방어력
    public float moveSpeed = 0;  // 이동속도
    //스킬
    public float dmg = 0;  // 공격력
    public float knuckback = 0;  // 넉백정도
    public float aerial = 0;  // 에어리얼 정도
    // 소비형
    public bool recoverHp = false;  // 체력회복
    public bool recoverMp = false;  // 마나회복
    
    public CardProperty(int _cardID, string _cardName = "", string _cardDes = "", int _cost = 0,
        float _TrueDmg = 0, float _maxHpUp = 0, float _maxMpUp = 0, float _regenMp = 0, float _moveSpeed = 0, float _Armor = 0,
        float _knuckback = 0, float _dmg = 0, float _aerial = 0,
        bool _recoverHp = false, bool _recoverMp = false,
        Sprite _CardSprite = null,Sprite _BackSprite=null)
    {      
        cardID = _cardID;
        cardName = _cardName;
        cardDescription = _cardDes;

        cost = _cost;

        TrueDmg = _TrueDmg;
        maxHpUp = _maxHpUp;
        maxMpUp = _maxMpUp;
        regenMp = _regenMp;
        Armor = _Armor;
        moveSpeed = _moveSpeed;

        knuckback = _knuckback;
        dmg = _dmg;
        aerial = _aerial;

        recoverHp = _recoverHp;
        recoverMp = _recoverMp;


        CardSprite = _CardSprite;// 이미지 호출
        BackSprite = _BackSprite;
    }
}
