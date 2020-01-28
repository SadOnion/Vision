using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class AreaCamera : MonoBehaviour
{
    Camera cam;
    bool takeScreenshot;
    float fillAmount=0;
    public event Action<float> OnAreaChange;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(AreaCalc());
    }
    
    private IEnumerator AreaCalc()
    {
        TakeScreenShot(16,9);
        OnAreaChange?.Invoke(fillAmount);
        yield return new WaitForSeconds(.05f);
        StartCoroutine(AreaCalc());
    }
    public void StopCalculatingArea()
    {
        StopAllCoroutines();
    }
    private void OnPostRender()
    {
        if (takeScreenshot)
        {
            takeScreenshot=false;
            RenderTexture renderTexture = cam.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width,renderTexture.height,TextureFormat.RGB24,false);
            Rect rect = new Rect(0,0,renderTexture.width,renderTexture.height);
            renderResult.ReadPixels(rect,0,0);
            Color[] colors = renderResult.GetPixels();
            int counter=0;
            foreach (var item in colors)
            {
                if(item != Color.black) counter++;
            }
            fillAmount = (float)counter/colors.Length;
            
            RenderTexture.ReleaseTemporary(renderTexture);
            cam.targetTexture=null;
        }
    }
    private void TakeScreenShot(int width,int height)
    {
        cam.targetTexture = RenderTexture.GetTemporary(width,height,16);
        takeScreenshot=true;
    }
}
[System.Serializable]
public class FUnityEvent : UnityEvent<float>{}
