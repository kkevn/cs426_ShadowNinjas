using UnityEngine;

public class CameraController : MonoBehaviour {

    public float xOffset = 0f;
    public float yOffset = 10f;
    public float zOffset = 10f;

    private float panSpeed = 0.25f;

    public bool pan = true;

    public Transform Player;
    public Transform ViewOfStart;
    public Transform ViewOfGoal;


    void Start() {
        transform.position = ViewOfGoal.position;
    }

    // Update is called once per frame
    void Update() {
        
        // pan camera to start from goal, then give player control of camera
        if (pan == true && transform.position.x >= ViewOfStart.position.x - 5.0f && transform.position.z <= ViewOfStart.position.z + 5.0f) {
            pan = false;
        }
        else {
            // pan camera from goal to start
            transform.position = Vector3.Slerp(transform.position, ViewOfStart.position, panSpeed * Time.deltaTime);
        }

        if (pan == false) {
            // follow player's position with given offsets
            transform.position = new Vector3(Player.position.x + xOffset, Player.position.y + yOffset, Player.position.z + zOffset);
        }
    }
}
