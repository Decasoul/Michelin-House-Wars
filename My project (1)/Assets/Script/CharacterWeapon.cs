using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private Camera cam;
    private 
    void Update()
    {
            Vector3 mousePosition = Vector3.zero;
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = cam.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            {
                mousePosition = raycastHit.point;
            }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 aimDir = (mousePosition - shootingStartPosition.position).normalized;
            Instantiate(Projectile, shootingStartPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        }
    }
}
