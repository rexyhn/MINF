using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;
    [SerializeField]
    private float platformSpeed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
	// Use this for initialization
	void Start () {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.transform.position;
        float distance = pos.magnitude;
        Debug.Log(distance);
        platformSpeed = distance * 0.1f;
        Move();
        
	}
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, platformSpeed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.001) {
            changeDestination();
        }
    }
    private void changeDestination() {
        nexPos = nexPos != posA ? posA : posB;
    }
}
