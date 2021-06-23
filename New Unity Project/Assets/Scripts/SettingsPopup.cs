using UnityEngine.UI;

public class SettingsPopup : Popup
{
    public Slider slider;
    
    public void ChangeVolume(Slider slider)
    {
        if(_manager)
            _manager.ChangeVolume(slider.value);
    }

    public void SetVolume(float audioSourceVolume)
    {
        slider.value = audioSourceVolume;
    }
}
