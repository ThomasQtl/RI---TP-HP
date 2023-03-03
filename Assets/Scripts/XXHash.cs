using System;

public class XXHash : NoiseGenerator
{
    private const UInt64 PRIME1 = 0x9E3779B185EBCA87;
    private const UInt64 PRIME2 = 0xC2B2AE3D27D4EB4F;
    private const UInt64 PRIME3 = 0x165667B19E3779F9;
    private const UInt64 PRIME4 = 0x85EBCA77C2B2AE63;
    private const UInt64 PRIME5 = 0x27D4EB2F165667C5;

    readonly UInt64[] acc;

    public XXHash(UInt64 seed)
    {
        acc = new UInt64[]
        {
            // Input greater than 32 bytes
            seed + PRIME1 + PRIME2,
            seed + PRIME2,
            seed,
            seed - PRIME1,
            // Input less than 32 bytes
            seed + PRIME5
        };

        
    }
}