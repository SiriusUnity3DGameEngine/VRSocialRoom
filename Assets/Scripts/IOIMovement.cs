using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class IOIMovement : MonoBehaviour
{
    public float fadeInTime = 2f;
    public float fadeOutTime = 2f;
    public GameObject loadingSprite;
    public GameObject player;
    private Material materialCutOff;
    public GameObject planeFadeInFadeOut;

    private Material planeMaterial;

    void Start()
    {
        materialCutOff = loadingSprite.transform.GetChild(0).GetComponent<Renderer>().material;
        planeMaterial = planeFadeInFadeOut.GetComponent<MeshRenderer>().material;
    }

    IEnumerator MovementIOI()
    {
        float startTime = Time.time;
        float progress = (Time.time - startTime) / fadeInTime;
        while (progress < 1.0f)
        {
            //Código para executar o loading da UI
            materialCutOff.SetFloat(CachedMaterialAnimatorShader.material_cutoff, 1 - progress);
            planeMaterial.color = new Color(planeMaterial.color.r, planeMaterial.color.g, planeMaterial.color.b, 0 + progress);
            progress = (Time.time - startTime) / fadeInTime;
            yield return null;
        }

        materialCutOff.SetFloat(CachedMaterialAnimatorShader.material_cutoff, 1);
        player.transform.position = new Vector3(gameObject.transform.position.x,1, gameObject.transform.position.z);

        yield return null;
    }
    

    public void StartMovement()
    {
        loadingSprite.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine("MovementIOI");
    }

    public void StopMovement()
    {
        StopCoroutine("MovementIOI");
        materialCutOff.SetFloat(CachedMaterialAnimatorShader.material_cutoff, 1);
        loadingSprite.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(FadeTo(0f, 1f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = planeMaterial.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            planeMaterial.color = newColor;
            yield return null;
        }
    }
}
