using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public float speed = 5;
    public bool canMove = true;

    public int maxHP = 100;
    public int hp;

    public bool hasControlPowerUp;

    Rigidbody rb;

    [HideInInspector] public Renderer _renderer;
    [HideInInspector] public MaterialPropertyBlock propBlock;

    #region Timers
    float controlPUpTimer = 0;
    float controlPUpLimit = 5;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        propBlock = new MaterialPropertyBlock();
        _renderer = GetComponentInChildren<Renderer>();
        _renderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", new Color32(106, 106, 106, 255));
        _renderer.SetPropertyBlock(propBlock);

        hp = maxHP;
    }

    void Update()
    {
        UpdateLifebar();
        if (!GameController.gm.hasGameFinished)
        {
            Move();
            Commands();
            CheckLife();
        }
    }

    void Move()
    {
        if(canMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 controllerAxis = new Vector3(h, 0, v);
            controllerAxis.Normalize();

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(controllerAxis.x * speed, rb.velocity.y, controllerAxis.z * speed);
            }
        }
    }

    void Commands()
    {
        #region ControlPowerUp
        if(hasControlPowerUp)
        {
            if (Input.GetKey(KeyCode.C))
            {
                controlPUpTimer += Time.deltaTime;
                if(controlPUpTimer <= controlPUpLimit)
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                    canMove = false;
                    GameController.gm.finish.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);
                    GameController.gm.cam.m_Follow = GameController.gm.finish.transform;
                }
            }
            
            if(Input.GetKeyUp(KeyCode.C) || controlPUpTimer > controlPUpLimit)
            {
                if (!canMove)
                {
                    GameController.gm.finish.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    canMove = true;
                    GameController.gm.cam.m_Follow = transform;
                    if(controlPUpTimer > controlPUpLimit)
                    {
                        controlPUpTimer = 0;
                        hasControlPowerUp = false;
                    }
                }
            }
        }
        #endregion

        #region Slow-Down Weapon

        #endregion
    }

    public void CheckLife()
    {
        if(hp <= 0)
        {
            GameController.gm.GameOver();
        }
    }

    void UpdateLifebar()
    {
        if((float)(hp / maxHP) >= 0)
        {
            GameController.gm.lifebar.fillAmount = (float)hp / maxHP;
        }
        else
        {
            GameController.gm.lifebar.fillAmount = 0;
        }
    }
}
