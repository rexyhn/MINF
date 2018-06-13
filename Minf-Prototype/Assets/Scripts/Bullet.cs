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
        StartCoroutine("Wait");
    }


    void FixedUpdate()
    {
        //this.transform.Translate(direction* Time.deltaTime * travelspeed);
        // transform.position += transform.forward * Time.deltaTime * travelspeed;

        transform.Translate(Vector3.right * Time.deltaTime * travelspeed);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(this.gameObject);
    }
    IEnumerator Wait()
    {
        Debug.Log("start");
       
  
        yield return new WaitForSeconds(3f);
        Debug.Log("end");
        Destroy(this.gameObject);
    }
}
