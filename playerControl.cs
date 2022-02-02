//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerControl : MonoBehaviour
{

    public float speed = 6f;

    Rigidbody playerRigidBody;
    public GameObject shot;
    public GameObject shotB;

    public int activeWeps;

    public ScoreManager scoreManager;

    public int health;
    public bool isAlive;
    private float rotateY;
    public Inventory inv;
    private WeaponBase activeWep;
    public bool hasDied;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        health = 100;
        isAlive = true;
        hasDied = false;
        inv = new Inventory();
        activeWep = null;
    }
    /// <summary>
    /// use for shooting, x for weapon select, L shift for firing
    /// </summary>
    void Update() 
    {
        //Movement();
        Attack();
       
    }
    void FixedUpdate()
    {
      Movement();
    }
    
    void Movement()
    {
        if (playerRigidBody == null)
            isAlive = false;
        if (isAlive)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            rotateY += h * 5;
            if (rotateY > 360)
                rotateY -= 360;
            if (rotateY < 0)
                rotateY += 360;
            playerRigidBody.rotation = Quaternion.Euler(0, rotateY, 0);
            if (v != 0)
            {
                Vector3 velocity = transform.forward * speed * Time.deltaTime * v;
                playerRigidBody.MovePosition(playerRigidBody.position + velocity);
            }
            inv.Positioning(this.transform);
            if (health <= 0)
            {
                hasDied = true;
                isAlive = false;
                scoreManager.gameActive = false;
            }
        }
        if (hasDied)
        {
            playerRigidBody.gameObject.SetActive(false);

        }
    }

    void Attack()
    {
        if (playerRigidBody == null)
            isAlive = false;

        if (isAlive)
        {

            if (Input.GetKeyDown("x"))
            {
                activeWep = inv.SelectWep();
            }
            if (Input.GetKeyDown("left shift"))
            {
                if (activeWep != null)
                {
                    activeWep.shoot();
                }
            }

        }
        if(!playerRigidBody.gameObject.activeSelf)
                    activeWep.GetComponent<Renderer>().enabled = false;

    }

}

