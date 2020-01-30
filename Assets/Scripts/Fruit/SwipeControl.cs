using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{

    private bool tap, swipeUp, swipeDown, swipeRight, swipeLeft;
    private bool İsDragging = false;

    private Vector2 StartTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeLeft { get { return swipeRight; } }
    public bool SwipeRight { get { return swipeLeft; } }

    private void Update()
    {
        tap = swipeUp = swipeDown = swipeRight = swipeLeft = false;
        #region MouseInputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            İsDragging = true;
            StartTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            İsDragging = false;
            Reset();
        }

        #endregion

        #region MobileInputs

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                İsDragging = true;
                tap = true;
                StartTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                İsDragging = false;
                Reset();
            }
        }

        #endregion

        swipeDelta = Vector2.zero;
        if (İsDragging)
        {
            if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - StartTouch;
            }
             if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - StartTouch;
                
            }
         
        }

        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right 
                if (x < 0)
                    swipeRight = true;
                else
                    swipeLeft = true;
            }
            if (Mathf.Abs(x) < Mathf.Abs(y))
            {
                //Up OR dOWN
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
        }


    }

    private void Reset()
    {
        StartTouch = swipeDelta = Vector2.zero;
        İsDragging = false;
    }




}
