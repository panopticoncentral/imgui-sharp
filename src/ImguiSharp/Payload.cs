﻿namespace ImguiSharp
{
    public readonly unsafe struct Payload : INativeReferenceWrapper<Payload, Native.ImGuiPayload>
    {
        private readonly Native.ImGuiPayload* _payload;

        private Payload(Native.ImGuiPayload* payload)
        {
            _payload = payload;
        }

        public static Payload? Wrap(Native.ImGuiPayload* native) => native == null ? null : new(native);

        public Native.ImGuiPayload* ToNative() => _payload;
    }
}
