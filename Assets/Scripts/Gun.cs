using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private Spawner bulletSpawner;
    [SerializeField] private Spawner emptyShellSpawner;
    [SerializeField] private GameObject muzzleFlashPrefab;

    [SerializeField] float firePower = 1000f;

    private const float EMPTY_SHELL_FORCE = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = bulletSpawner.Spawn();
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * firePower);

        GameObject emptyShell = emptyShellSpawner.Spawn();
        emptyShell.GetComponent<Rigidbody>().AddForce(transform.right * EMPTY_SHELL_FORCE);

        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        muzzleFlash.transform.Rotate(new Vector3(0, 180, 0));

        audioSource.Play();
    }
}
