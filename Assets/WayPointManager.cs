using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] waypoints; // Array to store the references to the waypoints

    public void SetWaypointPositions(int level)
    {
        if(level == 1)
        {
            SetLevel1Positions();
        }
        if (level == 2)
        {
            SetLevel2Positions();
        }
        if (level == 3)
        {
            SetLevel3Positions();
        }

    }

    private void SetLevel1Positions()
    {
        // Update the positions of waypoints for Level 1
        waypoints[0].position = new Vector3(1f, 0f, 0f);
        waypoints[1].position = new Vector3(2f, 0f, 0f);
        waypoints[2].position = new Vector3(3f, 0f, 0f);
        waypoints[3].position = new Vector3(3f, 0f, 0f);
        waypoints[4].position = new Vector3(3f, 0f, 0f);
    }

    private void SetLevel2Positions()
    {
        // Update the positions of waypoints for Level 2
        waypoints[0].position = new Vector3(1f, 0f, 0f);
        waypoints[1].position = new Vector3(2f, 0f, 0f);
        waypoints[2].position = new Vector3(3f, 0f, 0f);
        waypoints[3].position = new Vector3(3f, 0f, 0f);
        waypoints[4].position = new Vector3(3f, 0f, 0f);
    }

    private void SetLevel3Positions()
    {
        // Update the positions of waypoints for Level 2
        waypoints[0].position = new Vector3(1f, 0f, 0f);
        waypoints[1].position = new Vector3(2f, 0f, 0f);
        waypoints[2].position = new Vector3(3f, 0f, 0f);
        waypoints[3].position = new Vector3(3f, 0f, 0f);
        waypoints[4].position = new Vector3(3f, 0f, 0f);
    }
}

