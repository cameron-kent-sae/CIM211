/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitCRT : MonoBehaviour
{
    #region Variables
    public Material EffectMaterial;
    public float smoothRefresh;
    public float smoothDistort;
    public float interval;
    private float refreshP;
    private float distortion;
    private float sD;
    #endregion

    #region Built In Methods
    void Start()
    {
        refreshP = 1080.0f;
        sD = smoothDistort;
        StartCoroutine(Distort());
    }
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        EffectMaterial.SetFloat("_ScanPoint", refreshP);
        EffectMaterial.SetFloat("_Distort", distortion);

        if (EffectMaterial != null)
            Graphics.Blit(src, dst, EffectMaterial);
    }

    void FixedUpdate()
    {
        refreshP = Mathf.MoveTowards(refreshP, -200.0f, smoothRefresh);
        if (refreshP <= -200.0f)
        {
            refreshP = 2000.0f;
        }
    }
    #endregion

    #region Custom Methods
    private IEnumerator Distort()
    {
        float current = 0.0f;
        float target = NormalRandom(-interval, interval);
        distortion = current;
        while (true)
        {
            current = Mathf.MoveTowards(current, target, sD * Time.deltaTime);
            distortion = current;
            if (current == target)
            {
                yield return new WaitForSeconds(Random.Range(0.0f, 0.1f));
                target = NormalRandom(-interval, interval);
            }
            yield return null;
        }
    }

    private float NormalRandom(float min, float max)
    {
        sD = smoothDistort * Random.Range(0.2f, 1.0f);
        return Random.Range(min, max);
    }
    #endregion
}