using UnityEngine;

public class CameraController : MonoBehaviour {

    public float xOffset = 0f;
    public float yOffset = 10f;
    public float zOffset = 10f;

    public Transform Player;

    // Update is called once per frame
    void Update() {

        // follow player's position with given offsets
        transform.position = new Vector3(Player.position.x + xOffset, Player.position.y + yOffset, Player.position.z + zOffset);
    }
}
