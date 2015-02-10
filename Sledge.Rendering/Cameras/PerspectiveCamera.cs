﻿using OpenTK;
using Sledge.DataStructures.Geometric;
using Sledge.Rendering.Scenes.Renderables;

namespace Sledge.Rendering.Cameras
{
    public class PerspectiveCamera : Camera
    {
        private Coordinate _direction;
        private Coordinate _lookAt;

        public int FOV { get; set; }
        public int ClipDistance { get; set; }
        public Coordinate Position { get; set; }

        public Coordinate Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                _lookAt = Position + _direction;
            }
        }

        public Coordinate LookAt
        {
            get { return _lookAt; }
            set
            {
                _lookAt = value;
                _direction = _lookAt - Position;
            }
        }

        public PerspectiveCamera()
        {
            Position = Coordinate.Zero;
            Direction = Coordinate.One;
            FOV = 90;
            ClipDistance = 1000;
            Flags = CameraFlags.Perspective;
        }

        public override Matrix4 GetCameraMatrix()
        {
            return Matrix4.LookAt(Position.ToVector3(), _lookAt.ToVector3(), Vector3.UnitZ);
        }

        public override Matrix4 GetViewportMatrix(int width, int height)
        {
            const float near = 1.0f;
            var ratio = width / (float)height;
            if (ratio <= 0) ratio = 1;
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FOV), ratio, near, ClipDistance);
        }
    }
}