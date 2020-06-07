using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorChange : MonoBehaviour
{
    private SpriteRenderer Target;
    [SerializeField] private float _duration;

    [SerializeField] private Color _targetColor;
    private Color _startColor;


    private float _runningTime;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _startColor = Target.color;
    }
    void Update()
    {
        if (_runningTime <= _duration) 
        { 
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            Target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);

        }
    }

}
