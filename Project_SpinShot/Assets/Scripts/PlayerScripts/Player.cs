using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInventory pInventory;
    [SerializeField] UpgradeSystem upgradeSystem;
    [SerializeField] PlayerMovement pMovement;
    private void Awake()
    {
      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         pInventory = GetComponent<PlayerInventory>();
        upgradeSystem = GetComponent<UpgradeSystem>();
       pMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
