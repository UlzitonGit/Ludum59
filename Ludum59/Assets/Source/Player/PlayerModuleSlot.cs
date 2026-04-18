using System.Collections.Generic;
using UnityEngine;

public class PlayerModuleSlot : MonoBehaviour
{
     public Modul firstModule;
     public Modul secondModule;
     public Modul thirdModule;

     public void AddModule(Modul module)
     {
          if (firstModule == null)
          {
               SetFirstModule(module);
          }

          else if (secondModule == null)
          {
               SetSecondModule(module);
          }

          else if  (thirdModule == null)
          {
               SetThirdModule(module);
          }
     }
     public void PrepareModule()
     {
          if(firstModule == null) return;
          if (firstModule.Prepare())
          {
               firstModule.Perform(transform.position);
          }
     }

     private void SetFirstModule(Modul firstModule)
     {
          if(this.firstModule != null) return;
          this.firstModule = Instantiate(firstModule.gameObject, transform).GetComponent<Modul>();
     }

     private void SetSecondModule(Modul secondModule)
     {
          if(this.secondModule != null) return;
          this.secondModule = Instantiate(secondModule.gameObject, transform).GetComponent<Modul>();
          firstModule.SetChildModule(this.secondModule);
     }

     private void SetThirdModule(Modul thirdModule)
     {
          if(this.thirdModule != null) return;
          this.thirdModule =  Instantiate(secondModule.gameObject, transform).GetComponent<Modul>();
          secondModule.SetChildModule(this.thirdModule);
     }
}
