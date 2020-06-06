using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    /*시작 덱이 있음
     * 랜덤하게 뽑음
     * 사용 시 소모품과 일회용 카드를 제외하고는 남아있음 사용리스트로 감
     * 마지막 카드를 뽑았을 때 -> 패의 개수가 최대고 덱 리스트가 없을 때
     * 사용 리스트를 랜덤하게 덱 리스트에 집어넣음
     * 몬스터를 잡거나 기물 파괴시 확률적으로 
     * 스텟카드(장비대신),소모품카드,스킬카드
     * 레벨업 시 스텟, 소모품, 스킬 중 선택하여 랜덤카드 획득
     * 리스트로 덱 리스트, 패 리스트 생성
     * 카드를 먹을 시 패에 카드가 x개 이하면 패에도 가져옴 
     * 스크립트 구성은 아이템 상점을 참고하여 만들자
     * 
     * 
     */

      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
