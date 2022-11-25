using System.Collections;
using UnityEngine;

namespace Assets.Managers
{
    public class MarqueeManager : MonoBehaviour
    {
        [SerializeField] private GameObject SongName;

        [SerializeField] private float increment = 0.1f;

        [SerializeField] private float pauseMarqueeDuration = 3f;

        [SerializeField] private MarqueeStyle marqueeStyle = MarqueeStyle.SpotifyBouncing;

        [SerializeField] private float rollOverWidth = 30f;

        private Vector3 endingPos;

        private float oldXDelta;

        private GameObject SongNameClone;

        private RectTransform songNameRect;

        private Vector3 startingPos;
        public bool IsNewSong { get; set; }

        // Start is called before the first frame update
        private void Start()
        {
            songNameRect = SongName.GetComponent<RectTransform>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (oldXDelta != songNameRect.sizeDelta.x)
            {
                oldXDelta = songNameRect.sizeDelta.x;
                RecalculateBounds();
            }
        }

        private void RecalculateBounds()
        {
            StopAllCoroutines();
            Destroy(SongNameClone);
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

            switch (marqueeStyle)
            {
                case MarqueeStyle.SpotifyBouncing:
                    StartCoroutine(MarqueeText());
                    break;

                case MarqueeStyle.RollOver:
                    StartCoroutine(StartRollOverMarquee());
                    break;
            }
        }

        private IEnumerator StartRollOverMarquee()
        {
            var currentIncrement = increment;
            yield return new WaitForSeconds(pauseMarqueeDuration);
            var offset = rollOverWidth;
            SongNameClone = Instantiate(SongName, SongName.transform.position, Quaternion.identity,
                SongName.transform.parent);
            var cloneRect = SongNameClone.GetComponent<RectTransform>();
            cloneRect.localPosition += new Vector3(songNameRect.rect.width + offset, 0, 0);

            var posOfEnd = startingPos.x - songNameRect.rect.width - offset;

            var isClonedShowing = false;

            while (true)
            {
                var isEnd = isClonedShowing
                    ? cloneRect.localPosition.x < posOfEnd
                    : songNameRect.localPosition.x < posOfEnd;

                if (isEnd)
                {
                    if (isClonedShowing)
                        cloneRect.localPosition = songNameRect.localPosition +
                                                  new Vector3(songNameRect.rect.width + offset, 0, 0);
                    else
                        songNameRect.localPosition = cloneRect.localPosition +
                                                     new Vector3(songNameRect.rect.width + offset, 0, 0);

                    isClonedShowing = !isClonedShowing;
                }

                songNameRect.localPosition += new Vector3(-currentIncrement, 0, 0);
                cloneRect.localPosition += new Vector3(-currentIncrement, 0, 0);
                yield return new WaitForFixedUpdate();
                yield return null;
            }
        }

        private IEnumerator MarqueeText()
        {
            var currentIncrement = increment;
            yield return new WaitForSeconds(pauseMarqueeDuration);
            while (true)
            {
                var isEnd = songNameRect.localPosition.x - endingPos.x < 0;
                var isBeginning = startingPos.x - songNameRect.localPosition.x < 0;
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

        private enum MarqueeStyle
        {
            SpotifyBouncing,

            RollOver
        }
    }
}