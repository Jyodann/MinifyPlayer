using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarqueeManager : MonoBehaviour
{
    public bool isNewSong { get; set; }
    [SerializeField] GameObject SongName;
    GameObject SongNameClone;

    RectTransform songNameRect;
    Vector3 startingPos;
    Vector3 endingPos;
    [SerializeField] float increment = 0.1f;
    [SerializeField] float pauseMarqueeDuration = 3f;
    [SerializeField] MarqueeStyle marqueeStyle = MarqueeStyle.SpotifyBouncing;

    float oldXDelta = 0.0f;


    enum MarqueeStyle
    {
        SpotifyBouncing,
        RollOver
    }
    // Start is called before the first frame update
    void Start()
    {
        songNameRect = SongName.GetComponent<RectTransform>();
    }


    // Update is called once per frame
    void Update()
    {
        if (oldXDelta != songNameRect.sizeDelta.x)
        {
            oldXDelta = songNameRect.sizeDelta.x;
            RecalculateBounds();
        }
    }

    void RecalculateBounds()
    {
        print($"Recalculating Boundaries: {songNameRect.sizeDelta.x}");
        StopAllCoroutines();
        if (songNameRect.sizeDelta.x < 0)
        {
            // Resize to Center, if song fits whole screen
            songNameRect.localPosition = new Vector3(0, songNameRect.localPosition.y, 0);
            startingPos = Vector3.zero;
            endingPos = Vector3.zero;
            return;
        }

        // If song does not fit, start Marquee
        startingPos = new Vector3(songNameRect.sizeDelta.x / 2, songNameRect.localPosition.y, 0);
        endingPos = new Vector3(-(songNameRect.sizeDelta.x / 2), songNameRect.localPosition.y, 0);
        songNameRect.localPosition = startingPos;

        Destroy(SongNameClone);

        switch (marqueeStyle)
        {
            case MarqueeStyle.SpotifyBouncing:
                StartCoroutine(MarqueeText());
                break;
            case MarqueeStyle.RollOver:
                StartCoroutine(StartRollOverMarquee());
                break;
            default:
                break;
        }
        
    }

    IEnumerator StartRollOverMarquee()
    {
        var currentIncrement = increment;
        yield return new WaitForSeconds(pauseMarqueeDuration);

        SongNameClone = Instantiate(SongName, SongName.transform.position, Quaternion.identity, SongName.transform.parent);
        var cloneRect = SongNameClone.GetComponent<RectTransform>();
        cloneRect.localPosition += new Vector3(songNameRect.rect.width, 0, 0);
        while (true)
        {
            songNameRect.localPosition += new Vector3(-currentIncrement, 0, 0);
            cloneRect.localPosition += new Vector3(-currentIncrement, 0, 0);
            yield return new WaitForFixedUpdate();
            var isBeginning = (startingPos.x - songNameRect.localPosition.x) < 0;
            var isEndning = (startingPos.y - songNameRect.localPosition.y);
            var isAnimating = !isBeginning;

            yield return null;
        }
    }

    IEnumerator MarqueeText()
    {
        var currentIncrement = increment;
        yield return new WaitForSeconds(pauseMarqueeDuration);
        while (true)
        {
            var isEnd = (songNameRect.localPosition.x - endingPos.x) < 0;
            var isBeginning = (startingPos.x - songNameRect.localPosition.x) < 0;
            var isAnimating = !isBeginning && !isEnd;
            print($"IsBegin: {isBeginning} isEnd: {isEnd} isAnimating: {isAnimating} Increment: {increment}");
            
            if (isAnimating)
            {
                songNameRect.localPosition += new Vector3(-currentIncrement, 0, 0);
                yield return new WaitForFixedUpdate();
            }

            if (isEnd)
            {
                yield return new WaitForSeconds(pauseMarqueeDuration);
                currentIncrement = -currentIncrement;
                songNameRect.localPosition += new Vector3(-currentIncrement, 0, 0);
            }

            if (isBeginning)
            {
                yield return new WaitForSeconds(pauseMarqueeDuration);
                currentIncrement = -currentIncrement;
                songNameRect.localPosition += new Vector3(-currentIncrement, 0, 0);
            }
            //songNameRect.localPosition += new Vector3(-increment, 0, 0);
            
        }   
    }
}
