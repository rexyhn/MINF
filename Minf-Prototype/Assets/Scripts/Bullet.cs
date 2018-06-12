using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 direction;
    public float travelspeed = 2;
    public float force = 750f;
    // Use this for initialization
    void Start()
    {
        //direction = this.transform.rotation * Vector3.forward;

    }


    void FixedUpdate()
    {
        //this.transform.Translate(direction* Time.deltaTime * travelspeed);
        // transform.position += transform.forward * Time.deltaTime * travelspeed;

        transform.Translate(Vector3.right * Time.deltaTime * travelspeed);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {

            StartCoroutine("Wait");

        }
    }
    IEnumerator Wait()
    {
        Debug.Log("start");
       
  
        yield return new WaitForSeconds(0.01f);
        Debug.Log("end");
        Destroy(this.gameObject);
    }
}
