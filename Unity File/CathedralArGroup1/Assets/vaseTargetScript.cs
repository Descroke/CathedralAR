using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.IO;


public class vaseTargetScript : MonoBehaviour,
ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void saveTrackedItem()
    {
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "testFile.txt");

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine("\n Object 2 tracked: True");
        }
    }

    public bool tracked = false;

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            GetComponent<AudioSource>().Play();

            if (tracked == false)
            {
                saveTrackedItem();
                tracked = true;
            }

        }
        else
        {
            // Stop audio when target is lost
            GetComponent<AudioSource>().Stop();
        }
    }
}
