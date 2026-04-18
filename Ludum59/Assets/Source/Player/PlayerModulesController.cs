using UnityEngine;

public class PlayerModulesController : MonoBehaviour
{
    [SerializeField] private PlayerModuleSlot[] playerModuleSlots;

    public void ReloadModule()
    {
        foreach (PlayerModuleSlot playerModuleSlot in playerModuleSlots)
        {
            playerModuleSlot.PrepareModule();
        }
    }
}
