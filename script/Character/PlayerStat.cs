using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{

    private Image content;  //Gage의 Image Component를 받을 공간

    [SerializeField]
    private Text statText;


    [SerializeField]
    private float lerpSpeed; 

    private float currentFill; 
    public float MyMaxValue { get; set; } 

    public float MyCurrentValue
    {
        get
        {
            return currentValue; //현재 fill 값을 가져옴
        }
        set
        {
            if (value > MyMaxValue)    //fill값이 최대 수치보다 넘을 경우 
                currentValue = MyMaxValue;
            else if (value < 0)        //fill값이 0보다 작을 경우
                currentValue = 0;
            else                      
                currentValue = value;

            currentFill = currentValue / MyMaxValue; //currentFill에 (현재값/전체값)을 넘겨줌
            statText.text = currentValue+ " / " + MyMaxValue;
        }
    }

    private float currentValue;

    void Start()
    {
        content = GetComponent<Image>();
    }

    void Update()
    {
        //Image의 fillAmount와 Gage 수치가 다를 경우 
        if(currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue; //맴버변수를통해 Gage의 최대 값을 넘겨줌
        MyCurrentValue = currentValue; //현재 값을 넘겨줌
    }
}
