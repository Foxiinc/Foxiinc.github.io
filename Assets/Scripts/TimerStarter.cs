using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerStarter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textObject;

    [SerializeField] private List<string> _strings = new();

    [SerializeField] private float _speed;

    private Color _color;

    private Tween tween;

    private void Start()
    {
        _color = Color.white;

        StartTimer();
    }

    private void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        if (_strings.Count == 0)
        {
            EnableWalls();
            yield break;
        }

        _textObject.color = _color;
        _textObject.text = _strings[0];

        tween = _textObject.DOColor(new Color(_color.r, _color.b, _color.g, 0), _speed);

        tween.onComplete = () => _strings.RemoveAt(0);

        yield return tween.WaitForCompletion();

        StartCoroutine(Timer());
    }

    private void EnableWalls()
    {
        WallCreator wallCreator = FindObjectOfType<WallCreator>();
        WallMover wallMover = FindObjectOfType<WallMover>();

        wallMover.enabled = true;
        wallCreator.enabled = true;
    }
}