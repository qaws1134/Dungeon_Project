using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_check : MonoBehaviour
{
    public bool ground = true;


    private void OnCollisionEnter2D(Collision2D col)
    {
            ground = true;   
    }
    private void OnCollisionExit2D(Collision2D col)
    {
            ground = false;
    }
}
