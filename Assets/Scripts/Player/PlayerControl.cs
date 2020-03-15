using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    bool grounded = false;
    bool isRight = true;

    Rigidbody2D r2;
    Animator anim;
    Transform gun;

    // Start is called before the first frame update
    void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gun = GameObject.Find("Gun").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed",Mathf.Abs(r2.velocity.x));
    }

    void FixedUpdate(){
        //Moving left and right
        float h = Input.GetAxisRaw("Horizontal");
        r2.velocity = new Vector2(h*speed,r2.velocity.y);

        //Jump
        if(grounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                r2.AddForce(new Vector3(0f,jumpForce,0f));
            }
        }
        //Set scale correct
        if((h>0 && !isRight)|| (h<0 && isRight)){
            Flip();
        }
    }

    void Flip(){
        isRight = !isRight;
        Vector3 scale = gameObject.transform.localScale;
        scale.x  *= -1;
        gameObject.transform.localScale = scale;

        //change gun's direction to correctly 
        Vector3 temp = gun.transform.localScale;
        temp.x *= -1;
        gun.transform.localScale = temp;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }
}
