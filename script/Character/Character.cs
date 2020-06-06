using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    protected float jumpForce;
    protected Vector2 direction;
    protected Animator ani;

    private Rigidbody2D RGD;
    private Rigidbody2D INRGD;

    protected bool isJumping = false;
    protected bool isAttacking = false;

    protected Coroutine AttackRoutine;
    protected Coroutine JumpRoutine;

    private bool ground;

    public enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2,
        JumpLayer = 3
    }

   public bool IsMoving
    {
        get
        {
            return direction.x!=0 || direction.y !=0;
        }
    }

   public  bool IsGround
    {
        get
        {
            ground = transform.GetChild(1).GetComponent<ground_check>().ground;
            return ground;
        }
    }

    protected virtual void Start()
    {
        RGD = GetComponent<Rigidbody2D>();     
        INRGD = transform.GetChild(0).GetComponent<Rigidbody2D>(); // Body에 있는 RGD에 접근  
        ani = transform.GetChild(0).GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleLayers();
    }
    private void FixedUpdate()
    {

        Move();
        stopJump();
    }
    public void Move()
    {
        if (direction.x > 0)
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        else if (direction.x < 0)
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;

        if (!IsGround)
        {
            RGD.transform.Translate(new Vector2(direction.x, direction.y / 2) * Time.deltaTime);      
        }
        else
        {
            RGD.transform.Translate(direction * Time.deltaTime);
        }
    }

    public void Jump()
    { 
        INRGD.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void stopJump()
    {
        ani.SetBool("jump", IsGround);
        isJumping = false;
    }
    //애니메이터 레이어 핸들
    private void HandleLayers()
    {
        if(IsMoving)
        {
            ActiveLayer(LayerName.WalkLayer); //walk
        }
        else if (isAttacking)
        {
            ActiveLayer(LayerName.AttackLayer); //attck
        }
        else if (isJumping)
        {
            ActiveLayer(LayerName.JumpLayer); //jump
        }
        else
        {
            ActiveLayer(LayerName.IdleLayer); //Idle
        }
    }

    //레이어 초기화
    public void ActiveLayer(LayerName layerName)
    {
        for(int i = 0; i<ani.layerCount; i++)
        {
            ani.SetLayerWeight(1, 0);
        }

        ani.SetLayerWeight((int)layerName, 1);
    }

    public void StopAttack()
    {
        if(AttackRoutine != null)
        {
            StopCoroutine(AttackRoutine);
            isAttacking = false;
            ani.SetBool("attack",isAttacking);
        }
    }
}
