using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage RawImage;
    public VideoPlayer VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo()
    {
        VideoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!VideoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        RawImage.texture = VideoPlayer.texture;
        VideoPlayer.Play();
    }
}
