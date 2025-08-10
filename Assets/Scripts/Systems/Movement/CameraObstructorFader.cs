using System.Collections.Generic;
using UnityEngine;

public class CameraObstructorFader : MonoBehaviour
{
    public Transform target;
    public LayerMask obstructionMask;
    public float fadeAlpha = 0.3f;
    public float fadeSpeed = 8f;
    public Material transparentMat;

    class FadeInfo { public Renderer r; public List<Material> originalMats; public float t; }
    Dictionary<Renderer, FadeInfo> _fading = new();

    void LateUpdate()
    {
        if (!target) return;
        var cam = Camera.main;
        var dir = target.position - cam.transform.position;
        float dist = dir.magnitude;
        Ray ray = new Ray(cam.transform.position, dir.normalized);
        var hits = Physics.RaycastAll(ray, dist, obstructionMask, QueryTriggerInteraction.Ignore);

        HashSet<Renderer> seen = new();
        foreach (var h in hits)
        {
            if (!h.collider.TryGetComponent<Renderer>(out var rend)) continue;
            seen.Add(rend);
            if (!_fading.ContainsKey(rend))
            {
                var fi = new FadeInfo{ r = rend, originalMats = new List<Material>(rend.sharedMaterials), t = 0f };
                var mats = rend.materials;
                for (int i=0;i<mats.Length;i++) mats[i] = new Material(transparentMat);
                rend.materials = mats;
                _fading.Add(rend, fi);
            }
        }

        List<Renderer> toRestore = new();
        foreach (var kv in _fading)
        {
            bool active = seen.Contains(kv.Key);
            kv.Value.t = Mathf.MoveTowards(kv.Value.t, active ? 1f : 0f, Time.deltaTime * fadeSpeed);
            var mats = kv.Key.materials;
            for (int i=0;i<mats.Length;i++)
            {
                Color c = mats[i].color;
                c.a = Mathf.Lerp(1f, fadeAlpha, kv.Value.t);
                mats[i].color = c;
            }
            if (!active && kv.Value.t <= 0.001f) toRestore.Add(kv.Key);
        }
        foreach (var r in toRestore)
        {
            r.sharedMaterials = _fading[r].originalMats.ToArray();
            _fading.Remove(r);
        }
    }
}
