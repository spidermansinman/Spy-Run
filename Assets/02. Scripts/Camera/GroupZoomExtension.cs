using UnityEngine;
using Cinemachine;

public class GroupZoomExtension : CinemachineExtension
{
    [SerializeField]
    private Vector2 _minMaxDistance;
    [SerializeField]
    private Vector2 _minMaxFov;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Aim)
        {
            if (vcam.Follow == null) return;
            CinemachineTargetGroup targetGroup = vcam.Follow.GetComponent<CinemachineTargetGroup>();
            if (targetGroup == null) return;

            float separation = Mathf.Max(targetGroup.BoundingBox.size.x, targetGroup.BoundingBox.size.z);
            var t = Mathf.InverseLerp(_minMaxDistance.x, _minMaxDistance.y, separation);
            var fov = Mathf.Lerp(_minMaxFov.x, _minMaxFov.y, t);
            ((CinemachineVirtualCamera)vcam).m_Lens.FieldOfView = fov;
        }
    }
}
