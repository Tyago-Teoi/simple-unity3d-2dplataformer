using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    // Array of all the back and foregrounds to be parallaxed
    public Transform[] backgrounds;
    // Proportion of the camera's movement to move the backgrounds by
    private float[] parallaxScales;
    // How smooth the parallax is going to be. Set this above 0
    public float smoothing = 1f;
    // Reference to the main camera transform
    private Transform cam;
    // Store the position of the camera in the previous frame
    private Vector3 previousCamPos;

    // Called before Start() (Great for references)
    void Awake()
    {
        // Set up camera the reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // The previous frame had the current frames camera position
        previousCamPos = cam.position;

        // Asigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the 
            // previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position wich is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position wich is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Fade betwee current position and the taget position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        // set the previousCamPos to the camera position at the end of the frame
        previousCamPos = cam.position;
    }
}
