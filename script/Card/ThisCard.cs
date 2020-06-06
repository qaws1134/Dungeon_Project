using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThisCard : MonoBehaviour
{


    public List<CardProperty> thisCard = new List<CardProperty>();
    public int thisId= 0;


    public int cardID = 0;
    public string cardName = "";
    public string cardDescription = "";

    public int cost = 0;

    public float dmg = 0;  // 공격력
    public Sprite CardSprite;
    public Sprite BackSprite;
    /*
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
    public float recoverHp = 0;  // 체력회복
    public float recoverMp = 0;  // 마나회복
    */

    public Image CardImage;
    public Image BackImage;
    // public Image spImage;
    public Text Cost;
    public Text DMG_or_restore;
    public Text Cardinfo;
    public int numberOfCardsInDeck;


    public GameObject DropZone;



    void Start()
    {
        //인덱스와 아이디에 맞는 카드를 가져옴
        thisCard[0] = CardBuffer.Card[thisId];
        numberOfCardsInDeck = CardDeck.deckSize;

    }
 

 
    void Update()
    {
        //가져온 속성들을 카드에 표시 
        cardID = thisCard[0].cardID;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;
        cost = thisCard[0].cost;
        dmg = thisCard[0].dmg;

        CardSprite = thisCard[0].CardSprite;
        BackSprite = thisCard[0].BackSprite;

        Cost.text = "" + cost;
        DMG_or_restore.text = "" + dmg;
        Cardinfo.text = "" + cardDescription;
        CardImage.sprite = CardSprite;
        BackImage.sprite = BackSprite;

        
        //덱에서 카드를 가져오면 static으로 카운팅 후 덱 사이즈를 줄임
        if (this.tag == "Clone")
        {
            thisCard[0] = CardDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            CardDeck.deckSize -= 1;
            this.tag = "Untagged";
        }
        DropZone = GameObject.Find("DropZone");
        /*
        if (this.transform.parent == DropZone.transform)
        {
            Destroy(gameObject);
        }
        */
   }
    private void OnDestroy()
    {
        //effect
    }


}
