using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBehaviour : MonoBehaviour
{
    public float Force = 1;
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private float touchStart;
    private float touchFinish;
    private float touchInterval;

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchFinish = Time.time;
            touchInterval = touchFinish - touchStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            rb2d.AddForce(-direction / touchInterval * Force);
        }
#endif
    }
}
