using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    Text text;
    float _updateInterval = 0.5f;
    float _accum = .0f;
    int _frames = 0; 
    float _timeLeft;

    void Start()
    {
        text = GetComponent<Text>();
        _timeLeft = _updateInterval;
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        _accum += Time.timeScale / Time.deltaTime;
        ++_frames;
        if (_timeLeft <= 0)
        {
            float fps = _accum / _frames;  
            text.text = "FPS:" + fps.ToString("f2");

            _timeLeft = _updateInterval;
            _accum = .0f;
            _frames = 0;
        }
    }
}
