using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


//카메라 영역설정
public class MapCtrl : MonoBehaviour
{

    private Transform target;

    float xMax, xMin, yMax, yMin;

    [SerializeField]
    Tilemap tilemap;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
