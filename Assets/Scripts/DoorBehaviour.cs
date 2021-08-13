using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
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
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInParent<CharacterBehaviour>()._renderer.GetPropertyBlock(col.gameObject.GetComponentInParent<CharacterBehaviour>().propBlock);
            col.gameObject.GetComponentInParent<CharacterBehaviour>().propBlock.SetColor("_Color", new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255));
            col.gameObject.GetComponentInParent<CharacterBehaviour>()._renderer.SetPropertyBlock(col.gameObject.GetComponentInParent<CharacterBehaviour>().propBlock);
        }
    }
}