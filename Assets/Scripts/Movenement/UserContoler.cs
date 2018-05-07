using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlayerControler))]
public class UserContoler : MonoBehaviour {

    private PlayerControler pc;
    private Animator anim;

     void Start()
    {
        pc = GetComponent<PlayerControler>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            pc.Jump();
        }
       
      
        {
            pc.Move(Input.GetAxis("Horizontal"));

        
        

        pc.CrouchControl(Input.GetKey(KeyCode.LeftControl));
        pc.Attack_Hero(Input.GetMouseButtonDown(0));
        pc.Slide(Input.GetKey(KeyCode.LeftShift));
      
	}
}
