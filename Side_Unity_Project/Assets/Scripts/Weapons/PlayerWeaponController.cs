using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script can be change to Equip everything and not only weapons.
public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }


   Transform projectileSpawn;
    IWeapon equippedWeapon;

    CharacterStats characterStats;

    private void Start()
    {
        projectileSpawn = transform.Find("ProjectileSpawn");
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        // This destroy the already equiped weapon, to be changed so it puts it back in inventory/ground... .
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if(EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = projectileSpawn;

        equippedWeapon.Stats = itemToEquip.Stats;

        EquippedWeapon.transform.SetParent(playerHand.transform);

        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(characterStats.Stats[0].GetCalculatedStatValue());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformBaseWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformSpecialWeaponAttack();
        }
    }

    public void PerformBaseWeaponAttack()
    {
        equippedWeapon.PerformBaseAttack();
    }

    public void PerformSpecialWeaponAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
}
