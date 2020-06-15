using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knifeBarUI : MonoBehaviour
{

    Image KnifeBar;
    float maxStamina = 250f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        KnifeBar = GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        KnifeBar.fillAmount =  Move2D.canKnifeTime/ maxStamina;
    }
}
