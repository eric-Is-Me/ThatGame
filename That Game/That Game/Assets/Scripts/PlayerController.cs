using System;
using UnityEngine;

public enum State
{
    SwipeStarted, SwipeNotStarted
}
public class PlayerController : MonoBehaviour, InputDetector
{

    private State state = State.SwipeNotStarted;
    private Vector2 startPoint;
    private DateTime timeSwipeStarted;
    private TimeSpan maxSwipeTime = TimeSpan.FromSeconds(1);
    private TimeSpan minSwipeTime = TimeSpan.FromMilliseconds(100);
    public InputDirection direction = InputDirection.Up;

    public InputDirection? DetectInputDirection()
    {
        if (state == State.SwipeNotStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {

                timeSwipeStarted = DateTime.Now;
                state = State.SwipeStarted;
                startPoint = Input.mousePosition;
            }
        }
        else if (state == State.SwipeStarted)
        {
            if (Input.GetMouseButtonUp(0))
            {
                TimeSpan timeDifference = DateTime.Now - timeSwipeStarted;
                if (timeDifference <= maxSwipeTime && timeDifference >= minSwipeTime)
                {
                    Vector2 mousePosition = Input.mousePosition;
                    Vector2 differenceVector = mousePosition - startPoint;
                    float angle = Vector2.Angle(differenceVector, Vector2.right);
                    Vector3 cross = Vector3.Cross(differenceVector, Vector2.right);

                    if (cross.z > 0)
                        angle = 360 - angle;
                    state = State.SwipeNotStarted;

                    if ((angle >= 315 && angle <= 360 || angle >= 0 && angle <= 45))
                    {
                        direction = InputDirection.Right;
                        //return InputDirection.Right;
                    }
                    if ((angle >= 45 && angle <= 135))
                    {

                        return InputDirection.Up;
                    }
                    if ((angle >= 135 && angle <= 180 || angle >= 180 && angle <= 225))
                    {

                        direction = InputDirection.Left;
                        //return InputDirection.Left;
                    }

                    else
                    {

                        return InputDirection.Down;
                    }
                }
            }
        }
        return null;
    }
}
