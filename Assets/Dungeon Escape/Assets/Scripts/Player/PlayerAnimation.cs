using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = transform.GetChild(0).GetComponent<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

   public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    } 

    public void Jump(bool jump)
    {
        _anim.SetBool("Jump", jump);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
