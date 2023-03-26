using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypeDamageEffect { Normal, Critical,  Healing}

public class DamageEffectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> damageEffects;

    [SerializeField] private float timeEffect;

    [SerializeField] private Color normalColor;
    [SerializeField] private Color criticalColor;
    [SerializeField] private Color healingColor;

    private static DamageEffectPool instace;
    public static DamageEffectPool Instance { get { return instace; } }

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public GameObject RequestDamageEffect(int damage, TypeDamageEffect typeDamage)
    {
        for (int i = 0; i < damageEffects.Count; i++)
        {
            if (!damageEffects[i].activeSelf)
            {
                SetDamageEffect(damageEffects[i], damage, typeDamage);
                return damageEffects[i];             
            }
        }
        return null;
    }

    private void SetDamageEffect(GameObject _damageEffect, int _damage, TypeDamageEffect _typeDamage)
    {
        TextMeshPro tmp = _damageEffect.GetComponentInChildren<TextMeshPro>();

        tmp.text = _damage.ToString();

        switch (_typeDamage)
        {
            case TypeDamageEffect.Normal:              
                tmp.color = normalColor;
                break;

            case TypeDamageEffect.Critical:
                tmp.color = criticalColor;
                break;

            case TypeDamageEffect.Healing:
                tmp.color = healingColor;
                break;
        }

        StartCoroutine(StartDamageEffect(_damageEffect));
    }

    private IEnumerator StartDamageEffect(GameObject _damageEffect)
    {
        _damageEffect.SetActive(true);

        yield return new WaitForSeconds(timeEffect);

        _damageEffect.SetActive(false);
    }
}
