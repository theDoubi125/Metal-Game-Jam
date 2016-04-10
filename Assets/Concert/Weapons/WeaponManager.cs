using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;


    public void setWeapon(EnumWeapons.WeaponId newWeapon)
    {
        currentWeapon = newWeapon;
        GameObject[] guiWeapons = GameObject.FindGameObjectsWithTag("GUIWeapons");
        print("take arme");
        if (guiWeapons != null && guiWeapons.Length > 0)
        {
            guiWeapons[0].GetComponent<Image>().sprite = (Sprite)Resources.Load("Weapons/arme" + (int)currentWeapon, typeof(Sprite));
            print("done");
        }
    }

}
