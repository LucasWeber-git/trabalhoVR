using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{    

    [SerializeField] private Spawner bulletSpawner;
    [SerializeField] private GameObject muzzleFlashPrefab;

    [SerializeField] float firePower = 1000f;
    [SerializeField] int maxAmmo = 10;
    [SerializeField] float rotation = 1f;

    private TextMeshProUGUI ammoTextMesh;
    private AudioSource audioSource;
    private int currentAmmo;
    private Vector2 turn;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammoTextMesh = GameObject.FindGameObjectWithTag("Ammo").GetComponent<TextMeshProUGUI>();
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        ammoTextMesh.text = currentAmmo + " / " + maxAmmo;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            turn.y = turn.y >= 90 ? 90 : turn.y += rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            turn.y = turn.y <= -90 ? -90 : turn.y -= rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            turn.x = turn.x == 360 ? 0 : turn.x += rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turn.x = turn.x == 360 ? 0 : turn.x -= rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Fire();
        }

        if (Input.GetButtonDown("Reload"))
        {
            currentAmmo = maxAmmo;
        }
    }

    private void Fire()
    {
        GameObject bullet = bulletSpawner.Spawn();
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * firePower);

        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        muzzleFlash.transform.Rotate(new Vector3(0, 180, 0));

        audioSource.Play();

        currentAmmo--;
    }

}
