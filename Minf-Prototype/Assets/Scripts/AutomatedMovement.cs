﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AutomatedMovement : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;
    public bool moveallowed = true;
    private int stage = 0;
    public GameObject checkppoint1, checkpoint2;
    private GameObject target;

    public int Stage
    {
        get
        {
            return stage;
        }

        set
        {
            stage = value;
        }
    }

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
    }

    void FixedUpdate()
    {
       

    
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * (myWidth*0.65f) + Vector2.up * myHeight;
        
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down* myHeight*3.5f, Color.red,0.5f);
     
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down* myHeight*3.5f, enemyMask);
      
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f,Color.yellow,0.1f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);

        
        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }



        if (moveallowed) {
            Vector2 myVel = myBody.velocity;
            myVel.x = -myTrans.right.x * speed;
            myBody.velocity = myVel;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {

            SetToCheckpoint();

        }
    }
    private void SetToCheckpoint() {
        switch (stage) {
            case 1:
                target = checkppoint1;
                    break;
            case 2:
                target = checkpoint2;
                break;
        }
        this.transform.position = new Vector2(target.transform.position.x, target.transform.position.y);
    }

}
