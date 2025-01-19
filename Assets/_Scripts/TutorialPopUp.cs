using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialPopUp : MonoBehaviour
{

    public GameObject popUpBox;
    public Animator animator;


    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }

    public void ClosePopup()
    {
        animator.SetTrigger("close");
    }

}
