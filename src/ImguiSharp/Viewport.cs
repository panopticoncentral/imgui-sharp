﻿namespace ImguiSharp
{
    public readonly unsafe struct Viewport : INativeReferenceWrapper<Viewport, Native.ImGuiViewport>
    {
        private readonly Native.ImGuiViewport* _viewport;

        public ViewportOptions Options
        {
            get => (ViewportOptions)_viewport->Flags;
            set => _viewport->Flags = (Native.ImGuiViewportFlags)value;
        }

        public Position Position
        {
            get => Position.Wrap(_viewport->Pos);
            set => _viewport->Pos = value.ToNative();
        }

        public Size Size
        {
            get => Size.Wrap(_viewport->Size);
            set => _viewport->Size = value.ToNative();
        }

        public Position WorkPosition
        {
            get => Position.Wrap(_viewport->WorkPos);
            set => _viewport->WorkPos = value.ToNative();
        }

        public Size WorkSize
        {
            get => Size.Wrap(_viewport->WorkSize);
            set => _viewport->WorkSize = value.ToNative();
        }

        public Position Center => Position.Wrap(Native.ImGuiViewport_GetCenter(_viewport));

        public Position WorkCenter => Position.Wrap(Native.ImGuiViewport_GetWorkCenter(_viewport));

        public nuint PlatformHandleRaw
        {
            get => (nuint)_viewport->PlatformHandleRaw;
            set => _viewport->PlatformHandleRaw = (void*)value;
        }

        private Viewport(Native.ImGuiViewport* viewport)
        {
            _viewport = viewport;
        }

        public static Viewport? Wrap(Native.ImGuiViewport* native) => native == null ? null : new(native);

        public Native.ImGuiViewport* ToNative() => _viewport;
    }
}
