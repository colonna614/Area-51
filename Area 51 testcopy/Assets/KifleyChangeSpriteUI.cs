using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KifleyChangeSpriteUI : MonoBehaviour
{
    public Sprite KifleyGuns;
    private void Update()
    {
        if (Boss3Behavior.bossHealth <= 150)
        {
            this.GetComponent<SpriteRenderer>().sprite = KifleyGuns;
        }
    }
    
}
