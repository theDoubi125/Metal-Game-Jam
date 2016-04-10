using UnityEngine;
public class WeaponManager : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;


    public void setWeapon(EnumWeapons.WeaponId newWeapon)
    {
        currentWeapon = newWeapon;
        GameObject[] guiWeapons = GameObject.FindGameObjectsWithTag("GUIWeapons");
        Debug.Log(guiWeapons);
        if (guiWeapons != null && guiWeapons.Length > 0)
        {
            Debug.Log("ok");
            guiWeapons[0].GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Weapons/arme" + (int)currentWeapon, typeof(Sprite));
        }
    }

}
