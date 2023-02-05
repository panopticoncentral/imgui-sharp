﻿namespace ImguiSharp
{
    public readonly unsafe struct DrawCommand : INativeReferenceWrapper<DrawCommand, Native.ImDrawCmd>
    {
        private readonly Native.ImDrawCmd* _cmd;

        public DrawCommandKind Kind =>
            _cmd->UserCallback == null
                ? DrawCommandKind.Vertex
                : (nint)_cmd->UserCallback == Native.ImDrawCallback_ResetRenderState
                    ? DrawCommandKind.ResetRenderState
                    : DrawCommandKind.Callback;

        public Rectangle ClipRectangle => Rectangle.Wrap(_cmd->ClipRect);

        public TextureId TextureId => TextureId.Wrap(_cmd->TextureId);

        public uint VertexOffset => _cmd->VtxOffset;

        public uint IndexOffset => _cmd->IdxOffset;

        public uint ElementCount => _cmd->ElemCount;

        private DrawCommand(Native.ImDrawCmd* cmd)
        {
            _cmd = cmd;
        }

        public void DoCallback(DrawList drawList) => _cmd->UserCallback(drawList.ToNative(), _cmd);

        public static DrawCommand? Wrap(Native.ImDrawCmd* native) => native == null ? null : new(native);

        public Native.ImDrawCmd* ToNative() => _cmd;
    }
}
