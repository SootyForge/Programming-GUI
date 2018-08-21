using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject mainCam;
    // public Camera cam;
	void Start ()
    {
        player = GameObject.Find("Player"); // Finding by NAME. DON'T USE FOR SIMILARLY NAMED THINGS (i.e. Doors)!
        mainCam = GameObject.FindGameObjectWithTag("MainCamera"); // Caution! 'FindGameObject' vs. 'FindGameObjects'.
        // cam = mainCam.GetComponent<Camera>(); Option 1 to reference the camera.
        // cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); Option 2 to reference the camera.
	}
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.E)) // KeyCode is actually an Enum(?)
        {
            Ray interact; // Raycast!
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // Vector2 is screen space (divide by 2 to centre ray).
            RaycastHit hitInfo; // The info we get back when hitting an object.
            if (Physics.Raycast(interact, out hitInfo, 10.0f)) // Raycasts work using Physics; out is output, 10.0f is the range (max distance)
            { // Regions used to shorten/minimize sections; they're not read by code. MUST HAVE REGIONS & CODE COMMENTS OR ELSE!!!
                #region NPC Dialogue
                if(hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("Talk to NPC");
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))
                {
                    Debug.Log("Open Chest");
                }
                #endregion
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Pick up Item");
                }
                #endregion
            }
        }
	}
}
