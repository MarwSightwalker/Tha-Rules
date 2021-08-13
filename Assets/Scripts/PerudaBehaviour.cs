using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerudaBehaviour : MonoBehaviour
{
    public int damage = 20;

    public float turnSpeed = 3;
    public float tongueSpeed = 1;

    public GameObject tongue;

    float counter = 0;
    float ctLimit = 5;
    public bool isLicking = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        ctLimit = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLicking)
        {
            RotateToCharacter();
        }

        if(!GameController.gm.hasGameFinished)
        {
            Lick();
        }

    }

    void RotateToCharacter()
    {

    }

    void Lick()
    {
        counter += Time.deltaTime;
        if(counter >= ctLimit)
        {
            anim.Play("Lick_Peruda");
            counter = 0;
            ctLimit = Random.Range(3, 7);
        }
    }

    /*IEnumerator Lick()
    {
        while(true)
        {
            Vector3 initPos = tongue.transform.localPosition;
            Vector3 endPos;
            isLicking = true;
            //Lick
            if (Vector3.Distance(transform.position, tongue.transform.position) < 1.1f)
                tongue.transform.localPosition += tongue.transform.forward * tongueSpeed;

            yield return new WaitForSeconds(5f);
            endPos = tongue.transform.localPosition;
            if (Vector3.Distance(transform.position, tongue.transform.position) > 0.1f)
                tongue.transform.localPosition -= tongue.transform.forward * tongueSpeed;

            isLicking = false;
            yield return new WaitForSeconds(2);
        }

        //counter += Time.deltaTime;
        //if(counter >= ctLimit)
        //{

        //}
    }*/
}
