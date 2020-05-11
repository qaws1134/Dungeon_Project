using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCtrl : MonoBehaviour
{

    [SerializeField] float Xspeed = 3f;
    [SerializeField] float Yspeed = 3f;
    [SerializeField] float jumpForce = 6.0f;

    [SerializeField] private PlayerStat health;
    [SerializeField]private PlayerStat mana;

    private float initHealth = 100;
    private float initMana = 50;

    private Animator P_Animator;//플레이어 애니메이터
    private Rigidbody2D P_body; //플레이어 몸체
    private Rigidbody2D P_all;  //플레이어 전체

    private bool m_isDead = false;
    private bool m_grounded = false;
    private bool m_combatIdle = false;

    private float Yinitspeed;  //점프 시 기존 y이동속도를 저장

    void Start()
    {
        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);
        Yinitspeed = this.Yspeed;           
        P_Animator = GetComponent<Animator>();
        P_all = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        P_body = GameObject.Find("Body").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        this.Yspeed = Yinitspeed;
        m_grounded = true;
        P_Animator.SetBool("Grounded", m_grounded);
    }
  
    //점프 시 속도 반감
    private void OnCollisionExit2D(Collision2D collision)
    {
        Yinitspeed = this.Yspeed;
        this.Yspeed /= 2;
    }


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        GameObject Camera = GameObject.Find("Camera");

        if (inputX > 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (inputX < 0)
            GetComponent<SpriteRenderer>().flipX = false;

        P_all.transform.Translate(new Vector2(inputX * Xspeed, inputY * Yspeed)*Time.deltaTime);
        Camera.transform.Translate(new Vector2(inputX * Xspeed, inputY * Yspeed)* Time.deltaTime); //카메라 이동


        //게이지 up down
        if (Input.GetKeyDown("p"))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown("l"))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        // -- Handle Animations --
        //Death

        if (Input.GetKeyDown("e"))
        {
            if (!m_isDead)
                P_Animator.SetTrigger("Death");
            else
                P_Animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            P_Animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0))
        {
            P_Animator.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space")&& m_grounded)
        {
            P_Animator.SetTrigger("Jump");
            m_grounded = false;
            P_Animator.SetBool("Grounded", m_grounded);
            P_body.velocity = new Vector2(P_body.velocity.x, jumpForce);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon|| Mathf.Abs(inputY) > Mathf.Epsilon)
            P_Animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            P_Animator.SetInteger("AnimState", 1);

        //Idle
        else
            P_Animator.SetInteger("AnimState", 0);
    }
}
