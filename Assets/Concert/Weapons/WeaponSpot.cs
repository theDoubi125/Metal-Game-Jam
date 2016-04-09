using UnityEngine;
using System.Collections;

public class WeaponSpot : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        updateSprite();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && currentWeapon != EnumWeapons.WeaponId.NO_WEAPON)
        {
            print("Switch weapon");
           
            WeaponManager weaponManager = col.gameObject.GetComponent<WeaponManager>();
            if (weaponManager)
            {
                EnumWeapons.WeaponId tmpWeapon = weaponManager.currentWeapon;
                weaponManager.currentWeapon = currentWeapon;
                currentWeapon = tmpWeapon;
                // Update spot graphics

                updateSprite();

                print("CurrentWeapon : "+currentWeapon);
            }

        }

    }

    void updateSprite()
    {
        sprite.sprite = (Sprite)Resources.Load("Weapons/arme" + (int)currentWeapon, typeof(Sprite));
    }
}
