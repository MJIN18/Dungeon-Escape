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

    public virtual void Init()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        else
        {
            Movement();
        }
        if (transform.position == target.position)
        {
            anim.SetTrigger("Idle");
        }
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            target = pointB;
            spriteRenderer.flipX = false;
        }
        else if (transform.position == pointB.position)
        {
            target = pointA;
            spriteRenderer.flipX = true;
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
