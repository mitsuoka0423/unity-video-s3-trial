using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoDownloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer video = gameObject.GetComponent<VideoPlayer>();
        video.playOnAwake = false;
        video.waitForFirstFrame = true;
        video.source = VideoSource.Url;
        video.url = "http://unity-video-s3-trial-20220509.s3-website-ap-northeast-1.amazonaws.com/video.mp4";

        video.prepareCompleted += VideoPlayerOnPrepareCompleted;
        video.Prepare();
    }

    private void VideoPlayerOnPrepareCompleted(VideoPlayer source)
    {
        // Prepare の Completed 時にPlay を同時に呼ぶことでストリーミング再生を行う
        source.Play();
    }
}
