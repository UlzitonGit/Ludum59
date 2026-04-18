using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   [SerializeField] private Modul attack;
   private List<Modul> currentModuls = new List<Modul>();
   private void Start()
   {
        currentModuls.Add(Instantiate(attack.gameObject, transform).GetComponent<Modul>());
   }

   public void ReloadModule()
   {
       foreach (var modul in currentModuls)
       {
           if (modul.Prepare())
           {
               modul.Perform(transform.position);
           }
       }
   }
}
