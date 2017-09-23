using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiddleController : MonoBehaviour {

    public Camera  cam;
    public float rotateSpeed = 10;
    public float speed = 10;

    public bool isOnMovement = false;

    private Vector2 targetPosition;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.touchCount > 0)
        {
            targetPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            Debug.Log("Fire");
        }

        if (Vector2.Distance(rigid.position, targetPosition) > 0.1f)
        {
            isOnMovement = true;
            Vector2 diff = targetPosition - rigid.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            float angle = Mathf.Lerp(rigid.rotation, rot, rotateSpeed * Time.fixedDeltaTime);

            diff = Vector2.Lerp(rigid.position, targetPosition, speed * Time.fixedDeltaTime);

            rigid.MoveRotation(rot);
            rigid.MovePosition(diff);
        }
        else
        {
            isOnMovement = false;
        }

	}
}
