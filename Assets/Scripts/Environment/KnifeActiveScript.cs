using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeActiveScript : MonoBehaviour
{
   [SerializeField] private GameObject Knife;

   private bool isTrigger = false;
   private void Update()
   {
      var fife1ButtonDown = Input.GetButtonDown(GlobalStringVars.FIRE1);
      ButtonClick(fife1ButtonDown);
   }

   private void ButtonClick(bool button)
   {
      if (button && isTrigger)
      {
         Knife.SetActive(true);
         Destroy(gameObject);
      }
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
         isTrigger = true;
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
         isTrigger = false;
   }
}
