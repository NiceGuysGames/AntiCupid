using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class DetectionViewBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private float speedOfDetection;
    [SerializeField] private PlayerDetector playerDetector;
    private const float speed = 1f;
    private Sequence _seq;
    private Tween _start;
    private Tween _end;

    private void OnEnable()
    {
        playerDetector.Fill+= FillingBar;
        playerDetector.UnFill += UnFillingBar;
    }

    private void OnDisable()
    {
        playerDetector.Fill -= FillingBar;
        playerDetector.UnFill -= UnFillingBar;
    }

    private void  FillingBar()
    {
        if(_seq == null)
            _seq = DOTween.Sequence();
        else
        {
            _end.Kill();
        }
        _start = healthBarImage.DOFillAmount(1, speedOfDetection)
            .OnComplete(() => healthBarImage.color = Color.red);

    }

    private void UnFillingBar()
    {
        _start.Kill();
        healthBarImage.color = Color.white;
        _end = healthBarImage.DOFillAmount(0, speed);  
    }
}