using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] public virtual string description => "This is a sample item.";

    public void Interact()
    {
        Debug.Log("Picked up" + gameObject.name);
        Destroy(gameObject);
    }

    public string GetDescription()
    {
        return description;
    }
}
