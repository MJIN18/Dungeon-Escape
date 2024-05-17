using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    

    protected Transform target;
    protected SpriteRenderer spriteRenderer;
    protected Animator anim;

    protected bool isHit;
    protected bool isDead = false;

    protected PlayerController _player;
    public virtual void Init()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        else if(!isDead)
        {
            Movement();
        }
        
    }

    public virtual void Movement()
    {
        if (transform.position == pointA.position)
        {
            target = pointB;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            target = pointA;
            anim.SetTrigger("Idle");

        }

        //if (transform.position == target.position)
        //{
            
        //}

        if (target.position == pointA.position)
        {
            spriteRenderer.flipX = true;
        }
        else if (target.position == pointB.position)
        {
            spriteRenderer.flipX = false;
        }
        if (isHit == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        float distance = Vector3.Distance(transform.localPosition, _player.transform.localPosition);
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = _player.transform.position - transform.position;

        if (anim.GetBool("InCombat"))
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
