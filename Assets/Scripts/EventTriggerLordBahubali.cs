using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerLordBahubali : EventTrigger 
{

    public override void OnPointerEnter(PointerEventData data)
    {
        BahubaliScript.SetGazedAtBahubali(true);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        BahubaliScript.SetGazedAtBahubali(false);
    }

}
