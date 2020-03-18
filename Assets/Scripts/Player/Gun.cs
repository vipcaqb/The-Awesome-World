using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotpoint;
    public float startTimeBwtShots;

    float timeBtwShots;

    private void Start() {
        startTimeBwtShots = 1f/GameData.playerInfo.attackSpeed;
    }


    private void Update() {
            
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position ;
        float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotZ + offset);

        if(timeBtwShots <= 0){
            if(Input.GetMouseButtonDown(0)){
                Instantiate(projectile,shotpoint.position,transform.rotation);
                timeBtwShots = startTimeBwtShots;
            }
            else if(Input.GetMouseButton(0)){
                Instantiate(projectile,shotpoint.position,transform.rotation);
                timeBtwShots = startTimeBwtShots;
            }
        }else {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}
