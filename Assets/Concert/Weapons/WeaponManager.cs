using UnityEngine;
public class WeaponManager : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;


    public void setWeapon(EnumWeapons.WeaponId newWeapon)
    {
        currentWeapon = newWeapon;
        // Update interface ?
    }
}
