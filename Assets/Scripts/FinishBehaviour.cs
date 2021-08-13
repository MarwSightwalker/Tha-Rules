using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishBehaviour : MonoBehaviour
{
    public TextMeshProUGUI winningMessage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //You Win!!
            GameController.gm.cam.m_Follow = col.transform.parent;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(0, col.gameObject.GetComponentInParent<Rigidbody>().velocity.y, 0);
            winningMessage.gameObject.SetActive(true);
            col.gameObject.GetComponentInParent<CharacterBehaviour>().canMove = false;
            GameController.gm.hasGameFinished = true;
        }
    }
}
