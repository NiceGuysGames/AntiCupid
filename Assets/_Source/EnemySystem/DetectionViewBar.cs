using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DetectionViewBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Canvas healthBar;
    [SerializeField] private float speedOfDetection;
    private const float speed = 1f;
    

    private void OnEnable()
    {
        PlayerDetector.action += FillingBar;
        PlayerDetector.UnFill += UnFillingBar;
    }

    private void OnDisable()
    {
        PlayerDetector.action -= FillingBar;
        PlayerDetector.UnFill -= UnFillingBar;
    }

    private void  FillingBar()
    {
        Debug.Log("Invoke");
         healthBarImage.DOFillAmount(1, speedOfDetection).OnComplete(() => healthBarImage.color = Color.red  );
        
         
    }

    private void UnFillingBar()
    {
        healthBarImage.color = Color.white;
        healthBarImage.DOFillAmount(0, speed);
    }
}