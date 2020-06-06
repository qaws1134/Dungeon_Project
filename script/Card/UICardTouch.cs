using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//각 카드에 들어가서 터치 컨트롤을 할 스크립트
//이미지는 슬롯에서 컨트롤?
public class UICardTouch : MonoBehaviour, IPointerUpHandler
{

    public Image img;
    public GameObject Card;  //카드 위치 넣어줌

    private RectTransform CartP;

    private bool btnup = false;

    //기존 위치
    private float initRotation;
    private Vector3 initscale;
    private Vector3 initposition;


    public void OnPointerUp(PointerEventData eventData)
    {
        btnup = true;
    }
    
    private void OnMouseUP()
    {
       
        CartP.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnMouseExit()
    {
        //원래대로
    }

    private void OnMouseDown()
    {
        //현재 포인트로 이동 현재 커서로 이동
    }
    private void OnMouseDrag()
    {
        //현재 포인트로 이동
    }
    private void OnMouseUp()
    {
        //위치가 사용하는 위치면 카드 사용 애니메이션 실행
        //아니면 천천히 원위치로 돌아감-> Lerp
    }


    // Start is called before the first frame update
    void Start()
    {
        CartP = Card.GetComponent<RectTransform>();
        initRotation = CartP.rotation.z;
        initposition = CartP.position;
        initscale = CartP.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(btnup)
        {
            Debug.Log("1");
            OnMouseUP();
        }
    }
}
