using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    public byte powerUpID; //0 - Control Power Up

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        switch(powerUpID)
        {
            case 0: //Control Power Up
                if (col.gameObject.tag == "Player")
                {
                    col.gameObject.GetComponentInParent<CharacterBehaviour>().hasControlPowerUp = true;
                    gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
