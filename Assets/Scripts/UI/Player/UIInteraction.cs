using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private Text interaction;

    public void ManualUpdate()
    {
        gameObject.SetActive(false);
    }

    public void ManualUpdate(Vector2 screenPosition, string interactionText)
    {
        transform.position = screenPosition;
        interaction.text = interactionText;
        gameObject.SetActive(true);
    }
}
