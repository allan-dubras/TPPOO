using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme
{
    public class WeaponManager : MonoBehaviour
    {
        private Arme currentWeapon;
        private List<Arme> armes = new List<Arme>();

        Arme sword = new Sword();
        Arme arc = new Bow();
        Arme wand = new Wand();
        Arme axe = new Axe();

        public void Attack()
        {
            currentWeapon.Attack();
        }

        public void SwitchWeapon(Arme weaponName)
        {
            currentWeapon = weaponName;
            Debug.Log("Switch to " + weaponName.Nom);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchWeapon(sword);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwitchWeapon(arc);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                SwitchWeapon(wand);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SwitchWeapon(axe);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Attack();
            }
        }
    }
}