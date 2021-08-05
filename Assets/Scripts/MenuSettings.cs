using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer = null;

    Resolution[] resolutions;

    public Dropdown resolutionDropDown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> listOptions = new List<string>();

        int curretResolutionIndex = 0;
        for(int i = 0; i< resolutions.Length; i++)
        {

            string option = resolutions[i].width + "x" + resolutions[i].height;
            listOptions.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curretResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(listOptions);
        resolutionDropDown.value = curretResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

}
