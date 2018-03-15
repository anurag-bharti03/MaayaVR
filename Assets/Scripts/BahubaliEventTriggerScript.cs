using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BahubaliEventTriggerScript : EventTrigger {


    public override void OnPointerEnter(PointerEventData eventData)
    {
        BahubaliScript.SetGazedAtBahubali(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        BahubaliScript.SetGazedAtBahubali(false);
    }

}
