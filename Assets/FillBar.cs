using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class FillBar : MonoBehaviour
{
    Image Image;
    [Range(0,1)]
    public float maxFill;
    public UnityEvent OnLevelCompleate;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        GameObject.FindObjectOfType<AreaCamera>().OnAreaChange+=UpdateProgressBar;
    }

    public void UpdateProgressBar(float fill)
    {
        float percent = fill/maxFill;
        Image.fillAmount = percent;
        if(percent >= .99) OnLevelCompleate?.Invoke();
    }
}
