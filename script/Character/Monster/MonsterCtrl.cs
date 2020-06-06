using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{

    private Transform target;
    private float speed = 1;


    public Transform Target
    {
        get 
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();


    }



    private void FollowTarget()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 myPosition = transform.position;

            transform.position = Vector2.MoveTowards(myPosition, targetPosition, speed * Time.deltaTime);
        }
    }




}
