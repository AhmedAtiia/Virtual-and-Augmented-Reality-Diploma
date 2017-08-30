using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDrawing : NetworkBehaviour
{

    public GameObject trailPrefab;
    Player plr;
    GameObject rightTrail;
    GameObject leftTrail;
    // Use this for initialization
    void Start()
    {
        plr = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority) return;
        if (ViveInput.GetButtonDown(ViveHand.Left, ViveButton.Trigger) || Input.GetMouseButtonDown(1))
        {
            CmdInstantiate(plr.leftHand, trailPrefab);
        }
        if (ViveInput.GetButtonDown(ViveHand.Right, ViveButton.Trigger) || Input.GetMouseButtonDown(0))
        {
            CmdInstantiate(plr.rightHand, trailPrefab);
        }
        if (ViveInput.GetButtonUp(ViveHand.Left, ViveButton.Trigger) || Input.GetMouseButtonUp(1))
        {
            CmdDest(leftTrail);
        }
        if (ViveInput.GetButtonUp(ViveHand.Right, ViveButton.Trigger) || Input.GetMouseButtonUp(0))
        {
            CmdDest(rightTrail);
        }
    }

    [Command]
    void CmdInstantiate(GameObject hnd, GameObject trail)
    {
        if (ViveHand.Right.Equals(hnd) || Input.GetMouseButtonDown(0))
        {
            rightTrail = Instantiate(trailPrefab);
            rightTrail.transform.SetParent(hnd.transform);
            rightTrail.transform.localPosition = Vector3.zero;
            NetworkServer.Spawn(rightTrail);
            RpcSetTrailColor(rightTrail);
        }
        if (ViveHand.Left.Equals(hnd) || Input.GetMouseButtonDown(1))
        {
            leftTrail = Instantiate(trailPrefab);
            leftTrail.transform.SetParent(hnd.transform);
            leftTrail.transform.localPosition = Vector3.zero;
            NetworkServer.Spawn(leftTrail);
            RpcSetTrailColor(leftTrail);
        }
    }

    [Command]
    void CmdDest(GameObject tail)
    {
        tail.transform.SetParent(null);
    }

    [ClientRpc]
    void RpcSetTrailColor(GameObject trail)
    {
        Color col = Random.ColorHSV();
        trail.GetComponent<TrailRenderer>().startColor = trail.GetComponent<TrailRenderer>().endColor = col;
    }
}
