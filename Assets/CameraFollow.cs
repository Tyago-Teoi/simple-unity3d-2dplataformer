using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        // Lerp = linear interpolation (from one point A to a point B, give a smooth moviment betweet then)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
