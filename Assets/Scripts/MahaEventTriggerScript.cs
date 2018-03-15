using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MahaEventTriggerScript : EventTrigger {

    public override void OnPointerEnter(PointerEventData eventData)
    {
        MahamastabhishekaScript.SetGazedAtMahamastabhisheka(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        MahamastabhishekaScript.SetGazedAtMahamastabhisheka(false);
    }
}
