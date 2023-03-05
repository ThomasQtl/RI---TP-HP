using System;

public class XXNoiseGenerator : NoiseGenerator {
    XXHash64 hash;

    public XXNoiseGenerator(Uint64 seed) {
        hash = new XXHash64(seed);
    }

    public float Generate(float x, float y) {
        byte[] data = new byte[sizeof(float) * 2];

        Buffer.BlockCopy(x, 0, data, 0, sizeof(float));
        Buffer.BlockCopy(y, 0, data, sizeof(float), sizeof(float));

        byte[] hash = this.hash.ComputeHash(data);
        UInt64 hash_u64;

        Buffer.BlockCopy(hash, 0, hash_u64, 0, sizeof(UInt64));

        return (float)hash_u64 / (float)UInt64.MaxValue;
    }
}