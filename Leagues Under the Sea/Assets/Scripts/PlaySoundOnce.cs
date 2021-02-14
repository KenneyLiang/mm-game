using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour {
    private AudioSource _audio;
    public bool randomPitch;

    void Start() {
        _audio = gameObject.GetComponent<AudioSource>();

        if (randomPitch) {
            _audio.pitch = Random.Range(0.75f, 1.25f);
        }

        _audio.Play();
    }

    void Update()
    {
        if (!_audio.isPlaying) {
            Destroy(gameObject);
        }
    }
}