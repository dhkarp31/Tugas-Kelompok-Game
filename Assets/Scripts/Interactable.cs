using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
  public bool useEvents;
  [SerializeField]
  public string promptMassage;
  public virtual string OnLook()
  {
    return promptMassage;
  }

  public void BaseInteract()
  {
    if (useEvents)
        GetComponent<InteractionEvent>().OnInteract.Invoke();
    Interact();
  }

  protected virtual void Interact()
  {

  }  
}