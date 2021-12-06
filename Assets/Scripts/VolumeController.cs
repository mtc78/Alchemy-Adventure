using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    string volumeParameter = "Master";
    [SerializeField]
    AudioMixer mixer;
    [SerializeField]
    Slider slider;
    [SerializeField]
    public float multiplier = 30f;
    [SerializeField]
    public Toggle toggle;
    [SerializeField]
    public bool disabledToggle;

    void Awake(){
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
        //slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    private void HandleSliderValueChanged(float value){
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
        disabledToggle = true;
        toggle.isOn = slider.value > slider.minValue;
        disabledToggle = false;
    }

    private void HandleToggleValueChanged(bool soundToggle){
        
        if (disabledToggle)
            return;

        if (soundToggle)
            slider.value = slider.maxValue;
        else
            slider.value = slider.minValue;
    }

    private void OnDisable(){
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    // Start is called before the first frame update
    void Start()
    { 
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
