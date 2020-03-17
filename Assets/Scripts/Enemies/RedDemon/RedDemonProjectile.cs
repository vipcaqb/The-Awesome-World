using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDemonProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject destroyEffect;
    public GameObject redDemon;
    public float damage;

    Transform targetIsPlayer;
    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyRedDemonProjectile",lifeTime);
        targetIsPlayer = GameObject.Find("Player").GetComponent<Transform>();
        target = new Vector2(targetIsPlayer.position.x,targetIsPlayer.position.y);

        target.x -= transform.position.x;
        target.y -= transform.position.y;

        target.x *=3;
        target.y *= 3;

        target.x += transform.position.x;
        target.y += transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }

    public void DestroyRedDemonProjectile(){
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            DestroyRedDemonProjectile();
            other.gameObject.GetComponent<Status>().TakeDamage(damage);
        }
        if(other.gameObject.CompareTag("Ground")){
            DestroyRedDemonProjectile();
        }
    }

}
