﻿using Sledge.Gui.Attributes;
using Sledge.Gui.Events;

namespace Sledge.Gui.Interfaces.Controls
{
    [ControlInterface]
    public interface IViewport : IControl
    {
        event FrameEventHandler Update;
        event FrameEventHandler Render;
        event RenderExceptionEventHandler RenderException;
        void Run();
        void UpdateNextFrame();
    }
}