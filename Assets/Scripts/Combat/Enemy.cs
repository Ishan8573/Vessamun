using UnityEngine;
using TMPro;  

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public int currentHP;

    [Header("UI")]
    public GameObject hpTextPrefab;     
    private TMP_Text hpTextInstance;    

    public void Apply(EnemyData d)
    {
        data = d;
        currentHP = d.maxHP;
        GetComponent<SpriteRenderer>().sprite = d.sprite;
        name = $"Enemy_{d.enemyName}";

        if (hpTextPrefab != null)
        {
            var go = Instantiate(hpTextPrefab);
            go.transform.SetParent(transform, false);
            go.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            go.transform.localRotation = Quaternion.identity;

            hpTextInstance = go.GetComponentInChildren<TMP_Text>();

            if (hpTextInstance != null)
            {
                hpTextInstance.text = $"HP: {currentHP}";
            }
        }
    }

    private void Update()
    {
        if (hpTextInstance != null)
        {
            hpTextInstance.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            hpTextInstance.text = $"HP: {currentHP}";
        }
    }
}



