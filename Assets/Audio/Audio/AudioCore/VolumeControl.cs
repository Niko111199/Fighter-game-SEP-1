using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier;
    [SerializeField] private Toggle _toggle;
    private bool _disableToggleEvent;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
        _toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(_volumeParameter))
        {
            PlayerPrefs.SetFloat(_volumeParameter, 1f);
        }

        _slider.value = PlayerPrefs.GetFloat(_volumeParameter);
        UpdateToggleState();
    }

    private void HandleSliderValueChanged(float value)
    {
        float clampedValue = Mathf.Clamp(value, 0.0001f, 1);
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(clampedValue) * _multiplier);

        if (!_disableToggleEvent)
        {
            UpdateToggleState();
        }
    }
    private void HandleToggleValueChanged(bool enableSound)
    {
        if (_disableToggleEvent)
            return;

        _disableToggleEvent = true;

        if (!enableSound)
        {
            _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
            _mixer.SetFloat(_volumeParameter,  Mathf.Log10(_slider.value) * _multiplier);
        }

        else
        {
            PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
            _slider.value = _slider.minValue;
            _mixer.SetFloat(_volumeParameter, -80f);
        }

        _disableToggleEvent = false;
    }

    private void UpdateToggleState()
    {
        _toggle.isOn = !(_slider.value > _slider.minValue);
    }
}
