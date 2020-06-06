using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCtrl : Character
{
    [SerializeField]
    private PlayerStat HP;
    [SerializeField]
    private PlayerStat MP;

    private Vector3 min, max;

    private float speed;
    private float initHP = 100;
    private float initMP = 50;
    float force;



    protected override void Start()
    {
        HP.Initialize(initHP, initHP);
        MP.Initialize(initMP, initMP);
        speed = 2f;
        base.Start();
    }

    protected override void Update()
    {

        GetInput();
        base.Update();
    }

    private void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        direction = moveVector * speed ;


        if(Input.GetKeyDown("a"))
        {
            if(!isAttacking)
            {
                AttackRoutine = StartCoroutine(Attack());
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (!isJumping&& IsGround)
            {
                isJumping = true;
                jumpForce = 3f;
                ani.SetBool("jump", isJumping);
                Jump();
                
            }
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        ani.SetBool("attack", isAttacking);

        yield return new WaitForSeconds(1f);
        
        StopAttack();
    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

}
