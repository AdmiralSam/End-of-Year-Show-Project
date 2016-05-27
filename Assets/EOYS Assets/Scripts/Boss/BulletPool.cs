using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public VelocityMove bullet;
    public int poolCount;
    private List<VelocityMove> active;
    private List<VelocityMove> bullets;

    public VelocityMove GetBullet()
    {
        /*
        if (bullets.Count > 0)
        {
            VelocityMove instance = bullets[0];
            bullets.RemoveAt(0);
            instance.gameObject.SetActive(true);
            active.Add(instance);
            return instance;
        }
        return null;
        */
        VelocityMove instance = Instantiate(bullet);
        instance.transform.SetParent(transform);
        instance.GetComponent<RemoveOnExit>().Listener = RecycleBullet;
        return instance;
    }

    public void Pause()
    {
        foreach (VelocityMove bullet in active)
        {
            bullet.Pause();
        }
    }

    public void Reset()
    {
        for (int i = active.Count - 1; i >= 0; i--)
        {
            RecycleBullet(active[i]);
        }
    }

    public void Resume()
    {
        foreach (VelocityMove bullet in active)
        {
            bullet.Resume();
        }
    }

    private void RecycleBullet(VelocityMove bullet)
    {
        //bullet.gameObject.SetActive(false);
        active.Remove(bullet);
        //bullets.Add(bullet);
        Destroy(bullet.gameObject);
    }

    private void Start()
    {
        active = new List<VelocityMove>();
        /*
        bullets = new List<VelocityMove>();
        for (int i = 0; i < poolCount; i++)
        {
            VelocityMove instance = Instantiate(bullet);
            instance.GetComponent<RemoveOnExit>().Listener = RecycleBullet;
            instance.gameObject.SetActive(false);
            bullets.Add(instance);
        }
        */
    }
}