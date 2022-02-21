using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   [SerializeField] bool startHidden = false;
   protected VisualElement Root;

   protected virtual void Awake() {
      Root = GetComponent<UIDocument>().rootVisualElement;
      if (startHidden) {
         Root.style.display = DisplayStyle.None;
      }
   }

   public void ToggleVisibility(bool visible) {
      Root.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
   }
}
