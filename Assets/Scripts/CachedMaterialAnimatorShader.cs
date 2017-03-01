using UnityEngine;
using System.Collections;

/* Visto na Unite Tokyo 2016, em Optmize Mobile Applications
 * static readonly int material_Color = Shader.PropertyToID(“_Color”);
 * static readonly int anim_Attack = Animator.StringToHash(“attack”); 
 * material.SetColor(material_Color, Color.white); 
 * animator.SetTrigger(anim_Attack);
*/
public static class CachedMaterialAnimatorShader { 

    public static readonly int material_Color = Shader.PropertyToID("_Color");
    public static readonly int material_cutoff = Shader.PropertyToID("_Cutoff");

}