using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //카드 이동 시 아래있는 오브젝트의 판단 
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    //드래그하는 카드를  임시로 저장할 오브젝트
    GameObject placeholder = null;

    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        //클릭한 오브젝트를 임시로 저장 
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);

        //레이아웃 유지
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        //현재 위치의 하이어아키 인덱스를 가져옴
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        //현재 위치를 저장
        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        //레이케스트 판단을 끔
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //드래그 도중
    public void OnDrag(PointerEventData eventData)
    {
        //현재 위치를 드래그 위치로
        this.transform.position = eventData.position;

        //현재위치에 있는 부모 오브젝트로 부모 오브젝트를 바꿔줌
        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        //현재 위치의 인덱스를 가져올 변수 
        int newSiblingIndex = placeholderParent.childCount;

        for(int i = 0; i<placeholderParent.childCount; i++)
        {
            //x위치를 비교해서 해당 인덱스에 넣어주기 위해 newSiblingIndex값을 정해줌 -> 패에 다시 돌릴때
            if(this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        //들고 있는 오브젝트를 해당 인덱스에 넣어줌 
        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    //드래그 종료
    public void OnEndDrag(PointerEventData eventData)
    {
        //현재 위치로 부모 설정, 인덱스 설정 후 오브젝트 이동
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = false ;

        //해당 오브젝트 제거
        Destroy(placeholder);
    }
}
