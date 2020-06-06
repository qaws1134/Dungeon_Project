using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    //포인터가 해당 존에 들어왔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        //이벤트가 없으면 리턴
        if (eventData.pointerDrag == null)
            return;
        //이벤트가 있으면 해당 이벤트의 부모 오브젝트를 드래그존으로 바꿈
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }
    //포인터가 나갈 때
    public void OnPointerExit(PointerEventData eventData)
    {
        
        //이벤트가 없으면 리턴
        if (eventData.pointerDrag == null)
            return;

        //이벤트가 있으면 다시 이벤트가 가지고 있는 (부모 오브젝트의 위치) 기존 변수로 변경
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
        
    }

    //포인터를 내려놨을 때
    public void OnDrop(PointerEventData eventData)
    {
        //이벤트의 해당 변수를 현재 위치로 변경
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

}
