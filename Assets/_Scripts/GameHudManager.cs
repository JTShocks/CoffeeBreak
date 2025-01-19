using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameHudManager : MonoBehaviour
{
    [SerializeField] Animator screenAnimator;
    public GameObject floatingTextPrefab;
    [SerializeField] GameObject floatTextPosition;
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

        floatingText.transform.SetParent(floatTextPosition.transform);
        
        floatingText.GetComponentInChildren<TextMeshProUGUI>().text = points.ToString();
        //floatingText.GetComponentInChildren<TextMeshProUGUI>().rectTransform.position = new Vector3(300,300,0);
        Destroy(floatingText, 1f);

        
    }

    void Flash()
    {
        screenAnimator?.SetTrigger("CameraFlash");
    }


}
