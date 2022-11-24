using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
<<<<<<< HEAD
    private Vector2 turn;
    public float speed = 1f;
    public int rotation = 5;

    // Start is called before the first frame update
=======

    [SerializeField] private Spawner bulletSpawner;
    [SerializeField] private Spawner emptyShellSpawner;
    [SerializeField] private GameObject muzzleFlashPrefab;

    [SerializeField] float firePower = 1000f;

    private const float EMPTY_SHELL_FORCE = 10f;

    private AudioSource audioSource;

>>>>>>> 5ef3d6be4d9d6b2f327698cc1f2cea37e2f11743
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.UpArrow))
        {
            turn.y = turn.y >= 90 ? 90 : turn.y += rotation;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log(turn.y);
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
=======
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
>>>>>>> 5ef3d6be4d9d6b2f327698cc1f2cea37e2f11743
    }
}
