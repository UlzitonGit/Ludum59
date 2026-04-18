using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] private PlayerModuleSlot playerModuleSlot;
    
    public void OnObjectDropped(ModuleInfo prefab)
    {
        Instantiate(prefab.gameObject, transform);
        playerModuleSlot.AddModule(prefab.module);
    }
}
