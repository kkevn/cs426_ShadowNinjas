using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Transform canvas;

    private float rotateSpeed = 50f;
    private float positionSpeed = 3f;

    private float startY;

    // Start is called before the first frame update
    void Start() {
        canvas = GetComponent<Transform>();
        startY = GetComponentInParent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update() {

        // animate crosshair by rotating and bobbing up and down
        canvas.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f), Space.World);
        canvas.position = new Vector3(canvas.position.x, Mathf.Sin(Time.time * positionSpeed) + startY, canvas.position.z) * 1f;
    }
}
