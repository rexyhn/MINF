using System.Collections;
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
       

    
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;
        
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down*1f,Color.red,1f);
     
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down*1f, enemyMask);
      
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f);
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
   
}
