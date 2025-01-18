using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameHudManager : MonoBehaviour
{

    public GameObject floatingTextPrefab;
    void OnEnable()
    {
        Target.TargetHit += ShowPoints;
    }

    void OnDisable()
    {
        Target.TargetHit -= ShowPoints;
    }

    void ShowPoints(int points)
    {
        Canvas canvas = GetComponent<Canvas>();
        GameObject floatingText = Instantiate(floatingTextPrefab, Input.mousePosition, Quaternion.identity);

        floatingText.transform.SetParent(canvas.transform);
        floatingText.GetComponentInChildren<TextMeshProUGUI>().text = points.ToString();
        Destroy(floatingText, 1f);

        
    }
}
