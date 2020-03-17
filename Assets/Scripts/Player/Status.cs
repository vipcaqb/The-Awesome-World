using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public float hp;
    public float startTimeBtwTakeDamage;
    public float money;
    public float maxHp;
    public float damage;
    public float attackSpeed;
    public float critical;

    float timeBtwTakeDamage;

    Rigidbody2D r2;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        r2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dead
        if(hp <= 0){
            Debug.Log("You dead!");
        }

        if(timeBtwTakeDamage >0){
            timeBtwTakeDamage-= Time.deltaTime;
        }
    }

    public bool TakeDamage(float damage){
        if(timeBtwTakeDamage<=0){
            hp -= damage;
            timeBtwTakeDamage = startTimeBtwTakeDamage;
            return true;
        }
        return false;
    }

    public void KnockBack(float sign){
        r2.AddForce(new Vector3(3000f*sign,200f,0f));
    }
}
