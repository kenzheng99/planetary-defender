using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   protected VisualElement Root;

   protected virtual void Awake() {
      Root = GetComponent<UIDocument>().rootVisualElement;
   }

   public void ToggleVisibility(bool visible) {
      Root.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
   }
}
