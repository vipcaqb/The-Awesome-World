using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    Status playerStatus;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<Status>();
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = playerStatus.maxHp;
        slider.value = playerStatus.hp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerStatus.hp;
    }
}
