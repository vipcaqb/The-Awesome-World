using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float speed;
    public float attackRange;
    public float hp;
    public GameObject destroyEffect;
    
    bool isRight = true;

    Transform player;
    Rigidbody2D r2;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update(){
        anim.SetFloat("Speed",speed);
        if(hp<= 0){
            DestroySlime();
        }
    }

    void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x-player.position.x)<attackRange){
            if(transform.position.x>player.position.x){
                r2.velocity = new Vector2(speed*Time.deltaTime*-1,r2.velocity.y);
            }
            else {
                r2.velocity = new Vector2(speed*Time.deltaTime,r2.velocity.y);
            }
        }
        if((isRight && r2.velocity.x>0)||(!isRight && r2.velocity.x<0)){
            Flip();
        }
    }

    void Flip(){
        isRight = !isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void DestroySlime(){
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage){
        hp-= damage;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Player must take damage");
        }
    }
}
