using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination;
    public Transform cameraPosition;
    public Animator anim;
    public float delay;
    private bool isTransitioning = false; // Tambahkan flag ini

    public Transform GetDestination()
    {
        return destination;
    }

    public Transform GetCameraPosition()
    {
        return cameraPosition;
    }

    public IEnumerator ChangeLocationCoroutine(GameObject player, Transform Pycamera)
    {
        // Jika transisi sudah berjalan, jangan mulai lagi
        if (isTransitioning)
        {
            yield break; // Keluar dari coroutine jika transisi sedang berlangsung
        }

        isTransitioning = true; // Mulai transisi

        // Nonaktifkan interaksi pemain saat transisi dimulai
        player.GetComponent<PlayerController>().canInteract = false;

        TransitionActive(); // Memulai transisi (misal animasi pintu)

        // Tunggu separuh durasi delay sebelum memindahkan pemain
        yield return new WaitForSeconds(delay / 2);

        // Memindahkan player ke posisi pintu tujuan
        player.transform.position = GetDestination().position;

        // Memindahkan kamera ke posisi yang benar (sesuai dengan pintu tujuan)
        Pycamera.position = new Vector3(GetCameraPosition().position.x, Pycamera.transform.position.y, Pycamera.transform.position.z);

        // Tunggu sisa durasi delay sebelum transisi selesai
        yield return new WaitForSeconds(delay / 2);

        TransitionDeactive(); // Mengakhiri transisi (misal animasi pintu selesai)

        // Aktifkan kembali interaksi pemain setelah transisi selesai
        player.GetComponent<PlayerController>().canInteract = true;

        isTransitioning = false; // Transisi selesai
    }


    public void TransitionActive(){
        anim.SetBool("ChangeLoc", true);
    }
    public void TransitionDeactive(){
        anim.SetBool("ChangeLoc", false);
    }
}

