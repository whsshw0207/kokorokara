﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoHandle : MonoBehaviour
{
    public GameObject BackGround;
    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.SetActive(false);
        BackGround.SetActive(false);
    }
}