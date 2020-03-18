using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage;
    public GameObject destroyEffect;

    Vector2 mousePoint;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        damage = GameData.playerInfo.damage;
        Invoke("DestroyProjectile",lifeTime);
        mousePoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        target.x = mousePoint.x - transform.position.x;
        target.y = mousePoint.y - transform.position.y;
        target*= 500;
        target.x = target.x + transform.position.x;
        target.y = target.y + transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.right * speed * Time.deltaTime );
        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }

    void DestroyProjectile(){
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            DestroyProjectile();
            if(other.GetComponent<Slime>()!= null){
                other.GetComponent<Slime>().TakeDamage(damage);
            }
                
            else if(other.GetComponent<RedDemon>()!= null){
                other.GetComponent<RedDemon>().TakeDamage(damage);
            }
                
        }
        if(other.gameObject.CompareTag("Ground")){
            DestroyProjectile();
        }
    }

}
