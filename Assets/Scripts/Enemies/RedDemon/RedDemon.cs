using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDemon : MonoBehaviour
{
    public float maxHp;
    public float speed;
    public float damage;
    public float attackRange;
    public float followPlayerRange;
    public float startTimeBtwAttack;
    public GameObject redDemonProjectile;
    public GameObject shotPoint;
    public GameObject redDemonDestroyEffect;

    float hp;
    float timeBtwAttack;
    bool isRight;
    float distancePlayer;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        isRight = false;
        player = GameObject.Find("Player");
        timeBtwAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check player in attack range
        distancePlayer = Vector2.Distance(transform.position,player.transform.position);
        if(distancePlayer<= attackRange){
            if(timeBtwAttack<= 0){
                //Attack player.
                Instantiate(redDemonProjectile,shotPoint.transform.position,Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else if(distancePlayer <= followPlayerRange){
            //Follow player.
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
        }

        if(timeBtwAttack >0){
            timeBtwAttack -= Time.deltaTime;
        }
        FixDirection();

        if(hp <= 0){
            Dead();
        }
    }

    void Dead(){
        Instantiate(redDemonDestroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    void FixDirection(){
        if((isRight && transform.position.x > player.transform.position.x)||(!isRight && transform.position.x < player.transform.position.x)){
            Flip();
        }
    }

    void Flip(){
        isRight = !isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage(float damage){
        hp -= damage;
    }
}
