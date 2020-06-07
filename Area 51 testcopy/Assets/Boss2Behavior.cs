using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behavior : MonoBehaviour
{
    private void Update()
    {
        if (TimsBehavior.TimIsDead && TomsBehavior.TomIsDead)
        {
            gameObject.SetActive(false);
            
        }
    }
}
