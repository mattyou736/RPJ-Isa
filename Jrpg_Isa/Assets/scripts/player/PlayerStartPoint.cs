using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerMovement thePlayer;
    private CameraControler theCamera;

    public Vector2 startDirection;

    public GameObject startPos1, startPos2;

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerFlags>().inside)
        {
            thePlayer = FindObjectOfType<PlayerMovement>();

            thePlayer.transform.position = startPos2.transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraControler>();
            theCamera.transform.position = new Vector3(startPos2.transform.position.x, startPos2.transform.position.y, theCamera.transform.position.z);
        }
        else
        {
            thePlayer = FindObjectOfType<PlayerMovement>();

            thePlayer.transform.position = startPos1.transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraControler>();
            theCamera.transform.position = new Vector3(startPos1.transform.position.x, startPos1.transform.position.y, theCamera.transform.position.z);
        }
        
    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
