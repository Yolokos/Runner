using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour {

    public float runSpeed = 6f;
    public float jumpForce = 5f;
    public Transform cirTarget;
    public float radCir = 0.6f;
    private bool isCrouch = false;
    private bool slide = false;
    public float koefCrounch = 0.6f;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator at;

     void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        bc = GetComponent<BoxCollider2D>();
        at = GetComponent<Animator>();
    }

     bool IsGround()
    {
       Collider2D[] gh = Physics2D.OverlapCircleAll(cirTarget.position,radCir);
        int j = 0;
        for(int i = 0; i < gh.Length; i++)
        {
            if(gh[i].gameObject != gameObject)
            {
                j++;
            }
           
        }
        return j > 0;

    }

    public void Attack_Hero(bool attack)
    {

        if (attack)
        {
          
            at.SetTrigger("attack");
            rb.velocity = Vector2.zero;
            
           
        }
    }

    public void CrouchControl(bool isNado)
    {
        if(isNado && !isCrouch)
        {
            isCrouch = true;
            bc.offset = new Vector2(bc.offset.x, bc.offset.y - bc.size.y * (1 - koefCrounch) / 2);
            bc.size = new Vector2(bc.size.x, koefCrounch * bc.size.y);
           
        }
        else if(!isNado && isCrouch)
        {
            isCrouch = false;
            bc.offset = new Vector2(bc.offset.x, bc.offset.y + (bc.size.y/koefCrounch - bc.size.y) / 2);
            bc.size = new Vector2(bc.size.x,  bc.size.y/ koefCrounch);
        }
    }

    public void Jump()
    {

        if (IsGround()) 
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        

    }

    public void Move(float ax)
    {
        Vector3 direction = transform.right * ax;
        if (!at.GetBool("slide") && !at.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + direction,
                                               runSpeed * Time.deltaTime);
        }
       

        
            if ((ax > 0 && transform.localScale.x < 0) || (ax < 0 && transform.localScale.x > 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,
                                                    transform.localScale.z);
            }

        
        at.SetFloat("speed", Mathf.Abs(ax));
    }

    public void Slide(bool value)
    {
        
        if (value && !at.GetCurrentAnimatorStateInfo(0).IsName("Slide") && IsGround())
        {
            at.SetBool("slide", true);
        }
        if (!value && at.GetCurrentAnimatorStateInfo(0).IsName("Slide") && IsGround())
        {
            at.SetBool("slide", false);
        }
    }


    public void ResetValues()
    {
        Attack_Hero(false);
    }
}
