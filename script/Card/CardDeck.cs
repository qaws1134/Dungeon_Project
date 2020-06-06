using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    //카드 리스트 선언
    public List<CardProperty> deck = new List<CardProperty>();
    public List<CardProperty> container = new List<CardProperty>();
    public static List<CardProperty> staticDeck = new List<CardProperty>();

    public int x;
    public static int deckSize;

    public GameObject CardToHand;
    public GameObject Deck;
    public GameObject Hand;


    //초기 덱 생성
    void Start()
    {
        x = 0;
        deckSize = 40;

        for (int i = 0; i < deckSize; i++)
        {
            //버퍼의 리스트만큼 랜덤으로 덱에 넣음
            x = Random.Range(0, 10); 
            deck[i] = CardBuffer.Card[x];
        } 

        StartCoroutine(StartGame());

    }
    //현재 덱 개수를 카운트
    void Update()
    {
        staticDeck = deck;
    }

    //드로우 코루틴
    IEnumerator StartGame()
    {
        for(int i = 0; i<=4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    //카드덱 셔플 알고리즘
    public void Shuffle()
    {
        for(int i = 0; i<deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        

    }

}
