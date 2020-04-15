// partial source: https://www.youtube.com/watch?v=GIDz0DjhA4E

using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour {

    // loop: move to first waypoint after reaching last waypoint
    // random: traverse waypoints in random order
    // backtrack: traverse same path back to first waypoint after reaching last waypoint
    public enum TraversalMode {Loop, Random, Backtrack};
    public TraversalMode mode;

    public List<Transform> waypoints = new List<Transform>();
    private Transform TargetWaypoint;
    private int waypointIndex = 0;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;

    private float movementSpeed = 3.0f;
    private float rotateSpeed = 2.0f;
    private bool onBacktrack = false;

    private Animator anim;

    public List<AudioSource> step_sounds = new List<AudioSource>();
    public AudioSource burn;
    private float nextTimeToPlay = 0.0f;
    private float period;

    // Start is called before the first frame update
    void Start() {

        // set default waypoint to first in list
        TargetWaypoint = waypoints[waypointIndex];
        lastWaypointIndex = waypoints.Count;

        anim = GetComponent<Animator>();

        burn.Play();

        // set period between sound based on movement speed
        period = 2.0f / movementSpeed;
    }

    // Update is called once per frame
    void Update() {

        // start walking animation
        anim.SetBool("Walk", true);

        // set movement and rotation step rates
        float movementStep = movementSpeed * Time.deltaTime;
        float rotatetStep = rotateSpeed * Time.deltaTime;

        // get direction and rotation angle of current waypoint target
        Vector3 directionToTarget = TargetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        // move towards rotate smoothly to face current waypoint target
        transform.position = Vector3.MoveTowards(transform.position, TargetWaypoint.position, movementStep);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotatetStep);

        // play random step sound effect every period seconds
        if (Time.time > nextTimeToPlay) {
            nextTimeToPlay += period;
            int index = Random.Range(0, step_sounds.Count);
            step_sounds[index].Play();
        }

        // get current distance from target waypoint and check if we reached it to get new target waypoint
        float distance = Vector3.Distance(transform.position, TargetWaypoint.position);
        CheckDistanceToWaypoint(distance);
    }

    void CheckDistanceToWaypoint(float currentDistance) {

        // if we reached our current waypoint within minDistance
        if (currentDistance <= minDistance) {

            // stop walking animation
            anim.SetBool("Walk", false);

            // decide traversal strategy based on selection
            switch (mode) {

                // go to first waypoint when reaching last
                case TraversalMode.Loop:
                    waypointIndex++;
                    if (waypointIndex == lastWaypointIndex) {
                        waypointIndex = 0;
                    }
                    break;

                // choose a new random waypoint
                case TraversalMode.Random:
                    waypointIndex = Random.Range(0, lastWaypointIndex);
                    break;

                // backtrack when reaching first or last waypoint
                case TraversalMode.Backtrack:

                    // if moving up list of waypoints
                    if (onBacktrack == false) {
                        waypointIndex++;

                        // reached end, go backwards
                        if (waypointIndex == lastWaypointIndex) {
                            waypointIndex = lastWaypointIndex - 1;
                            onBacktrack = true;
                        }
                    }

                    // if moving down list of waypoints
                    else {

                        // reached start, go forwards
                        if (waypointIndex == 0) {
                            waypointIndex = 1;
                            onBacktrack = false;
                        }
                        else {
                            waypointIndex--;
                        }
                    }
                    break;
            }

            // set new waypoint target
            TargetWaypoint = waypoints[waypointIndex];
        }
    }
}
