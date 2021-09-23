using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrackGenerator : MonoBehaviour
{
    [SerializeField] private TrackSegment[] segmentPrefabs;
    private List<TrackSegment> currentSegments = new List<TrackSegment>();

    private void Start()
    {
        //Fazer o spawn de todos os pedacos de leveis que eu tenho
        TrackSegment initialTrack = Instantiate(segmentPrefabs[0], transform);
        currentSegments.Add(initialTrack);

        TrackSegment previousTrack = initialTrack;
        foreach (var trackPrefab in segmentPrefabs)
        {
            TrackSegment trackInstance = Instantiate(trackPrefab, transform);
            //posiciona o track no fim do previous track
            trackInstance.transform.position = previousTrack.End.position
                + (trackInstance.transform.position - trackInstance.Start.position);
            currentSegments.Add(trackInstance);
            previousTrack = trackInstance;
        }
    }
}
