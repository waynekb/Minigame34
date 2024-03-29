﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudios : MonoBehaviour
{
    // 音效
    public AudioClip jump = null;
    public AudioClip landSuccess = null;
    public AudioClip buff = null;
    public AudioClip dragPlatform = null;
    public AudioClip releasePlatform = null;
    public AudioClip landFailure = null;
    public AudioClip fire = null;

    private static AudioSource audioComp = null;
    public static AudioClip jumpSfx = null;
    public static AudioClip landSfx = null;
    public static AudioClip buffSfx = null;
    public static AudioClip dragPlatformSfx = null;
    public static AudioClip releasePlatformSfx = null;
    public static AudioClip landDeadSfx = null;
    public static AudioClip fireSfx = null;

    public void Awake()
    {
        jumpSfx = jump;
        landSfx = landSuccess;
        buffSfx = buff;
        dragPlatformSfx = dragPlatform;
        releasePlatformSfx = releasePlatform;
        landDeadSfx = landFailure;
        fireSfx = fire;
    }

    public static void PlaySfx(GameObject obj, AudioClip audioClip)
    {
        if(audioComp == null)
        {
            audioComp = obj.AddComponent<AudioSource>();
            audioComp.playOnAwake = false;
        }

        audioComp.clip = audioClip;
        audioComp.Play();
    }

    public static void SetVolume(GameObject obj, float volume)
    {
        if (audioComp == null)
        {
            audioComp = obj.AddComponent<AudioSource>();
            audioComp.playOnAwake = false;
        }
        audioComp.volume = volume;
    }

    public static void StopSfx(GameObject obj)
    {
        if(audioComp != null)
        {
            audioComp.Stop();
        }
    }
}
