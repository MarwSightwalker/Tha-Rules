using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerudaTongue : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInParent<CharacterBehaviour>().hp -= GetComponentInParent<PerudaBehaviour>().damage;
        }
    }
}
