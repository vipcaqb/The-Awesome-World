using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minY;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 temp = transform.position;
            temp.x = player.transform.position.x;
            

            if(player.transform.position.y < minY){
                temp.y = minY;
            }else{
                temp.y = player.transform.position.y;
            }

            transform.position = temp;
        }
    }
}
