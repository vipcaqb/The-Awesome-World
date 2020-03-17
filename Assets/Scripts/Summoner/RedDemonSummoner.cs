using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDemonSummoner : MonoBehaviour
{
    public float startTimeBtwSummon;
    public float startSummonRange;
    public GameObject redDemon;
    public GameObject summonEffect;

    float timeBtwSummon;
    float playerDistance;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSummon = 0;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance(player.position,transform.position);

        if(timeBtwSummon <= 0){
            if(playerDistance <= startSummonRange){
                SummonRedDemon();
            }
        }

        if(timeBtwSummon >0){
            timeBtwSummon -= Time.deltaTime;
        }

    }

    void SummonRedDemon(){
        Instantiate(summonEffect, transform.position, Quaternion.identity);
        Instantiate(redDemon, transform.position, Quaternion.identity);
        timeBtwSummon = startTimeBtwSummon;
    }
}
